namespace Checkout.Com.BasketPrototype.ApiGateway.Controllers
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Business.Interfaces;
    using Core.Interfaces.Services;

    [RoutePrefix("api/v1/user/{userGuid:guid}/basket")]
    public class BasketController : ApiControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMappingService _mappingService;


        public BasketController(IBasketService basketService, IMappingService mappingService)
        {
            _basketService = basketService;
            _mappingService = mappingService;
        }


        /// <summary>
        ///     Create Basket For User.
        /// </summary>
        /// <param name="userGuid">The users unique identifier.</param>
        /// <returns></returns>
        /// <response code="204">The item was created</response>
        /// <response code="500">An Error occured</response>
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(Guid))]
        public async Task<IHttpActionResult> PostBasketAsync(Guid userGuid)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var basketGuid = await _basketService.CreateBasketAsync(userGuid);

                return Created(Request.RequestUri + "/" + basketGuid.ToString("D"), basketGuid);
            }
            catch (Exception e)
            {
                LogException(e);
                return InternalServerError();
            }
        }


        /// <summary>
        ///     Deletes the basket.
        /// </summary>
        /// <param name="basketGuid">The basket unique identifier.</param>
        /// <returns></returns>
        /// <response code="204">The item was deleted</response>
        /// <response code="500">An Error occured</response>
        [Route("{basketGuid:guid}")]
        [HttpDelete]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> DeleteBasketAsync(Guid basketGuid)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                await _basketService.RemoveBasketAsync(basketGuid);

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