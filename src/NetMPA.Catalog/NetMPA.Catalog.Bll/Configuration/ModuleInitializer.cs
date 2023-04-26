using Microsoft.Extensions.DependencyInjection;
using NetMPA.Catalog.Bll.Interfaces.Services;
using NetMPA.Catalog.Bll.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Bll.Configuration
{
    public static class ModuleInitializer
    {
        public static IServiceCollection ConfigureBll(this IServiceCollection services)
        {
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();

            return services;
        }

    }
}
