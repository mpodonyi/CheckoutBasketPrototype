namespace Checkout.Com.BasketPrototype.ApiGateway.Controllers
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Business.Interfaces;
    using Core.Interfaces.Services;
    using Models;

    [RoutePrefix("api/v1/user/{userGuid:guid}/basket/{basketGuid:guid}")]
    public class BasketItemController : ApiControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMappingService _mappingService;

        public BasketItemController(IBasketService basketService, IMappingService mappingService)
        {
            _basketService = basketService;
            _mappingService = mappingService;
        }


        /// <summary>
        ///     Creates a new basket item.
        /// </summary>
        /// <param name="basketGuid">The basket unique identifier.</param>
        /// <param name="basketItemCreateModel">The basket item create model.</param>
        /// <returns></returns>
        /// <response code="204">The item was created</response>
        /// <response code="500">An Error occured</response>
        [Route("basketitem")]
        [HttpPost]
        [ResponseType(typeof(Guid))]
        public async Task<IHttpActionResult> PostBasketItemAsync(Guid basketGuid,
            [FromBody] BasketItemCreateModel basketItemCreateModel)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var targetModel =
                    _mappingService.Map<BasketItemCreateModel, Business.Models.BasketItemCreateModel>(
                        basketItemCreateModel);

                //var targetModel = new Business.Models.BasketItemCreateModel
                //{
                //    ProductSku = basketItemCreateModel.ProductSku,
                //    Count = basketItemCreateModel.Count
                //};

                var basketItemGuid = await _basketService.AddBasketItemAsync(basketGuid, targetModel);

                return Created(Request.RequestUri + "/" + basketItemGuid.ToString("D"), basketItemGuid);
            }
            catch (Exception e)
            {
                LogException(e);
                return InternalServerError();
            }
        }

        /// <summary>
        ///     Deletes the basket item.
        /// </summary>
        /// <param name="basketitemGuid">The basketitem unique identifier.</param>
        /// <returns></returns>
        /// <response code="204">The item was deleted</response>
        /// <response code="500">An Error occured</response>
        [Route("basketitem/{basketitemGuid:guid}")]
        [HttpDelete]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> DeleteBasketItemAsync(Guid basketitemGuid)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                await _basketService.RemoveBasketItemAsync(basketitemGuid);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                LogException(e);
                return InternalServerError();
            }
        }

        /// <summary>
        ///     Changes the content of basket item.
        /// </summary>
        /// <param name="basketitemGuid">The basketitem unique identifier.</param>
        /// <param name="basketItemChangeModel">The basket item change model.</param>
        /// <returns></returns>
        /// <response code="204">The item was changed</response>
        /// <response code="500">An Error occured</response>
        [Route("basketitem/{basketitemGuid:guid}")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBasketItemAsync(Guid basketitemGuid,
            [FromBody] BasketItemChangeModel basketItemChangeModel)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var targetModel =
                    _mappingService.Map<BasketItemChangeModel, Business.Models.BasketItemChangeModel>(
                        basketItemChangeModel);
                targetModel.Guid = basketitemGuid;
               
                await _basketService.ChangeBasketItemAsync(targetModel);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                LogException(e);
                return InternalServerError();
            }
        }

        /// <summary>
        ///     Deletes all basketitems in the basket.
        /// </summary>
        /// <param name="basketGuid">The basket unique identifier.</param>
        /// <returns></returns>
        /// <response code="204">The items were deleted</response>
        /// <response code="500">An Error occured</response>
        [Route("basketitems")]
        [HttpDelete]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> DeleteBasketItemsAsync(Guid basketGuid)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                await _basketService.RemoveAllBasketItemsAsync(basketGuid);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                LogException(e);
                return InternalServerError();
            }
        }
    }
}