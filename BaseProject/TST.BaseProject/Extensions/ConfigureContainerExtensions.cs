using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TST.CORE.Services.Implementations;
using TST.CORE.Services.Interfaces;
using TST.REPOSITORY.Base;
using TST.REPOSITORY.Repositories.Implementations;
using TST.REPOSITORY.Repositories.Interfaces;
using TST.SERVICE.Service.Implementations;
using TST.SERVICE.Service.Interfaces;

namespace TST.BaseProject.Extensions
{
    public static class ConfigureContainerExtensions
    {
        public static void AddRepository(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();
            serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
        }

        public static void AddTransientServices(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddTransient<IDataTableService, DataTableService>();
            serviceCollection.AddTransient<IProductService, ProductService>();
            serviceCollection.AddTransient<ICategoryService, CategoryService>();
        }
    }
}
