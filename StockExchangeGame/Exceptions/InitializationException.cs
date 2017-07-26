using System;

namespace StockExchangeGame.Exceptions
{

    // ReSharper disable once UnusedMember.Global
    public class InitializationException : Exception
    {
        public InitializationException()
        {
        }

        public InitializationException(string message)
            : base(message)
        {
        }

        public InitializationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}