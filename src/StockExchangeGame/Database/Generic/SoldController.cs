﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Languages.Interfaces;
using StockExchangeGame.Database.Extensions;
using StockExchangeGame.Database.Models;

namespace StockExchangeGame.Database.Generic
{
    public class SoldController : IEntityController<Sold>
    {
        private readonly SQLiteConnection _connection;
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private ILanguage _currentLanguage;

        public SoldController(SQLiteConnection connection)
        {
            this._connection = connection;
        }

        public void SetCurrentLanguage(ILanguage language)
        {
            this._currentLanguage = language;
            this._log.Info(string.Format(this._currentLanguage.GetWord("LanguageSet"), "Sold", language.Identifier));
        }

        public ILanguage GetCurrentLanguage()
        {
            return this._currentLanguage;
        }

        public int CreateTable()
        {
            int result;
            var sql = this.GetCreateTableSQL();
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                result = command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("TableCreated"), "Sold", result));
            this._connection.Close();
            return result;
        }

        public List<Sold> Get()
        {
            var list = new List<Sold>();
            var sql = "SELECT * FROM Sold";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var sold = this.GetSoldFromReader(reader);
                        list.Add(sold);
                    }
                }
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGet"), "Sold", string.Join("; ", list)));
            this._connection.Close();
            return list;
        }

        public Sold Get(long id)
        {
            Sold sold = null;
            var sql = "SELECT * FROM Sold WHERE Id = @Id";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                this.PrepareCommandSelect(command, id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        sold = this.GetSoldFromReader(reader);
                }
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetSingle"), "Sold", sold));
            this._connection.Close();
            return sold;
        }

        public ObservableCollection<Sold> Get<TValue>(Expression<Func<Sold, bool>> predicate = null,
            Expression<Func<Sold, TValue>> orderBy = null)
        {
            if (predicate == null && orderBy == null)
                return this.GetNoPredicateNoOrderBy();
            if (predicate != null && orderBy == null)
                return this.GetPredicateOnly(predicate);
            return predicate == null ? this.GetOrderByOnly(orderBy) : this.GetPredicateAndOrderBy(predicate, orderBy);
        }

        private ObservableCollection<Sold> GetNoPredicateNoOrderBy()
        {
            var result = this.Get().ToCollection();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "Sold", null, null,
                string.Join(";", result)));
            return result;
        }

        private ObservableCollection<Sold> GetPredicateOnly(Expression<Func<Sold, bool>> predicate = null)
        {
            var result = this.GetQueryable().Where(predicate).ToCollection();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "Sold", predicate, null,
                string.Join(";", result)));
            return result;
        }

        private ObservableCollection<Sold> GetOrderByOnly<TValue>(Expression<Func<Sold, TValue>> orderBy = null)
        {
            var result = this.GetQueryable().OrderBy(orderBy).ToCollection();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "Sold", null, orderBy,
                string.Join(";", result)));
            return result;
        }

        private ObservableCollection<Sold> GetPredicateAndOrderBy<TValue>(Expression<Func<Sold, bool>> predicate = null,
            Expression<Func<Sold, TValue>> orderBy = null)
        {
            var result = this.GetQueryable().Where(predicate).OrderBy(orderBy).ToCollection();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "Sold", predicate, orderBy,
                string.Join(";", result)));
            return result;
        }

        public Sold Get(Expression<Func<Sold, bool>> predicate)
        {
            var result = this.GetQueryable().Where(predicate).FirstOrDefault();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetSinglePredicate"), "Sold", predicate,
                string.Join(";", result)));
            return result;
        }

        public int Insert(Sold entity)
        {
            int result;
            this._connection.Open();
            using (var command = new SQLiteCommand(this._connection))
            {
                this.PrepareCommandInsert(command, entity);
                result = command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedInsert"), "Sold", entity, result));
            this._connection.Close();
            return result;
        }

        public int Update(Sold entity)
        {
            int result;
            this._connection.Open();
            using (var command = new SQLiteCommand(this._connection))
            {
                this.PrepareCommandUpdate(command, entity);
                result = command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedUpdate"), "Sold", entity, result));
            this._connection.Close();
            return result;
        }

        public int Delete(Sold entity)
        {
            int result;
            this._connection.Open();
            using (var command = new SQLiteCommand(this._connection))
            {
                this.PrepareDeleteCommand(command, entity);
                result = command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedDelete"), "Sold", entity, result));
            this._connection.Close();
            return result;
        }

        public int Count(Expression<Func<Sold, bool>> predicate = null)
        {
            return predicate == null ? this.CountNoPredicate() : this.CountPredicate(predicate);
        }

        private int CountNoPredicate()
        {
            var count = 0;
            const string sql = "SELECT COUNT(Id) FROM Sold";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())

                        count = Convert.ToInt32(reader[0].ToString());
                }
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedCount"), "Sold", null, count));
            this._connection.Close();
            return count;
        }

        private int CountPredicate(Expression<Func<Sold, bool>> predicate = null)
        {
            var count = this.GetQueryable().Where(predicate).Count();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedCount"), "Sold", predicate, count));
            return count;
        }

        private string GetCreateTableSQL()
        {
            return "CREATE TABLE IF NOT EXISTS Sold (" +
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

        private void PrepareCommandInsert(SQLiteCommand command, Sold sold)
        {
            command.CommandText = "INSERT INTO Sold (Id, Amount, CreatedAt, DateSold, Deleted, MerchantId, " +
                                  "ModifiedAt, StockId, ValuePerStockInEuro) VALUES (@Id, @Amount, @CreatedAt, " +
                                  "@DateSold, @Deleted, @MerchantId, @ModifiedAt, @StockId, @ValuePerStockInEuro)";
            command.Prepare();
            this.AddParametersUpdateInsert(command, sold);
        }

        private void AddParametersUpdateInsert(SQLiteCommand command, Sold sold)
        {
            command.Parameters.AddWithValue("@Id", sold.Id);
            command.Parameters.AddWithValue("@Amount", sold.Amount);
            command.Parameters.AddWithValue("@CreatedAt", sold.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@DateSold", sold.DateSold.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@Deleted", sold.Deleted);
            command.Parameters.AddWithValue("@MerchantId", sold.MerchantId);
            command.Parameters.AddWithValue("@ModifiedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
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
            this.AddParametersUpdateInsert(command, sold);
        }

        private void PrepareDeleteCommand(SQLiteCommand command, Sold sold)
        {
            command.CommandText = "UPDATE Sold SET Deleted = true, ModifiedAt = @ModifiedAt WHERE Id = @Id";
            command.Prepare();
            command.Parameters.AddWithValue("@Id", sold.Id);
            command.Parameters.AddWithValue("@ModifiedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private IQueryable<Sold> GetQueryable()
        {
            return this.Get().AsQueryable();
        }

        public void Truncate()
        {
            const string sql = "DELETE FROM Sold";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedTruncate"), "Sold"));
            this._connection.Close();
        }
    }
}