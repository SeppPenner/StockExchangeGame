using System.Threading.Tasks;

namespace StockExchangeGame.Database.Generic
{
    public interface IDatabaseAdapter
    {
        // ReSharper disable once UnusedMember.Global
        // ReSharper disable once UnusedMemberInSuper.Global
        SQLiteAsyncConnection GetConnection();

        // ReSharper disable once UnusedMember.Global
        Task<CreateTablesResult> CreateStockTable();

        // ReSharper disable once UnusedMember.Global
        Task<CreateTablesResult> CreateStockHistoryTable();
    }
}