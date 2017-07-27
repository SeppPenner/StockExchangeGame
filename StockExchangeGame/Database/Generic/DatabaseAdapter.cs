using System.IO;
using System.Reflection;
using StockExchangeGame.Database.Models;

namespace StockExchangeGame.Database.Generic
{
    // ReSharper disable once UnusedMember.Global
    public class DatabaseAdapter : IDatabaseAdapter
    {
        private readonly IEntityController<Bought> _boughtController;
        private const string SqlDbFileName = "StockGame.sqlite";

        public DatabaseAdapter()
        {
            var connectionString = GetConnectionString();
            _boughtController = new BoughtController(connectionString);
        }

        public string GetConnectionString()
        {
            return @"Data Source=" + GetDatabasePath() + "; " +
                @"Version=3; FailIfMissing=True; Foreign Keys=True;";
        }

        public string GetDatabasePath()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            return location != null
                ? Path.Combine(Directory.GetParent(location).FullName, SqlDbFileName)
                : string.Empty;
        }

        public void CreateBoughtTable()
        {
            _boughtController.CreateTable();
        }

        public void CreateCompanyEndingsTable()
        {
            return await GetConnection().CreateTableAsync<CompanyEndings>();
        }

        public void CreateCompanyNamesTable()
        {
            return await GetConnection().CreateTableAsync<CompanyNames>();
        }

        public void CreateDummyCompanyTable()
        {
            return await GetConnection().CreateTableAsync<DummyCompany>();
        }

        public void CreateMerchantTable()
        {
            return await GetConnection().CreateTableAsync<Merchant>();
        }

        public void CreateNamesTable()
        {
            return await GetConnection().CreateTableAsync<Names>();
        }

        public void CreateSoldTable()
        {
            return await GetConnection().CreateTableAsync<Sold>();
        }

        public void CreateStockTable()
        {
            return await GetConnection().CreateTableAsync<Stock>();
        }

        public void CreateStockHistoryTable()
        {
            return await GetConnection().CreateTableAsync<StockHistory>();
        }

        public void CreateStockMarketTable()
        {
            return await GetConnection().CreateTableAsync<StockMarket>();
        }

        public void CreateSurnamesTable()
        {
            return await GetConnection().CreateTableAsync<Surnames>();
        }

        public void CreateTaxesTable()
        {
            return await GetConnection().CreateTableAsync<Taxes>();
        }

        public void CreateAllTables()
        {
            CreateBoughtTable();
            CreateCompanyEndingsTable();
            CreateCompanyNamesTable();
            CreateDummyCompanyTable();
            CreateMerchantTable();
            CreateNamesTable();
            CreateSoldTable();
            CreateStockTable();
            CreateStockHistoryTable();
            CreateStockMarketTable();
            CreateSurnamesTable();
            CreateTaxesTable();
        }
    }
}