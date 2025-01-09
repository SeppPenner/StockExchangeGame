namespace StockExchangeGame.Database.Models
{
    public class DummyCompany : AbstractEntity
    {
        private bool _active;

        private long _merchantId;

        private string _name;

        private double _sumInEuro;

        public string Name
        {
            get => this._name;
            set
            {
                if (value.Equals(this._name))
                    return;
                this._name = value;
                this.OnPropertyChanged();
            }
        }

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

        public double SumInEuro
        {
            get => this._sumInEuro;
            set
            {
                if (value.Equals(this._sumInEuro))
                    return;
                this._sumInEuro = value;
                this.OnPropertyChanged();
            }
        }

        public bool Active
        {
            get => this._active;
            set
            {
                if (value.Equals(this._active))
                    return;
                this._active = value;
                this.OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return
                $"{nameof(this.ModifiedAt)}: {this.ModifiedAt}, {nameof(this.Deleted)}: {this.Deleted}, {nameof(this.CreatedAt)}: {this.CreatedAt}, {nameof(this._active)}: {this._active}, {nameof(this._merchantId)}: {this._merchantId}, {nameof(this._name)}: {this._name}, {nameof(this._sumInEuro)}: {this._sumInEuro}";
        }
    }
}