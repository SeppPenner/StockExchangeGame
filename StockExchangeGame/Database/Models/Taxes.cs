using System;

namespace StockExchangeGame.Database.Models
{
    // ReSharper disable once UnusedMember.Global
    public class Taxes : AbstractEntity
    {
        public Taxes()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
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

        private DateTime _dateTaxWasDue;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once MemberCanBeProtected.Global
        // ReSharper disable once UnusedMember.Global
        public DateTime DateTaxWasDue
        {
            get => _dateTaxWasDue;
            set
            {
                if (value.Equals(_dateTaxWasDue))
                {
                    return;
                }
                _dateTaxWasDue = value;
                OnPropertyChanged();
            }
        }

        private double _dueInEuro;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once MemberCanBeProtected.Global
        // ReSharper disable once UnusedMember.Global
        public double DueInEuro
        {
            get => _dueInEuro;
            set
            {
                if (value.Equals(_dueInEuro))
                {
                    return;
                }
                _dueInEuro = value;
                OnPropertyChanged();
            }
        }

        private double _payedInEuro;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once MemberCanBeProtected.Global
        // ReSharper disable once UnusedMember.Global
        public double PayedInEuro
        {
            get => _payedInEuro;
            set
            {
                if (value.Equals(_payedInEuro))
                {
                    return;
                }
                _payedInEuro = value;
                OnPropertyChanged();
            }
        }
    }
}