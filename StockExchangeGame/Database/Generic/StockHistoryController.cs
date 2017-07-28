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
    public class StockHistoryController : IEntityController<StockHistory>
    {
        private readonly SQLiteConnection _connection;

        public StockHistoryController(string connectionString)
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

        public List<StockHistory> Get()
        {
            var list = new List<StockHistory>();
            var sql = "SELECT * FROM StockHistory";
            _connection.Open();
            using (var command = new SQLiteCommand(sql, _connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var stockhistory = GetStockHistoryFromReader(reader);
                        list.Add(stockhistory);
                    }
                }
            }
            _connection.Close();
            return list;
        }

        public StockHistory Get(long id)
        {
            var sql = "SELECT * FROM StockHistory WHERE Id = @Id";
            _connection.Open();
            using (var command = new SQLiteCommand(sql, _connection))
            {
                PrepareCommandSelect(command, id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        return GetStockHistoryFromReader(reader);
                }
            }
            _connection.Close();
            return null;
        }

        public ObservableCollection<StockHistory> Get<TValue>(Expression<Func<StockHistory, bool>> predicate = null,
            Expression<Func<StockHistory, TValue>> orderBy = null)
        {
            if (predicate == null && orderBy == null)
                return GetCollection(Get());
            if (predicate != null && orderBy == null)
                return GetCollection(GetQueryable().Where(predicate).ToList());
            return GetCollection(predicate == null
                ? GetQueryable().OrderBy(orderBy).ToList()
                : GetQueryable().Where(predicate).OrderBy(orderBy).ToList());
        }

        public StockHistory Get(Expression<Func<StockHistory, bool>> predicate)
        {
            return GetQueryable().Where(predicate).FirstOrDefault();
        }

        public int Insert(StockHistory entity)
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

        public int Update(StockHistory entity)
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

        public int Delete(StockHistory entity)
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

        public int Count(Expression<Func<StockHistory, bool>> predicate = null)
        {
            return predicate == null ? Get().Count : GetQueryable().Where(predicate).Count();
        }

        private string GetCreateTableSQL()
        {
            return "CREATE TABLE StockHistory (" +
                   "Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE," +
                   "PriceDate TEXT NOT NULL," +
                   "CreatedAt TEXT NOT NULL," +
                   "PricePerStock DOUBLE NOT NULL," +
                   "Deleted BOOLEAN NOT NULL," +
                   "StockId INTEGER NOT NULL," +
                   "ModifiedAt TEXT NOT NULL)";
        }

        private void PrepareCommandSelect(SQLiteCommand command, long id)
        {
            command.Prepare();
            command.Parameters.AddWithValue("@Id", id);
        }

        private StockHistory GetStockHistoryFromReader(SQLiteDataReader reader)
        {
            return new StockHistory
            {
                Id = Convert.ToInt64(reader["Id"].ToString()),
                PriceDate = Convert.ToDateTime(reader["PriceDate"].ToString()),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"].ToString()),
                PricePerStock = Convert.ToDouble(reader["PricePerStock"].ToString()),
                Deleted = Convert.ToBoolean(reader["Deleted"].ToString()),
                StockId = Convert.ToInt64(reader["StockId"].ToString()),
                ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"].ToString())
            };
        }

        private ObservableCollection<StockHistory> GetCollection(IEnumerable<StockHistory> oldList)
        {
            var collection = new ObservableCollection<StockHistory>();
            foreach (var item in oldList)
                collection.Add(item);
            return collection;
        }

        private void PrepareCommandInsert(SQLiteCommand command, StockHistory stockHistory)
        {
            command.CommandText = "INSERT INTO StockHistory (Id, PriceDate, CreatedAt, PricePerStock, Deleted, StockId, " +
                                  "ModifiedAt) VALUES (@Id, @PriceDate, @CreatedAt, @PricePerStock, @Deleted, " +
                                  "@StockId, @ModifiedAt)";
            command.Prepare();
            AddParametersUpdateInsert(command, stockHistory);
        }

        private void AddParametersUpdateInsert(SQLiteCommand command, StockHistory stockHistory)
        {
            command.Parameters.AddWithValue("@Id", stockHistory.Id);
            command.Parameters.AddWithValue("@PriceDate", stockHistory.PriceDate.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@CreatedAt", stockHistory.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@PricePerStock", stockHistory.PricePerStock);
            command.Parameters.AddWithValue("@Deleted", stockHistory.Deleted);
            command.Parameters.AddWithValue("@StockId", stockHistory.StockId);
            command.Parameters.AddWithValue("@ModifiedAt", stockHistory.ModifiedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void PrepareCommandUpdate(SQLiteCommand command, StockHistory stockHistory)
        {
            command.CommandText =
                "UPDATE StockHistory SET PriceDate = @PriceDate, CreatedAt = @CreatedAt, PricePerStock = @PricePerStock," +
                " Deleted = @Deleted, StockId = @StockId, ModifiedAt = @ModifiedAt WHERE Id = @Id";
            command.Prepare();
            AddParametersUpdateInsert(command, stockHistory);
        }

        private void PrepareDeletCommand(SQLiteCommand command, StockHistory stockHistory)
        {
            command.CommandText = "DELETE FROM StockHistory WHERE Id = @Id";
            command.Prepare();
            command.Parameters.AddWithValue("@Id", stockHistory.Id);
        }

        private IQueryable<StockHistory> GetQueryable()
        {
            return Get().AsQueryable();
        }
    }
}