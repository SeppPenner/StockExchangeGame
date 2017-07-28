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
    public class SurnamesController : IEntityController<Surnames>
    {
        private readonly SQLiteConnection _connection;
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private ILanguage _currentLanguage;

        public SurnamesController(string connectionString)
        {
            _connection = new SQLiteConnection(connectionString);
        }

        public void SetCurrentLanguage(ILanguage language)
        {
            _log.Info(string.Format(_currentLanguage.GetWord("LanguageSet"), "Surnames", language.Identifier));
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
            _log.Info(string.Format(_currentLanguage.GetWord("TableCreated"), "Surnames", result));
            _connection.Close();
            return result;
        }

        public List<Surnames> Get()
        {
            var list = new List<Surnames>();
            var sql = "SELECT * FROM Surnames";
            _connection.Open();
            using (var command = new SQLiteCommand(sql, _connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var surnames = GetSurnamesFromReader(reader);
                        list.Add(surnames);
                    }
                }
            }
            _log.Info(string.Format(_currentLanguage.GetWord("ExecutedGet"), "Surnames", list));
            _connection.Close();
            return list;
        }

        public Surnames Get(long id)
        {
            Surnames surname = null;
            var sql = "SELECT * FROM Surnames WHERE Id = @Id";
            _connection.Open();
            using (var command = new SQLiteCommand(sql, _connection))
            {
                PrepareCommandSelect(command, id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        surname = GetSurnamesFromReader(reader);
                }
            }
            _log.Info(string.Format(_currentLanguage.GetWord("ExecutedGetSingle"), "Surnames", surname));
            _connection.Close();
            return surname;
        }

        public ObservableCollection<Surnames> Get<TValue>(Expression<Func<Surnames, bool>> predicate = null,
            Expression<Func<Surnames, TValue>> orderBy = null)
        {
            if (predicate == null && orderBy == null)
                return GetCollection(Get());
            if (predicate != null && orderBy == null)
                return GetCollection(GetQueryable().Where(predicate).ToList());
            return GetCollection(predicate == null
                ? GetQueryable().OrderBy(orderBy).ToList()
                : GetQueryable().Where(predicate).OrderBy(orderBy).ToList());
        }

        public Surnames Get(Expression<Func<Surnames, bool>> predicate)
        {
            return GetQueryable().Where(predicate).FirstOrDefault();
        }

        public int Insert(Surnames entity)
        {
            int result;
            _connection.Open();
            using (var command = new SQLiteCommand(_connection))
            {
                PrepareCommandInsert(command, entity);
                result = command.ExecuteNonQuery();
            }
            _log.Info(string.Format(_currentLanguage.GetWord("ExecutedInsert"), "Surnames", entity, result));
            _connection.Close();
            return result;
        }

        public int Update(Surnames entity)
        {
            int result;
            _connection.Open();
            using (var command = new SQLiteCommand(_connection))
            {
                PrepareCommandUpdate(command, entity);
                result = command.ExecuteNonQuery();
            }
            _log.Info(string.Format(_currentLanguage.GetWord("ExecutedUpdate"), "Surnames", entity, result));
            _connection.Close();
            return result;
        }

        public int Delete(Surnames entity)
        {
            int result;
            _connection.Open();
            using (var command = new SQLiteCommand(_connection))
            {
                PrepareDeletCommand(command, entity);
                result = command.ExecuteNonQuery();
            }
            _log.Info(string.Format(_currentLanguage.GetWord("ExecutedDelete"), "Surnames", entity, result));
            _connection.Close();
            return result;
        }

        public int Count(Expression<Func<Surnames, bool>> predicate = null)
        {
            if (predicate == null)
            {
                var count = Get().Count;
                _log.Info(string.Format(_currentLanguage.GetWord("ExecutedCountSimple"), "Surnames", count));
                return count;
            }
            var count2 = GetQueryable().Where(predicate).Count();
            _log.Info(string.Format(_currentLanguage.GetWord("ExecutedCount"), "Surnames", predicate, count2));
            return count2;
        }

        private string GetCreateTableSQL()
        {
            return "CREATE TABLE Surnames (" +
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

        private ObservableCollection<Surnames> GetCollection(IEnumerable<Surnames> oldList)
        {
            var collection = new ObservableCollection<Surnames>();
            foreach (var item in oldList)
                collection.Add(item);
            return collection;
        }

        private void PrepareCommandInsert(SQLiteCommand command, Surnames surnames)
        {
            command.CommandText = "INSERT INTO Surnames (Id, Name, CreatedAt, Deleted, ModifiedAt) " +
                                  "VALUES (@Id, @Name, @CreatedAt, @Deleted, @ModifiedAt)";
            command.Prepare();
            AddParametersUpdateInsert(command, surnames);
        }

        private void AddParametersUpdateInsert(SQLiteCommand command, Surnames surnames)
        {
            command.Parameters.AddWithValue("@Id", surnames.Id);
            command.Parameters.AddWithValue("@Name", surnames.Name);
            command.Parameters.AddWithValue("@CreatedAt", surnames.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@Deleted", surnames.Deleted);
            command.Parameters.AddWithValue("@ModifiedAt", surnames.ModifiedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void PrepareCommandUpdate(SQLiteCommand command, Surnames surnames)
        {
            command.CommandText =
                "UPDATE Surnames SET Name = @Name, CreatedAt = @CreatedAt, Deleted = @Deleted, " +
                "ModifiedAt = @ModifiedAt WHERE Id = @Id";
            command.Prepare();
            AddParametersUpdateInsert(command, surnames);
        }

        private void PrepareDeletCommand(SQLiteCommand command, Surnames surnames)
        {
            command.CommandText = "DELETE FROM Surnames WHERE Id = @Id";
            command.Prepare();
            command.Parameters.AddWithValue("@Id", surnames.Id);
        }

        private IQueryable<Surnames> GetQueryable()
        {
            return Get().AsQueryable();
        }
    }
}