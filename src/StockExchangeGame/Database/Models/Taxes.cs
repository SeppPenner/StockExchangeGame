using System;

namespace StockExchangeGame.Database.Models
{
    public class Taxes : AbstractEntity
    {
        private DateTime _dateTaxWasDue;

        private double _dueInEuro;

        private long _merchantId;

        private double _payedInEuro;

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

        public DateTime DateTaxWasDue
        {
            get => this._dateTaxWasDue;
            set
            {
                if (value.Equals(this._dateTaxWasDue))
                    return;
                this._dateTaxWasDue = value;
                this.OnPropertyChanged();
            }
        }

        public double DueInEuro
        {
            get => this._dueInEuro;
            set
            {
                if (value.Equals(this._dueInEuro))
                    return;
                this._dueInEuro = value;
                this.OnPropertyChanged();
            }
        }

        public double PayedInEuro
        {
            get => this._payedInEuro;
            set
            {
                if (value.Equals(this._payedInEuro))
                    return;
                this._payedInEuro = value;
                this.OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return
                $"{nameof(this.ModifiedAt)}: {this.ModifiedAt}, {nameof(this.Deleted)}: {this.Deleted}, {nameof(this.CreatedAt)}: {this.CreatedAt}, {nameof(this._dateTaxWasDue)}: {this._dateTaxWasDue}, {nameof(this._dueInEuro)}: {this._dueInEuro}, {nameof(this._merchantId)}: {this._merchantId}, {nameof(this._payedInEuro)}: {this._payedInEuro}";
        }
    }
}