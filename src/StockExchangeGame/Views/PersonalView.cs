using System;
using System.ComponentModel;
using System.Windows.Forms;
using StockExchangeGame.Database.Generic;
using StockExchangeGame.Database.Models;
using StockExchangeGame.Dialogs;
using StockExchangeGame.UiThreadInvoke;

namespace StockExchangeGame.Views
{
    public partial class PersonalView : UserControl
    {
        private readonly BackgroundWorker _dataLoader = new BackgroundWorker();

        public PersonalView()
        {
            InitializeComponent();
            InitBackgroundWorker();
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public IDatabaseAdapter DatabaseAdapter { get; set; }

        private void InitBackgroundWorker()
        {
            _dataLoader.DoWork += DataLoaderWork;
            _dataLoader.RunWorkerAsync();
        }

        private void DataLoaderWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            AddSolds();
            AddBoughts();
        }

        private void AddBoughts()
        {
            var boughts = DatabaseAdapter.Get<Bought>();
            foreach (var bought in boughts)
                AddBoughtsToDataGridView(bought);
        }

        private void AddBoughtsToDataGridView(Bought bought)
        {
            var merchant = DatabaseAdapter.Get<Merchant>(bought.MerchantId);
            var stock = DatabaseAdapter.Get<Stock>(bought.StockId);
            this.UiThreadInvoke(() =>
            {
                dataGridViewBoughtStocks.Rows.Add(
                    bought.Id.ToString(),
                    bought.Amount.ToString(),
                    bought.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                    bought.DateBought.ToString("yyyy-MM-dd HH:mm:ss"),
                    bought.Deleted.ToString(),
                    bought.MerchantId.ToString(),
                    merchant.Name,
                    bought.ModifiedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                    bought.StockId.ToString(),
                    stock.Name,
                    bought.ValuePerStockInEuro
                );
            });
        }

        private void AddSolds()
        {
            var solds = DatabaseAdapter.Get<Sold>();
            foreach (var sold in solds)
                AddSoldsToDataGridView(sold);
        }

        private void AddSoldsToDataGridView(Sold sold)
        {
            var merchant = DatabaseAdapter.Get<Merchant>(sold.MerchantId);
            var stock = DatabaseAdapter.Get<Stock>(sold.StockId);
            this.UiThreadInvoke(() =>
            {
                dataGridViewSoldStocks.Rows.Add(
                    sold.Id.ToString(),
                    sold.Amount.ToString(),
                    sold.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                    sold.DateSold.ToString("yyyy-MM-dd HH:mm:ss"),
                    sold.Deleted.ToString(),
                    sold.MerchantId.ToString(),
                    merchant.Name,
                    sold.ModifiedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                    sold.StockId.ToString(),
                    stock.Name,
                    sold.ValuePerStockInEuro
                );
            });
        }

        private void DummyMethod()
        {
            var boughts = DatabaseAdapter.Get<Bought>();
            var companyEndings = DatabaseAdapter.Get<CompanyEndings>();
            var companyNames = DatabaseAdapter.Get<CompanyNames>();
            var dummyCompanies = DatabaseAdapter.Get<DummyCompany>();
            var merchants = DatabaseAdapter.Get<Merchant>();
            var names = DatabaseAdapter.Get<Names>();
            var solds = DatabaseAdapter.Get<Sold>();
            var stocks = DatabaseAdapter.Get<Stock>();
            var stockHistories = DatabaseAdapter.Get<StockHistory>();
            var stockMarkets = DatabaseAdapter.Get<StockMarket>();
            var surnames = DatabaseAdapter.Get<Surnames>();
            var taxes = DatabaseAdapter.Get<Taxes>();
        }

        private void ButtonNewDummyCompany_Click(object sender, EventArgs e)
        {
            new CreateNewDummyCompany().ShowDialog();
        }

        private void ButtonLiquidFundsToCompany_Click(object sender, EventArgs e)
        {
            new MoveFundsToDummyCompany().ShowDialog();
        }

        private void ButtonCaptialIncrease_Click(object sender, EventArgs e)
        {
            new CapitalIncrease().ShowDialog();
        }

        private void ButtonBuyNewStocks_Click(object sender, EventArgs e)
        {
            new BuyStocks().ShowDialog();
        }

        private void ButtonSellStocks_Click(object sender, EventArgs e)
        {
            new SellStocks().ShowDialog();
        }
    }
}