using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Languages.Interfaces;

namespace StockExchangeGame.Database.Generic
{
    public interface IDatabaseAdapter
    {
        void SetCurrentLanguage(ILanguage language);

        ILanguage GetCurrentLanguage();

        string GetDatabasePath();

        string GetConnectionString();

        void CreateBoughtTable();

        void CreateCompanyEndingsTable();

        void CreateCompanyNamesTable();

        void CreateDummyCompanyTable();

        void CreateMerchantTable();

        void CreateNamesTable();

        void CreateSoldTable();

        void CreateStockTable();

        void CreateStockHistoryTable();

        void CreateStockMarketTable();

        void CreateSurnamesTable();

        void CreateTaxesTable();

        void CreateAllTables();

        List<T> Get<T>();

        T Get<T>(long id);

        ObservableCollection<T> Get<T, TValue>(Expression<Func<T, bool>> predicate = null,
            Expression<Func<T, TValue>> orderBy = null);

        T Get<T>(Expression<Func<T, bool>> predicate);

        int Insert<T>(T entity);

        int Update<T>(T entity);

        int Delete<T>(T entity);

        int Insert<T>(List<T>entities);

        int Update<T>(List<T> entities);

        int Delete<T>(List<T> entities);

        int Count<T>(Expression<Func<T, bool>> predicate = null);

        void Truncate<T>();
    }
}