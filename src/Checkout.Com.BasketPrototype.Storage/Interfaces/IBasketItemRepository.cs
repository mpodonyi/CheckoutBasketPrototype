namespace Checkout.Com.BasketPrototype.Storage.Interfaces
{
    using System;
    using System.Threading.Tasks;
    using Entities;

    public interface IBasketItemRepository 
    {
        Task<Guid> BasketItemCreateAsync(BasketItem basketItem);

        Task BasketItemUpdateAsync(BasketItem basketItem);

        Task BasketItemRemoveAsync(Guid basketItemGuid);

        Task BasketItemRemoveAllAsync(long basketId);

        Task<BasketItem> BasketItemGetByGuidAsync(Guid guid);
    }
}