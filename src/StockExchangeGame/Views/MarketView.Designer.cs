namespace StockExchangeGame.Views
{
    partial class MarketView : IView
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
            this.labelMarkets = new System.Windows.Forms.Label();
            this.comboBoxMarkets = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelMarkets
            // 
            this.labelMarkets.AutoSize = true;
            this.labelMarkets.Location = new System.Drawing.Point(32, 24);
            this.labelMarkets.Name = "labelMarkets";
            this.labelMarkets.Size = new System.Drawing.Size(43, 13);
            this.labelMarkets.TabIndex = 0;
            this.labelMarkets.Text = "Market:";
            // 
            // comboBoxMarkets
            // 
            this.comboBoxMarkets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMarkets.FormattingEnabled = true;
            this.comboBoxMarkets.Location = new System.Drawing.Point(35, 40);
            this.comboBoxMarkets.Name = "comboBoxMarkets";
            this.comboBoxMarkets.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMarkets.TabIndex = 1;
            // 
            // MarketView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxMarkets);
            this.Controls.Add(this.labelMarkets);
            this.Name = "MarketView";
            this.Size = new System.Drawing.Size(580, 389);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public bool CanClose()
        {
            return true;
        }

        private System.Windows.Forms.Label labelMarkets;
        private System.Windows.Forms.ComboBox comboBoxMarkets;
    }
}
