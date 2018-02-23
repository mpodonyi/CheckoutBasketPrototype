namespace Checkout.Com.BasketPrototype.Storage.Entities
{
    using System;

    public class BasketItem
    {
        public BasketItem()
        {
            Guid = Guid.NewGuid();
        }

        public long Id { get; set; }

        public Guid Guid { get; set; }

        public string ProductSku { get; set; }

        public int Count { get; set; }

        public long BasketId { get; set; }
        //public virtual Basket Basket { get; set; }
    }
}