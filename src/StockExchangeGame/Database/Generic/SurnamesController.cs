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
    public class SurnamesController : IEntityController<Surnames>
    {
        private readonly SQLiteConnection _connection;
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private ILanguage _currentLanguage;

        public SurnamesController(SQLiteConnection connection)
        {
            this._connection = connection;
        }

        public void SetCurrentLanguage(ILanguage language)
        {
            this._currentLanguage = language;
            this._log.Info(string.Format(this._currentLanguage.GetWord("LanguageSet"), "Surnames", language.Identifier));
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
            this._log.Info(string.Format(this._currentLanguage.GetWord("TableCreated"), "Surnames", result));
            this._connection.Close();
            return result;
        }

        public List<Surnames> Get()
        {
            var list = new List<Surnames>();
            var sql = "SELECT * FROM Surnames";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var surnames = this.GetSurnamesFromReader(reader);
                        list.Add(surnames);
                    }
                }
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGet"), "Surnames", string.Join("; ", list)));
            this._connection.Close();
            return list;
        }

        public Surnames Get(long id)
        {
            Surnames surname = null;
            var sql = "SELECT * FROM Surnames WHERE Id = @Id";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                this.PrepareCommandSelect(command, id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        surname = this.GetSurnamesFromReader(reader);
                }
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetSingle"), "Surnames", surname));
            this._connection.Close();
            return surname;
        }

        public ObservableCollection<Surnames> Get<TValue>(Expression<Func<Surnames, bool>> predicate = null,
            Expression<Func<Surnames, TValue>> orderBy = null)
        {
            if (predicate == null && orderBy == null)
                return this.GetNoPredicateNoOrderBy();
            if (predicate != null && orderBy == null)
                return this.GetPredicateOnly(predicate);
            return predicate == null ? this.GetOrderByOnly(orderBy) : this.GetPredicateAndOrderBy(predicate, orderBy);
        }

        private ObservableCollection<Surnames> GetNoPredicateNoOrderBy()
        {
            var result = this.Get().ToCollection();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "Surnames", null, null,
                string.Join(";", result)));
            return result;
        }

        private ObservableCollection<Surnames> GetPredicateOnly(Expression<Func<Surnames, bool>> predicate = null)
        {
            var result = this.GetQueryable().Where(predicate).ToCollection();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "Surnames", predicate,
                null, string.Join(";", result)));
            return result;
        }

        private ObservableCollection<Surnames> GetOrderByOnly<TValue>(Expression<Func<Surnames, TValue>> orderBy = null)
        {
            var result = this.GetQueryable().OrderBy(orderBy).ToCollection();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "Surnames", null, orderBy,
                string.Join(";", result)));
            return result;
        }

        private ObservableCollection<Surnames> GetPredicateAndOrderBy<TValue>(
            Expression<Func<Surnames, bool>> predicate = null,
            Expression<Func<Surnames, TValue>> orderBy = null)
        {
            var result = this.GetQueryable().Where(predicate).OrderBy(orderBy).ToCollection();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "Surnames", predicate,
                orderBy, string.Join(";", result)));
            return result;
        }

        public Surnames Get(Expression<Func<Surnames, bool>> predicate)
        {
            var result = this.GetQueryable().Where(predicate).FirstOrDefault();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetSinglePredicate"), "Surnames", predicate,
                string.Join(";", result)));
            return result;
        }

        public int Insert(Surnames entity)
        {
            int result;
            this._connection.Open();
            using (var command = new SQLiteCommand(this._connection))
            {
                this.PrepareCommandInsert(command, entity);
                result = command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedInsert"), "Surnames", entity, result));
            this._connection.Close();
            return result;
        }

        public int Update(Surnames entity)
        {
            int result;
            this._connection.Open();
            using (var command = new SQLiteCommand(this._connection))
            {
                this.PrepareCommandUpdate(command, entity);
                result = command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedUpdate"), "Surnames", entity, result));
            this._connection.Close();
            return result;
        }

        public int Delete(Surnames entity)
        {
            int result;
            this._connection.Open();
            using (var command = new SQLiteCommand(this._connection))
            {
                this.PrepareDeleteCommand(command, entity);
                result = command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedDelete"), "Surnames", entity, result));
            this._connection.Close();
            return result;
        }

        public int Count(Expression<Func<Surnames, bool>> predicate = null)
        {
            return predicate == null ? this.CountNoPredicate() : this.CountPredicate(predicate);
        }

        private int CountNoPredicate()
        {
            var count = 0;
            const string sql = "SELECT COUNT(Id) FROM Surnames";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())

                        count = Convert.ToInt32(reader[0].ToString());
                }
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedCount"), "Surnames", null, count));
            this._connection.Close();
            return count;
        }

        private int CountPredicate(Expression<Func<Surnames, bool>> predicate = null)
        {
            var count = this.GetQueryable().Where(predicate).Count();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedCount"), "Surnames", predicate, count));
            return count;
        }

        private string GetCreateTableSQL()
        {
            return "CREATE TABLE IF NOT EXISTS Surnames (" +
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

        private Surnames GetSurnamesFromReader(SQLiteDataReader reader)
        {
            return new Surnames
            {
                Id = Convert.ToInt64(reader["Id"].ToString()),
                Name = reader["Name"].ToString(),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"].ToString()),
                Deleted = Convert.ToBoolean(reader["Deleted"].ToString()),
                ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"].ToString())
            };
        }

        private void PrepareCommandInsert(SQLiteCommand command, Surnames surnames)
        {
            command.CommandText = "INSERT INTO Surnames (Id, Name, CreatedAt, Deleted, ModifiedAt) " +
                                  "VALUES (@Id, @Name, @CreatedAt, @Deleted, @ModifiedAt)";
            command.Prepare();
            this.AddParametersUpdateInsert(command, surnames);
        }

        private void AddParametersUpdateInsert(SQLiteCommand command, Surnames surnames)
        {
            command.Parameters.AddWithValue("@Id", surnames.Id);
            command.Parameters.AddWithValue("@Name", surnames.Name);
            command.Parameters.AddWithValue("@CreatedAt", surnames.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@Deleted", surnames.Deleted);
            command.Parameters.AddWithValue("@ModifiedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void PrepareCommandUpdate(SQLiteCommand command, Surnames surnames)
        {
            command.CommandText =
                "UPDATE Surnames SET Name = @Name, CreatedAt = @CreatedAt, Deleted = @Deleted, " +
                "ModifiedAt = @ModifiedAt WHERE Id = @Id";
            command.Prepare();
            this.AddParametersUpdateInsert(command, surnames);
        }

        private void PrepareDeleteCommand(SQLiteCommand command, Surnames surnames)
        {
            command.CommandText = "UPDATE Surnames SET Deleted = true, ModifiedAt = @ModifiedAt WHERE Id = @Id";
            command.Prepare();
            command.Parameters.AddWithValue("@Id", surnames.Id);
            command.Parameters.AddWithValue("@ModifiedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private IQueryable<Surnames> GetQueryable()
        {
            return this.Get().AsQueryable();
        }

        public void Truncate()
        {
            const string sql = "DELETE FROM Surnames";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedTruncate"), "Surnames"));
            this._connection.Close();
        }
    }
}