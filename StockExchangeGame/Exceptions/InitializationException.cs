using System;

namespace StockExchangeGame.Exceptions
{
    // ReSharper disable once UnusedMember.Global
    public class InitializationException : Exception
    {
        public InitializationException()
        {
        }

        // ReSharper disable once UnusedMember.Global
        public InitializationException(string message)
            : base(message)
        {
        }

        // ReSharper disable once UnusedMember.Global
        public InitializationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}