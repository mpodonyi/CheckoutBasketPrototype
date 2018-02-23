namespace Checkout.Com.BasketPrototype.Core.Mapping
{
    using AutoMapper;
    using AutoMapper.Configuration;

    public static class MappingRegistry
    {
        private static readonly MapperConfigurationExpression MapperConfiguration = new MapperConfigurationExpression();

        internal static MapperConfiguration GetMappingConfiguration => new MapperConfiguration(MapperConfiguration);

        public static void RegisterMap<TSourceDto, TArgetDto>()
        {
            MapperConfiguration.CreateMap<TSourceDto, TArgetDto>();
        }
    }
}