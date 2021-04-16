using System;
using System.Collections.Generic;
using System.Text;
using TST.ENTITIES.Models.Generals;
using TST.REPOSITORY.Base;
using TST.REPOSITORY.Data;
using TST.REPOSITORY.Repositories.Interfaces;

namespace TST.REPOSITORY.Repositories.Implementations
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(TstContext context) : base(context) { }
    }
}
