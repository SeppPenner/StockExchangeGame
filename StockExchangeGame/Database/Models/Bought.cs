using System;

namespace StockExchangeGame.Database.Models
{
    // ReSharper disable once UnusedMember.Global
    public class Bought : AbstractEntity
    {
        public Bought()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
        }

        private long _merchantId;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once MemberCanBeProtected.Global
        // ReSharper disable once UnusedMember.Global
        public long MerchantId
        {
            get => _merchantId;
            set
            {
                if (value.Equals(_merchantId))
                {
                    return;
                }
                _merchantId = value;
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

        private int _amount;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once MemberCanBeProtected.Global
        // ReSharper disable once UnusedMember.Global
        public int Amount
        {
            get => _amount;
            set
            {
                if (value.Equals(_amount))
                {
                    return;
                }
                _amount = value;
                OnPropertyChanged();
            }
        }

        private DateTime _dateBought;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once MemberCanBeProtected.Global
        // ReSharper disable once UnusedMember.Global
        public DateTime DateBought
        {
            get => _dateBought;
            set
            {
                if (value.Equals(_dateBought))
                {
                    return;
                }
                _dateBought = value;
                OnPropertyChanged();
            }
        }

        private double _valuePerStockInEuro;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once MemberCanBeProtected.Global
        // ReSharper disable once UnusedMember.Global
        public double ValuePerStockInEuro
        {
            get => _valuePerStockInEuro;
            set
            {
                if (value.Equals(_valuePerStockInEuro))
                {
                    return;
                }
                _valuePerStockInEuro = value;
                OnPropertyChanged();
            }
        }
    }
}