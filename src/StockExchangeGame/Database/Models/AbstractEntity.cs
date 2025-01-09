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
            get => this._createdAt;
            set
            {
                if (value.Equals(this._createdAt))
                    return;
                this._createdAt = value;
                this.OnPropertyChanged();
            }
        }

        public DateTime ModifiedAt
        {
            get => this._modifiedAt;
            set
            {
                if (value.Equals(this._modifiedAt))
                    return;
                this._modifiedAt = value;
                this.OnPropertyChanged();
            }
        }

        public bool Deleted
        {
            get => this._deleted;
            set
            {
                if (value.Equals(this._deleted))
                    return;
                this._deleted = value;
                this.OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            this.ModifiedAt = DateTime.Now;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}