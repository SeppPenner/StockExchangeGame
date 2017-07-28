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
    public class MerchantController : IEntityController<Merchant>
    {
        private readonly SQLiteConnection _connection;

        public MerchantController(string connectionString)
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

        public List<Merchant> Get()
        {
            var list = new List<Merchant>();
            var sql = "SELECT * FROM Merchant";
            _connection.Open();
            using (var command = new SQLiteCommand(sql, _connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var merchant = GetMerchantFromReader(reader);
                        list.Add(merchant);
                    }
                }
            }
            _connection.Close();
            return list;
        }

        public Merchant Get(long id)
        {
            var sql = "SELECT * FROM Merchant WHERE Id = @Id";
            _connection.Open();
            using (var command = new SQLiteCommand(sql, _connection))
            {
                PrepareCommandSelect(command, id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        return GetMerchantFromReader(reader);
                }
            }
            _connection.Close();
            return null;
        }

        public ObservableCollection<Merchant> Get<TValue>(Expression<Func<Merchant, bool>> predicate = null,
            Expression<Func<Merchant, TValue>> orderBy = null)
        {
            if (predicate == null && orderBy == null)
                return GetCollection(Get());
            if (predicate != null && orderBy == null)
                return GetCollection(GetQueryable().Where(predicate).ToList());
            return GetCollection(predicate == null
                ? GetQueryable().OrderBy(orderBy).ToList()
                : GetQueryable().Where(predicate).OrderBy(orderBy).ToList());
        }

        public Merchant Get(Expression<Func<Merchant, bool>> predicate)
        {
            return GetQueryable().Where(predicate).FirstOrDefault();
        }

        public int Insert(Merchant entity)
        {
            int result;
            _connection.Open();
            using (var command = new SQLiteCommand(_connection))
            {
                PrepareCommandInsert(command, entity);
                result = command.ExecuteNonQuery();
            }
            _connection.Close();
            return result;
        }

        public int Update(Merchant entity)
        {
            int result;
            _connection.Open();
            using (var command = new SQLiteCommand(_connection))
            {
                PrepareCommandUpdate(command, entity);
                result = command.ExecuteNonQuery();
            }
            _connection.Close();
            return result;
        }

        public int Delete(Merchant entity)
        {
            int result;
            _connection.Open();
            using (var command = new SQLiteCommand(_connection))
            {
                PrepareDeletCommand(command, entity);
                result = command.ExecuteNonQuery();
            }
            _connection.Close();
            return result;
        }

        public int Count(Expression<Func<Merchant, bool>> predicate = null)
        {
            return predicate == null ? Get().Count : GetQueryable().Where(predicate).Count();
        }

        private string GetCreateTableSQL()
        {
            Name = "",
            Deleted = true,
            ModifiedAt = DateTime.MaxValue,
            CreatedAt = DateTime.MaxValue,
            Id = 1,
            LiquidFunds = 1000
            return "CREATE TABLE Merchant (" +
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
                ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"].ToString()),
            };
        }

        private ObservableCollection<Merchant> GetCollection(IEnumerable<Merchant> oldList)
        {
            var collection = new ObservableCollection<Merchant>();
            foreach (var item in oldList)
                collection.Add(item);
            return collection;
        }

        private void PrepareCommandInsert(SQLiteCommand command, Merchant merchant)
        {
            command.CommandText = "INSERT INTO Merchant (Id, Name, CreatedAt, Deleted, ModifiedAt) " +
                                  "VALUES (@Id, @Name, @CreatedAt, @Deleted, @ModifiedAt)";
            command.Prepare();
            AddParametersInsert(command, merchant);
        }

        private void AddParametersInsert(SQLiteCommand command, Merchant merchant)
        {
            command.Parameters.AddWithValue("@Id", merchant.Id);
            command.Parameters.AddWithValue("@Name", merchant.Name);
            command.Parameters.AddWithValue("@CreatedAt", merchant.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@Deleted", merchant.Deleted);
            command.Parameters.AddWithValue("@ModifiedAt", merchant.ModifiedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void PrepareCommandUpdate(SQLiteCommand command, Merchant merchant)
        {
            command.CommandText =
                "UPDATE Merchant SET Name = @Name, CreatedAt = @CreatedAt, Deleted = @Deleted, " +
                "ModifiedAt = @ModifiedAt WHERE Id = @Id";
            command.Prepare();
            AddParametersUpdate(command, merchant);
        }

        private void AddParametersUpdate(SQLiteCommand command, Merchant merchant)
        {
            command.Parameters.AddWithValue("@Id", merchant.Id);
            command.Parameters.AddWithValue("@Name", merchant.Name);
            command.Parameters.AddWithValue("@CreatedAt", merchant.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@Deleted", merchant.Deleted);
            command.Parameters.AddWithValue("@ModifiedAt", merchant.ModifiedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void PrepareDeletCommand(SQLiteCommand command, Merchant merchant)
        {
            command.CommandText = "DELETE FROM Merchant WHERE Id = @Id";
            command.Prepare();
            command.Parameters.AddWithValue("@Id", merchant.Id);
        }

        private IQueryable<Merchant> GetQueryable()
        {
            return Get().AsQueryable();
        }
    }
}