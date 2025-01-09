namespace StockExchangeGame.Database.Models
{
    public class StockMarket : AbstractEntity
    {
        private string _name;

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

        public override string ToString()
        {
            return
                $"{nameof(this.ModifiedAt)}: {this.ModifiedAt}, {nameof(this.Deleted)}: {this.Deleted}, {nameof(this.CreatedAt)}: {this.CreatedAt}, {nameof(this._name)}: {this._name}";
        }
    }
}