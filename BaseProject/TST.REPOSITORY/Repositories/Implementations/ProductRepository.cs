using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TST.CORE.Extensions;
using TST.CORE.Structs;
using TST.ENTITIES.Models.Generals;
using TST.REPOSITORY.Base;
using TST.REPOSITORY.Data;
using TST.REPOSITORY.Repositories.Interfaces;

namespace TST.REPOSITORY.Repositories.Implementations
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(TstContext context) : base(context) { }

        public async Task<Product> GetWithData(string id)
            => await _context.Products.Include(x => x.Category).Where(x => x.Id == id).FirstOrDefaultAsync();
        public async Task<DataTablesStructs.ReturnedData<object>> GetAllDatatable(DataTablesStructs.SentParameters sentParameters, string search, string categoryId)
        {
            Expression<Func<Product, dynamic>> orderByPredicate = null;

            switch (sentParameters.OrderColumn)
            {
                case "0":
                    orderByPredicate = (x) => x.Name;
                    break;
                case "1":
                    orderByPredicate = (x) => x.Description;
                    break;
                case "2":
                    orderByPredicate = (x) => x.Amount;
                    break;
                case "3":
                    orderByPredicate = (x) => x.Stock;
                    break;
                case "4":
                    orderByPredicate = (x) => x.Category.Name;
                    break;
                default:
                    orderByPredicate = (x) => x.CreateAt;
                    break;
            }


            var query = _context.Products
                .AsNoTracking();

            var recordsFiltered = await query.CountAsync();

            if (!string.IsNullOrEmpty(categoryId) && categoryId != "Todos")
                query = query.Where(x => x.CategoryId == categoryId);

            if (!string.IsNullOrEmpty(search))
                query = query.Where(q => q.Name.ToUpper().Contains(search.ToUpper())
                                        || q.Description.ToUpper().Contains(search.ToUpper()));

            query = query.AsQueryable();

            var data = await query
                .OrderByCondition(sentParameters.OrderDirection, orderByPredicate)
                .Skip(sentParameters.PagingFirstRecord)
                .Take(sentParameters.RecordsPerDraw)
                .Select(x => new
                {
                    Id = x.Id,
                    name = x.Name,
                    img = x.Img,
                    description = x.Description,
                    amount = x.Amount,
                    stock = x.Stock,
                    category = x.Category.Name,
                    createdAt = x.CreateAt
                }).ToListAsync();

            var recordsTotal = data.Count;

            return new DataTablesStructs.ReturnedData<object>
            {
                Data = data,
                DrawCounter = sentParameters.DrawCounter,
                RecordsFiltered = recordsFiltered,
                RecordsTotal = recordsTotal
            };
        }
    }
}
