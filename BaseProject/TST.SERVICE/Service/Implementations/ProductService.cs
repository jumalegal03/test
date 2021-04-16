using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TST.CORE.Structs;
using TST.ENTITIES.Models.Generals;
using TST.REPOSITORY.Repositories.Interfaces;
using TST.SERVICE.Service.Interfaces;

namespace TST.SERVICE.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task Insert(Product product)
            => await _productRepository.Insert(product);
        public async Task<Product> Get(string id)
            => await _productRepository.Get(id);
        public async Task<Product> GetWithData(string id)
            => await _productRepository.GetWithData(id);
        public async Task Update(Product product)
            => await _productRepository.Update(product);
        public async Task Delete(Product product)
            => await _productRepository.Delete(product);
        public async Task<IEnumerable<Product>> GetAll()
            => await _productRepository.GetAll();
        public async Task<DataTablesStructs.ReturnedData<object>> GetAllDatatable(DataTablesStructs.SentParameters sentParameters, string search, string category)
            => await _productRepository.GetAllDatatable(sentParameters, search, category);
    }
}
