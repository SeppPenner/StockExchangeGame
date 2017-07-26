using System;

namespace StockExchangeGame.Database.Models
{
    // ReSharper disable once UnusedMember.Global
    public class DummyCompany : AbstractEntity
    {
        public DummyCompany()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
        }

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

        private long _merchantId;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once MemberCanBeProtected.Global
        // ReSharper disable once UnusedMember.Global
        public long MerchantId
        {
            get => _merchantId;
            set
            {
                if (value.Equals(_merchantId))
                {
                    return;
                }
                _merchantId = value;
                OnPropertyChanged();
            }
        }

        private double _sumInEuro;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once MemberCanBeProtected.Global
        // ReSharper disable once UnusedMember.Global
        public double SumInEuro
        {
            get => _sumInEuro;
            set
            {
                if (value.Equals(_sumInEuro))
                {
                    return;
                }
                _sumInEuro = value;
                OnPropertyChanged();
            }
        }

        private bool _active;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once MemberCanBeProtected.Global
        // ReSharper disable once UnusedMember.Global
        public bool Active
        {
            get => _active;
            set
            {
                if (value.Equals(_active))
                {
                    return;
                }
                _active = value;
                OnPropertyChanged();
            }
        }
    }
}