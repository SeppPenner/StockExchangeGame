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
    public class BoughtController : IEntityController<Bought>
    {
        private readonly SQLiteConnection _connection;

        public BoughtController(string connectionString)
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

        public List<Bought> Get()
        {
            var list = new List<Bought>();
            var sql = "SELECT * FROM Bought";
            _connection.Open();
            using (var command = new SQLiteCommand(sql, _connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var bought = GetBoughtFromReader(reader);
                        list.Add(bought);
                    }
                }
            }
            _connection.Close();
            return list;
        }

        public Bought Get(long id)
        {
            var sql = "SELECT * FROM Bought WHERE Id = @Id";
            _connection.Open();
            using (var command = new SQLiteCommand(sql, _connection))
            {
                PrepareCommandSelect(command, id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        return GetBoughtFromReader(reader);
                }
            }
            _connection.Close();
            return null;
        }

        public ObservableCollection<Bought> Get<TValue>(Expression<Func<Bought, bool>> predicate = null,
            Expression<Func<Bought, TValue>> orderBy = null)
        {
            if (predicate == null && orderBy == null)
                return GetCollection(Get());
            if (predicate != null && orderBy == null)
                return GetCollection(GetQueryable().Where(predicate).ToList());
            return GetCollection(predicate == null
                ? GetQueryable().OrderBy(orderBy).ToList()
                : GetQueryable().Where(predicate).OrderBy(orderBy).ToList());
        }

        public Bought Get(Expression<Func<Bought, bool>> predicate)
        {
            return GetQueryable().Where(predicate).FirstOrDefault();
        }

        public int Insert(Bought entity)
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

        public int Update(Bought entity)
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

        public int Delete(Bought entity)
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

        public int Count(Expression<Func<Bought, bool>> predicate = null)
        {
            return predicate == null ? Get().Count : GetQueryable().Where(predicate).Count();
        }

        private string GetCreateTableSQL()
        {
            return "CREATE TABLE Bought (" +
                   "Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE," +
                   "Amount INTEGER NOT NULL," +
                   "CreatedAt TEXT NOT NULL," +
                   "DateBought TEXT NOT NULL," +
                   "Deleted BOOLEAN NOT NULL," +
                   "MerchantId INTEGER NOT NULL," +
                   "ModifiedAt TEXT NOT NULL," +
                   "StockId INTEGER NOT NULL," +
                   "ValuePerStockInEuro DOUBLE NOT NULL)";
        }

        private void PrepareCommandSelect(SQLiteCommand command, long id)
        {
            command.Prepare();
            command.Parameters.AddWithValue("@Id", id);
        }

        private Bought GetBoughtFromReader(SQLiteDataReader reader)
        {
            return new Bought
            {
                Id = Convert.ToInt64(reader["Id"].ToString()),
                Amount = Convert.ToInt64(reader["Id"].ToString()),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"].ToString()),
                DateBought = Convert.ToDateTime(reader["DateBought"].ToString()),
                Deleted = Convert.ToBoolean(reader["Deleted"].ToString()),
                MerchantId = Convert.ToInt64(reader["MerchantId"].ToString()),
                ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"].ToString()),
                StockId = Convert.ToInt64(reader["StockId"].ToString()),
                ValuePerStockInEuro = Convert.ToDouble(reader["ValuePerStockInEuro"].ToString())
            };
        }

        private ObservableCollection<Bought> GetCollection(IEnumerable<Bought> oldList)
        {
            var collection = new ObservableCollection<Bought>();
            foreach (var item in oldList)
                collection.Add(item);
            return collection;
        }

        private void PrepareCommandInsert(SQLiteCommand command, Bought bought)
        {
            command.CommandText = "INSERT INTO Bought (Id, Amount, CreatedAt, DateBought, Deleted, MerchantId, " +
                                  "ModifiedAt, StockId, ValuePerStockInEuro) VALUES (@Id, @Amount, @CreatedAt, " +
                                  "@DateBought, @Deleted, @MerchantId, @ModifiedAt, @StockId, @ValuePerStockInEuro)";
            command.Prepare();
            AddParametersInsert(command, bought);
        }

        private void AddParametersInsert(SQLiteCommand command, Bought bought)
        {
            command.Parameters.AddWithValue("@Id", bought.Id);
            command.Parameters.AddWithValue("@Amount", bought.Amount);
            command.Parameters.AddWithValue("@CreatedAt", bought.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@DateBought", bought.DateBought.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@Deleted", bought.Deleted);
            command.Parameters.AddWithValue("@MerchantId", bought.MerchantId);
            command.Parameters.AddWithValue("@ModifiedAt", bought.ModifiedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@StockId", bought.StockId);
            command.Parameters.AddWithValue("@ValuePerStockInEuro", bought.ValuePerStockInEuro);
        }

        private void PrepareCommandUpdate(SQLiteCommand command, Bought bought)
        {
            command.CommandText =
                "UPDATE Bought SET Amount = @Amount, CreatedAt = @CreatedAt, DateBought = @DateBought," +
                " Deleted = @Deleted, MerchantId = @MerchantId, ModifiedAt = @ModifiedAt, StockId = @StockId, " +
                "ValuePerStockInEuro = @ValuePerStockInEuro WHERE Id = @Id";
            command.Prepare();
            AddParametersUpdate(command, bought);
        }

        private void AddParametersUpdate(SQLiteCommand command, Bought bought)
        {
            command.Parameters.AddWithValue("@Id", bought.Id);
            command.Parameters.AddWithValue("@Amount", bought.Amount);
            command.Parameters.AddWithValue("@CreatedAt", bought.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@DateBought", bought.DateBought.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@Deleted", bought.Deleted);
            command.Parameters.AddWithValue("@MerchantId", bought.MerchantId);
            command.Parameters.AddWithValue("@ModifiedAt", bought.ModifiedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@StockId", bought.StockId);
            command.Parameters.AddWithValue("@ValuePerStockInEuro", bought.ValuePerStockInEuro);
        }

        private void PrepareDeletCommand(SQLiteCommand command, Bought bought)
        {
            command.CommandText = "DELETE FROM Bought WHERE Id = @Id";
            command.Prepare();
            command.Parameters.AddWithValue("@Id", bought.Id);
        }

        private IQueryable<Bought> GetQueryable()
        {
            return Get().AsQueryable();
        }
    }
}