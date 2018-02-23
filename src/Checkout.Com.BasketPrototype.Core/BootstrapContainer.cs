namespace Checkout.Com.BasketPrototype.Core
{
    using Autofac;
    using Interfaces.Services;
    using Services;

    public static class BootstrapContainer
    {
        public static void Register(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<MappingService>().As<IMappingService>().SingleInstance();
        }
    }
}