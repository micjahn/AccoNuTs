namespace AccountNumberCheck
{
   /// <summary>
   /// 
   /// </summary>
   partial class MainForm
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
         this.tabControl1 = new System.Windows.Forms.TabControl();
         this.tabPageAccountNumbers = new System.Windows.Forms.TabPage();
         this.labGermanAccountResult = new System.Windows.Forms.Label();
         this.btnCheckGermanAccount = new System.Windows.Forms.Button();
         this.textBankCode = new System.Windows.Forms.TextBox();
         this.labBankcode = new System.Windows.Forms.Label();
         this.textGermanAccountNumber = new System.Windows.Forms.TextBox();
         this.labAccountNumber = new System.Windows.Forms.Label();
         this.tabPageCreditCard = new System.Windows.Forms.TabPage();
         this.btnCreditCardNumberCheck = new System.Windows.Forms.Button();
         this.label2 = new System.Windows.Forms.Label();
         this.labCreditCardResult = new System.Windows.Forms.Label();
         this.labCreditCardNumber = new System.Windows.Forms.Label();
         this.textCreditCardNumber = new System.Windows.Forms.TextBox();
         this.cmbCreditCardType = new System.Windows.Forms.ComboBox();
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.btnClose = new System.Windows.Forms.Button();
         this.tabPageIBANConverter = new System.Windows.Forms.TabPage();
         this.cmbCountry = new System.Windows.Forms.ComboBox();
         this.labCountry = new System.Windows.Forms.Label();
         this.propertyGridIBAN = new System.Windows.Forms.PropertyGrid();
         this.labNationalAccountNumber = new System.Windows.Forms.Label();
         this.btnConvertToIBAN = new System.Windows.Forms.Button();
         this.textIBAN = new System.Windows.Forms.TextBox();
         this.tabControl1.SuspendLayout();
         this.tabPageAccountNumbers.SuspendLayout();
         this.tabPageCreditCard.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.tabPageIBANConverter.SuspendLayout();
         this.SuspendLayout();
         // 
         // tabControl1
         // 
         this.tabControl1.Controls.Add(this.tabPageAccountNumbers);
         this.tabControl1.Controls.Add(this.tabPageCreditCard);
         this.tabControl1.Controls.Add(this.tabPageIBANConverter);
         this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabControl1.Location = new System.Drawing.Point(0, 0);
         this.tabControl1.Name = "tabControl1";
         this.tabControl1.SelectedIndex = 0;
         this.tabControl1.Size = new System.Drawing.Size(463, 204);
         this.tabControl1.TabIndex = 0;
         // 
         // tabPageAccountNumbers
         // 
         this.tabPageAccountNumbers.Controls.Add(this.labGermanAccountResult);
         this.tabPageAccountNumbers.Controls.Add(this.btnCheckGermanAccount);
         this.tabPageAccountNumbers.Controls.Add(this.textBankCode);
         this.tabPageAccountNumbers.Controls.Add(this.labBankcode);
         this.tabPageAccountNumbers.Controls.Add(this.textGermanAccountNumber);
         this.tabPageAccountNumbers.Controls.Add(this.labAccountNumber);
         this.tabPageAccountNumbers.Location = new System.Drawing.Point(4, 22);
         this.tabPageAccountNumbers.Name = "tabPageAccountNumbers";
         this.tabPageAccountNumbers.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageAccountNumbers.Size = new System.Drawing.Size(455, 178);
         this.tabPageAccountNumbers.TabIndex = 0;
         this.tabPageAccountNumbers.Text = "German Account Numbers";
         this.tabPageAccountNumbers.UseVisualStyleBackColor = true;
         // 
         // labGermanAccountResult
         // 
         this.labGermanAccountResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labGermanAccountResult.Location = new System.Drawing.Point(344, 17);
         this.labGermanAccountResult.Name = "labGermanAccountResult";
         this.labGermanAccountResult.Size = new System.Drawing.Size(101, 60);
         this.labGermanAccountResult.TabIndex = 5;
         this.labGermanAccountResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // btnCheckGermanAccount
         // 
         this.btnCheckGermanAccount.Location = new System.Drawing.Point(255, 83);
         this.btnCheckGermanAccount.Name = "btnCheckGermanAccount";
         this.btnCheckGermanAccount.Size = new System.Drawing.Size(75, 23);
         this.btnCheckGermanAccount.TabIndex = 4;
         this.btnCheckGermanAccount.Text = "Check";
         this.btnCheckGermanAccount.UseVisualStyleBackColor = true;
         this.btnCheckGermanAccount.Click += new System.EventHandler(this.btnCheckGermanAccount_Click);
         // 
         // textBankCode
         // 
         this.textBankCode.Location = new System.Drawing.Point(113, 57);
         this.textBankCode.Name = "textBankCode";
         this.textBankCode.Size = new System.Drawing.Size(217, 20);
         this.textBankCode.TabIndex = 3;
         // 
         // labBankcode
         // 
         this.labBankcode.AutoSize = true;
         this.labBankcode.Location = new System.Drawing.Point(8, 60);
         this.labBankcode.Name = "labBankcode";
         this.labBankcode.Size = new System.Drawing.Size(56, 13);
         this.labBankcode.TabIndex = 2;
         this.labBankcode.Text = "Bankcode";
         // 
         // textGermanAccountNumber
         // 
         this.textGermanAccountNumber.Location = new System.Drawing.Point(113, 17);
         this.textGermanAccountNumber.Name = "textGermanAccountNumber";
         this.textGermanAccountNumber.Size = new System.Drawing.Size(217, 20);
         this.textGermanAccountNumber.TabIndex = 1;
         // 
         // labAccountNumber
         // 
         this.labAccountNumber.AutoSize = true;
         this.labAccountNumber.Location = new System.Drawing.Point(8, 20);
         this.labAccountNumber.Name = "labAccountNumber";
         this.labAccountNumber.Size = new System.Drawing.Size(87, 13);
         this.labAccountNumber.TabIndex = 0;
         this.labAccountNumber.Text = "Account Number";
         // 
         // tabPageCreditCard
         // 
         this.tabPageCreditCard.Controls.Add(this.btnCreditCardNumberCheck);
         this.tabPageCreditCard.Controls.Add(this.label2);
         this.tabPageCreditCard.Controls.Add(this.labCreditCardResult);
         this.tabPageCreditCard.Controls.Add(this.labCreditCardNumber);
         this.tabPageCreditCard.Controls.Add(this.textCreditCardNumber);
         this.tabPageCreditCard.Controls.Add(this.cmbCreditCardType);
         this.tabPageCreditCard.Location = new System.Drawing.Point(4, 22);
         this.tabPageCreditCard.Name = "tabPageCreditCard";
         this.tabPageCreditCard.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageCreditCard.Size = new System.Drawing.Size(455, 178);
         this.tabPageCreditCard.TabIndex = 1;
         this.tabPageCreditCard.Text = "Credit Card Numbers";
         this.tabPageCreditCard.UseVisualStyleBackColor = true;
         // 
         // btnCreditCardNumberCheck
         // 
         this.btnCreditCardNumberCheck.Location = new System.Drawing.Point(255, 83);
         this.btnCreditCardNumberCheck.Name = "btnCreditCardNumberCheck";
         this.btnCreditCardNumberCheck.Size = new System.Drawing.Size(75, 23);
         this.btnCreditCardNumberCheck.TabIndex = 8;
         this.btnCreditCardNumberCheck.Text = "Check";
         this.btnCreditCardNumberCheck.UseVisualStyleBackColor = true;
         this.btnCreditCardNumberCheck.Click += new System.EventHandler(this.btnCreditCardNumberCheck_Click);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(8, 60);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(86, 13);
         this.label2.TabIndex = 7;
         this.label2.Text = "Credit Card Type";
         // 
         // labCreditCardResult
         // 
         this.labCreditCardResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labCreditCardResult.Location = new System.Drawing.Point(336, 17);
         this.labCreditCardResult.Name = "labCreditCardResult";
         this.labCreditCardResult.Size = new System.Drawing.Size(101, 60);
         this.labCreditCardResult.TabIndex = 6;
         this.labCreditCardResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // labCreditCardNumber
         // 
         this.labCreditCardNumber.AutoSize = true;
         this.labCreditCardNumber.Location = new System.Drawing.Point(8, 20);
         this.labCreditCardNumber.Name = "labCreditCardNumber";
         this.labCreditCardNumber.Size = new System.Drawing.Size(99, 13);
         this.labCreditCardNumber.TabIndex = 2;
         this.labCreditCardNumber.Text = "Credit Card Number";
         // 
         // textCreditCardNumber
         // 
         this.textCreditCardNumber.Location = new System.Drawing.Point(113, 17);
         this.textCreditCardNumber.Name = "textCreditCardNumber";
         this.textCreditCardNumber.Size = new System.Drawing.Size(217, 20);
         this.textCreditCardNumber.TabIndex = 1;
         // 
         // cmbCreditCardType
         // 
         this.cmbCreditCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbCreditCardType.FormattingEnabled = true;
         this.cmbCreditCardType.Location = new System.Drawing.Point(113, 57);
         this.cmbCreditCardType.MaxDropDownItems = 20;
         this.cmbCreditCardType.Name = "cmbCreditCardType";
         this.cmbCreditCardType.Size = new System.Drawing.Size(217, 21);
         this.cmbCreditCardType.TabIndex = 0;
         // 
         // splitContainer1
         // 
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
         this.splitContainer1.IsSplitterFixed = true;
         this.splitContainer1.Location = new System.Drawing.Point(0, 0);
         this.splitContainer1.Name = "splitContainer1";
         this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.btnClose);
         this.splitContainer1.Size = new System.Drawing.Size(463, 240);
         this.splitContainer1.SplitterDistance = 204;
         this.splitContainer1.TabIndex = 1;
         // 
         // btnClose
         // 
         this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnClose.Location = new System.Drawing.Point(359, 6);
         this.btnClose.Name = "btnClose";
         this.btnClose.Size = new System.Drawing.Size(100, 23);
         this.btnClose.TabIndex = 0;
         this.btnClose.Text = "&Close";
         this.btnClose.UseVisualStyleBackColor = true;
         this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
         // 
         // tabPageIBANConverter
         // 
         this.tabPageIBANConverter.Controls.Add(this.textIBAN);
         this.tabPageIBANConverter.Controls.Add(this.btnConvertToIBAN);
         this.tabPageIBANConverter.Controls.Add(this.labNationalAccountNumber);
         this.tabPageIBANConverter.Controls.Add(this.propertyGridIBAN);
         this.tabPageIBANConverter.Controls.Add(this.labCountry);
         this.tabPageIBANConverter.Controls.Add(this.cmbCountry);
         this.tabPageIBANConverter.Location = new System.Drawing.Point(4, 22);
         this.tabPageIBANConverter.Name = "tabPageIBANConverter";
         this.tabPageIBANConverter.Size = new System.Drawing.Size(455, 178);
         this.tabPageIBANConverter.TabIndex = 2;
         this.tabPageIBANConverter.Text = "IBAN Converter";
         this.tabPageIBANConverter.UseVisualStyleBackColor = true;
         // 
         // cmbCountry
         // 
         this.cmbCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbCountry.FormattingEnabled = true;
         this.cmbCountry.Location = new System.Drawing.Point(146, 12);
         this.cmbCountry.Name = "cmbCountry";
         this.cmbCountry.Size = new System.Drawing.Size(301, 21);
         this.cmbCountry.TabIndex = 0;
         this.cmbCountry.SelectedIndexChanged += new System.EventHandler(this.cmbCountry_SelectedIndexChanged);
         // 
         // labCountry
         // 
         this.labCountry.AutoSize = true;
         this.labCountry.Location = new System.Drawing.Point(8, 15);
         this.labCountry.Name = "labCountry";
         this.labCountry.Size = new System.Drawing.Size(43, 13);
         this.labCountry.TabIndex = 1;
         this.labCountry.Text = "Country";
         // 
         // propertyGridIBAN
         // 
         this.propertyGridIBAN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.propertyGridIBAN.HelpVisible = false;
         this.propertyGridIBAN.Location = new System.Drawing.Point(146, 39);
         this.propertyGridIBAN.Name = "propertyGridIBAN";
         this.propertyGridIBAN.Size = new System.Drawing.Size(301, 107);
         this.propertyGridIBAN.TabIndex = 2;
         this.propertyGridIBAN.ToolbarVisible = false;
         // 
         // labNationalAccountNumber
         // 
         this.labNationalAccountNumber.AutoSize = true;
         this.labNationalAccountNumber.Location = new System.Drawing.Point(8, 48);
         this.labNationalAccountNumber.Name = "labNationalAccountNumber";
         this.labNationalAccountNumber.Size = new System.Drawing.Size(129, 13);
         this.labNationalAccountNumber.TabIndex = 3;
         this.labNationalAccountNumber.Text = "National Account Number";
         // 
         // btnConvertToIBAN
         // 
         this.btnConvertToIBAN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnConvertToIBAN.Location = new System.Drawing.Point(347, 152);
         this.btnConvertToIBAN.Name = "btnConvertToIBAN";
         this.btnConvertToIBAN.Size = new System.Drawing.Size(100, 23);
         this.btnConvertToIBAN.TabIndex = 4;
         this.btnConvertToIBAN.Text = "Convert";
         this.btnConvertToIBAN.UseVisualStyleBackColor = true;
         this.btnConvertToIBAN.Click += new System.EventHandler(this.btnConvertToIBAN_Click);
         // 
         // textIBAN
         // 
         this.textIBAN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.textIBAN.Location = new System.Drawing.Point(8, 154);
         this.textIBAN.Name = "textIBAN";
         this.textIBAN.ReadOnly = true;
         this.textIBAN.Size = new System.Drawing.Size(333, 20);
         this.textIBAN.TabIndex = 5;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(463, 240);
         this.Controls.Add(this.splitContainer1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimumSize = new System.Drawing.Size(469, 272);
         this.Name = "MainForm";
         this.Text = "Account Number Check";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.tabControl1.ResumeLayout(false);
         this.tabPageAccountNumbers.ResumeLayout(false);
         this.tabPageAccountNumbers.PerformLayout();
         this.tabPageCreditCard.ResumeLayout(false);
         this.tabPageCreditCard.PerformLayout();
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
         this.splitContainer1.ResumeLayout(false);
         this.tabPageIBANConverter.ResumeLayout(false);
         this.tabPageIBANConverter.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TabControl tabControl1;
      private System.Windows.Forms.TabPage tabPageAccountNumbers;
      private System.Windows.Forms.Label labGermanAccountResult;
      private System.Windows.Forms.Button btnCheckGermanAccount;
      private System.Windows.Forms.TextBox textBankCode;
      private System.Windows.Forms.Label labBankcode;
      private System.Windows.Forms.TextBox textGermanAccountNumber;
      private System.Windows.Forms.Label labAccountNumber;
      private System.Windows.Forms.TabPage tabPageCreditCard;
      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.Button btnClose;
      private System.Windows.Forms.Label labCreditCardResult;
      private System.Windows.Forms.Label labCreditCardNumber;
      private System.Windows.Forms.TextBox textCreditCardNumber;
      private System.Windows.Forms.ComboBox cmbCreditCardType;
      private System.Windows.Forms.Button btnCreditCardNumberCheck;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TabPage tabPageIBANConverter;
      private System.Windows.Forms.Label labNationalAccountNumber;
      private System.Windows.Forms.PropertyGrid propertyGridIBAN;
      private System.Windows.Forms.Label labCountry;
      private System.Windows.Forms.ComboBox cmbCountry;
      private System.Windows.Forms.TextBox textIBAN;
      private System.Windows.Forms.Button btnConvertToIBAN;
   }
}

