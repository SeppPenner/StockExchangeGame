using System;
using System.Collections.Generic;
using StockExchangeGame.Database.Generic;
using StockExchangeGame.Database.Models;

namespace StockExchangeGame.DummyData
{
    // ReSharper disable once UnusedMember.Global
    public class DummyDataGenerator: IDummyDataGenerator
    {
        private readonly IDatabaseAdapter _databaseAdapter;
        public DummyDataGenerator(IDatabaseAdapter databaseAdapter)
        {
            _databaseAdapter = databaseAdapter;
        }

        public void GenerateDummyData()
        {
            var boughts = _databaseAdapter.Insert(GenerateBoughts);
            var companyEndings = _databaseAdapter.Insert(GenerateCompanyEndings);
            var companyNames = _databaseAdapter.Insert(GenerateCompanyNames);
            var dummyCompanies = _databaseAdapter.Insert(GenerateDummyCompanies);
            var merchants = _databaseAdapter.Insert(GenerateMerchants);
            var names = _databaseAdapter.Insert(GenerateNames);
            var solds = _databaseAdapter.Insert(GenerateSolds);
            var stocks = _databaseAdapter.Insert(GenerateStocks);
            var stockHistories = _databaseAdapter.Insert(GenerateStockHistory);
            var stockMarkets = _databaseAdapter.Insert(GenerateStockMarkets);
            var surnames = _databaseAdapter.Insert(GenerateSurnames);
            var taxes = _databaseAdapter.Insert(GenerateTaxes);
        }

        private List<Sold> GenerateSolds { get; } = new List<Sold>
        {
            new Sold
            {
                Id = 0,
                StockId = 2,
                Amount = 300,
                MerchantId = 0,
                ValuePerStockInEuro = 150,
                DateSold = DateTime.Now,
                Deleted = false
            },
            new Sold
            {
                Id = 1,
                StockId = 2,
                Amount = 150,
                MerchantId = 0,
                ValuePerStockInEuro = 190,
                DateSold = DateTime.Now.AddDays(-1),
                Deleted = false
            },
            new Sold
            {
                Id = 2,
                StockId = 1,
                Amount = 100,
                MerchantId = 1,
                ValuePerStockInEuro = 320,
                DateSold = DateTime.Now.AddMonths(-1),
                Deleted = false
            }
        };

        private List<Bought> GenerateBoughts { get; } = new List<Bought>
        {
            new Bought
            {
                Id = 0,
                StockId = 0,
                Amount = 100,
                MerchantId = 0,
                ValuePerStockInEuro = 100,
                DateBought = DateTime.Now,
                Deleted = false
            },
            new Bought
            {
                Id = 1,
                StockId = 0,
                Amount = 250,
                MerchantId = 0,
                ValuePerStockInEuro = 170,
                DateBought = DateTime.Now,
                Deleted = false
            },
            new Bought
            {
                Id = 2,
                StockId = 1,
                Amount = 500,
                MerchantId = 1,
                ValuePerStockInEuro = 300,
                DateBought = DateTime.Now,
                Deleted = false
            }
        };

        private List<StockHistory> GenerateStockHistory { get; } = new List<StockHistory>
        {
            new StockHistory
            {
                Id = 0,
                StockId = 0,
                PriceDate = DateTime.Now,
                PricePerStock = 100,
                Deleted = false
            },
            new StockHistory
            {
                Id = 1,
                StockId = 0,
                PriceDate = DateTime.Now.AddMonths(-1),
                PricePerStock = 300,
                Deleted = false
            },
            new StockHistory
            {
                Id = 2,
                StockId = 0,
                PriceDate = DateTime.Now.AddMonths(-2),
                PricePerStock = 170,
                Deleted = false
            }
        };

        private List<StockMarket> GenerateStockMarkets { get; } = new List<StockMarket>
        {
            new StockMarket
            {
                Id = 0,
                Name = "New York stock exchange",
                Deleted = false
            },
            new StockMarket
            {
                Id = 1,
                Name = "Japan stock exchange",
                Deleted = false
            },
            new StockMarket
            {
                Id = 2,
                Name = "Frankfurter Börse",
                Deleted = false
            }
        };

        private List<Taxes> GenerateTaxes { get; } = new List<Taxes>
        {
            new Taxes
            {
                Id = 0,
                DateTaxWasDue = DateTime.Now,
                DueInEuro = 1000,
                MerchantId = 0,
                PayedInEuro = 0,
                Deleted = false
            },
            new Taxes
            {
                Id = 1,
                DateTaxWasDue = DateTime.Now,
                DueInEuro = 2000,
                MerchantId = 1,
                PayedInEuro = 20,
                Deleted = false
            },
            new Taxes
            {
                Id = 2,
                DateTaxWasDue = DateTime.Now,
                DueInEuro = 5000,
                MerchantId = 2,
                PayedInEuro = 100,
                Deleted = false
            }
        };

