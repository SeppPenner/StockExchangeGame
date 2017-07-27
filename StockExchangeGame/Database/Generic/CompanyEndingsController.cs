using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Linq.Expressions;
using StockExchangeGame.Database.Models;

namespace StockExchangeGame.Database.Generic
{
    // ReSharper disable once UnusedMember.Global
    public class CompanyEndingsController : IEntityController<CompanyEndings>
    {
        private readonly SQLiteConnection _connection;

        public CompanyEndingsController(string connectionString)
        {
            _connection = new SQLiteConnection(connectionString);
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
            _connection.Close();
            return result;
        }

        public List<CompanyEndings> Get()
        {
            var list = new List<CompanyEndings>();
            var sql = "SELECT * FROM CompanyEndings";
            _connection.Open();
            using (var command = new SQLiteCommand(sql, _connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var companyEndings = GetCompanyEndingsFromReader(reader);
                        list.Add(companyEndings);
                    }
                }
            }
            _connection.Close();
            return list;
        }

        public CompanyEndings Get(long id)
        {
            var sql = "SELECT * FROM CompanyEndings WHERE Id = @Id";
            _connection.Open();
            using (var command = new SQLiteCommand(sql, _connection))
            {
                PrepareCommandSelect(command, id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        return GetCompanyEndingsFromReader(reader);
                }
            }
            _connection.Close();
            return null;
        }

        public ObservableCollection<CompanyEndings> Get<TValue>(Expression<Func<CompanyEndings, bool>> predicate = null,
            Expression<Func<CompanyEndings, TValue>> orderBy = null)
        {
            if (predicate == null && orderBy == null)
                return GetCollection(Get());
            if (predicate != null && orderBy == null)
                return GetCollection(GetQueryable().Where(predicate).ToList());
            return GetCollection(predicate == null
                ? GetQueryable().OrderBy(orderBy).ToList()
                : GetQueryable().Where(predicate).OrderBy(orderBy).ToList());
        }

        public CompanyEndings Get(Expression<Func<CompanyEndings, bool>> predicate)
        {
            return GetQueryable().Where(predicate).FirstOrDefault();
        }

        public int Insert(CompanyEndings companyEndings)
        {
            int result;
            _connection.Open();
            using (var command = new SQLiteCommand(_connection))
            {
                PrepareCommandInsert(command, companyEndings);
                result = command.ExecuteNonQuery();
            }
            _connection.Close();
            return result;
        }

        public int Update(CompanyEndings companyEndings)
        {
            int result;
            _connection.Open();
            using (var command = new SQLiteCommand(_connection))
            {
                PrepareCommandUpdate(command, companyEndings);
                result = command.ExecuteNonQuery();
            }
            _connection.Close();
            return result;
        }

        public int Delete(CompanyEndings companyEndings)
        {
            int result;
            _connection.Open();
            using (var command = new SQLiteCommand(_connection))
            {
                PrepareDeletCommand(command, companyEndings);
                result = command.ExecuteNonQuery();
            }
            _connection.Close();
            return result;
        }

        public int Count(Expression<Func<CompanyEndings, bool>> predicate = null)
        {
            return predicate == null ? Get().Count : GetQueryable().Where(predicate).Count();
        }

        private string GetCreateTableSQL()
        {
            return "CREATE TABLE CompanyEndings (" +
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

        private CompanyEndings GetCompanyEndingsFromReader(SQLiteDataReader reader)
        {
            return new CompanyEndings
            {
                Id = Convert.ToInt64(reader["Id"].ToString()),
                Name = reader["Name"].ToString(),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"].ToString()),
                Deleted = Convert.ToBoolean(reader["Deleted"].ToString()),
                ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"].ToString()),
            };
        }

        private ObservableCollection<CompanyEndings> GetCollection(IEnumerable<CompanyEndings> oldList)
        {
            var collection = new ObservableCollection<CompanyEndings>();
            foreach (var item in oldList)
                collection.Add(item);
            return collection;
        }

        private void PrepareCommandInsert(SQLiteCommand command, CompanyEndings companyEndings)
        {
            command.CommandText = "INSERT INTO CompanyEndings (Id, Name, CreatedAt, Deleted, ModifiedAt) " +
                                  "VALUES (@Id, @Name, @CreatedAt, @Deleted, @ModifiedAt)";
            command.Prepare();
            AddParametersInsert(command, companyEndings);
        }

        private void AddParametersInsert(SQLiteCommand command, CompanyEndings companyEndings)
        {
            command.Parameters.AddWithValue("@Id", companyEndings.Id);
            command.Parameters.AddWithValue("@Name", companyEndings.Name);
            command.Parameters.AddWithValue("@CreatedAt", companyEndings.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@Deleted", companyEndings.Deleted);
            command.Parameters.AddWithValue("@ModifiedAt", companyEndings.ModifiedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void PrepareCommandUpdate(SQLiteCommand command, CompanyEndings companyEndings)
        {
            command.CommandText =
                "UPDATE CompanyEndings SET Name = @Name, CreatedAt = @CreatedAt, Deleted = @Deleted, " +
                "ModifiedAt = @ModifiedAt WHERE Id = @Id";
            command.Prepare();
            AddParametersUpdate(command, companyEndings);
        }

        private void AddParametersUpdate(SQLiteCommand command, CompanyEndings companyEndings)
        {
            command.Parameters.AddWithValue("@Name", companyEndings.Name);
            command.Parameters.AddWithValue("@CreatedAt", companyEndings.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@Deleted", companyEndings.Deleted);
            command.Parameters.AddWithValue("@ModifiedAt", companyEndings.ModifiedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void PrepareDeletCommand(SQLiteCommand command, CompanyEndings companyEndings)
        {
            command.CommandText = "DELETE FROM CompanyEndings WHERE Id = @Id";
            command.Prepare();
            command.Parameters.AddWithValue("@Id", companyEndings.Id);
        }

        private IQueryable<CompanyEndings> GetQueryable()
        {
            return Get().AsQueryable();
        }
    }
}