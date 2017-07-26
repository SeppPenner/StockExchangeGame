using System;

namespace StockExchangeGame.Database.Models
{
    public class StockHistory : AbstractEntity
    {
        private DateTime _priceDate;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once MemberCanBeProtected.Global
        // ReSharper disable once UnusedMember.Global
        public DateTime PriceDate
        {
            get => _priceDate;
            set
            {
                if (value.Equals(_priceDate))
                {
                    return;
                }
                _priceDate = value;
                OnPropertyChanged();
            }
        }

        private long _stockId;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once MemberCanBeProtected.Global
        // ReSharper disable once UnusedMember.Global
        public long StockId
        {
            get => _stockId;
            set
            {
                if (value.Equals(_stockId))
                {
                    return;
                }
                _stockId = value;
                OnPropertyChanged();
            }
        }

        private double _pricePerStock;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once MemberCanBeProtected.Global
        // ReSharper disable once UnusedMember.Global
        public double PricePerStock
        {
            get => _pricePerStock;
            set
            {
                if (value.Equals(_pricePerStock))
                {
                    return;
                }
                _pricePerStock = value;
                OnPropertyChanged();
            }
        }

        public StockHistory()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
        }
    }
}