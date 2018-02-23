namespace Checkout.Com.BasketPrototype.Business.Exceptions
{
    using System;

    public static class ExceptionHelper
    {
        public static BasketException GetBasketExeption(string message)
        {
            return new BasketException(message);
        }

        public static ArgumentException GetArgumentException(string arg, string message)
        {
            return new ArgumentException(message, arg);
        }
    }
}