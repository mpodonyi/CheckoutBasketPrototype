namespace Checkout.Com.BasketPrototype.Business
{
    using Autofac;
    using BasketServices;
    using Core.Mapping;
    using Interfaces;
    using sourcemodels = Models;
    using targetmodels = Storage.Entities;

    public static class BootstrapContainer
    {
        public static void Register(ContainerBuilder containerBuilder)
        {
            RegisterMappings();
            containerBuilder.RegisterType<BasketService>().As<IBasketService>();
        }


        private static void RegisterMappings()
        {
            MappingRegistry.RegisterMap<sourcemodels.BasketItemChangeModel, targetmodels.BasketItem>();
            MappingRegistry.RegisterMap<sourcemodels.BasketItemCreateModel, targetmodels.BasketItem>();
        }
    }
}