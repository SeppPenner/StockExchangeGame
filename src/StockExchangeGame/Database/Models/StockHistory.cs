using System;

namespace StockExchangeGame.Database.Models
{
    public class StockHistory : AbstractEntity
    {
        private DateTime _priceDate;

        private double _pricePerStock;

        private long _stockId;

        public DateTime PriceDate
        {
            get => this._priceDate;
            set
            {
                if (value.Equals(this._priceDate))
                    return;
                this._priceDate = value;
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

        public double PricePerStock
        {
            get => this._pricePerStock;
            set
            {
                if (value.Equals(this._pricePerStock))
                    return;
                this._pricePerStock = value;
                this.OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return
                $"{nameof(this.ModifiedAt)}: {this.ModifiedAt}, {nameof(this.Deleted)}: {this.Deleted}, {nameof(this.CreatedAt)}: {this.CreatedAt}, {nameof(this._priceDate)}: {this._priceDate}, {nameof(this._pricePerStock)}: {this._pricePerStock}, {nameof(this._stockId)}: {this._stockId}";
        }
    }
}