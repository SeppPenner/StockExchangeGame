namespace StockExchangeGame.Database.Models
{
    public class Stock : AbstractEntity
    {
        private string _name;

        private long _stockMarketId;

        private long _total;

        private long _used;

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

        public long StockMarketId
        {
            get => this._stockMarketId;
            set
            {
                if (value.Equals(this._stockMarketId))
                    return;
                this._stockMarketId = value;
                this.OnPropertyChanged();
            }
        }

        public long Total
        {
            get => this._total;
            set
            {
                if (value.Equals(this._total))
                    return;
                this._total = value;
                this.OnPropertyChanged();
            }
        }

        public long Used
        {
            get => this._used;
            set
            {
                if (value.Equals(this._used))
                    return;
                this._used = value;
                this.OnPropertyChanged();
            }
        }

        public double GetQuotaUsed()
        {
            return this._used / (double)this._total * 100;
        }

        public override string ToString()
        {
            return
                $"{nameof(this.ModifiedAt)}: {this.ModifiedAt}, {nameof(this.Deleted)}: {this.Deleted}, {nameof(this.CreatedAt)}: {this.CreatedAt}, {nameof(this._name)}: {this._name}, {nameof(this._total)}: {this._total}, {nameof(this._used)}: {this._used}, {nameof(this._stockMarketId)}: {this._stockMarketId}";
        }
    }
}