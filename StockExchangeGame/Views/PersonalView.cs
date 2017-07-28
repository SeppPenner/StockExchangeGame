using System.Windows.Forms;
using StockExchangeGame.Dialogs;

namespace StockExchangeGame.Views
{
    public partial class PersonalView : UserControl
    {
        public PersonalView()
        {
            InitializeComponent();
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