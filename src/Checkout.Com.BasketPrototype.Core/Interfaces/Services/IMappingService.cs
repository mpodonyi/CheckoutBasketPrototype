namespace Checkout.Com.BasketPrototype.Core.Interfaces.Services
{
    public interface IMappingService
    {
        TDestination Map<TSource, TDestination>(TSource source);

        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}