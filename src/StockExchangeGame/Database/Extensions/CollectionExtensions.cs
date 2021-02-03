namespace StockExchangeGame.Database.Extensions
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public static class CollectionExtensions
    {
        public static ObservableCollection<T> ToCollection<T>(this IEnumerable<T> list)
        {
            var collection = new ObservableCollection<T>();

            foreach (var item in list)
            {
                collection.Add(item);
            }

            return collection;
        }
    }
}