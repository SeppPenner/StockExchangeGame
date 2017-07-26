namespace StockExchangeGame.Database.Models
{
    using System;

    // ReSharper disable once UnusedMember.Global
    public class Names : AbstractEntity
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

        public Names()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
        }
    }
}