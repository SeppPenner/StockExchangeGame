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
            get => _name;
            set
            {
                if (value.Equals(_name))
                    return;
                _name = value;
                OnPropertyChanged();
            }
        }

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

        public double SumInEuro
        {
            get => _sumInEuro;
            set
            {
                if (value.Equals(_sumInEuro))
                    return;
                _sumInEuro = value;
                OnPropertyChanged();
            }
        }

        public bool Active
        {
            get => _active;
            set
            {
                if (value.Equals(_active))
                    return;
                _active = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return
                $"{nameof(ModifiedAt)}: {ModifiedAt}, {nameof(Deleted)}: {Deleted}, {nameof(CreatedAt)}: {CreatedAt}, {nameof(_active)}: {_active}, {nameof(_merchantId)}: {_merchantId}, {nameof(_name)}: {_name}, {nameof(_sumInEuro)}: {_sumInEuro}";
        }
    }
}