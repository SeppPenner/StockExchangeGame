using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Languages.Interfaces;
using StockExchangeGame.Database.Models;

namespace StockExchangeGame.Database.Generic
{
    public class DatabaseAdapter : IDatabaseAdapter
    {
        private const string SqlDbFileName = "StockGame.sqlite3";
        private IEntityController<Bought> _boughtController;
        private IEntityController<CompanyEndings> _companyEndingsController;
        private IEntityController<CompanyNames> _companyNamesController;
        private SQLiteConnection _connection;
        private ILanguage _currentLanguage;
        private IEntityController<DummyCompany> _dummyCompanyController;
        private IEntityController<Merchant> _merchantController;
        private IEntityController<Names> _namesController;
        private IEntityController<Sold> _soldController;
        private IEntityController<Stock> _stockController;
        private IEntityController<StockHistory> _stockHistoryController;
        private IEntityController<StockMarket> _stockMarketController;
        private IEntityController<Surnames> _surnamesController;
        private IEntityController<Taxes> _taxesController;

        public DatabaseAdapter(ILanguage language)
        {
            this.InitializeControllers(this.GetConnectionString());
            this.SetCurrentLanguage(language);
            this.CreateDatabaseFileIfNotExists();
        }

        public void SetCurrentLanguage(ILanguage language)
        {
            this._currentLanguage = language;
            this.SetLanguages(language);
        }

        public ILanguage GetCurrentLanguage()
        {
            return this._currentLanguage;
        }

        public string GetConnectionString()
        {
            return @"Data Source=" + this.GetDatabasePath() + "; " +
                   @"Version=3; FailIfMissing=True; Foreign Keys=True;";
        }

        public string GetDatabasePath()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            return Path.Combine(Directory.GetParent(location).FullName, SqlDbFileName);
        }

        public void CreateBoughtTable()
        {
            this._boughtController.CreateTable();
        }

        public void CreateCompanyEndingsTable()
        {
            this._companyEndingsController.CreateTable();
        }

        public void CreateCompanyNamesTable()
        {
            this._companyNamesController.CreateTable();
        }

        public void CreateDummyCompanyTable()
        {
            this._dummyCompanyController.CreateTable();
        }

        public void CreateMerchantTable()
        {
            this._merchantController.CreateTable();
        }

        public void CreateNamesTable()
        {
            this._namesController.CreateTable();
        }

        public void CreateSoldTable()
        {
            this._soldController.CreateTable();
        }

        public void CreateStockTable()
        {
            this._stockController.CreateTable();
        }

        public void CreateStockHistoryTable()
        {
            this._stockHistoryController.CreateTable();
        }

        public void CreateStockMarketTable()
        {
            this._stockMarketController.CreateTable();
        }

        public void CreateSurnamesTable()
        {
            this._surnamesController.CreateTable();
        }

        public void CreateTaxesTable()
        {
            this._taxesController.CreateTable();
        }

        public void CreateAllTables()
        {
            this.CreateBoughtTable();
            this.CreateCompanyEndingsTable();
            this.CreateCompanyNamesTable();
            this.CreateDummyCompanyTable();
            this.CreateMerchantTable();
            this.CreateNamesTable();
            this.CreateSoldTable();
            this.CreateStockTable();
            this.CreateStockHistoryTable();
            this.CreateStockMarketTable();
            this.CreateSurnamesTable();
            this.CreateTaxesTable();
        }

        public List<T> Get<T>()
        {
            if (typeof(T) == typeof(Bought))
                return this._boughtController.Get() as List<T>;
            if (typeof(T) == typeof(CompanyEndings))
                return this._companyEndingsController.Get() as List<T>;
            if (typeof(T) == typeof(CompanyNames))
                return this._companyNamesController.Get() as List<T>;
            if (typeof(T) == typeof(DummyCompany))
                return this._dummyCompanyController.Get() as List<T>;
            if (typeof(T) == typeof(Merchant))
                return this._merchantController.Get() as List<T>;
            if (typeof(T) == typeof(Names))
                return this._namesController.Get() as List<T>;
            if (typeof(T) == typeof(Sold))
                return this._soldController.Get() as List<T>;
            if (typeof(T) == typeof(Stock))
                return this._stockController.Get() as List<T>;
            if (typeof(T) == typeof(StockHistory))
                return this._stockHistoryController.Get() as List<T>;
            if (typeof(T) == typeof(StockMarket))
                return this._stockMarketController.Get() as List<T>;
            if (typeof(T) == typeof(Surnames))
                return this._surnamesController.Get() as List<T>;
            if (typeof(T) == typeof(Taxes))
                return this._taxesController.Get() as List<T>;
            return null;
        }

