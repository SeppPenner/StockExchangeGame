namespace StockExchangeGame.Database.Models
{
    using System;

    // ReSharper disable once UnusedMember.Global
    public class StockMarket : AbstractEntity
    {
        private string _name;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once MemberCanBeProtected.Global
        // ReSharper disable once UnusedMember.Global
        public string Name
        {
            get => _name;
            set
            {
                if (value.Equals(_name))
                {
                    return;
                }
                _name = value;
                OnPropertyChanged();
            }
        }

        private long _stockId;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once MemberCanBeProtected.Global
        // ReSharper disable once UnusedMember.Global
        public long StockId
        {
            get => _stockId;
            set
            {
                if (value.Equals(_stockId))
                {
                    return;
                }
                _stockId = value;
                OnPropertyChanged();
            }
        }

        public StockMarket()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
        }
    }
}