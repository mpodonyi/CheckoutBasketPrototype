namespace Checkout.Com.BasketPrototype.Storage.Interfaces
{
    using System;
    using System.Threading.Tasks;
    using Entities;

    public interface IBasketRepository
    {
        Task<Guid> BasketCreateAsync(Basket basket);

        Task<Basket> BasketGetByUserGuidAsync(Guid userGuid);

        Task<Basket> BasketGetByBasketGuidAsync(Guid guid);

        Task BasketRemoveAsync(Guid guid);
    }
}