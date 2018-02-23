namespace Checkout.Com.BasketPrototype.Business.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class BasketException : Exception
    {


        public BasketException(string message) : base(message)
        {
        }


    }
}