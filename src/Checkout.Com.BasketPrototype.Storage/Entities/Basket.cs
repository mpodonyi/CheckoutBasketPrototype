namespace Checkout.Com.BasketPrototype.Storage.Entities
{
    using System;

    public class Basket
    {
        public Basket()
        {
            Guid = Guid.NewGuid();
        }

        public long Id { get; set; }

        public Guid Guid { get; set; }

        public Guid UserGuid { get; set; }

        // public virtual List<BasketItem> BasketItems { get; set; }
    }
}