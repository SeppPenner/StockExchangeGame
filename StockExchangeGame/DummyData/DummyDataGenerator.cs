using System.Collections.Generic;
using StockExchangeGame.Database.Generic;
using StockExchangeGame.Database.Models;

namespace StockExchangeGame.DummyData
{
    // ReSharper disable once UnusedMember.Global
    public class DummyDataGenerator: IDummyDataGenerator
    {
        private IDatabaseAdapter _databaseAdapter;
        public DummyDataGenerator(IDatabaseAdapter databaseAdapter)
        {
            _databaseAdapter = databaseAdapter;
        }

        public void GenerateDummyData()
        {

            var insertedStocks = _databaseAdapter.Insert(GenerateStocks);


        }

        private List<Stock> GenerateStocks { get; } = new List<Stock>
        {
            new Stock
            {
                Id = 0,
                Name = "Alphabet Inc.",
                Total = 1000,
                Used = 0,
                Deleted = false
            },
            new Stock
            {
                Id = 0,
                Name = "Apple Inc.",
                Total = 900,
                Used = 0,
                Deleted = false
            },
            new Stock
            {
                Id = 0,
                Name = "Tesla Motors",
                Total = 700,
                Used = 0,
                Deleted = false
            }
        };
    }
}