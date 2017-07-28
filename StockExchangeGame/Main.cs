using System;
using System.Reflection;
using System.Windows.Forms;
using log4net;
using Languages.Implementation;
using Languages.Interfaces;
using StockExchangeGame.Database.Generic;
using StockExchangeGame.DummyData;
using StockExchangeGame.Exceptions;
using StockExchangeGame.Views;

namespace StockExchangeGame
{
    public partial class Main : Form
    {
        private IDatabaseAdapter _databaseAdapter;
        private readonly ILanguageManager _lm = new LanguageManager();
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private ILanguage _lang;

        public Main()
        {
            InitializeComponent();
            LoadTitleAndDescription();
            InitializeLanguageManager();
            LoadLanguagesToCombo();
            InitDatabase();
            //Todo remove dummy data
            new DummyDataGenerator(_databaseAdapter).GenerateDummyData();
        }

        private void LoadTitleAndDescription()
        {
            Text = Application.ProductName + @" " + Application.ProductVersion;
        }

        private void InitDatabase()
        {
            try
            {
                _databaseAdapter = new DatabaseAdapter(_lang);
            }
            catch (Exception ex)
            {
                LogDatabaseInitializationException(ex);
            }
        }

        private void LogDatabaseInitializationException(Exception exception)
        {
            var ex = new InitializationException(_lang.GetWord("ErrorInDatabaseInit"), exception);
            LogError(ex);
        }

        private void InitializeLanguageManager()
        {
            _lm.SetCurrentLanguage("de-DE");
            _lm.OnLanguageChanged += OnLanguageChanged;
        }

        private void LoadLanguagesToCombo()
        {
            foreach (var lang in _lm.GetLanguages())
                comboBoxLanguage.Items.Add(lang.Name);
            comboBoxLanguage.SelectedIndex = 0;
        }

        private void ComboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lm.SetCurrentLanguageFromName(comboBoxLanguage.SelectedItem.ToString());
        }

        private void OnLanguageChanged(object sender, EventArgs eventArgs)
        {
            _lang = _lm.GetCurrentLanguage();
            labelSelectLanguage.Text = _lang.GetWord("SelectLanguage");
            SetDatabaseAdapterLanguageIfNotNull();
        }

        private void SetDatabaseAdapterLanguageIfNotNull()
        {
            if (_lang == null || _databaseAdapter == null) return;
            _databaseAdapter.SetCurrentLanguage(_lang);
        }

        private void ButtonMarketView_Click(object sender, EventArgs e)
        {
            if (CanCurrentViewClose())
                TrySwitchView(new MarketView());
            else
                LogViewCannotBeClosedException();
        }

        private void TrySwitchView(UserControl newView)
        {
            try
            {
                SwitchView(newView);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        private bool CanCurrentViewClose()
        {
            if (groupBoxViews.Controls.Count == 0)
                return true;

            var v = groupBoxViews.Controls[0] as IView;
            return v != null && v.CanClose();
        }

        private void SwitchView(UserControl newView)
        {
            if (groupBoxViews.Controls.Count > 0)
                DisposeOldView();
            AddNewView(newView);
        }

        private void AddNewView(UserControl newView)
        {
            groupBoxViews.Controls.Add(newView);
            newView.Dock = DockStyle.Fill;
            groupBoxViews.Refresh();
        }

        private void DisposeOldView()
        {
            var oldView = groupBoxViews.Controls[0] as UserControl;
            if (oldView == null) return;
            groupBoxViews.Controls.Remove(oldView);
            oldView.Dispose();
        }

        private void ButtonPersonalView_Click(object sender, EventArgs e)
        {
            if (CanCurrentViewClose())
                TrySwitchView(new PersonalView{ DatabaseAdapter = _databaseAdapter});
            else
                LogViewCannotBeClosedException();
        }

        private void LogViewCannotBeClosedException()
        {
            var ex = new ViewCannotBeClosedException(_lang.GetWord("CurrentViewCannotBeClosed"));
            LogError(ex);
        }

        private void LogError(Exception ex)
        {
            _log.Error(ex);
            MessageBox.Show(ex.Message, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}