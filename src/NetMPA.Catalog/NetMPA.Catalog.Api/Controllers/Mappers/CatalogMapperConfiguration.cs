using AutoMapper;

namespace NetMPA.Catalog.Api.Controllers.Mappers
{
    public static class CatalogMapperConfiguration
    {
        public static void ConfigureMappings(IMapperConfigurationExpression config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }
            config.CreateMap<Bll.Models.Category, Api.Models.Category > ();
            config.CreateMap<Bll.Models.Product, Api.Models.Product>();

        }
    }
}