        public T Get<T>(long id)
        {
            if (typeof(T) == typeof(Bought))
            {
                var value = this._boughtController.Get(id);
                return (T) Convert.ChangeType(value, typeof(T));
            }
            if (typeof(T) == typeof(CompanyEndings))
            {
                var value = this._companyEndingsController.Get(id);
                return (T) Convert.ChangeType(value, typeof(T));
            }
            if (typeof(T) == typeof(CompanyNames))
            {
                var value = this._companyNamesController.Get(id);
                return (T) Convert.ChangeType(value, typeof(T));
            }
            if (typeof(T) == typeof(DummyCompany))
            {
                var value = this._dummyCompanyController.Get(id);
                return (T) Convert.ChangeType(value, typeof(T));
            }
            if (typeof(T) == typeof(Merchant))
            {
                var value = this._merchantController.Get(id);
                return (T) Convert.ChangeType(value, typeof(T));
            }
            if (typeof(T) == typeof(Names))
            {
                var value = this._namesController.Get(id);
                return (T) Convert.ChangeType(value, typeof(T));
            }
            if (typeof(T) == typeof(Sold))
            {
                var value = this._soldController.Get(id);
                return (T) Convert.ChangeType(value, typeof(T));
            }
            if (typeof(T) == typeof(Stock))
            {
                var value = this._stockController.Get(id);
                return (T) Convert.ChangeType(value, typeof(T));
            }
            if (typeof(T) == typeof(StockHistory))
            {
                var value = this._stockHistoryController.Get(id);
                return (T) Convert.ChangeType(value, typeof(T));
            }
            if (typeof(T) == typeof(StockMarket))
            {
                var value = this._stockMarketController.Get(id);
                return (T) Convert.ChangeType(value, typeof(T));
            }
            if (typeof(T) == typeof(Surnames))
            {
                var value = this._surnamesController.Get(id);
                return (T) Convert.ChangeType(value, typeof(T));
            }
            if (typeof(T) != typeof(Taxes)) return (T) Convert.ChangeType(null, typeof(T));
            {
                var value = this._taxesController.Get(id);
                return (T) Convert.ChangeType(value, typeof(T));
            }
        }

        private void InitializeControllers(string connectionString)
        {
            this._connection = new SQLiteConnection(connectionString);
            this._boughtController = new BoughtController(this._connection);
            this._companyEndingsController = new CompanyEndingsController(this._connection);
            this._companyNamesController = new CompanyNamesController(this._connection);
            this._dummyCompanyController = new DummyCompanyController(this._connection);
            this._merchantController = new MerchantController(this._connection);
            this._namesController = new NamesController(this._connection);
            this._soldController = new SoldController(this._connection);
            this._stockController = new StockController(this._connection);
            this._stockHistoryController = new StockHistoryController(this._connection);
            this._stockMarketController = new StockMarketController(this._connection);
            this._surnamesController = new SurnamesController(this._connection);
            this._taxesController = new TaxesController(this._connection);
        }

        private void SetLanguages(ILanguage language)
        {
            this._boughtController.SetCurrentLanguage(language);
            this._boughtController.SetCurrentLanguage(language);
            this._companyEndingsController.SetCurrentLanguage(language);
            this._companyNamesController.SetCurrentLanguage(language);
            this._dummyCompanyController.SetCurrentLanguage(language);
            this._merchantController.SetCurrentLanguage(language);
            this._namesController.SetCurrentLanguage(language);
            this._soldController.SetCurrentLanguage(language);
            this._stockController.SetCurrentLanguage(language);
            this._stockHistoryController.SetCurrentLanguage(language);
            this._stockMarketController.SetCurrentLanguage(language);
            this._surnamesController.SetCurrentLanguage(language);
            this._taxesController.SetCurrentLanguage(language);
        }

        private void CreateDatabaseFileIfNotExists()
        {
            var databasePath = this.GetDatabasePath();
            if (File.Exists(databasePath))
            {
                this.CreateAllTables();
                return;
            }
            this.CreateDatabaseAndTables(databasePath);
        }

        private void CreateDatabaseAndTables(string databasePath)
        {
            File.Create(databasePath);
            this.CreateAllTables();
        }

