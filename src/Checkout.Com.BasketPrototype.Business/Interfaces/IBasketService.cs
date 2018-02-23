namespace Checkout.Com.BasketPrototype.Business.Interfaces
{
    using System;
    using System.Threading.Tasks;
    using Models;

    public interface IBasketService
    {
        Task<Guid> CreateBasketAsync(Guid userGuid);

        Task<Guid> AddBasketItemAsync(Guid basketGuid, BasketItemCreateModel basketItem);

        Task RemoveBasketItemAsync(Guid basketItemGuid);

        Task ChangeBasketItemAsync(BasketItemChangeModel basketItemChangeModel);

        Task RemoveAllBasketItemsAsync(Guid basketGuid);

        Task RemoveBasketAsync(Guid basketGuid);
    }
}