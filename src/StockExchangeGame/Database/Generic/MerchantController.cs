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
    public class MerchantController : IEntityController<Merchant>
    {
        private readonly SQLiteConnection _connection;
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private ILanguage _currentLanguage;

        public MerchantController(SQLiteConnection connection)
        {
            this._connection = connection;
        }

        public void SetCurrentLanguage(ILanguage language)
        {
            this._currentLanguage = language;
            this._log.Info(string.Format(this._currentLanguage.GetWord("LanguageSet"), "Merchant", language.Identifier));
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
            this._log.Info(string.Format(this._currentLanguage.GetWord("TableCreated"), "Merchant", result));
            this._connection.Close();
            return result;
        }

        public List<Merchant> Get()
        {
            var list = new List<Merchant>();
            var sql = "SELECT * FROM Merchant";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var merchant = this.GetMerchantFromReader(reader);
                        list.Add(merchant);
                    }
                }
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGet"), "Merchant", string.Join("; ", list)));
            this._connection.Close();
            return list;
        }

        public Merchant Get(long id)
        {
            Merchant merchant = null;
            var sql = "SELECT * FROM Merchant WHERE Id = @Id";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                this.PrepareCommandSelect(command, id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        merchant = this.GetMerchantFromReader(reader);
                }
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetSingle"), "Merchant", merchant));
            this._connection.Close();
            return merchant;
        }

        public ObservableCollection<Merchant> Get<TValue>(Expression<Func<Merchant, bool>> predicate = null,
            Expression<Func<Merchant, TValue>> orderBy = null)
        {
            if (predicate == null && orderBy == null)
                return this.GetNoPredicateNoOrderBy();
            if (predicate != null && orderBy == null)
                return this.GetPredicateOnly(predicate);
            return predicate == null ? this.GetOrderByOnly(orderBy) : this.GetPredicateAndOrderBy(predicate, orderBy);
        }

        private ObservableCollection<Merchant> GetNoPredicateNoOrderBy()
        {
            var result = this.Get().ToCollection();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "Merchant", null, null,
                string.Join(";", result)));
            return result;
        }

        private ObservableCollection<Merchant> GetPredicateOnly(Expression<Func<Merchant, bool>> predicate = null)
        {
            var result = this.GetQueryable().Where(predicate).ToCollection();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "Merchant", predicate,
                null, string.Join(";", result)));
            return result;
        }

        private ObservableCollection<Merchant> GetOrderByOnly<TValue>(Expression<Func<Merchant, TValue>> orderBy = null)
        {
            var result = this.GetQueryable().OrderBy(orderBy).ToCollection();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "Merchant", null, orderBy,
                string.Join(";", result)));
            return result;
        }

        private ObservableCollection<Merchant> GetPredicateAndOrderBy<TValue>(
            Expression<Func<Merchant, bool>> predicate = null,
            Expression<Func<Merchant, TValue>> orderBy = null)
        {
            var result = this.GetQueryable().Where(predicate).OrderBy(orderBy).ToCollection();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "Merchant", predicate,
                orderBy, string.Join(";", result)));
            return result;
        }

        public Merchant Get(Expression<Func<Merchant, bool>> predicate)
        {
            var result = this.GetQueryable().Where(predicate).FirstOrDefault();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetSinglePredicate"), "Merchant", predicate,
                string.Join(";", result)));
            return result;
        }

        public int Insert(Merchant entity)
        {
            int result;
            this._connection.Open();
            using (var command = new SQLiteCommand(this._connection))
            {
                this.PrepareCommandInsert(command, entity);
                result = command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedInsert"), "Merchant", entity, result));
            this._connection.Close();
            return result;
        }

        public int Update(Merchant entity)
        {
            int result;
            this._connection.Open();
            using (var command = new SQLiteCommand(this._connection))
            {
                this.PrepareCommandUpdate(command, entity);
                result = command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedUpdate"), "Merchant", entity, result));
            this._connection.Close();
            return result;
        }

        public int Delete(Merchant entity)
        {
            int result;
            this._connection.Open();
            using (var command = new SQLiteCommand(this._connection))
            {
                this.PrepareDeleteCommand(command, entity);
                result = command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedDelete"), "Merchant", entity, result));
            this._connection.Close();
            return result;
        }

        public int Count(Expression<Func<Merchant, bool>> predicate = null)
        {
            return predicate == null ? this.CountNoPredicate() : this.CountPredicate(predicate);
        }

        private int CountNoPredicate()
        {
            var count = 0;
            const string sql = "SELECT COUNT(Id) FROM Merchant";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())

                        count = Convert.ToInt32(reader[0].ToString());
                }
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedCount"), "Merchant", null, count));
            this._connection.Close();
            return count;
        }

        private int CountPredicate(Expression<Func<Merchant, bool>> predicate = null)
        {
            var count = this.GetQueryable().Where(predicate).Count();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedCount"), "Merchant", predicate, count));
            return count;
        }

        private string GetCreateTableSQL()
        {
            return "CREATE TABLE IF NOT EXISTS Merchant (" +
                   "Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE," +
                   "Name TEXT NOT NULL," +
                   "CreatedAt TEXT NOT NULL," +
                   "Deleted BOOLEAN NOT NULL," +
                   "ModifiedAt TEXT NOT NULL," +
                   "LiquidFundsInEuro DOUBLE NOT NULL)";
        }

        private void PrepareCommandSelect(SQLiteCommand command, long id)
        {
            command.Prepare();
            command.Parameters.AddWithValue("@Id", id);
        }

        private Merchant GetMerchantFromReader(SQLiteDataReader reader)
        {
            return new Merchant
            {
                Id = Convert.ToInt64(reader["Id"].ToString()),
                Name = reader["Name"].ToString(),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"].ToString()),
                Deleted = Convert.ToBoolean(reader["Deleted"].ToString()),
                ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"].ToString())
            };
        }

        private void PrepareCommandInsert(SQLiteCommand command, Merchant merchant)
        {
            command.CommandText =
                "INSERT INTO Merchant (Id, Name, CreatedAt, Deleted, ModifiedAt, LiquidFundsInEuro) " +
                "VALUES (@Id, @Name, @CreatedAt, @Deleted, @ModifiedAt, @LiquidFundsInEuro)";
            command.Prepare();
            this.AddParametersUpdateInsert(command, merchant);
        }

        private void AddParametersUpdateInsert(SQLiteCommand command, Merchant merchant)
        {
            command.Parameters.AddWithValue("@Id", merchant.Id);
            command.Parameters.AddWithValue("@Name", merchant.Name);
            command.Parameters.AddWithValue("@CreatedAt", merchant.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@Deleted", merchant.Deleted);
            command.Parameters.AddWithValue("@ModifiedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@LiquidFundsInEuro", merchant.LiquidFundsInEuro);
        }

        private void PrepareCommandUpdate(SQLiteCommand command, Merchant merchant)
        {
            command.CommandText =
                "UPDATE Merchant SET Name = @Name, CreatedAt = @CreatedAt, Deleted = @Deleted, " +
                "ModifiedAt = @ModifiedAt, LiquidFundsInEuro = @LiquidFundsInEuro WHERE Id = @Id";
            command.Prepare();
            this.AddParametersUpdateInsert(command, merchant);
        }

        private void PrepareDeleteCommand(SQLiteCommand command, Merchant merchant)
        {
            command.CommandText = "UPDATE Merchant SET Deleted = true, ModifiedAt = @ModifiedAt WHERE Id = @Id";
            command.Prepare();
            command.Parameters.AddWithValue("@Id", merchant.Id);
            command.Parameters.AddWithValue("@ModifiedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private IQueryable<Merchant> GetQueryable()
        {
            return this.Get().AsQueryable();
        }

        public void Truncate()
        {
            const string sql = "DELETE FROM Merchant";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedTruncate"), "Merchant"));
            this._connection.Close();
        }
    }
}