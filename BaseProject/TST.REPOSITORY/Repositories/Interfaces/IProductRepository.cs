using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TST.CORE.Structs;
using TST.ENTITIES.Models.Generals;
using TST.REPOSITORY.Base;

namespace TST.REPOSITORY.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetWithData(string id);
        Task<DataTablesStructs.ReturnedData<object>> GetAllDatatable(DataTablesStructs.SentParameters sentParameters, string search, string category);
    }
}
