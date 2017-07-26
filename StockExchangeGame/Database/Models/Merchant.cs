namespace StockExchangeGame.Database.Models
{
    using System;

    // ReSharper disable once UnusedMember.Global
    public class Merchant : AbstractEntity
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

        private double _liquidFunds;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once MemberCanBeProtected.Global
        // ReSharper disable once UnusedMember.Global
        public double LiquidFunds
        {
            get => _liquidFunds;
            set
            {
                if (value.Equals(_liquidFunds))
                {
                    return;
                }
                _liquidFunds = value;
                OnPropertyChanged();
            }
        }

        public Merchant()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
        }
    }
}