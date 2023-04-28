using Microsoft.Extensions.DependencyInjection;
using NetMPA.Carting.Bll.Interfaces;
using NetMPA.Carting.Bll.Services;

namespace NetMPA.Carting.Bll.Configuration
{
    public static class ModuleInitializer
    {
        public static IServiceCollection ConfigureBll(this IServiceCollection services)
        {
            services.AddTransient<ICartingService, CartingService>();
            return services;
        }

    }
}
