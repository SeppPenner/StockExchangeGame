using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using StockExchangeGame.Database.Models;

namespace StockExchangeGame.Database.Generic
{
    // ReSharper disable once UnusedMember.Global
    public class EntityController<T> : IEntityController<T> where T : AbstractEntity, new()
    {
        private readonly SqLiteAsyncConnection _db;

        public EntityController(SqLiteAsyncConnection db)
        {
            _db = db;
        }

        public AsyncTableQuery<T> AsQueryable()
        {
            return _db.Table<T>();
        }

        public async Task<int> Count(Expression<Func<T, bool>> predicate = null)
        {
            var query = QueryIfPredicateNotNull(predicate);
            return await query.CountAsync();
        }

        public async Task<int> Delete(T entity)
        {
            return await _db.DeleteAsync(entity);
        }

        public async Task<List<T>> Get()
        {
            return await _db.Table<T>().ToListAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await _db.FindAsync(predicate);
        }

        public async Task<T> Get(int id)
        {
            return await _db.FindAsync<T>(id);
        }

        public async Task<ObservableCollection<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null,
            Expression<Func<T, TValue>> orderBy = null)
        {
            var query = QueryIfPredicateNotNull(predicate);
            query = OrderByIfNotNull(query, orderBy);
            return await GetCollection(query);
        }

        public async Task<int> Insert(T entity)
        {
            return await _db.InsertAsync(entity);
        }

        public async Task<int> Update(T entity)
        {
            return await _db.UpdateAsync(entity);
        }

        private AsyncTableQuery<T> QueryIfPredicateNotNull(Expression<Func<T, bool>> predicate)
        {
            var query = _db.Table<T>();
            return predicate != null ? query.Where(predicate) : query;
        }

        private AsyncTableQuery<T> OrderByIfNotNull<TValue>(AsyncTableQuery<T> query,
            Expression<Func<T, TValue>> orderBy)
        {
            return orderBy != null ? query.OrderBy(orderBy) : query;
        }

        private async Task<ObservableCollection<T>> GetCollection(AsyncTableQuery<T> query)
        {
            var items = await query.ToListAsync();
            return GetItems(items);
        }

        private ObservableCollection<T> GetItems(IEnumerable<T> items)
        {
            var collection = new ObservableCollection<T>();
            foreach (var item in items)
                collection.Add(item);
            return collection;
        }
    }
}