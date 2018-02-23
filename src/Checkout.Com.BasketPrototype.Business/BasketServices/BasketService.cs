namespace Checkout.Com.BasketPrototype.Business.BasketServices
{
    using System;
    using System.Threading.Tasks;
    using Core.Interfaces.Services;
    using Exceptions;
    using Interfaces;
    using Models;
    using Storage.Entities;
    using Storage.Interfaces;

    public class BasketService : IBasketService
    {
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IMappingService _mappingService;

        public BasketService(IBasketRepository basketRepository, IBasketItemRepository basketItemRepository,
            IMappingService mappingService)
        {
            _basketRepository = basketRepository;
            _basketItemRepository = basketItemRepository;
            _mappingService = mappingService;
        }

        public async Task<Guid> CreateBasketAsync(Guid userGuid)
        {
            if (userGuid == Guid.Empty)
                throw ExceptionHelper.GetArgumentException(nameof(userGuid), "Invalid User");

            var basket = await _basketRepository.BasketGetByUserGuidAsync(userGuid);
            if (basket != null)
                throw ExceptionHelper.GetBasketExeption("The User has already a Basket.");

            basket = new Basket {UserGuid = userGuid};

            return await _basketRepository.BasketCreateAsync(basket);
        }

        public async Task<Guid> AddBasketItemAsync(Guid basketGuid, BasketItemCreateModel basketItemCreateModel)
        {
            //TODO ModelCheck

            if (basketGuid == Guid.Empty)
                throw ExceptionHelper.GetArgumentException(nameof(basketGuid), "Invalid Basket Guid");

            var basket = await _basketRepository.BasketGetByBasketGuidAsync(basketGuid);
            if (basket == null)
                throw ExceptionHelper.GetBasketExeption("The Basket with Guid does not exist.");

            

            var basketItem = _mappingService.Map<BasketItemCreateModel, BasketItem>(basketItemCreateModel);
            basketItem.Id = basket.Id;


            return await _basketItemRepository.BasketItemCreateAsync(basketItem);
        }

        public async Task RemoveBasketItemAsync(Guid basketItemGuid)
        {
            if (basketItemGuid == Guid.Empty)
                throw ExceptionHelper.GetArgumentException(nameof(basketItemGuid), "Invalid BasketItem Guid");

            await _basketItemRepository.BasketItemRemoveAsync(basketItemGuid);
        }

        public async Task ChangeBasketItemAsync(BasketItemChangeModel basketItemChangeModel)
        {
            //TODO modelcheck

            var basketItem = await _basketItemRepository.BasketItemGetByGuidAsync(basketItemChangeModel.Guid);

            basketItem = _mappingService.Map(basketItemChangeModel, basketItem);

            await _basketItemRepository.BasketItemUpdateAsync(basketItem);
        }

        public async Task RemoveAllBasketItemsAsync(Guid basketGuid)
        {
            if (basketGuid == Guid.Empty)
                throw ExceptionHelper.GetArgumentException(nameof(basketGuid), "Invalid Basket Guid");

            var basket = await _basketRepository.BasketGetByBasketGuidAsync(basketGuid);
            if (basket == null)
                throw ExceptionHelper.GetBasketExeption("The Basket with Guid does not exist.");

            await _basketItemRepository.BasketItemRemoveAllAsync(basket.Id);
        }

        public async Task RemoveBasketAsync(Guid basketGuid)
        {
            if (basketGuid == Guid.Empty)
                throw ExceptionHelper.GetArgumentException(nameof(basketGuid), "Invalid Basket Guid");

            await _basketRepository.BasketRemoveAsync(basketGuid);
        }
    }
}