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
    public class StockHistoryController : IEntityController<StockHistory>
    {
        private readonly SQLiteConnection _connection;
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private ILanguage _currentLanguage;

        public StockHistoryController(SQLiteConnection connection)
        {
            this._connection = connection;
        }

        public void SetCurrentLanguage(ILanguage language)
        {
            this._currentLanguage = language;
            this._log.Info(string.Format(this._currentLanguage.GetWord("LanguageSet"), "StockHistory", language.Identifier));
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
            this._log.Info(string.Format(this._currentLanguage.GetWord("TableCreated"), "StockHistory", result));
            this._connection.Close();
            return result;
        }

        public List<StockHistory> Get()
        {
            var list = new List<StockHistory>();
            var sql = "SELECT * FROM StockHistory";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var stockhistory = this.GetStockHistoryFromReader(reader);
                        list.Add(stockhistory);
                    }
                }
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGet"), "StockHistory", string.Join("; ", list)));
            this._connection.Close();
            return list;
        }

        public StockHistory Get(long id)
        {
            StockHistory stockHistory = null;
            var sql = "SELECT * FROM StockHistory WHERE Id = @Id";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                this.PrepareCommandSelect(command, id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        stockHistory = this.GetStockHistoryFromReader(reader);
                }
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetSingle"), "StockHistory", stockHistory));
            this._connection.Close();
            return stockHistory;
        }

        public ObservableCollection<StockHistory> Get<TValue>(Expression<Func<StockHistory, bool>> predicate = null,
            Expression<Func<StockHistory, TValue>> orderBy = null)
        {
            if (predicate == null && orderBy == null)
                return this.GetNoPredicateNoOrderBy();
            if (predicate != null && orderBy == null)
                return this.GetPredicateOnly(predicate);
            return predicate == null ? this.GetOrderByOnly(orderBy) : this.GetPredicateAndOrderBy(predicate, orderBy);
        }

        private ObservableCollection<StockHistory> GetNoPredicateNoOrderBy()
        {
            var result = this.Get().ToCollection();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "StockHistory", null, null,
                string.Join(";", result)));
            return result;
        }

        private ObservableCollection<StockHistory> GetPredicateOnly(
            Expression<Func<StockHistory, bool>> predicate = null)
        {
            var result = this.GetQueryable().Where(predicate).ToCollection();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "StockHistory", predicate,
                null, string.Join(";", result)));
            return result;
        }

        private ObservableCollection<StockHistory> GetOrderByOnly<TValue>(
            Expression<Func<StockHistory, TValue>> orderBy = null)
        {
            var result = this.GetQueryable().OrderBy(orderBy).ToCollection();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "StockHistory", null,
                orderBy, string.Join(";", result)));
            return result;
        }

        private ObservableCollection<StockHistory> GetPredicateAndOrderBy<TValue>(
            Expression<Func<StockHistory, bool>> predicate = null,
            Expression<Func<StockHistory, TValue>> orderBy = null)
        {
            var result = this.GetQueryable().Where(predicate).OrderBy(orderBy).ToCollection();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "StockHistory", predicate,
                orderBy, string.Join(";", result)));
            return result;
        }

        public StockHistory Get(Expression<Func<StockHistory, bool>> predicate)
        {
            var result = this.GetQueryable().Where(predicate).FirstOrDefault();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetSinglePredicate"), "StockHistory", predicate,
                string.Join(";", result)));
            return result;
        }

        public int Insert(StockHistory entity)
        {
            int result;
            this._connection.Open();
            using (var command = new SQLiteCommand(this._connection))
            {
                this.PrepareCommandInsert(command, entity);
                result = command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedInsert"), "StockHistory", entity, result));
            this._connection.Close();
            return result;
        }

        public int Update(StockHistory entity)
        {
            int result;
            this._connection.Open();
            using (var command = new SQLiteCommand(this._connection))
            {
                this.PrepareCommandUpdate(command, entity);
                result = command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedUpdate"), "StockHistory", entity, result));
            this._connection.Close();
            return result;
        }

        public int Delete(StockHistory entity)
        {
            int result;
            this._connection.Open();
            using (var command = new SQLiteCommand(this._connection))
            {
                this.PrepareDeleteCommand(command, entity);
                result = command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedDelete"), "StockHistory", entity, result));
            this._connection.Close();
            return result;
        }

        public int Count(Expression<Func<StockHistory, bool>> predicate = null)
        {
            return predicate == null ? this.CountNoPredicate() : this.CountPredicate(predicate);
        }

        private int CountNoPredicate()
        {
            var count = 0;
            const string sql = "SELECT COUNT(Id) FROM StockHistory";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())

                        count = Convert.ToInt32(reader[0].ToString());
                }
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedCount"), "StockHistory", null, count));
            this._connection.Close();
            return count;
        }

        private int CountPredicate(Expression<Func<StockHistory, bool>> predicate = null)
        {
            var count = this.GetQueryable().Where(predicate).Count();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedCount"), "StockHistory", predicate, count));
            return count;
        }

        private string GetCreateTableSQL()
        {
            return "CREATE TABLE IF NOT EXISTS StockHistory (" +
                   "Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE," +
                   "PriceDate TEXT NOT NULL," +
                   "CreatedAt TEXT NOT NULL," +
                   "PricePerStock DOUBLE NOT NULL," +
                   "Deleted BOOLEAN NOT NULL," +
                   "StockId INTEGER NOT NULL," +
                   "ModifiedAt TEXT NOT NULL)";
        }

        private void PrepareCommandSelect(SQLiteCommand command, long id)
        {
            command.Prepare();
            command.Parameters.AddWithValue("@Id", id);
        }

        private StockHistory GetStockHistoryFromReader(SQLiteDataReader reader)
        {
            return new StockHistory
            {
                Id = Convert.ToInt64(reader["Id"].ToString()),
                PriceDate = Convert.ToDateTime(reader["PriceDate"].ToString()),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"].ToString()),
                PricePerStock = Convert.ToDouble(reader["PricePerStock"].ToString()),
                Deleted = Convert.ToBoolean(reader["Deleted"].ToString()),
                StockId = Convert.ToInt64(reader["StockId"].ToString()),
                ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"].ToString())
            };
        }

        private void PrepareCommandInsert(SQLiteCommand command, StockHistory stockHistory)
        {
            command.CommandText =
                "INSERT INTO StockHistory (Id, PriceDate, CreatedAt, PricePerStock, Deleted, StockId, " +
                "ModifiedAt) VALUES (@Id, @PriceDate, @CreatedAt, @PricePerStock, @Deleted, " +
                "@StockId, @ModifiedAt)";
            command.Prepare();
            this.AddParametersUpdateInsert(command, stockHistory);
        }

        private void AddParametersUpdateInsert(SQLiteCommand command, StockHistory stockHistory)
        {
            command.Parameters.AddWithValue("@Id", stockHistory.Id);
            command.Parameters.AddWithValue("@PriceDate", stockHistory.PriceDate.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@CreatedAt", stockHistory.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@PricePerStock", stockHistory.PricePerStock);
            command.Parameters.AddWithValue("@Deleted", stockHistory.Deleted);
            command.Parameters.AddWithValue("@StockId", stockHistory.StockId);
            command.Parameters.AddWithValue("@ModifiedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void PrepareCommandUpdate(SQLiteCommand command, StockHistory stockHistory)
        {
            command.CommandText =
                "UPDATE StockHistory SET PriceDate = @PriceDate, CreatedAt = @CreatedAt, PricePerStock = @PricePerStock," +
                " Deleted = @Deleted, StockId = @StockId, ModifiedAt = @ModifiedAt WHERE Id = @Id";
            command.Prepare();
            this.AddParametersUpdateInsert(command, stockHistory);
        }

        private void PrepareDeleteCommand(SQLiteCommand command, StockHistory stockHistory)
        {
            command.CommandText = "UPDATE StockHistory SET Deleted = true, ModifiedAt = @ModifiedAt WHERE Id = @Id";
            command.Prepare();
            command.Parameters.AddWithValue("@Id", stockHistory.Id);
            command.Parameters.AddWithValue("@ModifiedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private IQueryable<StockHistory> GetQueryable()
        {
            return this.Get().AsQueryable();
        }

        public void Truncate()
        {
            const string sql = "DELETE FROM StockHistory";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedTruncate"), "StockHistory"));
            this._connection.Close();
        }
    }
}