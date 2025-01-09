namespace StockExchangeGame.Database.Models
{
    public class Merchant : AbstractEntity
    {
        private double _liquidFundsInEuro;
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

        public double LiquidFundsInEuro
        {
            get => this._liquidFundsInEuro;
            set
            {
                if (value.Equals(this._liquidFundsInEuro))
                    return;
                this._liquidFundsInEuro = value;
                this.OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return
                $"{nameof(this.ModifiedAt)}: {this.ModifiedAt}, {nameof(this.Deleted)}: {this.Deleted}, {nameof(this.CreatedAt)}: {this.CreatedAt}, {nameof(this._liquidFundsInEuro)}: {this._liquidFundsInEuro}, {nameof(this._name)}: {this._name}";
        }
    }
}