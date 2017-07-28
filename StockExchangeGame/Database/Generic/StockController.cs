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
    public class StockController : IEntityController<Stock>
    {
        private readonly SQLiteConnection _connection;

        public StockController(string connectionString)
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

        public List<Stock> Get()
        {
            var list = new List<Stock>();
            var sql = "SELECT * FROM Stock";
            _connection.Open();
            using (var command = new SQLiteCommand(sql, _connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var stock = GetStockFromReader(reader);
                        list.Add(stock);
                    }
                }
            }
            _connection.Close();
            return list;
        }

        public Stock Get(long id)
        {
            var sql = "SELECT * FROM Stock WHERE Id = @Id";
            _connection.Open();
            using (var command = new SQLiteCommand(sql, _connection))
            {
                PrepareCommandSelect(command, id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        return GetStockFromReader(reader);
                }
            }
            _connection.Close();
            return null;
        }

        public ObservableCollection<Stock> Get<TValue>(Expression<Func<Stock, bool>> predicate = null,
            Expression<Func<Stock, TValue>> orderBy = null)
        {
            if (predicate == null && orderBy == null)
                return GetCollection(Get());
            if (predicate != null && orderBy == null)
                return GetCollection(GetQueryable().Where(predicate).ToList());
            return GetCollection(predicate == null
                ? GetQueryable().OrderBy(orderBy).ToList()
                : GetQueryable().Where(predicate).OrderBy(orderBy).ToList());
        }

        public Stock Get(Expression<Func<Stock, bool>> predicate)
        {
            return GetQueryable().Where(predicate).FirstOrDefault();
        }

        public int Insert(Stock entity)
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

        public int Update(Stock entity)
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

        public int Delete(Stock entity)
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

        public int Count(Expression<Func<Stock, bool>> predicate = null)
        {
            return predicate == null ? Get().Count : GetQueryable().Where(predicate).Count();
        }

        private string GetCreateTableSQL()
        {
            return "CREATE TABLE Stock (" +
                   "Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE," +
                   "Name TEXT NOT NULL," +
                   "CreatedAt TEXT NOT NULL," +
                   "Total INTEGER NOT NULL," +
                   "Deleted BOOLEAN NOT NULL," +
                   "Used INTEGER NOT NULL," +
                   "ModifiedAt TEXT NOT NULL)";
        }

        private void PrepareCommandSelect(SQLiteCommand command, long id)
        {
            command.Prepare();
            command.Parameters.AddWithValue("@Id", id);
        }

        private Stock GetStockFromReader(SQLiteDataReader reader)
        {
            return new Stock
            {
                Id = Convert.ToInt64(reader["Id"].ToString()),
                Name = reader["Name"].ToString(),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"].ToString()),
                Total = Convert.ToInt64(reader["Total"].ToString()),
                Deleted = Convert.ToBoolean(reader["Deleted"].ToString()),
                Used = Convert.ToInt64(reader["Used"].ToString()),
                ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"].ToString())
            };
        }

        private ObservableCollection<Stock> GetCollection(IEnumerable<Stock> oldList)
        {
            var collection = new ObservableCollection<Stock>();
            foreach (var item in oldList)
                collection.Add(item);
            return collection;
        }

        private void PrepareCommandInsert(SQLiteCommand command, Stock stock)
        {
            command.CommandText = "INSERT INTO Stock (Id, Name, CreatedAt, Total, Deleted, Used, " +
                                  "ModifiedAt) VALUES (@Id, @Name, @CreatedAt, @Total, @Deleted, " +
                                  "@Used, @ModifiedAt)";
            command.Prepare();
            AddParametersUpdateInsert(command, stock);
        }

        private void AddParametersUpdateInsert(SQLiteCommand command, Stock stock)
        {
            command.Parameters.AddWithValue("@Id", stock.Id);
            command.Parameters.AddWithValue("@Name", stock.Name);
            command.Parameters.AddWithValue("@CreatedAt", stock.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@Total", stock.Total);
            command.Parameters.AddWithValue("@Deleted", stock.Deleted);
            command.Parameters.AddWithValue("@Used", stock.Used);
            command.Parameters.AddWithValue("@ModifiedAt", stock.ModifiedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void PrepareCommandUpdate(SQLiteCommand command, Stock stock)
        {
            command.CommandText =
                "UPDATE Stock SET Name = @Name, CreatedAt = @CreatedAt, Total = @Total," +
                " Deleted = @Deleted, Used = @Used, ModifiedAt = @ModifiedAt WHERE Id = @Id";
            command.Prepare();
            AddParametersUpdateInsert(command, stock);
        }

        private void PrepareDeletCommand(SQLiteCommand command, Stock stock)
        {
            command.CommandText = "DELETE FROM Stock WHERE Id = @Id";
            command.Prepare();
            command.Parameters.AddWithValue("@Id", stock.Id);
        }

        private IQueryable<Stock> GetQueryable()
        {
            return Get().AsQueryable();
        }
    }
}