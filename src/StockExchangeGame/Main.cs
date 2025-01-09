using System;
using System.Reflection;
using System.Windows.Forms;
using Languages.Implementation;
using Languages.Interfaces;
using StockExchangeGame.Database.Generic;
using StockExchangeGame.Exceptions;
using StockExchangeGame.Views;

namespace StockExchangeGame
{
    public partial class Main : Form
    {
        private readonly ILanguageManager _lm = new LanguageManager();
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private IDatabaseAdapter _databaseAdapter;
        private ILanguage _lang;

        public Main()
        {
            this.InitializeComponent();
            this.LoadTitleAndDescription();
            this.InitializeLanguageManager();
            this.LoadLanguagesToCombo();
            this.InitDatabase();
            //Todo remove dummy data
            //new DummyDataGenerator(_databaseAdapter).GenerateDummyData();
        }

        private void LoadTitleAndDescription()
        {
            this.Text = Application.ProductName + @" " + Application.ProductVersion;
        }

        private void InitDatabase()
        {
            try
            {
                this._databaseAdapter = new DatabaseAdapter(this._lang);
            }
            catch (Exception ex)
            {
                this.LogDatabaseInitializationException(ex);
            }
        }

        private void LogDatabaseInitializationException(Exception exception)
        {
            var ex = new InitializationException(this._lang.GetWord("ErrorInDatabaseInit"), exception);
            this.LogError(ex);
        }

        private void InitializeLanguageManager()
        {
            this._lm.SetCurrentLanguage("de-DE");
            this._lm.OnLanguageChanged += this.OnLanguageChanged;
        }

        private void LoadLanguagesToCombo()
        {
            foreach (var lang in this._lm.GetLanguages())
                this.comboBoxLanguage.Items.Add(lang.Name);
            this.comboBoxLanguage.SelectedIndex = 0;
        }

        private void ComboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._lm.SetCurrentLanguageFromName(this.comboBoxLanguage.SelectedItem.ToString());
        }

        private void OnLanguageChanged(object sender, EventArgs eventArgs)
        {
            this._lang = this._lm.GetCurrentLanguage();
            this.labelSelectLanguage.Text = this._lang.GetWord("SelectLanguage");
            this.SetDatabaseAdapterLanguageIfNotNull();
        }

        private void SetDatabaseAdapterLanguageIfNotNull()
        {
            if (this._lang == null || this._databaseAdapter == null) return;
            this._databaseAdapter.SetCurrentLanguage(this._lang);
        }

        private void ButtonMarketView_Click(object sender, EventArgs e)
        {
            if (this.CanCurrentViewClose())
                this.TrySwitchView(new MarketView());
            else
                this.LogViewCannotBeClosedException();
        }

        private void TrySwitchView(UserControl newView)
        {
            try
            {
                this.SwitchView(newView);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
        }

        private bool CanCurrentViewClose()
        {
            if (this.groupBoxViews.Controls.Count == 0)
                return true;

            var v = this.groupBoxViews.Controls[0] as IView;
            return v != null && v.CanClose();
        }

        private void SwitchView(UserControl newView)
        {
            if (this.groupBoxViews.Controls.Count > 0)
                this.DisposeOldView();
            this.AddNewView(newView);
        }

        private void AddNewView(UserControl newView)
        {
            this.groupBoxViews.Controls.Add(newView);
            newView.Dock = DockStyle.Fill;
            this.groupBoxViews.Refresh();
        }

        private void DisposeOldView()
        {
            var oldView = this.groupBoxViews.Controls[0] as UserControl;
            if (oldView == null) return;
            this.groupBoxViews.Controls.Remove(oldView);
            oldView.Dispose();
        }

        private void ButtonPersonalView_Click(object sender, EventArgs e)
        {
            if (this.CanCurrentViewClose())
                this.TrySwitchView(new PersonalView {DatabaseAdapter = this._databaseAdapter });
            else
                this.LogViewCannotBeClosedException();
        }

        private void LogViewCannotBeClosedException()
        {
            var ex = new ViewCannotBeClosedException(this._lang.GetWord("CurrentViewCannotBeClosed"));
            this.LogError(ex);
        }

        private void LogError(Exception ex)
        {
            this._log.Error(ex);
            MessageBox.Show(ex.Message, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}