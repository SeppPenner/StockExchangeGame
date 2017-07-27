using System;
using System.Threading;

namespace StockExchangeGame.Database.Generic
{
    // ReSharper disable once UnusedMember.Global
    public class LockWrapper : IDisposable
    {
        private readonly object _lockPoint;

        public LockWrapper(object lockPoint)
        {
            _lockPoint = lockPoint;
            Monitor.Enter(_lockPoint);
        }

        public void Dispose()
        {
            Monitor.Exit(_lockPoint);
        }
    }
}