        public ObservableCollection<T> Get<T, TValue>(Expression<Func<T, bool>> predicate = null,
            Expression<Func<T, TValue>> orderBy = null)
        {
            if (typeof(T) == typeof(Bought))
                return this._boughtController.Get(predicate as Expression<Func<Bought, bool>>,
                    orderBy as Expression<Func<Bought, TValue>>) as ObservableCollection<T>;
            if (typeof(T) == typeof(CompanyEndings))
                return this._companyEndingsController.Get(predicate as Expression<Func<CompanyEndings, bool>>,
                    orderBy as Expression<Func<CompanyEndings, TValue>>) as ObservableCollection<T>;
            if (typeof(T) == typeof(CompanyNames))
                return this._companyNamesController.Get(predicate as Expression<Func<CompanyNames, bool>>,
                    orderBy as Expression<Func<CompanyNames, TValue>>) as ObservableCollection<T>;
            if (typeof(T) == typeof(DummyCompany))
                return this._dummyCompanyController.Get(predicate as Expression<Func<DummyCompany, bool>>,
                    orderBy as Expression<Func<DummyCompany, TValue>>) as ObservableCollection<T>;
            if (typeof(T) == typeof(Merchant))
                return this._merchantController.Get(predicate as Expression<Func<Merchant, bool>>,
                    orderBy as Expression<Func<Merchant, TValue>>) as ObservableCollection<T>;
            if (typeof(T) == typeof(Names))
                return this._namesController.Get(predicate as Expression<Func<Names, bool>>,
                    orderBy as Expression<Func<Names, TValue>>) as ObservableCollection<T>;
            if (typeof(T) == typeof(Sold))
                return this._soldController.Get(predicate as Expression<Func<Sold, bool>>,
                    orderBy as Expression<Func<Sold, TValue>>) as ObservableCollection<T>;
            if (typeof(T) == typeof(Stock))
                return this._stockController.Get(predicate as Expression<Func<Stock, bool>>,
                    orderBy as Expression<Func<Stock, TValue>>) as ObservableCollection<T>;
            if (typeof(T) == typeof(StockHistory))
                return this._stockHistoryController.Get(predicate as Expression<Func<StockHistory, bool>>,
                    orderBy as Expression<Func<StockHistory, TValue>>) as ObservableCollection<T>;
            if (typeof(T) == typeof(StockMarket))
                return this._stockMarketController.Get(predicate as Expression<Func<StockMarket, bool>>,
                    orderBy as Expression<Func<StockMarket, TValue>>) as ObservableCollection<T>;
            if (typeof(T) == typeof(Surnames))
                return this._surnamesController.Get(predicate as Expression<Func<Surnames, bool>>,
                    orderBy as Expression<Func<Surnames, TValue>>) as ObservableCollection<T>;
            if (typeof(T) == typeof(Taxes))
                return this._taxesController.Get(predicate as Expression<Func<Taxes, bool>>,
                    orderBy as Expression<Func<Taxes, TValue>>) as ObservableCollection<T>;
            return null;
        }

        public T Get<T>(Expression<Func<T, bool>> predicate)
        {
            if (typeof(T) == typeof(Bought))
            {
                var value = this._boughtController.Get(predicate as Expression<Func<Bought, bool>>);
                return (T) Convert.ChangeType(value, typeof(T));
            }
            if (typeof(T) == typeof(CompanyEndings))
            {
                var value = this._companyEndingsController.Get(predicate as Expression<Func<CompanyEndings, bool>>);
                return (T) Convert.ChangeType(value, typeof(T));
            }
            if (typeof(T) == typeof(CompanyNames))
            {
                var value = this._companyNamesController.Get(predicate as Expression<Func<CompanyNames, bool>>);
                return (T) Convert.ChangeType(value, typeof(T));
            }
            if (typeof(T) == typeof(DummyCompany))
            {
                var value = this._dummyCompanyController.Get(predicate as Expression<Func<DummyCompany, bool>>);
                return (T) Convert.ChangeType(value, typeof(T));
            }
            if (typeof(T) == typeof(Merchant))
            {
                var value = this._merchantController.Get(predicate as Expression<Func<Merchant, bool>>);
                return (T) Convert.ChangeType(value, typeof(T));
            }
            if (typeof(T) == typeof(Names))
            {
                var value = this._namesController.Get(predicate as Expression<Func<Names, bool>>);
                return (T) Convert.ChangeType(value, typeof(T));
            }
            if (typeof(T) == typeof(Sold))
            {
                var value = this._soldController.Get(predicate as Expression<Func<Sold, bool>>);
                return (T) Convert.ChangeType(value, typeof(T));
            }
            if (typeof(T) == typeof(Stock))
            {
                var value = this._stockController.Get(predicate as Expression<Func<Stock, bool>>);
                return (T) Convert.ChangeType(value, typeof(T));
            }
            if (typeof(T) == typeof(StockHistory))
            {
                var value = this._stockHistoryController.Get(predicate as Expression<Func<StockHistory, bool>>);
                return (T) Convert.ChangeType(value, typeof(T));
            }
            if (typeof(T) == typeof(StockMarket))
            {
                var value = this._stockMarketController.Get(predicate as Expression<Func<StockMarket, bool>>);
                return (T) Convert.ChangeType(value, typeof(T));
            }
            if (typeof(T) == typeof(Surnames))
            {
                var value = this._surnamesController.Get(predicate as Expression<Func<Surnames, bool>>);
                return (T) Convert.ChangeType(value, typeof(T));
            }
            if (typeof(T) != typeof(Taxes)) return (T) Convert.ChangeType(null, typeof(T));
            {
                var value = this._taxesController.Get(predicate as Expression<Func<Taxes, bool>>);
                return (T) Convert.ChangeType(value, typeof(T));
            }
        }

