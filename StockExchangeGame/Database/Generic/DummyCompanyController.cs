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
    public class DummyCompanyController : IEntityController<DummyCompany>
    {
        private readonly SQLiteConnection _connection;
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private ILanguage _currentLanguage;

        public DummyCompanyController(string connectionString)
        {
            _connection = new SQLiteConnection(connectionString);
        }

        public void SetCurrentLanguage(ILanguage language)
        {
            _log.Info(string.Format(_currentLanguage.GetWord("LanguageSet"), "DummyCompany", language.Identifier));
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
            _log.Info(string.Format(_currentLanguage.GetWord("TableCreated"), "DummyCompany", result));
            _connection.Close();
            return result;
        }

        public List<DummyCompany> Get()
        {
            var list = new List<DummyCompany>();
            var sql = "SELECT * FROM DummyCompany";
            _connection.Open();
            using (var command = new SQLiteCommand(sql, _connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dummyCompany = GetDummyCompanyFromReader(reader);
                        list.Add(dummyCompany);
                    }
                }
            }
            _log.Info(string.Format(_currentLanguage.GetWord("ExecutedGet"), "DummyCompany", list));
            _connection.Close();
            return list;
        }

        public DummyCompany Get(long id)
        {
            DummyCompany dummyCompany = null;
            var sql = "SELECT * FROM DummyCompany WHERE Id = @Id";
            _connection.Open();
            using (var command = new SQLiteCommand(sql, _connection))
            {
                PrepareCommandSelect(command, id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        dummyCompany = GetDummyCompanyFromReader(reader);
                }
            }
            _log.Info(string.Format(_currentLanguage.GetWord("ExecutedGetSingle"), "DummyCompany", dummyCompany));
            _connection.Close();
            return dummyCompany;
        }

        public ObservableCollection<DummyCompany> Get<TValue>(Expression<Func<DummyCompany, bool>> predicate = null,
            Expression<Func<DummyCompany, TValue>> orderBy = null)
        {
            if (predicate == null && orderBy == null)
                return GetCollection(Get());
            if (predicate != null && orderBy == null)
                return GetCollection(GetQueryable().Where(predicate).ToList());
            return GetCollection(predicate == null
                ? GetQueryable().OrderBy(orderBy).ToList()
                : GetQueryable().Where(predicate).OrderBy(orderBy).ToList());
        }

        public DummyCompany Get(Expression<Func<DummyCompany, bool>> predicate)
        {
            return GetQueryable().Where(predicate).FirstOrDefault();
        }

        public int Insert(DummyCompany entity)
        {
            int result;
            _connection.Open();
            using (var command = new SQLiteCommand(_connection))
            {
                PrepareCommandInsert(command, entity);
                result = command.ExecuteNonQuery();
            }
            _log.Info(string.Format(_currentLanguage.GetWord("ExecutedInsert"), "DummyCompany", entity, result));
            _connection.Close();
            return result;
        }

        public int Update(DummyCompany entity)
        {
            int result;
            _connection.Open();
            using (var command = new SQLiteCommand(_connection))
            {
                PrepareCommandUpdate(command, entity);
                result = command.ExecuteNonQuery();
            }
            _log.Info(string.Format(_currentLanguage.GetWord("ExecutedUpdate"), "DummyCompany", entity, result));
            _connection.Close();
            return result;
        }

        public int Delete(DummyCompany entity)
        {
            int result;
            _connection.Open();
            using (var command = new SQLiteCommand(_connection))
            {
                PrepareDeletCommand(command, entity);
                result = command.ExecuteNonQuery();
            }
            _log.Info(string.Format(_currentLanguage.GetWord("ExecutedDelete"), "DummyCompany", entity, result));
            _connection.Close();
            return result;
        }

        public int Count(Expression<Func<DummyCompany, bool>> predicate = null)
        {
            return predicate == null ? CountNoPredicate() : CountPredicate();
        }

        private int CountNoPredicate()
        {
            var count = Get().Count;
            _log.Info(string.Format(_currentLanguage.GetWord("ExecutedCountSimple"), "DummyCompany", count));
            return count;
        }

        private int CountPredicate(Expression<Func<DummyCompany, bool>> predicate = null)
        {
            var count2 = GetQueryable().Where(predicate).Count();
            _log.Info(string.Format(_currentLanguage.GetWord("ExecutedCount"), "DummyCompany", predicate, count2));
            return count2;
        }

        private string GetCreateTableSQL()
        {
            return "CREATE TABLE DummyCompany (" +
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

        private ObservableCollection<DummyCompany> GetCollection(IEnumerable<DummyCompany> oldList)
        {
            var collection = new ObservableCollection<DummyCompany>();
            foreach (var item in oldList)
                collection.Add(item);
            return collection;
        }

        private void PrepareCommandInsert(SQLiteCommand command, DummyCompany dummyCompany)
        {
            command.CommandText = "INSERT INTO DummyCompany (Id, Deleted, CreatedAt, ModifiedAt, Active, MerchantId, " +
                                  "Name, SumInEuro) VALUES (@Id, @Deleted, @CreatedAt, @ModifiedAt, @Active, " +
                                  "@MerchantId, @Name, @SumInEuro)";
            command.Prepare();
            AddParametersUpdateInsert(command, dummyCompany);
        }

        private void AddParametersUpdateInsert(SQLiteCommand command, DummyCompany dummyCompany)
        {
            command.Parameters.AddWithValue("@Id", dummyCompany.Id);
            command.Parameters.AddWithValue("@Deleted", dummyCompany.Deleted);
            command.Parameters.AddWithValue("@ModifiedAt", dummyCompany.ModifiedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
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
            AddParametersUpdateInsert(command, dummyCompany);
        }

        private void PrepareDeletCommand(SQLiteCommand command, DummyCompany dummyCompany)
        {
            command.CommandText = "DELETE FROM DummyCompany WHERE Id = @Id";
            command.Prepare();
            command.Parameters.AddWithValue("@Id", dummyCompany.Id);
        }

        private IQueryable<DummyCompany> GetQueryable()
        {
            return Get().AsQueryable();
        }
    }
}