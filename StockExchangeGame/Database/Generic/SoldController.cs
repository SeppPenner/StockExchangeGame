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
    public class SoldController : IEntityController<Sold>
    {
        private readonly SQLiteConnection _connection;

        public SoldController(string connectionString)
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

        public List<Sold> Get()
        {
            var list = new List<Sold>();
            var sql = "SELECT * FROM Sold";
            _connection.Open();
            using (var command = new SQLiteCommand(sql, _connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var sold = GetSoldFromReader(reader);
                        list.Add(sold);
                    }
                }
            }
            _connection.Close();
            return list;
        }

        public Sold Get(long id)
        {
            var sql = "SELECT * FROM Sold WHERE Id = @Id";
            _connection.Open();
            using (var command = new SQLiteCommand(sql, _connection))
            {
                PrepareCommandSelect(command, id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        return GetSoldFromReader(reader);
                }
            }
            _connection.Close();
            return null;
        }

        public ObservableCollection<Sold> Get<TValue>(Expression<Func<Sold, bool>> predicate = null,
            Expression<Func<Sold, TValue>> orderBy = null)
        {
            if (predicate == null && orderBy == null)
                return GetCollection(Get());
            if (predicate != null && orderBy == null)
                return GetCollection(GetQueryable().Where(predicate).ToList());
            return GetCollection(predicate == null
                ? GetQueryable().OrderBy(orderBy).ToList()
                : GetQueryable().Where(predicate).OrderBy(orderBy).ToList());
        }

        public Sold Get(Expression<Func<Sold, bool>> predicate)
        {
            return GetQueryable().Where(predicate).FirstOrDefault();
        }

        public int Insert(Sold entity)
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

        public int Update(Sold entity)
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

        public int Delete(Sold entity)
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

        public int Count(Expression<Func<Sold, bool>> predicate = null)
        {
            return predicate == null ? Get().Count : GetQueryable().Where(predicate).Count();
        }

        private string GetCreateTableSQL()
        {
            return "CREATE TABLE Sold (" +
                   "Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE," +
                   "Amount INTEGER NOT NULL," +
                   "CreatedAt TEXT NOT NULL," +
                   "DateSold TEXT NOT NULL," +
                   "Deleted BOOLEAN NOT NULL," +
                   "MerchantId INTEGER NOT NULL," +
                   "ModifiedAt TEXT NOT NULL," +
                   "StockId INTEGER NOT NULL," +
                   "ValuePerStockInEuro DOUBLE NOT NULL)";
        }

        private void PrepareCommandSelect(SQLiteCommand command, long id)
        {
            command.Prepare();
            command.Parameters.AddWithValue("@Id", id);
        }

        private Sold GetSoldFromReader(SQLiteDataReader reader)
        {
            return new Sold
            {
                Id = Convert.ToInt64(reader["Id"].ToString()),
                Amount = Convert.ToInt64(reader["Amount"].ToString()),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"].ToString()),
                DateSold = Convert.ToDateTime(reader["DateSold"].ToString()),
                Deleted = Convert.ToBoolean(reader["Deleted"].ToString()),
                MerchantId = Convert.ToInt64(reader["MerchantId"].ToString()),
                ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"].ToString()),
                StockId = Convert.ToInt64(reader["StockId"].ToString()),
                ValuePerStockInEuro = Convert.ToDouble(reader["ValuePerStockInEuro"].ToString())
            };
        }

        private ObservableCollection<Sold> GetCollection(IEnumerable<Sold> oldList)
        {
            var collection = new ObservableCollection<Sold>();
            foreach (var item in oldList)
                collection.Add(item);
            return collection;
        }

        private void PrepareCommandInsert(SQLiteCommand command, Sold sold)
        {
            command.CommandText = "INSERT INTO Sold (Id, Amount, CreatedAt, DateSold, Deleted, MerchantId, " +
                                  "ModifiedAt, StockId, ValuePerStockInEuro) VALUES (@Id, @Amount, @CreatedAt, " +
                                  "@DateSold, @Deleted, @MerchantId, @ModifiedAt, @StockId, @ValuePerStockInEuro)";
            command.Prepare();
            AddParametersInsert(command, sold);
        }

        private void AddParametersInsert(SQLiteCommand command, Sold sold)
        {
            command.Parameters.AddWithValue("@Id", sold.Id);
            command.Parameters.AddWithValue("@Amount", sold.Amount);
            command.Parameters.AddWithValue("@CreatedAt", sold.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@DateSold", sold.DateSold.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@Deleted", sold.Deleted);
            command.Parameters.AddWithValue("@MerchantId", sold.MerchantId);
            command.Parameters.AddWithValue("@ModifiedAt", sold.ModifiedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@StockId", sold.StockId);
            command.Parameters.AddWithValue("@ValuePerStockInEuro", sold.ValuePerStockInEuro);
        }

        private void PrepareCommandUpdate(SQLiteCommand command, Sold sold)
        {
            command.CommandText =
                "UPDATE Sold SET Amount = @Amount, CreatedAt = @CreatedAt, DateSold = @DateSold," +
                " Deleted = @Deleted, MerchantId = @MerchantId, ModifiedAt = @ModifiedAt, StockId = @StockId, " +
                "ValuePerStockInEuro = @ValuePerStockInEuro WHERE Id = @Id";
            command.Prepare();
            AddParametersUpdate(command, sold);
        }

        private void AddParametersUpdate(SQLiteCommand command, Sold sold)
        {
            command.Parameters.AddWithValue("@Id", sold.Id);
            command.Parameters.AddWithValue("@Amount", sold.Amount);
            command.Parameters.AddWithValue("@CreatedAt", sold.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@DateSold", sold.DateSold.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@Deleted", sold.Deleted);
            command.Parameters.AddWithValue("@MerchantId", sold.MerchantId);
            command.Parameters.AddWithValue("@ModifiedAt", sold.ModifiedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@StockId", sold.StockId);
            command.Parameters.AddWithValue("@ValuePerStockInEuro", sold.ValuePerStockInEuro);
        }

        private void PrepareDeletCommand(SQLiteCommand command, Sold sold)
        {
            command.CommandText = "DELETE FROM Sold WHERE Id = @Id";
            command.Prepare();
            command.Parameters.AddWithValue("@Id", sold.Id);
        }

        private IQueryable<Sold> GetQueryable()
        {
            return Get().AsQueryable();
        }
    }
}