        public int Insert<T>(T entity)
        {
            if (typeof(T) == typeof(Bought))
                return this._boughtController.Insert(entity as Bought);
            if (typeof(T) == typeof(CompanyEndings))
                return this._companyEndingsController.Insert(entity as CompanyEndings);
            if (typeof(T) == typeof(CompanyNames))
                return this._companyNamesController.Insert(entity as CompanyNames);
            if (typeof(T) == typeof(DummyCompany))
                return this._dummyCompanyController.Insert(entity as DummyCompany);
            if (typeof(T) == typeof(Merchant))
                return this._merchantController.Insert(entity as Merchant);
            if (typeof(T) == typeof(Names))
                return this._namesController.Insert(entity as Names);
            if (typeof(T) == typeof(Sold))
                return this._soldController.Insert(entity as Sold);
            if (typeof(T) == typeof(Stock))
                return this._stockController.Insert(entity as Stock);
            if (typeof(T) == typeof(StockHistory))
                return this._stockHistoryController.Insert(entity as StockHistory);
            if (typeof(T) == typeof(StockMarket))
                return this._stockMarketController.Insert(entity as StockMarket);
            if (typeof(T) == typeof(Surnames))
                return this._surnamesController.Insert(entity as Surnames);
            if (typeof(T) == typeof(Taxes))
                return this._taxesController.Insert(entity as Taxes);
            return -1;
        }

        public int Update<T>(T entity)
        {
            if (typeof(T) == typeof(Bought))
                return this._boughtController.Update(entity as Bought);
            if (typeof(T) == typeof(CompanyEndings))
                return this._companyEndingsController.Update(entity as CompanyEndings);
            if (typeof(T) == typeof(CompanyNames))
                return this._companyNamesController.Update(entity as CompanyNames);
            if (typeof(T) == typeof(DummyCompany))
                return this._dummyCompanyController.Update(entity as DummyCompany);
            if (typeof(T) == typeof(Merchant))
                return this._merchantController.Update(entity as Merchant);
            if (typeof(T) == typeof(Names))
                return this._namesController.Update(entity as Names);
            if (typeof(T) == typeof(Sold))
                return this._soldController.Update(entity as Sold);
            if (typeof(T) == typeof(Stock))
                return this._stockController.Update(entity as Stock);
            if (typeof(T) == typeof(StockHistory))
                return this._stockHistoryController.Update(entity as StockHistory);
            if (typeof(T) == typeof(StockMarket))
                return this._stockMarketController.Update(entity as StockMarket);
            if (typeof(T) == typeof(Surnames))
                return this._surnamesController.Update(entity as Surnames);
            if (typeof(T) == typeof(Taxes))
                return this._taxesController.Update(entity as Taxes);
            return -1;
        }

