using System;

namespace StockExchangeGame.Exceptions
{
    // ReSharper disable once UnusedMember.Global
    public class ViewCannotBeClosedException : Exception
    {
        public ViewCannotBeClosedException()
        {
        }

        // ReSharper disable once UnusedMember.Global
        public ViewCannotBeClosedException(string message)
            : base(message)
        {
        }

        // ReSharper disable once UnusedMember.Global
        public ViewCannotBeClosedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}