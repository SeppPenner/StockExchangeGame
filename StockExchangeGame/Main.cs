using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using StockExchangeGame.Database.Generic;
using StockExchangeGame.Exceptions;

namespace StockExchangeGame
{
    public partial class Main : Form
    {
        private readonly IDatabaseAdapter _databaseAdapter = new DatabaseAdapter();
        public Main()
        {
            InitializeComponent();
            InitializeLanguageManager();
            LoadLanguagesToCombo();
            InitializeDatabaseIfNecessary();
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
            if (result.Result.Any(x => x.Results == null))
            {
                throw new InitializationException("");
            }
        }

        private readonly ILanguageManager _lm = new LanguageManager();
        private Language _lang;

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
    }
}
}
