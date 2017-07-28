﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Linq.Expressions;
using StockExchangeGame.Database.Models;

namespace StockExchangeGame.Database.Generic
{
    // ReSharper disable once UnusedMember.Global
    public class StockMarketController : IEntityController<StockMarket>
    {
        private readonly SQLiteConnection _connection;

        public StockMarketController(string connectionString)
        {
            _connection = new SQLiteConnection(connectionString);
        }

        public int CreateTable()
        {
            int result;
            var sql = GetCreateTableSQL();
            _connection.Open();
            using (var command = new SQLiteCommand(sql, _connection))
            {
                result = command.ExecuteNonQuery();
            }
            _connection.Close();
            return result;
        }

        public List<StockMarket> Get()
        {
            var list = new List<StockMarket>();
            var sql = "SELECT * FROM StockMarket";
            _connection.Open();
            using (var command = new SQLiteCommand(sql, _connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var stockmarket = GetStockMarketFromReader(reader);
                        list.Add(stockmarket);
                    }
                }
            }
            _connection.Close();
            return list;
        }

        public StockMarket Get(long id)
        {
            var sql = "SELECT * FROM StockMarket WHERE Id = @Id";
            _connection.Open();
            using (var command = new SQLiteCommand(sql, _connection))
            {
                PrepareCommandSelect(command, id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        return GetStockMarketFromReader(reader);
                }
            }
            _connection.Close();
            return null;
        }

        public ObservableCollection<StockMarket> Get<TValue>(Expression<Func<StockMarket, bool>> predicate = null,
            Expression<Func<StockMarket, TValue>> orderBy = null)
        {
            if (predicate == null && orderBy == null)
                return GetCollection(Get());
            if (predicate != null && orderBy == null)
                return GetCollection(GetQueryable().Where(predicate).ToList());
            return GetCollection(predicate == null
                ? GetQueryable().OrderBy(orderBy).ToList()
                : GetQueryable().Where(predicate).OrderBy(orderBy).ToList());
        }

        public StockMarket Get(Expression<Func<StockMarket, bool>> predicate)
        {
            return GetQueryable().Where(predicate).FirstOrDefault();
        }

        public int Insert(StockMarket entity)
        {
            int result;
            _connection.Open();
            using (var command = new SQLiteCommand(_connection))
            {
                PrepareCommandInsert(command, entity);
                result = command.ExecuteNonQuery();
            }
            _connection.Close();
            return result;
        }

        public int Update(StockMarket entity)
        {
            int result;
            _connection.Open();
            using (var command = new SQLiteCommand(_connection))
            {
                PrepareCommandUpdate(command, entity);
                result = command.ExecuteNonQuery();
            }
            _connection.Close();
            return result;
        }

        public int Delete(StockMarket entity)
        {
            int result;
            _connection.Open();
            using (var command = new SQLiteCommand(_connection))
            {
                PrepareDeletCommand(command, entity);
                result = command.ExecuteNonQuery();
            }
            _connection.Close();
            return result;
        }

        public int Count(Expression<Func<StockMarket, bool>> predicate = null)
        {
            return predicate == null ? Get().Count : GetQueryable().Where(predicate).Count();
        }

        private string GetCreateTableSQL()
        {
            return "CREATE TABLE StockMarket (" +
                   "Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE," +
                   "Name TEXT NOT NULL," +
                   "CreatedAt TEXT NOT NULL," +
                   "Deleted BOOLEAN NOT NULL," +
                   "ModifiedAt TEXT NOT NULL," +
                   "StockId INTEGER NOT NULL)";
        }

        private void PrepareCommandSelect(SQLiteCommand command, long id)
        {
            command.Prepare();
            command.Parameters.AddWithValue("@Id", id);
        }

        private StockMarket GetStockMarketFromReader(SQLiteDataReader reader)
        {
            return new StockMarket
            {
                Id = Convert.ToInt64(reader["Id"].ToString()),
                Name = reader["Name"].ToString(),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"].ToString()),
                Deleted = Convert.ToBoolean(reader["Deleted"].ToString()),
                ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"].ToString()),
                StockId = Convert.ToInt64(reader["StockId"].ToString())
            };
        }

        private ObservableCollection<StockMarket> GetCollection(IEnumerable<StockMarket> oldList)
        {
            var collection = new ObservableCollection<StockMarket>();
            foreach (var item in oldList)
                collection.Add(item);
            return collection;
        }

        private void PrepareCommandInsert(SQLiteCommand command, StockMarket stockMarket)
        {
            command.CommandText = "INSERT INTO StockMarket (Id, Name, CreatedAt, Deleted, ModifiedAt, StockId) " +
                                  "VALUES (@Id, @Name, @CreatedAt, @Deleted, @ModifiedAt, @StockId)";
            command.Prepare();
            AddParametersUpdateInsert(command, stockMarket);
        }

        private void AddParametersUpdateInsert(SQLiteCommand command, StockMarket stockMarket)
        {
            command.Parameters.AddWithValue("@Id", stockMarket.Id);
            command.Parameters.AddWithValue("@Name", stockMarket.Name);
            command.Parameters.AddWithValue("@CreatedAt", stockMarket.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@Deleted", stockMarket.Deleted);
            command.Parameters.AddWithValue("@ModifiedAt", stockMarket.ModifiedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@StockId", stockMarket.StockId);
        }

        private void PrepareCommandUpdate(SQLiteCommand command, StockMarket stockMarket)
        {
            command.CommandText =
                "UPDATE StockMarket SET Name = @Name, CreatedAt = @CreatedAt, Deleted = @Deleted, " +
                "ModifiedAt = @ModifiedAt, StockId = @StockId WHERE Id = @Id";
            command.Prepare();
            AddParametersUpdateInsert(command, stockMarket);
        }

        private void PrepareDeletCommand(SQLiteCommand command, StockMarket stockMarket)
        {
            command.CommandText = "DELETE FROM StockMarket WHERE Id = @Id";
            command.Prepare();
            command.Parameters.AddWithValue("@Id", stockMarket.Id);
        }

        private IQueryable<StockMarket> GetQueryable()
        {
            return Get().AsQueryable();
        }
    }
}