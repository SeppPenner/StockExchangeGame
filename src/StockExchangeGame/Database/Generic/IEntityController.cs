using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Languages.Interfaces;

namespace StockExchangeGame.Database.Generic
{
    public interface IEntityController<T>
    {
        void SetCurrentLanguage(ILanguage language);

        ILanguage GetCurrentLanguage();

        int CreateTable();

        List<T> Get();

        T Get(long id);

        ObservableCollection<T> Get<TValue>(Expression<Func<T, bool>> predicate = null,
            Expression<Func<T, TValue>> orderBy = null);

        T Get(Expression<Func<T, bool>> predicate);

        int Insert(T entity);

        int Update(T entity);

        int Delete(T entity);

        int Count(Expression<Func<T, bool>> predicate = null);

        void Truncate();
    }
}