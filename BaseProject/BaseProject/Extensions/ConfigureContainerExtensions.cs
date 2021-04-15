using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TST.REPOSITORY.Base;

namespace TST.BaseProject.Extensions
{
    public static class ConfigureContainerExtensions
    {
        public static void AddRepository(this IServiceCollection services)
        {
            
        }

        public static void AddTransientServices(this IServiceCollection serviceCollection)
        {

        }
    }
}
