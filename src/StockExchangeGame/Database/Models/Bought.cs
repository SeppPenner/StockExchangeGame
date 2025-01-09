using System;

namespace StockExchangeGame.Database.Models
{
    public class Bought : AbstractEntity
    {
        private long _amount;

        private DateTime _dateBought;

        private long _merchantId;

        private long _stockId;

        private double _valuePerStockInEuro;

        public long MerchantId
        {
            get => this._merchantId;
            set
            {
                if (value.Equals(this._merchantId))
                    return;
                this._merchantId = value;
                this.OnPropertyChanged();
            }
        }

        public long StockId
        {
            get => this._stockId;
            set
            {
                if (value.Equals(this._stockId))
                    return;
                this._stockId = value;
                this.OnPropertyChanged();
            }
        }

        public long Amount
        {
            get => this._amount;
            set
            {
                if (value.Equals(this._amount))
                    return;
                this._amount = value;
                this.OnPropertyChanged();
            }
        }

        public DateTime DateBought
        {
            get => this._dateBought;
            set
            {
                if (value.Equals(this._dateBought))
                    return;
                this._dateBought = value;
                this.OnPropertyChanged();
            }
        }

        public double ValuePerStockInEuro
        {
            get => this._valuePerStockInEuro;
            set
            {
                if (value.Equals(this._valuePerStockInEuro))
                    return;
                this._valuePerStockInEuro = value;
                this.OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return
                $"{nameof(this.ModifiedAt)}: {this.ModifiedAt}, {nameof(this.Deleted)}: {this.Deleted}, {nameof(this.CreatedAt)}: {this.CreatedAt}, {nameof(this._amount)}: {this._amount}, {nameof(this._dateBought)}: {this._dateBought}, {nameof(this._merchantId)}: {this._merchantId}, {nameof(this._stockId)}: {this._stockId}, {nameof(this._valuePerStockInEuro)}: {this._valuePerStockInEuro}";
        }
    }
}