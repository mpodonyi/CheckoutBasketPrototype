namespace Checkout.Com.BasketPrototype.Storage
{
    using Autofac;
    using Entities;
    using Interfaces;
    using Repositories;

    public static class BootstrapContainer
    {
        public static void Register(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<InMemoryContext>().AsSelf().SingleInstance();


            containerBuilder.RegisterType<BasketRepository>().As<IBasketRepository>();
            containerBuilder.RegisterType<BasketItemRepository>().As<IBasketItemRepository>();
        }
    }
}