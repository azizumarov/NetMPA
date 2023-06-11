using Microsoft.Extensions.DependencyInjection;
using NetMPA.Carting.Dal.Interfaces;
using NetMPA.Carting.Dal.Models;
using NetMPA.Carting.Dal.Repositories;

namespace NetMPA.Carting.Bll.Configuration
{
    public static class ModuleInitializer
    {
        public static IServiceCollection ConfigureDal(this IServiceCollection services)
        {
            services.AddTransient<IDictionary<Guid, CartDao>>(sp =>
                new Dictionary<Guid, CartDao>());
            services.AddTransient<IDictionary<int, ItemDao>>(sp =>
                new Dictionary<int, ItemDao>());

            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();

            return services;
        }

    }
}
