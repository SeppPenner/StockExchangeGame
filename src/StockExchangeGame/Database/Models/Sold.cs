using System;

namespace StockExchangeGame.Database.Models
{
    public class Sold : AbstractEntity
    {
        private long _amount;

        private DateTime _dateSold;

        private long _merchantId;

        private long _stockId;

        private double _valuePerStockInEuro;

        public long MerchantId
        {
            get => _merchantId;
            set
            {
                if (value.Equals(_merchantId))
                    return;
                _merchantId = value;
                OnPropertyChanged();
            }
        }

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

        public long Amount
        {
            get => _amount;
            set
            {
                if (value.Equals(_amount))
                    return;
                _amount = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateSold
        {
            get => _dateSold;
            set
            {
                if (value.Equals(_dateSold))
                    return;
                _dateSold = value;
                OnPropertyChanged();
            }
        }

        public double ValuePerStockInEuro
        {
            get => _valuePerStockInEuro;
            set
            {
                if (value.Equals(_valuePerStockInEuro))
                    return;
                _valuePerStockInEuro = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return
                $"{nameof(ModifiedAt)}: {ModifiedAt}, {nameof(Deleted)}: {Deleted}, {nameof(CreatedAt)}: {CreatedAt}, {nameof(_amount)}: {_amount}, {nameof(_dateSold)}: {_dateSold}, {nameof(_merchantId)}: {_merchantId}, {nameof(_stockId)}: {_stockId}, {nameof(_valuePerStockInEuro)}: {_valuePerStockInEuro}";
        }
    }
}