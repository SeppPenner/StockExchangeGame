using System;
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
    public class StockMarketController : IEntityController<StockMarket>
    {
        private readonly SQLiteConnection _connection;
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private ILanguage _currentLanguage;

        public StockMarketController(SQLiteConnection connection)
        {
            this._connection = connection;
        }

        public void SetCurrentLanguage(ILanguage language)
        {
            this._currentLanguage = language;
            this._log.Info(string.Format(this._currentLanguage.GetWord("LanguageSet"), "StockMarket", language.Identifier));
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
            this._log.Info(string.Format(this._currentLanguage.GetWord("TableCreated"), "StockMarket", result));
            this._connection.Close();
            return result;
        }

        public List<StockMarket> Get()
        {
            var list = new List<StockMarket>();
            var sql = "SELECT * FROM StockMarket";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var stockmarket = this.GetStockMarketFromReader(reader);
                        list.Add(stockmarket);
                    }
                }
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGet"), "StockMarket", string.Join("; ", list)));
            this._connection.Close();
            return list;
        }

        public StockMarket Get(long id)
        {
            StockMarket stockMarket = null;
            var sql = "SELECT * FROM StockMarket WHERE Id = @Id";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                this.PrepareCommandSelect(command, id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        stockMarket = this.GetStockMarketFromReader(reader);
                }
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetSingle"), "StockMarket", stockMarket));
            this._connection.Close();
            return stockMarket;
        }

        public ObservableCollection<StockMarket> Get<TValue>(Expression<Func<StockMarket, bool>> predicate = null,
            Expression<Func<StockMarket, TValue>> orderBy = null)
        {
            if (predicate == null && orderBy == null)
                return this.GetNoPredicateNoOrderBy();
            if (predicate != null && orderBy == null)
                return this.GetPredicateOnly(predicate);
            return predicate == null ? this.GetOrderByOnly(orderBy) : this.GetPredicateAndOrderBy(predicate, orderBy);
        }

        private ObservableCollection<StockMarket> GetNoPredicateNoOrderBy()
        {
            var result = this.Get().ToCollection();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "StockMarket", null, null,
                string.Join(";", result)));
            return result;
        }

        private ObservableCollection<StockMarket> GetPredicateOnly(Expression<Func<StockMarket, bool>> predicate = null)
        {
            var result = this.GetQueryable().Where(predicate).ToCollection();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "StockMarket", predicate,
                null, string.Join(";", result)));
            return result;
        }

        private ObservableCollection<StockMarket> GetOrderByOnly<TValue>(
            Expression<Func<StockMarket, TValue>> orderBy = null)
        {
            var result = this.GetQueryable().OrderBy(orderBy).ToCollection();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "StockMarket", null,
                orderBy, string.Join(";", result)));
            return result;
        }

        private ObservableCollection<StockMarket> GetPredicateAndOrderBy<TValue>(
            Expression<Func<StockMarket, bool>> predicate = null,
            Expression<Func<StockMarket, TValue>> orderBy = null)
        {
            var result = this.GetQueryable().Where(predicate).OrderBy(orderBy).ToCollection();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "StockMarket", predicate,
                orderBy, string.Join(";", result)));
            return result;
        }

        public StockMarket Get(Expression<Func<StockMarket, bool>> predicate)
        {
            var result = this.GetQueryable().Where(predicate).FirstOrDefault();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetSinglePredicate"), "StockMarket", predicate,
                string.Join(";", result)));
            return result;
        }

        public int Insert(StockMarket entity)
        {
            int result;
            this._connection.Open();
            using (var command = new SQLiteCommand(this._connection))
            {
                this.PrepareCommandInsert(command, entity);
                result = command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedInsert"), "StockMarket", entity, result));
            this._connection.Close();
            return result;
        }

        public int Update(StockMarket entity)
        {
            int result;
            this._connection.Open();
            using (var command = new SQLiteCommand(this._connection))
            {
                this.PrepareCommandUpdate(command, entity);
                result = command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedUpdate"), "StockMarket", entity, result));
            this._connection.Close();
            return result;
        }

        public int Delete(StockMarket entity)
        {
            int result;
            this._connection.Open();
            using (var command = new SQLiteCommand(this._connection))
            {
                this.PrepareDeleteCommand(command, entity);
                result = command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedDelete"), "StockMarket", entity, result));
            this._connection.Close();
            return result;
        }

        public int Count(Expression<Func<StockMarket, bool>> predicate = null)
        {
            return predicate == null ? this.CountNoPredicate() : this.CountPredicate(predicate);
        }

        private int CountNoPredicate()
        {
            var count = 0;
            const string sql = "SELECT COUNT(Id) FROM StockMarket";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())

                        count = Convert.ToInt32(reader[0].ToString());
                }
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedCount"), "StockMarket", null, count));
            this._connection.Close();
            return count;
        }

        private int CountPredicate(Expression<Func<StockMarket, bool>> predicate = null)
        {
            var count = this.GetQueryable().Where(predicate).Count();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedCount"), "StockMarket", predicate, count));
            return count;
        }

        private string GetCreateTableSQL()
        {
            return "CREATE TABLE IF NOT EXISTS StockMarket (" +
                   "Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE," +
                   "Name TEXT NOT NULL," +
                   "CreatedAt TEXT NOT NULL," +
                   "Deleted BOOLEAN NOT NULL," +
                   "ModifiedAt TEXT NOT NULL)";
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
                ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"].ToString())
            };
        }

        private void PrepareCommandInsert(SQLiteCommand command, StockMarket stockMarket)
        {
            command.CommandText = "INSERT INTO StockMarket (Id, Name, CreatedAt, Deleted, ModifiedAt) " +
                                  "VALUES (@Id, @Name, @CreatedAt, @Deleted, @ModifiedAt)";
            command.Prepare();
            this.AddParametersUpdateInsert(command, stockMarket);
        }

        private void AddParametersUpdateInsert(SQLiteCommand command, StockMarket stockMarket)
        {
            command.Parameters.AddWithValue("@Id", stockMarket.Id);
            command.Parameters.AddWithValue("@Name", stockMarket.Name);
            command.Parameters.AddWithValue("@CreatedAt", stockMarket.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@Deleted", stockMarket.Deleted);
            command.Parameters.AddWithValue("@ModifiedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void PrepareCommandUpdate(SQLiteCommand command, StockMarket stockMarket)
        {
            command.CommandText =
                "UPDATE StockMarket SET Name = @Name, CreatedAt = @CreatedAt, Deleted = @Deleted, " +
                "ModifiedAt = @ModifiedAt WHERE Id = @Id";
            command.Prepare();
            this.AddParametersUpdateInsert(command, stockMarket);
        }

        private void PrepareDeleteCommand(SQLiteCommand command, StockMarket stockMarket)
        {
            command.CommandText = "UPDATE StockMarket SET Deleted = true, ModifiedAt = @ModifiedAt WHERE Id = @Id";
            command.Prepare();
            command.Parameters.AddWithValue("@Id", stockMarket.Id);
            command.Parameters.AddWithValue("@ModifiedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private IQueryable<StockMarket> GetQueryable()
        {
            return this.Get().AsQueryable();
        }

        public void Truncate()
        {
            const string sql = "DELETE FROM StockMarket";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedTruncate"), "StockMarket"));
            this._connection.Close();
        }
    }
}