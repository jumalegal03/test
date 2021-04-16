using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TST.ENTITIES.Models.Generals;
using TST.REPOSITORY.Repositories.Interfaces;
using TST.SERVICE.Service.Interfaces;

namespace TST.SERVICE.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Get(string id)
            => await _categoryRepository.Get(id);

        public async Task<IEnumerable<Category>> GetAll()
           => await _categoryRepository.GetAll();
    }
}
