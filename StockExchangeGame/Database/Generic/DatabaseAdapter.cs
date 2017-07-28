using System.IO;
using System.Reflection;
using StockExchangeGame.Database.Models;

namespace StockExchangeGame.Database.Generic
{
    // ReSharper disable once UnusedMember.Global
    public class DatabaseAdapter : IDatabaseAdapter
    {
        private readonly IEntityController<Bought> _boughtController;
        private readonly IEntityController<CompanyEndings> _companyEndingsController;
        private readonly IEntityController<CompanyNames> _companyNamesController;
        private readonly IEntityController<DummyCompany> _dummyCompanyController;
        private readonly IEntityController<Merchant> _merchantController;
        private readonly IEntityController<Names> _namesController;
        private readonly IEntityController<Sold> _soldController;
        private readonly IEntityController<Stock> _stockController;
        private readonly IEntityController<StockHistory> _stockHistoryController;
        private readonly IEntityController<StockMarket> _stockMarketController;
        private readonly IEntityController<Surnames> _surnamesController;
        private const string SqlDbFileName = "StockGame.sqlite3";

        public DatabaseAdapter()
        {
            var connectionString = GetConnectionString();
            _boughtController = new BoughtController(connectionString);
            _companyEndingsController = new CompanyEndingsController(connectionString);
            _companyNamesController = new CompanyNamesController(connectionString);
            _dummyCompanyController = new DummyCompanyController(connectionString);
            _merchantController = new MerchantController(connectionString);
            _namesController = new NamesController(connectionString);
            _soldController = new SoldController(connectionString);
            _stockController = new StockController(connectionString);
            _stockHistoryController = new StockHistoryController(connectionString);
            _stockMarketController = new StockMarketController(connectionString);
            _surnamesController = new SurnamesController(connectionString);
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
            _companyEndingsController.CreateTable();
        }

        public void CreateCompanyNamesTable()
        {
            _companyNamesController.CreateTable();
        }

        public void CreateDummyCompanyTable()
        {
            _dummyCompanyController.CreateTable();
        }

        public void CreateMerchantTable()
        {
            _merchantController.CreateTable();
        }

        public void CreateNamesTable()
        {
            _namesController.CreateTable();
        }

        public void CreateSoldTable()
        {
            _soldController.CreateTable();
        }

        public void CreateStockTable()
        {
            _stockController.CreateTable();
        }

        public void CreateStockHistoryTable()
        {
            _stockHistoryController.CreateTable();
        }

        public void CreateStockMarketTable()
        {
            _stockMarketController.CreateTable();
        }

        public void CreateSurnamesTable()
        {
            _surnamesController.CreateTable();
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