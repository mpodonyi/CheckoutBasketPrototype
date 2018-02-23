namespace Checkout.Com.BasketPrototype.Business.Test
{
    using System;
    using System.Threading.Tasks;
    using Autofac;
    using Container;
    using Exceptions;
    using FluentAssertions;
    using Interfaces;
    using Models;
    using Moq;
    using Storage.Entities;
    using Storage.Interfaces;
    using Xunit;

    public class BasketServiceTest : TestBase
    {
        [Fact]
        public async Task AddBasketItemAsync_SkuNotInBasket_ShouldBeSuccessful()
        {
            var basketGuid = Guid.NewGuid();

            var mock = new Mock<IBasketRepository>();
            mock.Setup(x => x.BasketGetByBasketGuidAsync(basketGuid))
                .Returns(Task.FromResult(new Basket {Guid = basketGuid}));

            var container =
                ContainerFacade.GetContainer(builder => builder.RegisterInstance(mock.Object).As<IBasketRepository>());
            var service = container.Resolve<IBasketService>();

            var basketItemCreateModel = new BasketItemCreateModel
            {
                ProductSku = "foo",
                Count = 1
            };

            Func<Task> f = async () =>
            {
                (await service.AddBasketItemAsync(basketGuid, basketItemCreateModel)).Should().NotBe(Guid.Empty);
            };
            f.Should().NotThrow();
        }

        [Fact]
        public async Task CreateBasket_WithEmptyGuid_ShouldThrowException()
        {
            var container = ContainerFacade.GetContainer();
            var service = container.Resolve<IBasketService>();

            Func<Task> f = async () => { await service.CreateBasketAsync(Guid.Empty); };
            f.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task CreateBasket_WithExistingUserBasket_ShouldThrowException()
        {
            var userguid = Guid.NewGuid();

            var mock = new Mock<IBasketRepository>();
            mock.Setup(x => x.BasketGetByUserGuidAsync(userguid))
                .Returns(Task.FromResult(new Basket {UserGuid = userguid}));

            var container =
                ContainerFacade.GetContainer(builder => builder.RegisterInstance(mock.Object).As<IBasketRepository>());
            var service = container.Resolve<IBasketService>();

            Func<Task> f = async () => { await service.CreateBasketAsync(userguid); };
            f.Should().Throw<BasketException>();
        }

        [Fact]
        public async Task CreateBasket_WithNotExistingUserBasket_ShouldBeSuccessful()
        {
            var userguid = Guid.NewGuid();

            var container = ContainerFacade.GetContainer();
            var service = container.Resolve<IBasketService>();

            Func<Task> f = async () => { (await service.CreateBasketAsync(userguid)).Should().NotBe(Guid.Empty); };
            f.Should().NotThrow();
        }

        //TODO missing UnitTests 
    }
}