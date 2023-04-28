using MassTransit;
using RabbitMQ.Client;

namespace NetMPA.Catalog.Api.Configuration
{
    public static class MassTransitConstants
    {
        public readonly static int RETRY_COUNT = 5;
        public readonly static int RETRY_INTERVAL = 10;
        public readonly static int RETRY_STEP = 1;
    }

    public static class ConfigureMassTransitOptions
    {
        public static IServiceCollection ConfigureMassTransit(this IServiceCollection services,
            IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("RabbitSettings");
            var rabbitConfig = appSettingsSection.Get<RabbitSettings>();

            services.AddMassTransit(c =>
            {
                c.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri(rabbitConfig.HostName), rabbitConfig.VirtualHost, h =>
                    {
                        h.Username(rabbitConfig.UserName);
                        h.Password(rabbitConfig.Password);
                    });

                    cfg.ExchangeType = ExchangeType.Direct;

                    cfg.ConfigureEndpoints(provider);

                    cfg.UseRetry(rt =>
                    {
                        rt.Handle(typeof(RabbitMqConnectionException), typeof(TimeoutException));
                        rt.Immediate(MassTransitConstants.RETRY_COUNT);
                        rt.Interval(MassTransitConstants.RETRY_INTERVAL, TimeSpan.FromMinutes(MassTransitConstants.RETRY_STEP));
                    });

                }));
            });

            services.AddSingleton<IPublishEndpoint>(provider => provider.GetRequiredService<IBusControl>());

            services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());

            return services;
        }
    }
}
