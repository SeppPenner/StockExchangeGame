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

        // ReSharper disable once UnusedMember.Global
        public InitializationException(string message, List<CreateTablesResult> results)
            : base(message)
        {
            Results = results;
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        private List<CreateTablesResult> Results { get;}

        // ReSharper disable once UnusedMember.Global
        public override string ToString()
        {
            return "<Results: " + string.Join(",", Results) + " Results/>";
        }
    }
}