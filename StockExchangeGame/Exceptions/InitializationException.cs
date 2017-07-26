using System;
using System.Collections.Generic;
using StockExchangeGame.Database.Generic;

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

        public InitializationException(string message, List<CreateTablesResult> results)
            : base(message)
        {
            Results = results;
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        private List<CreateTablesResult> Results { get;}
    }
}