using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StockExchangeGame.Database.Attributes;

namespace StockExchangeGame.Database.Models
{
    public class AbstractEntity : INotifyPropertyChanged
    {
        private DateTime _createdAt;

        private bool _deleted;

        private DateTime _modifiedAt;

        [PrimaryKey]
        [AutoIncrement]
        public long Id { get; set; }

        public DateTime CreatedAt
        {
            get => _createdAt;
            set
            {
                if (value.Equals(_createdAt))
                    return;
                _createdAt = value;
                OnPropertyChanged();
            }
        }

        public DateTime ModifiedAt
        {
            get => _modifiedAt;
            set
            {
                if (value.Equals(_modifiedAt))
                    return;
                _modifiedAt = value;
                OnPropertyChanged();
            }
        }

        public bool Deleted
        {
            get => _deleted;
            set
            {
                if (value.Equals(_deleted))
                    return;
                _deleted = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            ModifiedAt = DateTime.Now;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}