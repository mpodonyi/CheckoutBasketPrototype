namespace Checkout.Com.BasketPrototype.Container
{
    using System;
    using System.Reflection;
    using Autofac;
    using Autofac.Integration.WebApi;
    using Core;

    public static class ContainerFacade
    {
        private static readonly Lazy<ContainerBuilder> ContainerBuilder = new Lazy<ContainerBuilder>();
        // ReSharper disable once InconsistentNaming
        private static readonly Lazy<IContainer> _Container = new Lazy<IContainer>(Initialize);

        private static Action<ContainerBuilder> RegisterCallBack;

        public static IContainer Container => _Container.Value;

        public static void RegisterControllers(Assembly assembly)
        {
            ContainerBuilder.Value.RegisterApiControllers(assembly);
        }

        public static IContainer GetContainer(Action<ContainerBuilder> act = null)
        {
            var containerBuilder = new ContainerBuilder();

            ContainerRegistrations(containerBuilder);

            act?.Invoke(containerBuilder);

            return containerBuilder.Build();
        }


        private static IContainer Initialize()
        {
            var containerBuilder = ContainerBuilder.Value;

            ContainerRegistrations(containerBuilder);

            RegisterCallBack?.Invoke(containerBuilder);

            return containerBuilder.Build();
        }

        private static void ContainerRegistrations(ContainerBuilder containerBuilder)
        {
            BootstrapContainer.Register(containerBuilder);
            Storage.BootstrapContainer.Register(containerBuilder);
            Business.BootstrapContainer.Register(containerBuilder);
        }
    }
}