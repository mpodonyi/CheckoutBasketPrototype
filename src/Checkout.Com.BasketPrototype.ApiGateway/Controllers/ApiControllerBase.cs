namespace Checkout.Com.BasketPrototype.ApiGateway.Controllers
{
    using System;
    using System.Web.Http;

    public abstract class ApiControllerBase : ApiController
    {
        protected void LogException(Exception exception)
        {
            //LogException With Framework of your choice
        }
    }
}