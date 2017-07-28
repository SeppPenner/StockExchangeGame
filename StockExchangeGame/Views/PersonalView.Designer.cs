namespace StockExchangeGame.Views
{
    partial class PersonalView: IView
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelTopLeft = new System.Windows.Forms.TableLayoutPanel();
            this.labelCurrentStocks = new System.Windows.Forms.Label();
            this.dataGridViewCurrentStocks = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelBottomLeft = new System.Windows.Forms.TableLayoutPanel();
            this.labelBoughtStocks = new System.Windows.Forms.Label();
            this.dataGridViewBoughtStocks = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelMiddleLeft = new System.Windows.Forms.TableLayoutPanel();
            this.labelSoldStocks = new System.Windows.Forms.Label();
            this.dataGridViewSoldStocks = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelTopRight = new System.Windows.Forms.TableLayoutPanel();
            this.labelDummyCompanies = new System.Windows.Forms.Label();
            this.dataGridViewDummyCompanies = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelMiddleRight = new System.Windows.Forms.TableLayoutPanel();
            this.labelTaxes = new System.Windows.Forms.Label();
            this.dataGridViewTaxes = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelBottomRight = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelSmallBottomLeftRightSide = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSellStocks = new System.Windows.Forms.Button();
            this.buttonNewDummyCompany = new System.Windows.Forms.Button();
            this.buttonLiquidFundsToCompany = new System.Windows.Forms.Button();
            this.buttonCaptialIncrease = new System.Windows.Forms.Button();
            this.buttonBuyNewStocks = new System.Windows.Forms.Button();
            this.tableLayoutPanelSmallBottomLeft = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBoxLiquidFunds = new System.Windows.Forms.RichTextBox();
            this.labelLiquidFundsHeader = new System.Windows.Forms.Label();
            this.StocksSoldIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StocksSoldAmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StocksSoldCreatedAtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StocksSoldDateSoldColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StocksSoldDeletedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StocksSoldMerchantIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StocksSoldMerchantColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StocksSoldModifiedAtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StocksSoldStockIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StocksSoldStockColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StocksSoldValuePerStockColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelTopLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCurrentStocks)).BeginInit();
            this.tableLayoutPanelBottomLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBoughtStocks)).BeginInit();
            this.tableLayoutPanelMiddleLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSoldStocks)).BeginInit();
            this.tableLayoutPanelTopRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDummyCompanies)).BeginInit();
            this.tableLayoutPanelMiddleRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaxes)).BeginInit();
            this.tableLayoutPanelBottomRight.SuspendLayout();
            this.tableLayoutPanelSmallBottomLeftRightSide.SuspendLayout();
            this.tableLayoutPanelSmallBottomLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelTopLeft, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelBottomLeft, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelMiddleLeft, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelTopRight, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelMiddleRight, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelBottomRight, 1, 2);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(997, 596);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // tableLayoutPanelTopLeft
            // 
            this.tableLayoutPanelTopLeft.ColumnCount = 1;
            this.tableLayoutPanelTopLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTopLeft.Controls.Add(this.labelCurrentStocks, 0, 0);
            this.tableLayoutPanelTopLeft.Controls.Add(this.dataGridViewCurrentStocks, 0, 1);
            this.tableLayoutPanelTopLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTopLeft.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelTopLeft.Name = "tableLayoutPanelTopLeft";
            this.tableLayoutPanelTopLeft.RowCount = 2;
            this.tableLayoutPanelTopLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelTopLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTopLeft.Size = new System.Drawing.Size(492, 192);
            this.tableLayoutPanelTopLeft.TabIndex = 1;
            // 
            // labelCurrentStocks
            // 
            this.labelCurrentStocks.AutoSize = true;
            this.labelCurrentStocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCurrentStocks.Location = new System.Drawing.Point(3, 0);
            this.labelCurrentStocks.Name = "labelCurrentStocks";
            this.labelCurrentStocks.Size = new System.Drawing.Size(486, 20);
            this.labelCurrentStocks.TabIndex = 0;
            this.labelCurrentStocks.Text = "Current stocks:";
            // 
            // dataGridViewCurrentStocks
            // 
            this.dataGridViewCurrentStocks.AllowUserToAddRows = false;
            this.dataGridViewCurrentStocks.AllowUserToDeleteRows = false;
            this.dataGridViewCurrentStocks.AllowUserToOrderColumns = true;
            this.dataGridViewCurrentStocks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewCurrentStocks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewCurrentStocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCurrentStocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCurrentStocks.Location = new System.Drawing.Point(3, 23);
            this.dataGridViewCurrentStocks.Name = "dataGridViewCurrentStocks";
            this.dataGridViewCurrentStocks.ReadOnly = true;
            this.dataGridViewCurrentStocks.Size = new System.Drawing.Size(486, 166);
            this.dataGridViewCurrentStocks.TabIndex = 1;
            // 
            // tableLayoutPanelBottomLeft
            // 
            this.tableLayoutPanelBottomLeft.ColumnCount = 1;
            this.tableLayoutPanelBottomLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBottomLeft.Controls.Add(this.labelBoughtStocks, 0, 0);
            this.tableLayoutPanelBottomLeft.Controls.Add(this.dataGridViewBoughtStocks, 0, 1);
            this.tableLayoutPanelBottomLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBottomLeft.Location = new System.Drawing.Point(3, 399);
            this.tableLayoutPanelBottomLeft.Name = "tableLayoutPanelBottomLeft";
            this.tableLayoutPanelBottomLeft.RowCount = 2;
            this.tableLayoutPanelBottomLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelBottomLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBottomLeft.Size = new System.Drawing.Size(492, 194);
            this.tableLayoutPanelBottomLeft.TabIndex = 3;
            // 
            // labelBoughtStocks
            // 
            this.labelBoughtStocks.AutoSize = true;
            this.labelBoughtStocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBoughtStocks.Location = new System.Drawing.Point(3, 0);
            this.labelBoughtStocks.Name = "labelBoughtStocks";
            this.labelBoughtStocks.Size = new System.Drawing.Size(486, 20);
            this.labelBoughtStocks.TabIndex = 0;
            this.labelBoughtStocks.Text = "Stocks bought:";
            // 
            // dataGridViewBoughtStocks
            // 
            this.dataGridViewBoughtStocks.AllowUserToAddRows = false;
            this.dataGridViewBoughtStocks.AllowUserToDeleteRows = false;
            this.dataGridViewBoughtStocks.AllowUserToOrderColumns = true;
            this.dataGridViewBoughtStocks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewBoughtStocks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewBoughtStocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBoughtStocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBoughtStocks.Location = new System.Drawing.Point(3, 23);
            this.dataGridViewBoughtStocks.Name = "dataGridViewBoughtStocks";
            this.dataGridViewBoughtStocks.ReadOnly = true;
            this.dataGridViewBoughtStocks.Size = new System.Drawing.Size(486, 169);
            this.dataGridViewBoughtStocks.TabIndex = 1;
            // 
            // tableLayoutPanelMiddleLeft
            // 
            this.tableLayoutPanelMiddleLeft.ColumnCount = 1;
            this.tableLayoutPanelMiddleLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMiddleLeft.Controls.Add(this.labelSoldStocks, 0, 0);
            this.tableLayoutPanelMiddleLeft.Controls.Add(this.dataGridViewSoldStocks, 0, 1);
            this.tableLayoutPanelMiddleLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMiddleLeft.Location = new System.Drawing.Point(3, 201);
            this.tableLayoutPanelMiddleLeft.Name = "tableLayoutPanelMiddleLeft";
            this.tableLayoutPanelMiddleLeft.RowCount = 2;
            this.tableLayoutPanelMiddleLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMiddleLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMiddleLeft.Size = new System.Drawing.Size(492, 192);
            this.tableLayoutPanelMiddleLeft.TabIndex = 2;
            // 
            // labelSoldStocks
            // 
            this.labelSoldStocks.AutoSize = true;
            this.labelSoldStocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSoldStocks.Location = new System.Drawing.Point(3, 0);
            this.labelSoldStocks.Name = "labelSoldStocks";
            this.labelSoldStocks.Size = new System.Drawing.Size(486, 20);
            this.labelSoldStocks.TabIndex = 0;
            this.labelSoldStocks.Text = "Stocks sold:";
            // 
            // dataGridViewSoldStocks
            // 
            this.dataGridViewSoldStocks.AllowUserToAddRows = false;
            this.dataGridViewSoldStocks.AllowUserToDeleteRows = false;
            this.dataGridViewSoldStocks.AllowUserToOrderColumns = true;
            this.dataGridViewSoldStocks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewSoldStocks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewSoldStocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSoldStocks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StocksSoldIdColumn,
            this.StocksSoldAmountColumn,
            this.StocksSoldCreatedAtColumn,
            this.StocksSoldDateSoldColumn,
            this.StocksSoldDeletedColumn,
            this.StocksSoldMerchantIdColumn,
            this.StocksSoldMerchantColumn,
            this.StocksSoldModifiedAtColumn,
            this.StocksSoldStockIdColumn,
            this.StocksSoldStockColumn,
            this.StocksSoldValuePerStockColumn});
            this.dataGridViewSoldStocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSoldStocks.Location = new System.Drawing.Point(3, 23);
            this.dataGridViewSoldStocks.Name = "dataGridViewSoldStocks";
            this.dataGridViewSoldStocks.ReadOnly = true;
            this.dataGridViewSoldStocks.Size = new System.Drawing.Size(486, 169);
            this.dataGridViewSoldStocks.TabIndex = 1;
            // 
            // tableLayoutPanelTopRight
            // 
            this.tableLayoutPanelTopRight.ColumnCount = 1;
            this.tableLayoutPanelTopRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTopRight.Controls.Add(this.labelDummyCompanies, 0, 0);
            this.tableLayoutPanelTopRight.Controls.Add(this.dataGridViewDummyCompanies, 0, 1);
            this.tableLayoutPanelTopRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTopRight.Location = new System.Drawing.Point(501, 3);
            this.tableLayoutPanelTopRight.Name = "tableLayoutPanelTopRight";
            this.tableLayoutPanelTopRight.RowCount = 2;
            this.tableLayoutPanelTopRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelTopRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTopRight.Size = new System.Drawing.Size(493, 192);
            this.tableLayoutPanelTopRight.TabIndex = 4;
            // 
            // labelDummyCompanies
            // 
            this.labelDummyCompanies.AutoSize = true;
            this.labelDummyCompanies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDummyCompanies.Location = new System.Drawing.Point(3, 0);
            this.labelDummyCompanies.Name = "labelDummyCompanies";
            this.labelDummyCompanies.Size = new System.Drawing.Size(487, 20);
            this.labelDummyCompanies.TabIndex = 0;
            this.labelDummyCompanies.Text = "Dummy companies:";
            // 
            // dataGridViewDummyCompanies
            // 
            this.dataGridViewDummyCompanies.AllowUserToAddRows = false;
            this.dataGridViewDummyCompanies.AllowUserToDeleteRows = false;
            this.dataGridViewDummyCompanies.AllowUserToOrderColumns = true;
            this.dataGridViewDummyCompanies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewDummyCompanies.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewDummyCompanies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDummyCompanies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDummyCompanies.Location = new System.Drawing.Point(3, 23);
            this.dataGridViewDummyCompanies.Name = "dataGridViewDummyCompanies";
            this.dataGridViewDummyCompanies.ReadOnly = true;
            this.dataGridViewDummyCompanies.Size = new System.Drawing.Size(487, 169);
            this.dataGridViewDummyCompanies.TabIndex = 1;
            // 
            // tableLayoutPanelMiddleRight
            // 
            this.tableLayoutPanelMiddleRight.ColumnCount = 1;
            this.tableLayoutPanelMiddleRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMiddleRight.Controls.Add(this.labelTaxes, 0, 0);
            this.tableLayoutPanelMiddleRight.Controls.Add(this.dataGridViewTaxes, 0, 1);
            this.tableLayoutPanelMiddleRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMiddleRight.Location = new System.Drawing.Point(501, 201);
            this.tableLayoutPanelMiddleRight.Name = "tableLayoutPanelMiddleRight";
            this.tableLayoutPanelMiddleRight.RowCount = 2;
            this.tableLayoutPanelMiddleRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMiddleRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMiddleRight.Size = new System.Drawing.Size(493, 192);
            this.tableLayoutPanelMiddleRight.TabIndex = 5;
            // 
            // labelTaxes
            // 
            this.labelTaxes.AutoSize = true;
            this.labelTaxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTaxes.Location = new System.Drawing.Point(3, 0);
            this.labelTaxes.Name = "labelTaxes";
            this.labelTaxes.Size = new System.Drawing.Size(487, 20);
            this.labelTaxes.TabIndex = 0;
            this.labelTaxes.Text = "Taxes to pay:";
            // 
            // dataGridViewTaxes
            // 
            this.dataGridViewTaxes.AllowUserToAddRows = false;
            this.dataGridViewTaxes.AllowUserToDeleteRows = false;
            this.dataGridViewTaxes.AllowUserToOrderColumns = true;
            this.dataGridViewTaxes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewTaxes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewTaxes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTaxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTaxes.Location = new System.Drawing.Point(3, 23);
            this.dataGridViewTaxes.Name = "dataGridViewTaxes";
            this.dataGridViewTaxes.ReadOnly = true;
            this.dataGridViewTaxes.Size = new System.Drawing.Size(487, 169);
            this.dataGridViewTaxes.TabIndex = 1;
            // 
            // tableLayoutPanelBottomRight
            // 
            this.tableLayoutPanelBottomRight.ColumnCount = 2;
            this.tableLayoutPanelBottomRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBottomRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBottomRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelBottomRight.Controls.Add(this.tableLayoutPanelSmallBottomLeftRightSide, 0, 0);
            this.tableLayoutPanelBottomRight.Controls.Add(this.tableLayoutPanelSmallBottomLeft, 1, 0);
            this.tableLayoutPanelBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBottomRight.Location = new System.Drawing.Point(501, 399);
            this.tableLayoutPanelBottomRight.Name = "tableLayoutPanelBottomRight";
            this.tableLayoutPanelBottomRight.RowCount = 1;
            this.tableLayoutPanelBottomRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBottomRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelBottomRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelBottomRight.Size = new System.Drawing.Size(493, 194);
            this.tableLayoutPanelBottomRight.TabIndex = 6;
            // 
            // tableLayoutPanelSmallBottomLeftRightSide
            // 
            this.tableLayoutPanelSmallBottomLeftRightSide.ColumnCount = 1;
            this.tableLayoutPanelSmallBottomLeftRightSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSmallBottomLeftRightSide.Controls.Add(this.buttonSellStocks, 0, 4);
            this.tableLayoutPanelSmallBottomLeftRightSide.Controls.Add(this.buttonNewDummyCompany, 0, 0);
            this.tableLayoutPanelSmallBottomLeftRightSide.Controls.Add(this.buttonLiquidFundsToCompany, 0, 1);
            this.tableLayoutPanelSmallBottomLeftRightSide.Controls.Add(this.buttonCaptialIncrease, 0, 2);
            this.tableLayoutPanelSmallBottomLeftRightSide.Controls.Add(this.buttonBuyNewStocks, 0, 3);
            this.tableLayoutPanelSmallBottomLeftRightSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSmallBottomLeftRightSide.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelSmallBottomLeftRightSide.Name = "tableLayoutPanelSmallBottomLeftRightSide";
            this.tableLayoutPanelSmallBottomLeftRightSide.RowCount = 5;
            this.tableLayoutPanelSmallBottomLeftRightSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelSmallBottomLeftRightSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelSmallBottomLeftRightSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelSmallBottomLeftRightSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelSmallBottomLeftRightSide.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSmallBottomLeftRightSide.Size = new System.Drawing.Size(240, 188);
            this.tableLayoutPanelSmallBottomLeftRightSide.TabIndex = 4;
            // 
            // buttonSellStocks
            // 
            this.buttonSellStocks.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSellStocks.Location = new System.Drawing.Point(3, 123);
            this.buttonSellStocks.Name = "buttonSellStocks";
            this.buttonSellStocks.Size = new System.Drawing.Size(234, 23);
            this.buttonSellStocks.TabIndex = 4;
            this.buttonSellStocks.Text = "Sell stocks";
            this.buttonSellStocks.UseVisualStyleBackColor = true;
            this.buttonSellStocks.Click += new System.EventHandler(this.ButtonSellStocks_Click);
            // 
            // buttonNewDummyCompany
            // 
            this.buttonNewDummyCompany.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonNewDummyCompany.Location = new System.Drawing.Point(3, 3);
            this.buttonNewDummyCompany.Name = "buttonNewDummyCompany";
            this.buttonNewDummyCompany.Size = new System.Drawing.Size(234, 24);
            this.buttonNewDummyCompany.TabIndex = 0;
            this.buttonNewDummyCompany.Text = "Create a new dummy company";
            this.buttonNewDummyCompany.UseVisualStyleBackColor = true;
            this.buttonNewDummyCompany.Click += new System.EventHandler(this.ButtonNewDummyCompany_Click);
            // 
            // buttonLiquidFundsToCompany
            // 
            this.buttonLiquidFundsToCompany.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonLiquidFundsToCompany.Location = new System.Drawing.Point(3, 33);
            this.buttonLiquidFundsToCompany.Name = "buttonLiquidFundsToCompany";
            this.buttonLiquidFundsToCompany.Size = new System.Drawing.Size(234, 24);
            this.buttonLiquidFundsToCompany.TabIndex = 2;
            this.buttonLiquidFundsToCompany.Text = "Move liquid funds to a dummy company";
            this.buttonLiquidFundsToCompany.UseVisualStyleBackColor = true;
            this.buttonLiquidFundsToCompany.Click += new System.EventHandler(this.ButtonLiquidFundsToCompany_Click);
            // 
            // buttonCaptialIncrease
            // 
            this.buttonCaptialIncrease.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCaptialIncrease.Location = new System.Drawing.Point(3, 63);
            this.buttonCaptialIncrease.Name = "buttonCaptialIncrease";
            this.buttonCaptialIncrease.Size = new System.Drawing.Size(234, 23);
            this.buttonCaptialIncrease.TabIndex = 1;
            this.buttonCaptialIncrease.Text = "Perform a captial increase";
            this.buttonCaptialIncrease.UseVisualStyleBackColor = true;
            this.buttonCaptialIncrease.Click += new System.EventHandler(this.ButtonCaptialIncrease_Click);
            // 
            // buttonBuyNewStocks
            // 
            this.buttonBuyNewStocks.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonBuyNewStocks.Location = new System.Drawing.Point(3, 93);
            this.buttonBuyNewStocks.Name = "buttonBuyNewStocks";
            this.buttonBuyNewStocks.Size = new System.Drawing.Size(234, 23);
            this.buttonBuyNewStocks.TabIndex = 3;
            this.buttonBuyNewStocks.Text = "Buy new stocks";
            this.buttonBuyNewStocks.UseVisualStyleBackColor = true;
            this.buttonBuyNewStocks.Click += new System.EventHandler(this.ButtonBuyNewStocks_Click);
            // 
            // tableLayoutPanelSmallBottomLeft
            // 
            this.tableLayoutPanelSmallBottomLeft.ColumnCount = 1;
            this.tableLayoutPanelSmallBottomLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSmallBottomLeft.Controls.Add(this.richTextBoxLiquidFunds, 0, 1);
            this.tableLayoutPanelSmallBottomLeft.Controls.Add(this.labelLiquidFundsHeader, 0, 0);
            this.tableLayoutPanelSmallBottomLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSmallBottomLeft.Location = new System.Drawing.Point(249, 3);
            this.tableLayoutPanelSmallBottomLeft.Name = "tableLayoutPanelSmallBottomLeft";
            this.tableLayoutPanelSmallBottomLeft.RowCount = 2;
            this.tableLayoutPanelSmallBottomLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelSmallBottomLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSmallBottomLeft.Size = new System.Drawing.Size(241, 188);
            this.tableLayoutPanelSmallBottomLeft.TabIndex = 3;
            // 
            // richTextBoxLiquidFunds
            // 
            this.richTextBoxLiquidFunds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLiquidFunds.Location = new System.Drawing.Point(3, 33);
            this.richTextBoxLiquidFunds.Name = "richTextBoxLiquidFunds";
            this.richTextBoxLiquidFunds.ReadOnly = true;
            this.richTextBoxLiquidFunds.Size = new System.Drawing.Size(235, 152);
            this.richTextBoxLiquidFunds.TabIndex = 1;
            this.richTextBoxLiquidFunds.Text = "";
            // 
            // labelLiquidFundsHeader
            // 
            this.labelLiquidFundsHeader.AutoSize = true;
            this.labelLiquidFundsHeader.Location = new System.Drawing.Point(3, 0);
            this.labelLiquidFundsHeader.Name = "labelLiquidFundsHeader";
            this.labelLiquidFundsHeader.Size = new System.Drawing.Size(67, 13);
            this.labelLiquidFundsHeader.TabIndex = 0;
            this.labelLiquidFundsHeader.Text = "Liquid funds:";
            // 
            // StocksSoldIdColumn
            // 
            this.StocksSoldIdColumn.HeaderText = "Id";
            this.StocksSoldIdColumn.Name = "StocksSoldIdColumn";
            this.StocksSoldIdColumn.ReadOnly = true;
            this.StocksSoldIdColumn.Visible = false;
            // 
            // StocksSoldAmountColumn
            // 
            this.StocksSoldAmountColumn.HeaderText = "Amount";
            this.StocksSoldAmountColumn.Name = "StocksSoldAmountColumn";
            this.StocksSoldAmountColumn.ReadOnly = true;
            this.StocksSoldAmountColumn.Width = 68;
            // 
            // StocksSoldCreatedAtColumn
            // 
            this.StocksSoldCreatedAtColumn.HeaderText = "CreatedAt";
            this.StocksSoldCreatedAtColumn.Name = "StocksSoldCreatedAtColumn";
            this.StocksSoldCreatedAtColumn.ReadOnly = true;
            this.StocksSoldCreatedAtColumn.Visible = false;
            // 
            // StocksSoldDateSoldColumn
            // 
            this.StocksSoldDateSoldColumn.HeaderText = "DateSold";
            this.StocksSoldDateSoldColumn.Name = "StocksSoldDateSoldColumn";
            this.StocksSoldDateSoldColumn.ReadOnly = true;
            this.StocksSoldDateSoldColumn.Width = 76;
            // 
            // StocksSoldDeletedColumn
            // 
            this.StocksSoldDeletedColumn.HeaderText = "Deleted";
            this.StocksSoldDeletedColumn.Name = "StocksSoldDeletedColumn";
            this.StocksSoldDeletedColumn.ReadOnly = true;
            this.StocksSoldDeletedColumn.Width = 69;
            // 
            // StocksSoldMerchantIdColumn
            // 
            this.StocksSoldMerchantIdColumn.HeaderText = "MerchantId";
            this.StocksSoldMerchantIdColumn.Name = "StocksSoldMerchantIdColumn";
            this.StocksSoldMerchantIdColumn.ReadOnly = true;
            this.StocksSoldMerchantIdColumn.Visible = false;
            // 
            // StocksSoldMerchantColumn
            // 
            this.StocksSoldMerchantColumn.HeaderText = "Merchant";
            this.StocksSoldMerchantColumn.Name = "StocksSoldMerchantColumn";
            this.StocksSoldMerchantColumn.ReadOnly = true;
            this.StocksSoldMerchantColumn.Width = 77;
            // 
            // StocksSoldModifiedAtColumn
            // 
            this.StocksSoldModifiedAtColumn.HeaderText = "ModifiedAt";
            this.StocksSoldModifiedAtColumn.Name = "StocksSoldModifiedAtColumn";
            this.StocksSoldModifiedAtColumn.ReadOnly = true;
            this.StocksSoldModifiedAtColumn.Visible = false;
            // 
            // StocksSoldStockIdColumn
            // 
            this.StocksSoldStockIdColumn.HeaderText = "StockId";
            this.StocksSoldStockIdColumn.Name = "StocksSoldStockIdColumn";
            this.StocksSoldStockIdColumn.ReadOnly = true;
            this.StocksSoldStockIdColumn.Visible = false;
            // 
            // StocksSoldStockColumn
            // 
            this.StocksSoldStockColumn.HeaderText = "Stock";
            this.StocksSoldStockColumn.Name = "StocksSoldStockColumn";
            this.StocksSoldStockColumn.ReadOnly = true;
            this.StocksSoldStockColumn.Width = 60;
            // 
            // StocksSoldValuePerStockColumn
            // 
            this.StocksSoldValuePerStockColumn.HeaderText = "ValuePerStock";
            this.StocksSoldValuePerStockColumn.Name = "StocksSoldValuePerStockColumn";
            this.StocksSoldValuePerStockColumn.ReadOnly = true;
            this.StocksSoldValuePerStockColumn.Width = 103;
            // 
            // PersonalView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "PersonalView";
            this.Size = new System.Drawing.Size(997, 596);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelTopLeft.ResumeLayout(false);
            this.tableLayoutPanelTopLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCurrentStocks)).EndInit();
            this.tableLayoutPanelBottomLeft.ResumeLayout(false);
            this.tableLayoutPanelBottomLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBoughtStocks)).EndInit();
            this.tableLayoutPanelMiddleLeft.ResumeLayout(false);
            this.tableLayoutPanelMiddleLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSoldStocks)).EndInit();
            this.tableLayoutPanelTopRight.ResumeLayout(false);
            this.tableLayoutPanelTopRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDummyCompanies)).EndInit();
            this.tableLayoutPanelMiddleRight.ResumeLayout(false);
            this.tableLayoutPanelMiddleRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaxes)).EndInit();
            this.tableLayoutPanelBottomRight.ResumeLayout(false);
            this.tableLayoutPanelSmallBottomLeftRightSide.ResumeLayout(false);
            this.tableLayoutPanelSmallBottomLeft.ResumeLayout(false);
            this.tableLayoutPanelSmallBottomLeft.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public bool CanClose()
        {
            return true;
        }
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTopLeft;
        private System.Windows.Forms.Label labelCurrentStocks;
        private System.Windows.Forms.DataGridView dataGridViewCurrentStocks;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMiddleLeft;
        private System.Windows.Forms.Label labelSoldStocks;
        private System.Windows.Forms.DataGridView dataGridViewSoldStocks;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBottomLeft;
        private System.Windows.Forms.Label labelBoughtStocks;
        private System.Windows.Forms.DataGridView dataGridViewBoughtStocks;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTopRight;
        private System.Windows.Forms.Label labelDummyCompanies;
        private System.Windows.Forms.DataGridView dataGridViewDummyCompanies;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMiddleRight;
        private System.Windows.Forms.Label labelTaxes;
        private System.Windows.Forms.DataGridView dataGridViewTaxes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBottomRight;
        private System.Windows.Forms.Button buttonCaptialIncrease;
        private System.Windows.Forms.Button buttonNewDummyCompany;
        private System.Windows.Forms.Button buttonLiquidFundsToCompany;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSmallBottomLeft;
        private System.Windows.Forms.Label labelLiquidFundsHeader;
        private System.Windows.Forms.RichTextBox richTextBoxLiquidFunds;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSmallBottomLeftRightSide;
        private System.Windows.Forms.Button buttonSellStocks;
        private System.Windows.Forms.Button buttonBuyNewStocks;
        private System.Windows.Forms.DataGridViewTextBoxColumn StocksSoldIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StocksSoldAmountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StocksSoldCreatedAtColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StocksSoldDateSoldColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StocksSoldDeletedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StocksSoldMerchantIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StocksSoldMerchantColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StocksSoldModifiedAtColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StocksSoldStockIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StocksSoldStockColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StocksSoldValuePerStockColumn;
    }
}
