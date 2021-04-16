using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TST.CORE.Structs;
using TST.ENTITIES.Models.Generals;

namespace TST.SERVICE.Service.Interfaces
{
    public interface IProductService
    {
        Task Insert(Product product);
        Task<Product> Get(string id);
        Task<Product> GetWithData(string id);
        Task Update(Product product);
        Task Delete(Product product);
        Task<IEnumerable<Product>> GetAll();
        Task<DataTablesStructs.ReturnedData<object>> GetAllDatatable(DataTablesStructs.SentParameters sentParameters, string search, string category);
    }
}
