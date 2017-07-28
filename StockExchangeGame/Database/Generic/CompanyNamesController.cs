using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using log4net;
using Languages.Interfaces;
using StockExchangeGame.Database.Models;

namespace StockExchangeGame.Database.Generic
{
    // ReSharper disable once UnusedMember.Global
    public class CompanyNamesController : IEntityController<CompanyNames>
    {
        private readonly SQLiteConnection _connection;
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private ILanguage _currentLanguage;

        public CompanyNamesController(string connectionString)
        {
            _connection = new SQLiteConnection(connectionString);
        }

        public void SetCurrentLanguage(ILanguage language)
        {
            _log.Info(string.Format(_currentLanguage.GetWord("LanguageSet"), "CompanyNames", language.Identifier));
            _currentLanguage = language;
        }

        public ILanguage GetCurrentLanguage()
        {
            return _currentLanguage;
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
            _log.Info(string.Format(_currentLanguage.GetWord("TableCreated"), "CompanyNames", result));
            _connection.Close();
            return result;
        }

        public List<CompanyNames> Get()
        {
            var list = new List<CompanyNames>();
            var sql = "SELECT * FROM CompanyNames";
            _connection.Open();
            using (var command = new SQLiteCommand(sql, _connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var companyNames = GetCompanyNamesFromReader(reader);
                        list.Add(companyNames);
                    }
                }
            }
            _log.Info(string.Format(_currentLanguage.GetWord("ExecutedGet"), "CompanyNames", list));
            _connection.Close();
            return list;
        }

        public CompanyNames Get(long id)
        {
            CompanyNames companyName = null;
            var sql = "SELECT * FROM CompanyNames WHERE Id = @Id";
            _connection.Open();
            using (var command = new SQLiteCommand(sql, _connection))
            {
                PrepareCommandSelect(command, id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        companyName = GetCompanyNamesFromReader(reader);
                }
            }
            _log.Info(string.Format(_currentLanguage.GetWord("ExecutedGetSingle"), "CompanyNames", companyName));
            _connection.Close();
            return companyName;
        }

        public ObservableCollection<CompanyNames> Get<TValue>(Expression<Func<CompanyNames, bool>> predicate = null,
            Expression<Func<CompanyNames, TValue>> orderBy = null)
        {
            if (predicate == null && orderBy == null)
                return GetCollection(Get());
            if (predicate != null && orderBy == null)
                return GetCollection(GetQueryable().Where(predicate).ToList());
            return GetCollection(predicate == null
                ? GetQueryable().OrderBy(orderBy).ToList()
                : GetQueryable().Where(predicate).OrderBy(orderBy).ToList());
        }

        public CompanyNames Get(Expression<Func<CompanyNames, bool>> predicate)
        {
            return GetQueryable().Where(predicate).FirstOrDefault();
        }

        public int Insert(CompanyNames entity)
        {
            int result;
            _connection.Open();
            using (var command = new SQLiteCommand(_connection))
            {
                PrepareCommandInsert(command, entity);
                result = command.ExecuteNonQuery();
            }
            _log.Info(string.Format(_currentLanguage.GetWord("ExecutedInsert"), "CompanyNames", entity, result));
            _connection.Close();
            return result;
        }

        public int Update(CompanyNames entity)
        {
            int result;
            _connection.Open();
            using (var command = new SQLiteCommand(_connection))
            {
                PrepareCommandUpdate(command, entity);
                result = command.ExecuteNonQuery();
            }
            _log.Info(string.Format(_currentLanguage.GetWord("ExecutedUpdate"), "CompanyNames", entity, result));
            _connection.Close();
            return result;
        }

        public int Delete(CompanyNames entity)
        {
            int result;
            _connection.Open();
            using (var command = new SQLiteCommand(_connection))
            {
                PrepareDeletCommand(command, entity);
                result = command.ExecuteNonQuery();
            }
            _log.Info(string.Format(_currentLanguage.GetWord("ExecutedDelete"), "CompanyNames", entity, result));
            _connection.Close();
            return result;
        }

        public int Count(Expression<Func<CompanyNames, bool>> predicate = null)
        {
            if (predicate == null)
            {
                var count = Get().Count;
                _log.Info(string.Format(_currentLanguage.GetWord("ExecutedCountSimple"), "CompanyNames", count));
                return count;
            }
            var count2 = GetQueryable().Where(predicate).Count();
            _log.Info(string.Format(_currentLanguage.GetWord("ExecutedCount"), "CompanyNames", predicate, count2));
            return count2;
        }

        private string GetCreateTableSQL()
        {
            return "CREATE TABLE CompanyNames (" +
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
                ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"].ToString()),
            };
        }

        private ObservableCollection<CompanyNames> GetCollection(IEnumerable<CompanyNames> oldList)
        {
            var collection = new ObservableCollection<CompanyNames>();
            foreach (var item in oldList)
                collection.Add(item);
            return collection;
        }

        private void PrepareCommandInsert(SQLiteCommand command, CompanyNames companyNames)
        {
            command.CommandText = "INSERT INTO CompanyNames (Id, Name, CreatedAt, Deleted, ModifiedAt) " +
                                  "VALUES (@Id, @Name, @CreatedAt, @Deleted, @ModifiedAt)";
            command.Prepare();
            AddParametersUpdateInsert(command, companyNames);
        }

        private void AddParametersUpdateInsert(SQLiteCommand command, CompanyNames companyNames)
        {
            command.Parameters.AddWithValue("@Id", companyNames.Id);
            command.Parameters.AddWithValue("@Name", companyNames.Name);
            command.Parameters.AddWithValue("@CreatedAt", companyNames.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@Deleted", companyNames.Deleted);
            command.Parameters.AddWithValue("@ModifiedAt", companyNames.ModifiedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void PrepareCommandUpdate(SQLiteCommand command, CompanyNames companyNames)
        {
            command.CommandText =
                "UPDATE CompanyNames SET Name = @Name, CreatedAt = @CreatedAt, Deleted = @Deleted, " +
                "ModifiedAt = @ModifiedAt WHERE Id = @Id";
            command.Prepare();
            AddParametersUpdateInsert(command, companyNames);
        }

        private void PrepareDeletCommand(SQLiteCommand command, CompanyNames companyNames)
        {
            command.CommandText = "DELETE FROM CompanyNames WHERE Id = @Id";
            command.Prepare();
            command.Parameters.AddWithValue("@Id", companyNames.Id);
        }

        private IQueryable<CompanyNames> GetQueryable()
        {
            return Get().AsQueryable();
        }
    }
}