using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetMPA.Catalog.Bll.Interfaces.Repositories;
using NetMPA.Catalog.Dal.Repositories;
using NetMPA.Catalog.Dal.SqlContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Dal.Configuration
{
    public static class DalInitializer
    {
        public static IServiceCollection ConfigureDal(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureDbContext(services, configuration);
            AddDependenciesToContainer(services);

            return services;
        }

        private static void ConfigureDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("CatalogDatabase");

            services.AddDbContext<CatalogContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            var dbFactory = new CatalogContextFactory(connectionString);
            services.AddSingleton(typeof(ICatalogContextFactory), dbFactory);
        }

        private static void AddDependenciesToContainer(IServiceCollection services)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

        }

    }
}
