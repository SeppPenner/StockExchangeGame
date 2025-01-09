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
            this.InitializeComponent();
            this.InitBackgroundWorker();
        }

        public IDatabaseAdapter DatabaseAdapter { get; set; }

        private void InitBackgroundWorker()
        {
            this._dataLoader.DoWork += this.DataLoaderWork;
            this._dataLoader.RunWorkerAsync();
        }

        private void DataLoaderWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            this.AddSolds();
            this.AddBoughts();
        }

        private void AddBoughts()
        {
            var boughts = this.DatabaseAdapter.Get<Bought>();
            foreach (var bought in boughts)
                this.AddBoughtsToDataGridView(bought);
        }

        private void AddBoughtsToDataGridView(Bought bought)
        {
            var merchant = this.DatabaseAdapter.Get<Merchant>(bought.MerchantId);
            var stock = this.DatabaseAdapter.Get<Stock>(bought.StockId);
            this.UiThreadInvoke(() =>
            {
                this.dataGridViewBoughtStocks.Rows.Add(
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
            var solds = this.DatabaseAdapter.Get<Sold>();
            foreach (var sold in solds)
                this.AddSoldsToDataGridView(sold);
        }

        private void AddSoldsToDataGridView(Sold sold)
        {
            var merchant = this.DatabaseAdapter.Get<Merchant>(sold.MerchantId);
            var stock = this.DatabaseAdapter.Get<Stock>(sold.StockId);
            this.UiThreadInvoke(() =>
            {
                this.dataGridViewSoldStocks.Rows.Add(
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
            var boughts = this.DatabaseAdapter.Get<Bought>();
            var companyEndings = this.DatabaseAdapter.Get<CompanyEndings>();
            var companyNames = this.DatabaseAdapter.Get<CompanyNames>();
            var dummyCompanies = this.DatabaseAdapter.Get<DummyCompany>();
            var merchants = this.DatabaseAdapter.Get<Merchant>();
            var names = this.DatabaseAdapter.Get<Names>();
            var solds = this.DatabaseAdapter.Get<Sold>();
            var stocks = this.DatabaseAdapter.Get<Stock>();
            var stockHistories = this.DatabaseAdapter.Get<StockHistory>();
            var stockMarkets = this.DatabaseAdapter.Get<StockMarket>();
            var surnames = this.DatabaseAdapter.Get<Surnames>();
            var taxes = this.DatabaseAdapter.Get<Taxes>();
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