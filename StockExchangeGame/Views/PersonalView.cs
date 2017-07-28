using System.ComponentModel;
using System.Windows.Forms;
using StockExchangeGame.Database.Generic;
using StockExchangeGame.Database.Models;
using StockExchangeGame.Dialogs;

namespace StockExchangeGame.Views
{
    public partial class PersonalView : UserControl
    {
        private readonly BackgroundWorker _dataLoader = new BackgroundWorker();
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public IDatabaseAdapter DatabaseAdapter { get; set; }

        public PersonalView()
        {
            InitializeComponent();
            InitBackgroundWorker();
        }

        private void InitBackgroundWorker()
        {
            _dataLoader.DoWork += DataLoaderWork;
            _dataLoader.RunWorkerAsync();
        }

        private void DataLoaderWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            var dummyCompanies = DatabaseAdapter.Get<DummyCompany>();
            var taxes = DatabaseAdapter.Get<Taxes>();
            var stocksBought = DatabaseAdapter.Get<Bought>();
            var stocksSold = DatabaseAdapter.Get<Sold>();
        }

        private void ButtonNewDummyCompany_Click(object sender, System.EventArgs e)
        {
            new CreateNewDummyCompany().ShowDialog();
        }

        private void ButtonLiquidFundsToCompany_Click(object sender, System.EventArgs e)
        {
            new MoveFundsToDummyCompany().ShowDialog();
        }

        private void ButtonCaptialIncrease_Click(object sender, System.EventArgs e)
        {
            new CapitalIncrease().ShowDialog();
        }

        private void ButtonBuyNewStocks_Click(object sender, System.EventArgs e)
        {
            new BuyStocks().ShowDialog();
        }

        private void ButtonSellStocks_Click(object sender, System.EventArgs e)
        {
            new SellStocks().ShowDialog();
        }
    }
}