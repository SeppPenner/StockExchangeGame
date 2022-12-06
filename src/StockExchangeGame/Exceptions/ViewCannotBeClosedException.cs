using System;

namespace StockExchangeGame.Exceptions
{
    public class ViewCannotBeClosedException : Exception
    {
        public ViewCannotBeClosedException()
        {
        }

        public ViewCannotBeClosedException(string message)
            : base(message)
        {
        }

        public ViewCannotBeClosedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}