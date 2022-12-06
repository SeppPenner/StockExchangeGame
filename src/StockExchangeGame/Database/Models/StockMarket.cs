namespace StockExchangeGame.Database.Models
{
    public class StockMarket : AbstractEntity
    {
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

        public override string ToString()
        {
            return
                $"{nameof(ModifiedAt)}: {ModifiedAt}, {nameof(Deleted)}: {Deleted}, {nameof(CreatedAt)}: {CreatedAt}, {nameof(_name)}: {_name}";
        }
    }
}