using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using log4net;
using Languages.Implementation;
using Languages.Interfaces;
using StockExchangeGame.Database.Generic;
using StockExchangeGame.Exceptions;
using StockExchangeGame.Views;

namespace StockExchangeGame
{
    public partial class Main : Form
    {
        private readonly IDatabaseAdapter _databaseAdapter = new DatabaseAdapter();
        private readonly ILanguageManager _lm = new LanguageManager();
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private Language _lang;

        public Main()
        {
            InitializeComponent();
            InitializeLanguageManager();
            LoadLanguagesToCombo();
            //InitializeDatabaseIfNecessary();
        }

        private void InitializeDatabaseIfNecessary()
        {
            var databasePath = _databaseAdapter.GetDatabasePath();
            if (File.Exists(databasePath)) return;
            CreateAllTables();
        }

        private void CreateAllTables()
        {
            var result = _databaseAdapter.CreateAllTables();
            if (result.Result.All(x => x.Results != null)) return;
            LogDatabaseInitializationError(result.Result);
        }

        private void LogDatabaseInitializationError(List<CreateTablesResult> results)
        {
            var ex = new InitializationException(_lang.GetWord("ErrorInDatabaseInit"), results);
            MessageBox.Show(ex.Message, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            _log.Error(ex);
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

        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lm.SetCurrentLanguageFromName(comboBoxLanguage.SelectedItem.ToString());
        }

        private void OnLanguageChanged(object sender, EventArgs eventArgs)
        {
            _lang = _lm.GetCurrentLanguage();
            labelSelectLanguage.Text = _lang.GetWord("SelectLanguage");
        }

        private void buttonMarketView_Click(object sender, EventArgs e)
        {
            if (CanCurrentViewClose())
            {
                var v = new MarketView();
                SwitchView(v);
            }
            else
            {
                MessageBox.Show("Current View can not close!");
            }
        }

        private bool CanCurrentViewClose()
        {
            if(groupBoxViews.Controls.Count == 0)
                return true;

            var v = groupBoxViews.Controls[0] as IView;
            return v != null && v.CanClose();
        }

        private void SwitchView(UserControl newView)
        {
            if (newView == null) throw new ArgumentNullException(nameof(newView));
            if (groupBoxViews.Controls.Count > 0)
            {
                var oldView = groupBoxViews.Controls[0] as UserControl;
                if (oldView == null) return;
                groupBoxViews.Controls.Remove(oldView);
                oldView.Dispose();
            }
            groupBoxViews.Controls.Add(newView);
            newView.Dock = DockStyle.Fill;
            groupBoxViews.Refresh();
        }

        private void buttonPersonalView_Click(object sender, EventArgs e)
        {
            if (CanCurrentViewClose())
            {
                var v = new PersonalView();
                SwitchView(v);
            }
            else
            {
                MessageBox.Show("Current View can not close!");
            }
        }
    }
}