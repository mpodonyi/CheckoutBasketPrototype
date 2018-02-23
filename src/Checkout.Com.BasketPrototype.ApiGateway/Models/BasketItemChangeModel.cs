namespace Checkout.Com.BasketPrototype.ApiGateway.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BasketItemChangeModel
    {
        /// <summary>
        ///     Gets or sets the product sku.
        /// </summary>
        /// <value>
        ///     The product sku.
        /// </value>
        [Required]
        public string ProductSku { get; set; }

        /// <summary>
        ///     Gets or sets the count.
        /// </summary>
        /// <value>
        ///     The count.
        /// </value>
        [Required]
        [Range(1, 1000)]
        public int Count { get; set; }
    }
}