using System.Threading.Tasks;
using StockExchangeGame.Database.Models;
using System.IO;
using System.Reflection;

namespace StockExchangeGame.Database.Generic
{
    // ReSharper disable once UnusedMember.Global
    public class DatabaseAdapter: IDatabaseAdapter
    {
        private const string SqlDbFileName = "StockGame.db3";

        private string GetDatabasePath()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            return location != null ? Path.Combine(Directory.GetParent(location).FullName, SqlDbFileName) : string.Empty;
        }

        public SQLiteAsyncConnection GetConnection()
        {
            return new SQLiteAsyncConnection(GetDatabasePath());
        }

        public async Task<CreateTablesResult> CreateStockTable()
        {
            return await GetConnection().CreateTableAsync<Stock>();
        }

        public async Task<CreateTablesResult> CreateStockHistoryTable()
        {
            return await GetConnection().CreateTableAsync<StockHistory>();
        }
    }
}