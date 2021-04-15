using TST.REPOSITORY.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TST.REPOSITORY.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly TstContext _context;
        private readonly DbSet<T> _entities;

        public Repository(TstContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<bool> Any(Guid id)
        {
            var entity = await _entities.FindAsync(id);
            return entity != null;
        }

        public async Task<bool> Any(string id)
        {
            var entity = await _entities.FindAsync(id);
            return entity != null;
        }

        public async Task<int> Count() => await _entities.CountAsync();

        public async Task<T> First() => await _entities.FirstOrDefaultAsync();

        public async Task<T> Last() => await _entities.LastOrDefaultAsync();

        public virtual async Task<T> Get(Guid id) => await _entities.FindAsync(id);

        public virtual async Task<T> Get(string id) => await _entities.FindAsync(id);

        public virtual async Task<T> Get(params object[] keyValues) => await _entities.FindAsync(keyValues);

        public virtual async Task<IEnumerable<T>> GetAll() => await _entities.AsQueryable().ToListAsync();

        public async Task<T> Add(T entity)
        {
            var result = await _entities.AddAsync(entity);
            return result.Entity;
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            await _entities.AddRangeAsync(entities);
        }

        public virtual async Task Delete(T entity)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteById(Guid id)
        {
            var entity = await this.Get(id);
            await Delete(entity);
        }

        public virtual async Task DeleteById(string id)
        {
            var entity = await this.Get(id);
            await Delete(entity);
        }

        public virtual async Task DeleteById(params object[] keyValues)
        {
            var entity = await this.Get(keyValues);
            await Delete(entity);
        }

        public async Task DeleteRange(IEnumerable<T> entities)
        {
            _entities.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Insert(T entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task InsertRange(IEnumerable<T> entities)
        {
            await _entities.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            if (entity == null)
            {
                // Should call Dispose() to remove the elements from the failed context?
                throw new ArgumentNullException(nameof(entity));
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateRange(IEnumerable<T> entities)
        {
            if (entities != null)
            {
                await _context.SaveChangesAsync();
            }
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _entities.RemoveRange(entities);
        }
    }
}