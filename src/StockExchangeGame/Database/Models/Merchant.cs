namespace StockExchangeGame.Database.Models
{
    public class Merchant : AbstractEntity
    {
        private double _liquidFundsInEuro;
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                if (value.Equals(_name))
                    return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public double LiquidFundsInEuro
        {
            get => _liquidFundsInEuro;
            set
            {
                if (value.Equals(_liquidFundsInEuro))
                    return;
                _liquidFundsInEuro = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return
                $"{nameof(ModifiedAt)}: {ModifiedAt}, {nameof(Deleted)}: {Deleted}, {nameof(CreatedAt)}: {CreatedAt}, {nameof(_liquidFundsInEuro)}: {_liquidFundsInEuro}, {nameof(_name)}: {_name}";
        }
    }
}