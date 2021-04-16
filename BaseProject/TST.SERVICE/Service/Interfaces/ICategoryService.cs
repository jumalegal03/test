using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TST.ENTITIES.Models.Generals;

namespace TST.SERVICE.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> Get(string id);
        Task<IEnumerable<Category>> GetAll();
    }
}
