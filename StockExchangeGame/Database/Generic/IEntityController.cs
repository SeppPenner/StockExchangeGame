using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using StockExchangeGame.Database.Models;

namespace StockExchangeGame.Database.Generic
{
    // ReSharper disable once UnusedMember.Global
    public interface IEntityController<T> where T : AbstractEntity, new()
    {
        // ReSharper disable once UnusedMember.Global
        Task<List<T>> Get();

        // ReSharper disable once UnusedMember.Global
        Task<T> Get(int id);

        // ReSharper disable once UnusedMember.Global
        Task<ObservableCollection<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null);

        // ReSharper disable once UnusedMember.Global
        Task<T> Get(Expression<Func<T, bool>> predicate);

        // ReSharper disable once UnusedMember.Global
        AsyncTableQuery<T> AsQueryable();

        // ReSharper disable once UnusedMember.Global
        Task<int> Insert(T entity);

        // ReSharper disable once UnusedMember.Global
        Task<int> Update(T entity);

        // ReSharper disable once UnusedMember.Global
        Task<int> Delete(T entity);

        // ReSharper disable once UnusedMember.Global
        Task<int> Count(Expression<Func<T, bool>> predicate = null);
    }
}