using AutoMapper;

namespace NetMPA.Carting.Api.Controllers.Mappers
{
    public static class CatalogMapperConfiguration
    {
        public static void ConfigureMappings(IMapperConfigurationExpression config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }
            config.CreateMap<Bll.Models.Cart, Api.Models.Cart> ();
            config.CreateMap<Bll.Models.Item, Api.Models.Item>();

        }
    }
}
