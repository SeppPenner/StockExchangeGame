using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace StockExchangeGame.Database.Generic
{
    public interface IDatabaseAdapter
    {
        // ReSharper disable once UnusedMemberInSuper.Global
        string GetDatabasePath();

        // ReSharper disable once UnusedMemberInSuper.Global
        SQLiteConnection GetConnection();

        // ReSharper disable once UnusedMember.Global
        // ReSharper disable once UnusedMemberInSuper.Global
        Task<CreateTablesResult> CreateBoughtTable();

        // ReSharper disable once UnusedMember.Global
        // ReSharper disable once UnusedMemberInSuper.Global
        Task<CreateTablesResult> CreateCompanyEndingsTable();

        // ReSharper disable once UnusedMember.Global
        // ReSharper disable once UnusedMemberInSuper.Global
        Task<CreateTablesResult> CreateCompanyNamesTable();

        // ReSharper disable once UnusedMember.Global
        // ReSharper disable once UnusedMemberInSuper.Global
        Task<CreateTablesResult> CreateDummyCompanyTable();

        // ReSharper disable once UnusedMember.Global
        // ReSharper disable once UnusedMemberInSuper.Global
        Task<CreateTablesResult> CreateMerchantTable();

        // ReSharper disable once UnusedMember.Global
        // ReSharper disable once UnusedMemberInSuper.Global
        Task<CreateTablesResult> CreateNamesTable();

        // ReSharper disable once UnusedMember.Global
        // ReSharper disable once UnusedMemberInSuper.Global
        Task<CreateTablesResult> CreateSoldTable();

        // ReSharper disable once UnusedMember.Global
        // ReSharper disable once UnusedMemberInSuper.Global
        Task<CreateTablesResult> CreateStockTable();

        // ReSharper disable once UnusedMember.Global
        // ReSharper disable once UnusedMemberInSuper.Global
        Task<CreateTablesResult> CreateStockHistoryTable();

        // ReSharper disable once UnusedMember.Global
        // ReSharper disable once UnusedMemberInSuper.Global
        Task<CreateTablesResult> CreateStockMarketTable();

        // ReSharper disable once UnusedMember.Global
        // ReSharper disable once UnusedMemberInSuper.Global
        Task<CreateTablesResult> CreateSurnamesTable();

        // ReSharper disable once UnusedMember.Global
        // ReSharper disable once UnusedMemberInSuper.Global
        Task<CreateTablesResult> CreateTaxesTable();

        // ReSharper disable once UnusedMember.Global
        // ReSharper disable once UnusedMemberInSuper.Global
        Task<List<CreateTablesResult>> CreateAllTables();
    }
}