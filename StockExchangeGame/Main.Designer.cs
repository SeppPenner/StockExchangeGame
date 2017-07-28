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
            this.SuspendLayout();
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(45, 34);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLanguage.TabIndex = 0;
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.ComboBoxLanguage_SelectedIndexChanged);
            // 
            // labelSelectLanguage
            // 
            this.labelSelectLanguage.AutoSize = true;
            this.labelSelectLanguage.Location = new System.Drawing.Point(172, 37);
            this.labelSelectLanguage.Name = "labelSelectLanguage";
            this.labelSelectLanguage.Size = new System.Drawing.Size(107, 13);
            this.labelSelectLanguage.TabIndex = 1;
            this.labelSelectLanguage.Text = "labelSelectLanguage";
            // 
            // buttonMarketView
            // 
            this.buttonMarketView.Location = new System.Drawing.Point(13, 94);
            this.buttonMarketView.Name = "buttonMarketView";
            this.buttonMarketView.Size = new System.Drawing.Size(75, 23);
            this.buttonMarketView.TabIndex = 3;
            this.buttonMarketView.Text = "Market view";
            this.buttonMarketView.UseVisualStyleBackColor = true;
            this.buttonMarketView.Click += new System.EventHandler(this.ButtonMarketView_Click);
            // 
            // buttonPersonalView
            // 
            this.buttonPersonalView.Location = new System.Drawing.Point(13, 123);
            this.buttonPersonalView.Name = "buttonPersonalView";
            this.buttonPersonalView.Size = new System.Drawing.Size(75, 23);
            this.buttonPersonalView.TabIndex = 4;
            this.buttonPersonalView.Text = "Personal view";
            this.buttonPersonalView.UseVisualStyleBackColor = true;
            this.buttonPersonalView.Click += new System.EventHandler(this.ButtonPersonalView_Click);
            // 
            // groupBoxViews
            // 
            this.groupBoxViews.Location = new System.Drawing.Point(132, 85);
            this.groupBoxViews.Name = "groupBoxViews";
            this.groupBoxViews.Size = new System.Drawing.Size(302, 200);
            this.groupBoxViews.TabIndex = 5;
            this.groupBoxViews.TabStop = false;
            this.groupBoxViews.Text = "groupBox1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 338);
            this.Controls.Add(this.groupBoxViews);
            this.Controls.Add(this.buttonPersonalView);
            this.Controls.Add(this.buttonMarketView);
            this.Controls.Add(this.labelSelectLanguage);
            this.Controls.Add(this.comboBoxLanguage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Label labelSelectLanguage;
        private System.Windows.Forms.Button buttonMarketView;
        private System.Windows.Forms.Button buttonPersonalView;
        private System.Windows.Forms.GroupBox groupBoxViews;
    }
}