        private List<DummyCompany> GenerateDummyCompanies { get; } = new List<DummyCompany>
        {
            new DummyCompany
            {
                Id = 0,
                Name = "Secure Bank OHG",
                Deleted = false
            },
            new DummyCompany
            {
                Id = 1,
                Name = "Alibaba Ihali eG",
                Deleted = false
            },
            new DummyCompany
            {
                Id = 2,
                Name = "Winklmoser EWIV",
                Deleted = false
            }
        };

        private List<Surnames> GenerateSurnames { get; } = new List<Surnames>
        {
            new Surnames
            {
                Id = 0,
                Name = "Meier",
                Deleted = false
            },
            new Surnames
            {
                Id = 1,
                Name = "Huber",
                Deleted = false
            },
            new Surnames
            {
                Id = 2,
                Name = "Winklmoser",
                Deleted = false
            }
        };

        private List<Names> GenerateNames { get; } = new List<Names>
        {
            new Names
            {
                Id = 0,
                Name = "Hans",
                Deleted = false
            },
            new Names
            {
                Id = 1,
                Name = "Franz",
                Deleted = false
            },
            new Names
            {
                Id = 2,
                Name = "Detlev",
                Deleted = false
            }
        };

        private List<Merchant> GenerateMerchants { get; } = new List<Merchant>
        {
            new Merchant
            {
                Id = 0,
                Name = "Sepp Meier",
                Deleted = false,
                LiquidFundsInEuro = 150000
            },
            new Merchant
            {
                Id = 1,
                Name = "Jack Swagger",
                Deleted = false,
                LiquidFundsInEuro = 120000
            },
            new Merchant
            {
                Id = 2,
                Name = "Bill Gates",
                Deleted = false,
                LiquidFundsInEuro = 130000
            }
        };

        private List<CompanyNames> GenerateCompanyNames { get; } = new List<CompanyNames>
        {
            new CompanyNames
            {
                Id = 0,
                Name = "Alphabet",
                Deleted = false
            },
            new CompanyNames
            {
                Id = 1,
                Name = "Hans Meier",
                Deleted = false
            },
            new CompanyNames
            {
                Id = 2,
                Name = "Tesla Motors",
                Deleted = false
            }
        };

        private List<CompanyEndings> GenerateCompanyEndings { get; } = new List<CompanyEndings>
        {
            new CompanyEndings
            {
                Id = 0,
                Name = "e.K.",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 1,
                Name = "e. Kfm.",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 2,
                Name = "e. Kfr.",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 3,
                Name = "OHG",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 4,
                Name = "EWIV",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 5,
                Name = "KG",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 6,
                Name = "GmbH",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 7,
                Name = "gGmbH",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 8,
                Name = "UG",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 9,
                Name = "AG",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 10,
                Name = "SE",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 11,
                Name = "VVaG",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 12,
                Name = "eG",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 13,
                Name = "SCE",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 14,
                Name = "eGmbH",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 15,
                Name = "eGmuH",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 16,
                Name = "KGaA",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 17,
                Name = " GmbH & Co.KG",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 18,
                Name = "AG & Co.KG",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 19,
                Name = "GmbH & Co.KGaA",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 20,
                Name = "AG & Co.KGaA",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 21,
                Name = "GbR",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 22,
                Name = "SUP",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 23,
                Name = "Limited & Co.KG",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 24,
                Name = "Stiftung & Co.KG",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 25,
                Name = "Stiftung GmbH & Co.KG",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 26,
                Name = "UG(haftungsbeschränkt) & Co.KG",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 27,
                Name = "Eigenbetrieb",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 28,
                Name = "Einzelunternehmen",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 29,
                Name = "e.V.",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 30,
                Name = "AöR",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 31,
                Name = "KöR",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 32,
                Name = "Regiebetrieb",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 33,
                Name = "Stiftung",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 34,
                Name = "gAG",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 35,
                Name = "InvAG",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 36,
                Name = "KGaA",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 37,
                Name = "GmbH & Co.OHG",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 38,
                Name = "AG & Co.OHG",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 39,
                Name = "Partenreederei",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 40,
                Name = "PartG",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 41,
                Name = "PartG mbB",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 42,
                Name = "Stille Gesellschaft",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 43,
                Name = "SE & Co.KGaA",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 44,
                Name = "PartG mbB",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 45,
                Name = "Stiftung & Co.KGaA",
                Deleted = false
            },
            new CompanyEndings
            {
                Id = 46,
                Name = "REIT-AG",
                Deleted = false
            }
        };

        private List<Stock> GenerateStocks { get; } = new List<Stock>
        {
            new Stock
            {
                Id = 0,
                Name = "Alphabet Inc.",
                Total = 1000,
                Used = 350,
                StockMarketId = 0,
                Deleted = false
            },
            new Stock
            {
                Id = 1,
                Name = "Apple Inc.",
                Total = 900,
                Used = 500,
                StockMarketId = 0,
                Deleted = false
            },
            new Stock
            {
                Id = 2,
                Name = "Tesla Motors",
                Total = 700,
                Used = 0,
                StockMarketId = 0,
                Deleted = false
            },
            new Stock
            {
                Id = 3,
                Name = "Fuihatsui Inc.",
                Total = 1900,
                Used = 0,
                StockMarketId = 1,
                Deleted = false
            }
        };
    }
}