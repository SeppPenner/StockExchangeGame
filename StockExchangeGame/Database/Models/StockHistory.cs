using System;

namespace StockExchangeGame.Database.Models
{
    public class StockHistory : AbstractEntity
    {
        private DateTime _priceDate;

        private double _pricePerStock;

        private long _stockId;

        public StockHistory()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
        }

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once MemberCanBeProtected.Global
        // ReSharper disable once UnusedMember.Global
        public DateTime PriceDate
        {
            get => _priceDate;
            set
            {
                if (value.Equals(_priceDate))
                    return;
                _priceDate = value;
                OnPropertyChanged();
            }
        }

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once MemberCanBeProtected.Global
        // ReSharper disable once UnusedMember.Global
        public long StockId
        {
            get => _stockId;
            set
            {
                if (value.Equals(_stockId))
                    return;
                _stockId = value;
                OnPropertyChanged();
            }
        }

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once MemberCanBeProtected.Global
        // ReSharper disable once UnusedMember.Global
        public double PricePerStock
        {
            get => _pricePerStock;
            set
            {
                if (value.Equals(_pricePerStock))
                    return;
                _pricePerStock = value;
                OnPropertyChanged();
            }
        }
    }
}