namespace Checkout.Com.BasketPrototype.Business.Models
{
    using System;

    public class BasketItemChangeModel
    {
        public Guid Guid { get; set; }

        public string ProductSku { get; set; }

        public int Count { get; set; }
    }
}