using System.IO;
using System.Reflection;
using Languages.Interfaces;
using StockExchangeGame.Database.Models;

namespace StockExchangeGame.Database.Generic
{
    // ReSharper disable once UnusedMember.Global
    public class DatabaseAdapter : IDatabaseAdapter
    {
        private IEntityController<Bought> _boughtController;
        private IEntityController<CompanyEndings> _companyEndingsController;
        private IEntityController<CompanyNames> _companyNamesController;
        private IEntityController<DummyCompany> _dummyCompanyController;
        private IEntityController<Merchant> _merchantController;
        private IEntityController<Names> _namesController;
        private IEntityController<Sold> _soldController;
        private IEntityController<Stock> _stockController;
        private IEntityController<StockHistory> _stockHistoryController;
        private IEntityController<StockMarket> _stockMarketController;
        private IEntityController<Surnames> _surnamesController;
        private IEntityController<Taxes> _taxesController;
        private const string SqlDbFileName = "StockGame.sqlite3";
        private ILanguage _currentLanguage;

        public void SetCurrentLanguage(ILanguage language)
        {
            _currentLanguage = language;
            SetLanguages(language);
        }

        public ILanguage GetCurrentLanguage()
        {
            return _currentLanguage;
        }

        public void Init(ILanguage language)
        {
            CreateDatabaseFileIfNotExists();
            InitializeControllers(GetConnectionString());
            SetCurrentLanguage(language);
        }

        private void InitializeControllers(string connectionString)
        {
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
            _taxesController = new TaxesController(connectionString);
        }

        private void SetLanguages(ILanguage language)
        {
            _boughtController.SetCurrentLanguage(language);
            _boughtController.SetCurrentLanguage(language);
            _companyEndingsController.SetCurrentLanguage(language);
            _companyNamesController.SetCurrentLanguage(language);
            _dummyCompanyController.SetCurrentLanguage(language);
            _merchantController.SetCurrentLanguage(language);
            _namesController.SetCurrentLanguage(language);
            _soldController.SetCurrentLanguage(language);
            _stockController.SetCurrentLanguage(language);
            _stockHistoryController.SetCurrentLanguage(language);
            _stockMarketController.SetCurrentLanguage(language);
            _surnamesController.SetCurrentLanguage(language);
            _taxesController.SetCurrentLanguage(language);
        }

        private void CreateDatabaseFileIfNotExists()
        {
            var databasePath = GetDatabasePath();
            if (File.Exists(databasePath)) return;
            CreateDatabaseAndTables(databasePath);
        }

        private void CreateDatabaseAndTables(string databasePath)
        {
            File.Create(databasePath);
            CreateAllTables();
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
            _taxesController.CreateTable();
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