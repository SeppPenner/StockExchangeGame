using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using StockExchangeGame.Database.Models;

namespace StockExchangeGame.Database.Generic
{
    // ReSharper disable once UnusedMember.Global
    public class DatabaseAdapter : IDatabaseAdapter
    {
        private const string SqlDbFileName = "StockGame.sqlite";

        public string GetDatabasePath()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            return location != null
                ? Path.Combine(Directory.GetParent(location).FullName, SqlDbFileName)
                : string.Empty;
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(GetDatabasePath());
        }

        public async Task<CreateTablesResult> CreateBoughtTable()
        {
            var connection = GetConnection();
            

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

        public async Task<List<CreateTablesResult>> CreateAllTables()
        {
            return new List<CreateTablesResult>
            {
                await CreateBoughtTable(),
                await CreateCompanyEndingsTable(),
                await CreateCompanyNamesTable(),
                await CreateDummyCompanyTable(),
                await CreateMerchantTable(),
                await CreateNamesTable(),
                await CreateSoldTable(),
                await CreateStockTable(),
                await CreateStockHistoryTable(),
                await CreateStockMarketTable(),
                await CreateSurnamesTable(),
                await CreateTaxesTable()
            };
        }
    }
}