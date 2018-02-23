namespace Checkout.Com.BasketPrototype.Storage.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Interfaces;

    public class BasketItemRepository : IBasketItemRepository
    {
        private readonly InMemoryContext _inMemoryContext;

        public BasketItemRepository(InMemoryContext inMemoryContext)
        {
            _inMemoryContext = inMemoryContext;
        }

        public Task<Guid> BasketItemCreateAsync(BasketItem basketItem)
        {
            var nextIndex = _inMemoryContext.BasketItems.DefaultIfEmpty(new BasketItem()).Max(o => o.Id) + 1;

            basketItem.Id = nextIndex;

            _inMemoryContext.BasketItems.Add(basketItem);

            return Task.FromResult(basketItem.Guid);
        }

        public Task BasketItemUpdateAsync(BasketItem basketItem)
        {
            var item = _inMemoryContext.BasketItems.First(o => o.Guid == basketItem.Guid);
            _inMemoryContext.BasketItems.Remove(item);
            _inMemoryContext.BasketItems.Add(basketItem);
            return Task.CompletedTask;
        }

        public Task BasketItemRemoveAsync(Guid basketItemGuid)
        {
            var item = _inMemoryContext.BasketItems.First(o => o.Guid == basketItemGuid);
            _inMemoryContext.BasketItems.Remove(item);
            return Task.CompletedTask;
        }


        public Task BasketItemRemoveAllAsync(long basketId)
        {
            _inMemoryContext.BasketItems.RemoveAll(basketItem => basketItem.BasketId == basketId);
            return Task.CompletedTask;
        }

        public Task<BasketItem> BasketItemGetByGuidAsync(Guid guid)
        {
            return Task.FromResult(_inMemoryContext.BasketItems.SingleOrDefault(o => o.Guid == guid));
        }
    }
}