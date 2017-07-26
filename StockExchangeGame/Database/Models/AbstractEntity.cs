using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StockExchangeGame.Database.Generic;

namespace StockExchangeGame.Database.Models
{
    public class AbstractEntity : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        // ReSharper disable once UnusedMember.Global
        public long Id { get; set; }

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once MemberCanBeProtected.Global
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private DateTime _createdAt;

        // ReSharper disable once MemberCanBeProtected.Global
        // ReSharper disable once UnusedMember.Global
        public DateTime CreatedAt
        {
            get => _createdAt;
            set
            {
                if (value.Equals(_createdAt))
                {
                    return;
                }
                _createdAt = value;
                OnPropertyChanged();
            }
        }

        private DateTime _modifiedAt;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once MemberCanBeProtected.Global
        // ReSharper disable once UnusedMember.Global
        public DateTime ModifiedAt
        {
            get => _modifiedAt;
            set
            {
                if (value.Equals(_modifiedAt))
                {
                    return;
                }
                _modifiedAt = value;
                OnPropertyChanged();
            }
        }

        private bool _deleted;

        // ReSharper disable once UnusedMember.Global
        public bool Deleted
        {
            get => _deleted;
            set
            {
                if (value.Equals(_deleted))
                {
                    return;
                }
                _deleted = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}