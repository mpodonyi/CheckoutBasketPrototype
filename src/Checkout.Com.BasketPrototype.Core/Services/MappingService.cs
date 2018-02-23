namespace Checkout.Com.BasketPrototype.Core.Services
{
    using AutoMapper;
    using Interfaces.Services;
    using Mapping;

    public class MappingService : IMappingService
    {
        private readonly IMapper _mapper;


        public MappingService()
        {
            _mapper = new Mapper(MappingRegistry.GetMappingConfiguration);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map(source, destination);
        }
    }
}