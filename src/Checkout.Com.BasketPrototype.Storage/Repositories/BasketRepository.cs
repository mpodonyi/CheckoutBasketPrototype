namespace Checkout.Com.BasketPrototype.Storage.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Interfaces;

    public class BasketRepository : IBasketRepository
    {
        private readonly InMemoryContext _inMemoryContext;

        public BasketRepository(InMemoryContext inMemoryContext)
        {
            _inMemoryContext = inMemoryContext;
        }


        public Task<Guid> BasketCreateAsync(Basket basket)
        {
            var nextIndex = _inMemoryContext.Baskets.DefaultIfEmpty(new Basket()).Max(o => o.Id) + 1;

            basket.Id = nextIndex;

            _inMemoryContext.Baskets.Add(basket);

            return Task.FromResult(basket.Guid);
        }

        public Task<Basket> BasketGetByBasketGuidAsync(Guid guid)
        {
            return Task.FromResult(_inMemoryContext.Baskets.SingleOrDefault(o => o.Guid == guid));
        }

        public Task BasketRemoveAsync(Guid guid)
        {
            var item = _inMemoryContext.Baskets.First(o => o.Guid == guid);
            _inMemoryContext.Baskets.Remove(item);
            return Task.CompletedTask;
        }

        public Task<Basket> BasketGetByUserGuidAsync(Guid userGuid)
        {
            return Task.FromResult(_inMemoryContext.Baskets.SingleOrDefault(o => o.UserGuid == userGuid));
        }
    }
}