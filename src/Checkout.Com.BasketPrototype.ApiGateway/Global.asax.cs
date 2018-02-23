namespace Checkout.Com.BasketPrototype.ApiGateway
{
    using System.Reflection;
    using System.Web;
    using System.Web.Http;
    using App_Start;
    using Autofac.Integration.WebApi;
    using Container;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var config = GlobalConfiguration.Configuration;

            MappingConfig.Register();
            ContainerFacade.RegisterControllers(Assembly.GetExecutingAssembly());

            config.DependencyResolver = new AutofacWebApiDependencyResolver(ContainerFacade.Container);
        }
    }
}