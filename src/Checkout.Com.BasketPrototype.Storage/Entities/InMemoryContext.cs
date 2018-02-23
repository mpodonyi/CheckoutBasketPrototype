namespace Checkout.Com.BasketPrototype.Storage.Entities
{
    using System.Collections.Generic;

    public class InMemoryContext // : DbContext
    {
        public readonly List<BasketItem> BasketItems = new List<BasketItem>();

        public readonly List<Basket> Baskets = new List<Basket>();


        //public virtual DbSet<Basket> Baskets { get; set; }
        //public virtual DbSet<BasketItem> BasketItems { get; set; }
    }
}