        public int Delete<T>(T entity)
        {
            if (typeof(T) == typeof(Bought))
                return this._boughtController.Delete(entity as Bought);
            if (typeof(T) == typeof(CompanyEndings))
                return this._companyEndingsController.Delete(entity as CompanyEndings);
            if (typeof(T) == typeof(CompanyNames))
                return this._companyNamesController.Delete(entity as CompanyNames);
            if (typeof(T) == typeof(DummyCompany))
                return this._dummyCompanyController.Delete(entity as DummyCompany);
            if (typeof(T) == typeof(Merchant))
                return this._merchantController.Delete(entity as Merchant);
            if (typeof(T) == typeof(Names))
                return this._namesController.Delete(entity as Names);
            if (typeof(T) == typeof(Sold))
                return this._soldController.Delete(entity as Sold);
            if (typeof(T) == typeof(Stock))
                return this._stockController.Delete(entity as Stock);
            if (typeof(T) == typeof(StockHistory))
                return this._stockHistoryController.Delete(entity as StockHistory);
            if (typeof(T) == typeof(StockMarket))
                return this._stockMarketController.Delete(entity as StockMarket);
            if (typeof(T) == typeof(Surnames))
                return this._surnamesController.Delete(entity as Surnames);
            if (typeof(T) == typeof(Taxes))
                return this._taxesController.Delete(entity as Taxes);
            return -1;
        }

        public int Insert<T>(List<T> entities)
        {
            return entities.Sum(this.Insert);
        }

        public int Update<T>(List<T> entities)
        {
            return entities.Sum(this.Update);
        }

        public int Delete<T>(List<T> entities)
        {
            return entities.Sum(this.Delete);
        }

        public int Count<T>(Expression<Func<T, bool>> predicate = null)
        {
            if (typeof(T) == typeof(Bought))
                return this._boughtController.Count(predicate as Expression<Func<Bought, bool>>);
            if (typeof(T) == typeof(CompanyEndings))
                return this._companyEndingsController.Count(predicate as Expression<Func<CompanyEndings, bool>>);
            if (typeof(T) == typeof(CompanyNames))
                return this._companyNamesController.Count(predicate as Expression<Func<CompanyNames, bool>>);
            if (typeof(T) == typeof(DummyCompany))
                return this._dummyCompanyController.Count(predicate as Expression<Func<DummyCompany, bool>>);
            if (typeof(T) == typeof(Merchant))
                return this._merchantController.Count(predicate as Expression<Func<Merchant, bool>>);
            if (typeof(T) == typeof(Names))
                return this._namesController.Count(predicate as Expression<Func<Names, bool>>);
            if (typeof(T) == typeof(Sold))
                return this._soldController.Count(predicate as Expression<Func<Sold, bool>>);
            if (typeof(T) == typeof(Stock))
                return this._stockController.Count(predicate as Expression<Func<Stock, bool>>);
            if (typeof(T) == typeof(StockHistory))
                return this._stockHistoryController.Count(predicate as Expression<Func<StockHistory, bool>>);
            if (typeof(T) == typeof(StockMarket))
                return this._stockMarketController.Count(predicate as Expression<Func<StockMarket, bool>>);
            if (typeof(T) == typeof(Surnames))
                return this._surnamesController.Count(predicate as Expression<Func<Surnames, bool>>);
            if (typeof(T) == typeof(Taxes))
                return this._taxesController.Count(predicate as Expression<Func<Taxes, bool>>);
            return -1;
        }

        public void Truncate<T>()
        {
            if (typeof(T) == typeof(Bought))
            {
                this._boughtController.Truncate();
                return;
            }
            if (typeof(T) == typeof(CompanyEndings))
            {
                this._companyEndingsController.Truncate();
                return;
            }
            if (typeof(T) == typeof(CompanyNames))
            {
                this._companyNamesController.Truncate();
                return;
            }
            if (typeof(T) == typeof(DummyCompany))
            {
                this._dummyCompanyController.Truncate();
                return;
            }
            if (typeof(T) == typeof(Merchant))
            {
                this._merchantController.Truncate();
                return;
            }
            if (typeof(T) == typeof(Names))
            {
                this._namesController.Truncate();
                return;
            }
            if (typeof(T) == typeof(Sold))
            {
                this._soldController.Truncate();
                return;
            }
            if (typeof(T) == typeof(Stock))
            {
                this._stockController.Truncate();
                return;
            }
            if (typeof(T) == typeof(StockHistory))
            {
                this._stockHistoryController.Truncate();
                return;
            }
            if (typeof(T) == typeof(StockMarket))
            {
                this._stockMarketController.Truncate();
                return;
            }
            if (typeof(T) == typeof(Surnames))
            {
                this._surnamesController.Truncate();
                return;
            }
            if (typeof(T) == typeof(Taxes))
                this._taxesController.Truncate();
        }
    }
}