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

        public string GetDatabasePath()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            return location != null ? Path.Combine(Directory.GetParent(location).FullName, SqlDbFileName) : string.Empty;
        }

        public SQLiteAsyncConnection GetConnection()
        {
            return new SQLiteAsyncConnection(GetDatabasePath());
        }

        public async Task<CreateTablesResult> CreateBoughtTable()
        {
            return await GetConnection().CreateTableAsync<Bought>();
        }

        public async Task<CreateTablesResult> CreateCompanyEndingsTable()
        {
            return await GetConnection().CreateTableAsync<CompanyEndings>();
        }

        public async Task<CreateTablesResult> CreateCompanyNamesTable()
        {
            return await GetConnection().CreateTableAsync<CompanyNames>();
        }

        public async Task<CreateTablesResult> CreateDummyCompanyTable()
        {
            return await GetConnection().CreateTableAsync<DummyCompany>();
        }

        public async Task<CreateTablesResult> CreateMerchantTable()
        {
            return await GetConnection().CreateTableAsync<Merchant>();
        }

        public async Task<CreateTablesResult> CreateNamesTable()
        {
            return await GetConnection().CreateTableAsync<Names>();
        }

        public async Task<CreateTablesResult> CreateSoldTable()
        {
            return await GetConnection().CreateTableAsync<Sold>();
        }

        public async Task<CreateTablesResult> CreateStockTable()
        {
            return await GetConnection().CreateTableAsync<Stock>();
        }

        public async Task<CreateTablesResult> CreateStockHistoryTable()
        {
            return await GetConnection().CreateTableAsync<StockHistory>();
        }

        public async Task<CreateTablesResult> CreateStockMarketTable()
        {
            return await GetConnection().CreateTableAsync<StockMarket>();
        }

        public async Task<CreateTablesResult> CreateSurnamesTable()
        {
            return await GetConnection().CreateTableAsync<Surnames>();
        }

        public async Task<CreateTablesResult> CreateTaxesTable()
        {
            return await GetConnection().CreateTableAsync<Taxes>();
        }
    }
}