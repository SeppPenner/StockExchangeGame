namespace StockExchangeGame
{
    partial class Main
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.labelSelectLanguage = new System.Windows.Forms.Label();
            this.buttonMarketView = new System.Windows.Forms.Button();
            this.buttonPersonalView = new System.Windows.Forms.Button();
            this.groupBoxViews = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelTopRight = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelTopLeft = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelTop = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelTopRight.SuspendLayout();
            this.tableLayoutPanelTopLeft.SuspendLayout();
            this.tableLayoutPanelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(3, 3);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(102, 21);
            this.comboBoxLanguage.TabIndex = 0;
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.ComboBoxLanguage_SelectedIndexChanged);
            // 
            // labelSelectLanguage
            // 
            this.labelSelectLanguage.AutoSize = true;
            this.labelSelectLanguage.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelSelectLanguage.Location = new System.Drawing.Point(111, 0);
            this.labelSelectLanguage.Name = "labelSelectLanguage";
            this.labelSelectLanguage.Size = new System.Drawing.Size(102, 26);
            this.labelSelectLanguage.TabIndex = 1;
            this.labelSelectLanguage.Text = "labelSelectLanguage";
            // 
            // buttonMarketView
            // 
            this.buttonMarketView.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonMarketView.Location = new System.Drawing.Point(3, 3);
            this.buttonMarketView.Name = "buttonMarketView";
            this.buttonMarketView.Size = new System.Drawing.Size(112, 21);
            this.buttonMarketView.TabIndex = 3;
            this.buttonMarketView.Text = "Market view";
            this.buttonMarketView.UseVisualStyleBackColor = true;
            this.buttonMarketView.Click += new System.EventHandler(this.ButtonMarketView_Click);
            // 
            // buttonPersonalView
            // 
            this.buttonPersonalView.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPersonalView.Location = new System.Drawing.Point(3, 30);
            this.buttonPersonalView.Name = "buttonPersonalView";
            this.buttonPersonalView.Size = new System.Drawing.Size(112, 21);
            this.buttonPersonalView.TabIndex = 4;
            this.buttonPersonalView.Text = "Personal view";
            this.buttonPersonalView.UseVisualStyleBackColor = true;
            this.buttonPersonalView.Click += new System.EventHandler(this.ButtonPersonalView_Click);
            // 
            // groupBoxViews
            // 
            this.groupBoxViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxViews.Location = new System.Drawing.Point(3, 73);
            this.groupBoxViews.Name = "groupBoxViews";
            this.groupBoxViews.Size = new System.Drawing.Size(1009, 527);
            this.groupBoxViews.TabIndex = 5;
            this.groupBoxViews.TabStop = false;
            this.groupBoxViews.Text = "groupBox1";
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelTop, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.groupBoxViews, 0, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1015, 603);
            this.tableLayoutPanelMain.TabIndex = 6;
            // 
            // tableLayoutPanelTopRight
            // 
            this.tableLayoutPanelTopRight.ColumnCount = 2;
            this.tableLayoutPanelTopRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTopRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTopRight.Controls.Add(this.comboBoxLanguage, 0, 0);
            this.tableLayoutPanelTopRight.Controls.Add(this.labelSelectLanguage, 1, 0);
            this.tableLayoutPanelTopRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTopRight.Location = new System.Drawing.Point(447, 4);
            this.tableLayoutPanelTopRight.Name = "tableLayoutPanelTopRight";
            this.tableLayoutPanelTopRight.RowCount = 2;
            this.tableLayoutPanelTopRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelTopRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTopRight.Size = new System.Drawing.Size(216, 61);
            this.tableLayoutPanelTopRight.TabIndex = 6;
            // 
            // tableLayoutPanelTopLeft
            // 
            this.tableLayoutPanelTopLeft.ColumnCount = 2;
            this.tableLayoutPanelTopLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTopLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTopLeft.Controls.Add(this.buttonMarketView, 0, 0);
            this.tableLayoutPanelTopLeft.Controls.Add(this.buttonPersonalView, 0, 1);
            this.tableLayoutPanelTopLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTopLeft.Location = new System.Drawing.Point(106, 11);
            this.tableLayoutPanelTopLeft.Name = "tableLayoutPanelTopLeft";
            this.tableLayoutPanelTopLeft.RowCount = 2;
            this.tableLayoutPanelTopLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTopLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTopLeft.Size = new System.Drawing.Size(236, 54);
            this.tableLayoutPanelTopLeft.TabIndex = 7;
            // 
            // tableLayoutPanelTop
            // 
            this.tableLayoutPanelTop.ColumnCount = 2;
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTop.Controls.Add(this.tableLayoutPanelTopRight, 1, 0);
            this.tableLayoutPanelTop.Controls.Add(this.tableLayoutPanelTopLeft, 0, 0);
            this.tableLayoutPanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTop.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelTop.Name = "tableLayoutPanelTop";
            this.tableLayoutPanelTop.RowCount = 1;
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTop.Size = new System.Drawing.Size(1009, 64);
            this.tableLayoutPanelTop.TabIndex = 8;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 603);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StockExchangeGame";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelTopRight.ResumeLayout(false);
            this.tableLayoutPanelTopRight.PerformLayout();
            this.tableLayoutPanelTopLeft.ResumeLayout(false);
            this.tableLayoutPanelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Label labelSelectLanguage;
        private System.Windows.Forms.Button buttonMarketView;
        private System.Windows.Forms.Button buttonPersonalView;
        private System.Windows.Forms.GroupBox groupBoxViews;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTopRight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTopLeft;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTop;
    }
}

