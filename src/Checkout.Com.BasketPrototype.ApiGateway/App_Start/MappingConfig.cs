using sourcemodels = Checkout.Com.BasketPrototype.ApiGateway.Models;
using targetmodels = Checkout.Com.BasketPrototype.Business.Models;

namespace Checkout.Com.BasketPrototype.ApiGateway.App_Start
{
    using Core.Mapping;

    public static class MappingConfig
    {
        public static void Register()
        {
            MappingRegistry.RegisterMap<sourcemodels.BasketItemCreateModel, targetmodels.BasketItemChangeModel>();
            MappingRegistry.RegisterMap<sourcemodels.BasketItemChangeModel, targetmodels.BasketItemChangeModel>();
        }
    }
}