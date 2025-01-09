namespace StockExchangeGame.Database.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.SQLite;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    using Languages.Interfaces;

    using Serilog;

    using StockExchangeGame.Database.Extensions;
    using StockExchangeGame.Database.Models;

    public class DummyCompanyController : IEntityController<DummyCompany>
    {
        private readonly SQLiteConnection _connection;
        private readonly ILogger _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private ILanguage _currentLanguage;

        public DummyCompanyController(SQLiteConnection connection)
        {
            this._connection = connection;
        }

        public void SetCurrentLanguage(ILanguage language)
        {
            this._currentLanguage = language;
            Log.Info(string.Format(this._currentLanguage.GetWord("LanguageSet"), "DummyCompany", language.Identifier));
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
            this._log.Info(string.Format(this._currentLanguage.GetWord("TableCreated"), "DummyCompany", result));
            this._connection.Close();
            return result;
        }

        public List<DummyCompany> Get()
        {
            var list = new List<DummyCompany>();
            var sql = "SELECT * FROM DummyCompany";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dummyCompany = this.GetDummyCompanyFromReader(reader);
                        list.Add(dummyCompany);
                    }
                }
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGet"), "DummyCompany", string.Join("; ", list)));
            this._connection.Close();
            return list;
        }

        public DummyCompany Get(long id)
        {
            DummyCompany dummyCompany = null;
            var sql = "SELECT * FROM DummyCompany WHERE Id = @Id";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                this.PrepareCommandSelect(command, id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        dummyCompany = this.GetDummyCompanyFromReader(reader);
                }
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetSingle"), "DummyCompany", dummyCompany));
            this._connection.Close();
            return dummyCompany;
        }

        public ObservableCollection<DummyCompany> Get<TValue>(Expression<Func<DummyCompany, bool>> predicate = null,
            Expression<Func<DummyCompany, TValue>> orderBy = null)
        {
            if (predicate == null && orderBy == null)
                return this.GetNoPredicateNoOrderBy();
            if (predicate != null && orderBy == null)
                return this.GetPredicateOnly(predicate);
            return predicate == null ? this.GetOrderByOnly(orderBy) : this.GetPredicateAndOrderBy(predicate, orderBy);
        }

        private ObservableCollection<DummyCompany> GetNoPredicateNoOrderBy()
        {
            var result = this.Get().ToCollection();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "DummyCompany", null, null,
                string.Join(";", result)));
            return result;
        }

        private ObservableCollection<DummyCompany> GetPredicateOnly(
            Expression<Func<DummyCompany, bool>> predicate = null)
        {
            var result = this.GetQueryable().Where(predicate).ToCollection();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "DummyCompany", predicate,
                null, string.Join(";", result)));
            return result;
        }

        private ObservableCollection<DummyCompany> GetOrderByOnly<TValue>(
            Expression<Func<DummyCompany, TValue>> orderBy = null)
        {
            var result = this.GetQueryable().OrderBy(orderBy).ToCollection();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "DummyCompany", null,
                orderBy, string.Join(";", result)));
            return result;
        }

        private ObservableCollection<DummyCompany> GetPredicateAndOrderBy<TValue>(
            Expression<Func<DummyCompany, bool>> predicate = null,
            Expression<Func<DummyCompany, TValue>> orderBy = null)
        {
            var result = this.GetQueryable().Where(predicate).OrderBy(orderBy).ToCollection();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "DummyCompany", predicate,
                orderBy, string.Join(";", result)));
            return result;
        }

        public DummyCompany Get(Expression<Func<DummyCompany, bool>> predicate)
        {
            var result = this.GetQueryable().Where(predicate).FirstOrDefault();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedGetSinglePredicate"), "DummyCompany", predicate,
                string.Join(";", result)));
            return result;
        }

        public int Insert(DummyCompany entity)
        {
            int result;
            this._connection.Open();
            using (var command = new SQLiteCommand(this._connection))
            {
                this.PrepareCommandInsert(command, entity);
                result = command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedInsert"), "DummyCompany", entity, result));
            this._connection.Close();
            return result;
        }

        public int Update(DummyCompany entity)
        {
            int result;
            this._connection.Open();
            using (var command = new SQLiteCommand(this._connection))
            {
                this.PrepareCommandUpdate(command, entity);
                result = command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedUpdate"), "DummyCompany", entity, result));
            this._connection.Close();
            return result;
        }

        public int Delete(DummyCompany entity)
        {
            int result;
            this._connection.Open();
            using (var command = new SQLiteCommand(this._connection))
            {
                this.PrepareDeleteCommand(command, entity);
                result = command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedDelete"), "DummyCompany", entity, result));
            this._connection.Close();
            return result;
        }

        public int Count(Expression<Func<DummyCompany, bool>> predicate = null)
        {
            return predicate == null ? this.CountNoPredicate() : this.CountPredicate(predicate);
        }

        private int CountNoPredicate()
        {
            var count = 0;
            const string sql = "SELECT COUNT(Id) FROM DummyCompany";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())

                        count = Convert.ToInt32(reader[0].ToString());
                }
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedCount"), "DummyCompany", null, count));
            this._connection.Close();
            return count;
        }

        private int CountPredicate(Expression<Func<DummyCompany, bool>> predicate = null)
        {
            var count = this.GetQueryable().Where(predicate).Count();
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedCount"), "DummyCompany", predicate, count));
            return count;
        }

        private string GetCreateTableSQL()
        {
            return "CREATE TABLE IF NOT EXISTS DummyCompany (" +
                   "Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE," +
                   "Name TEXT NOT NULL," +
                   "CreatedAt TEXT NOT NULL," +
                   "Deleted BOOLEAN NOT NULL," +
                   "MerchantId INTEGER NOT NULL," +
                   "ModifiedAt TEXT NOT NULL," +
                   "Active BOOLEAN NOT NULL," +
                   "SumInEuro DOUBLE NOT NULL)";
        }

        private void PrepareCommandSelect(SQLiteCommand command, long id)
        {
            command.Prepare();
            command.Parameters.AddWithValue("@Id", id);
        }

        private DummyCompany GetDummyCompanyFromReader(SQLiteDataReader reader)
        {
            return new DummyCompany
            {
                Id = Convert.ToInt64(reader["Id"].ToString()),
                Name = reader["Name"].ToString(),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"].ToString()),
                Deleted = Convert.ToBoolean(reader["Deleted"].ToString()),
                MerchantId = Convert.ToInt64(reader["MerchantId"].ToString()),
                ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"].ToString()),
                SumInEuro = Convert.ToInt64(reader["SumInEuro"].ToString()),
                Active = Convert.ToBoolean(reader["Active"].ToString())
            };
        }

        private void PrepareCommandInsert(SQLiteCommand command, DummyCompany dummyCompany)
        {
            command.CommandText = "INSERT INTO DummyCompany (Id, Deleted, CreatedAt, ModifiedAt, Active, MerchantId, " +
                                  "Name, SumInEuro) VALUES (@Id, @Deleted, @CreatedAt, @ModifiedAt, @Active, " +
                                  "@MerchantId, @Name, @SumInEuro)";
            command.Prepare();
            this.AddParametersUpdateInsert(command, dummyCompany);
        }

        private void AddParametersUpdateInsert(SQLiteCommand command, DummyCompany dummyCompany)
        {
            command.Parameters.AddWithValue("@Id", dummyCompany.Id);
            command.Parameters.AddWithValue("@Deleted", dummyCompany.Deleted);
            command.Parameters.AddWithValue("@ModifiedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@CreatedAt", dummyCompany.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@Active", dummyCompany.Active);
            command.Parameters.AddWithValue("@MerchantId", dummyCompany.MerchantId);
            command.Parameters.AddWithValue("@Name", dummyCompany.Name);
            command.Parameters.AddWithValue("@SumInEuro", dummyCompany.SumInEuro);
        }

        private void PrepareCommandUpdate(SQLiteCommand command, DummyCompany dummyCompany)
        {
            command.CommandText =
                "UPDATE DummyCompany SET Deleted = @Deleted, ModifiedAt = @ModifiedAt, CreatedAt = @CreatedAt," +
                " Active = @Active, MerchantId = @MerchantId, Name = @Name, SumInEuro = @SumInEuro, WHERE Id = @Id";
            command.Prepare();
            this.AddParametersUpdateInsert(command, dummyCompany);
        }

        private void PrepareDeleteCommand(SQLiteCommand command, DummyCompany dummyCompany)
        {
            command.CommandText = "UPDATE DummyCompany SET Deleted = true, ModifiedAt = @ModifiedAt WHERE Id = @Id";
            command.Prepare();
            command.Parameters.AddWithValue("@Id", dummyCompany.Id);
            command.Parameters.AddWithValue("@ModifiedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private IQueryable<DummyCompany> GetQueryable()
        {
            return this.Get().AsQueryable();
        }

        public void Truncate()
        {
            const string sql = "DELETE FROM DummyCompany";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                command.ExecuteNonQuery();
            }
            this._log.Info(string.Format(this._currentLanguage.GetWord("ExecutedTruncate"), "DummyCompany"));
            this._connection.Close();
        }
    }
}