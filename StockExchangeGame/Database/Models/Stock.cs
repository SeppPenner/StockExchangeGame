using System;

namespace StockExchangeGame.Database.Models
{
    // ReSharper disable once UnusedMember.Global
    public class Stock: AbstractEntity
    {
        public Stock()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
        }

        private string _name;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once MemberCanBeProtected.Global
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

        private int _total;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once MemberCanBeProtected.Global
        // ReSharper disable once UnusedMember.Global
        public int Total
        {
            get => _total;
            set
            {
                if (value.Equals(_total))
                {
                    return;
                }
                _total = value;
                OnPropertyChanged();
            }
        }

        private int _used;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once MemberCanBeProtected.Global
        // ReSharper disable once UnusedMember.Global
        public int Used
        {
            get => _used;
            set
            {
                if (value.Equals(_used))
                {
                    return;
                }
                _used = value;
                OnPropertyChanged();
            }
        }
    }
}