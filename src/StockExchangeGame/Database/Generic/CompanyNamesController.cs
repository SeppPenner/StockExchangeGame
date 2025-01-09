namespace StockExchangeGame.Database.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.SQLite;
    using System.Linq;
    using System.Linq.Expressions;

    using Languages.Interfaces;

    using Serilog;

    using StockExchangeGame.Database.Extensions;
    using StockExchangeGame.Database.Models;

    public class CompanyNamesController : IEntityController<CompanyNames>
    {
        private readonly SQLiteConnection _connection;

        private readonly ILogger logger;
        private ILanguage _currentLanguage;

        public CompanyNamesController(ILogger logger, SQLiteConnection connection)
        {
            this.logger = logger;
            this._connection = connection;
        }

        public void SetCurrentLanguage(ILanguage language)
        {
            this._currentLanguage = language;
            this.logger.Information(string.Format(this._currentLanguage.GetWord("LanguageSet"), "CompanyNames", language.Identifier));
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
            this.logger.Information(string.Format(this._currentLanguage.GetWord("TableCreated"), "CompanyNames", result));
            this._connection.Close();
            return result;
        }

        public List<CompanyNames> Get()
        {
            var list = new List<CompanyNames>();
            var sql = "SELECT * FROM CompanyNames";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var companyNames = this.GetCompanyNamesFromReader(reader);
                        list.Add(companyNames);
                    }
                }
            }
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedGet"), "CompanyNames", string.Join("; ", list)));
            this._connection.Close();
            return list;
        }

        public CompanyNames Get(long id)
        {
            CompanyNames companyName = null;
            var sql = "SELECT * FROM CompanyNames WHERE Id = @Id";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                this.PrepareCommandSelect(command, id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        companyName = this.GetCompanyNamesFromReader(reader);
                }
            }
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedGetSingle"), "CompanyNames", companyName));
            this._connection.Close();
            return companyName;
        }

        public ObservableCollection<CompanyNames> Get<TValue>(Expression<Func<CompanyNames, bool>> predicate = null,
            Expression<Func<CompanyNames, TValue>> orderBy = null)
        {
            if (predicate == null && orderBy == null)
                return this.GetNoPredicateNoOrderBy();
            if (predicate != null && orderBy == null)
                return this.GetPredicateOnly(predicate);
            return predicate == null ? this.GetOrderByOnly(orderBy) : this.GetPredicateAndOrderBy(predicate, orderBy);
        }

        private ObservableCollection<CompanyNames> GetNoPredicateNoOrderBy()
        {
            var result = this.Get().ToCollection();
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "CompanyNames", null, null,
                string.Join(";", result)));
            return result;
        }

        private ObservableCollection<CompanyNames> GetPredicateOnly(
            Expression<Func<CompanyNames, bool>> predicate = null)
        {
            var result = this.GetQueryable().Where(predicate).ToCollection();
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "CompanyNames", predicate,
                null, string.Join(";", result)));
            return result;
        }

        private ObservableCollection<CompanyNames> GetOrderByOnly<TValue>(
            Expression<Func<CompanyNames, TValue>> orderBy = null)
        {
            var result = this.GetQueryable().OrderBy(orderBy).ToCollection();
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "CompanyNames", null,
                orderBy, string.Join(";", result)));
            return result;
        }

        private ObservableCollection<CompanyNames> GetPredicateAndOrderBy<TValue>(
            Expression<Func<CompanyNames, bool>> predicate = null,
            Expression<Func<CompanyNames, TValue>> orderBy = null)
        {
            var result = this.GetQueryable().Where(predicate).OrderBy(orderBy).ToCollection();
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "CompanyNames", predicate,
                orderBy, string.Join(";", result)));
            return result;
        }

        public CompanyNames Get(Expression<Func<CompanyNames, bool>> predicate)
        {
            var result = this.GetQueryable().Where(predicate).FirstOrDefault();
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedGetSinglePredicate"), "CompanyNames", predicate,
                string.Join(";", result)));
            return result;
        }

        public int Insert(CompanyNames entity)
        {
            int result;
            this._connection.Open();
            using (var command = new SQLiteCommand(this._connection))
            {
                this.PrepareCommandInsert(command, entity);
                result = command.ExecuteNonQuery();
            }
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedInsert"), "CompanyNames", entity, result));
            this._connection.Close();
            return result;
        }

        public int Update(CompanyNames entity)
        {
            int result;
            this._connection.Open();
            using (var command = new SQLiteCommand(this._connection))
            {
                this.PrepareCommandUpdate(command, entity);
                result = command.ExecuteNonQuery();
            }
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedUpdate"), "CompanyNames", entity, result));
            this._connection.Close();
            return result;
        }

        public int Delete(CompanyNames entity)
        {
            int result;
            this._connection.Open();
            using (var command = new SQLiteCommand(this._connection))
            {
                this.PrepareDeleteCommand(command, entity);
                result = command.ExecuteNonQuery();
            }
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedDelete"), "CompanyNames", entity, result));
            this._connection.Close();
            return result;
        }

        public int Count(Expression<Func<CompanyNames, bool>> predicate = null)
        {
            return predicate == null ? this.CountNoPredicate() : this.CountPredicate(predicate);
        }

        private int CountNoPredicate()
        {
            var count = 0;
            const string sql = "SELECT COUNT(Id) FROM CompanyNames";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())

                        count = Convert.ToInt32(reader[0].ToString());
                }
            }
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedCount"), "CompanyNames", null, count));
            this._connection.Close();
            return count;
        }

        private int CountPredicate(Expression<Func<CompanyNames, bool>> predicate = null)
        {
            var count = this.GetQueryable().Where(predicate).Count();
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedCount"), "CompanyNames", predicate, count));
            return count;
        }

        private string GetCreateTableSQL()
        {
            return "CREATE TABLE IF NOT EXISTS CompanyNames (" +
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

        private CompanyNames GetCompanyNamesFromReader(SQLiteDataReader reader)
        {
            return new CompanyNames
            {
                Id = Convert.ToInt64(reader["Id"].ToString()),
                Name = reader["Name"].ToString(),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"].ToString()),
                Deleted = Convert.ToBoolean(reader["Deleted"].ToString()),
                ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"].ToString())
            };
        }

        private void PrepareCommandInsert(SQLiteCommand command, CompanyNames companyNames)
        {
            command.CommandText = "INSERT INTO CompanyNames (Id, Name, CreatedAt, Deleted, ModifiedAt) " +
                                  "VALUES (@Id, @Name, @CreatedAt, @Deleted, @ModifiedAt)";
            command.Prepare();
            this.AddParametersUpdateInsert(command, companyNames);
        }

        private void AddParametersUpdateInsert(SQLiteCommand command, CompanyNames companyNames)
        {
            command.Parameters.AddWithValue("@Id", companyNames.Id);
            command.Parameters.AddWithValue("@Name", companyNames.Name);
            command.Parameters.AddWithValue("@CreatedAt", companyNames.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@Deleted", companyNames.Deleted);
            command.Parameters.AddWithValue("@ModifiedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void PrepareCommandUpdate(SQLiteCommand command, CompanyNames companyNames)
        {
            command.CommandText =
                "UPDATE CompanyNames SET Name = @Name, CreatedAt = @CreatedAt, Deleted = @Deleted, " +
                "ModifiedAt = @ModifiedAt WHERE Id = @Id";
            command.Prepare();
            this.AddParametersUpdateInsert(command, companyNames);
        }

        private void PrepareDeleteCommand(SQLiteCommand command, CompanyNames companyNames)
        {
            command.CommandText = "UPDATE CompanyNames SET Deleted = true, ModifiedAt = @ModifiedAt WHERE Id = @Id";
            command.Prepare();
            command.Parameters.AddWithValue("@Id", companyNames.Id);
            command.Parameters.AddWithValue("@ModifiedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private IQueryable<CompanyNames> GetQueryable()
        {
            return this.Get().AsQueryable();
        }

        public void Truncate()
        {
            const string sql = "DELETE FROM CompanyNames";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                command.ExecuteNonQuery();
            }
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedTruncate"), "CompanyNames"));
            this._connection.Close();
        }
    }
}