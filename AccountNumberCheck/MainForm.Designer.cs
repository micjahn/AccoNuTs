namespace AccountNumberCheck
{
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
         this.tabPage1 = new System.Windows.Forms.TabPage();
         this.labGermanAccountResult = new System.Windows.Forms.Label();
         this.btnCheckGermanAccount = new System.Windows.Forms.Button();
         this.textBankCode = new System.Windows.Forms.TextBox();
         this.labBankcode = new System.Windows.Forms.Label();
         this.textGermanAccountNumber = new System.Windows.Forms.TextBox();
         this.labAccountNumber = new System.Windows.Forms.Label();
         this.tabPage2 = new System.Windows.Forms.TabPage();
         this.btnCreditCardNumberCheck = new System.Windows.Forms.Button();
         this.label2 = new System.Windows.Forms.Label();
         this.labCreditCardResult = new System.Windows.Forms.Label();
         this.labCreditCardNumber = new System.Windows.Forms.Label();
         this.textCreditCardNumber = new System.Windows.Forms.TextBox();
         this.cmbCreditCardType = new System.Windows.Forms.ComboBox();
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.btnClose = new System.Windows.Forms.Button();
         this.tabControl1.SuspendLayout();
         this.tabPage1.SuspendLayout();
         this.tabPage2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.SuspendLayout();
         // 
         // tabControl1
         // 
         this.tabControl1.Controls.Add(this.tabPage1);
         this.tabControl1.Controls.Add(this.tabPage2);
         this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabControl1.Location = new System.Drawing.Point(0, 0);
         this.tabControl1.Name = "tabControl1";
         this.tabControl1.SelectedIndex = 0;
         this.tabControl1.Size = new System.Drawing.Size(463, 204);
         this.tabControl1.TabIndex = 0;
         // 
         // tabPage1
         // 
         this.tabPage1.Controls.Add(this.labGermanAccountResult);
         this.tabPage1.Controls.Add(this.btnCheckGermanAccount);
         this.tabPage1.Controls.Add(this.textBankCode);
         this.tabPage1.Controls.Add(this.labBankcode);
         this.tabPage1.Controls.Add(this.textGermanAccountNumber);
         this.tabPage1.Controls.Add(this.labAccountNumber);
         this.tabPage1.Location = new System.Drawing.Point(4, 22);
         this.tabPage1.Name = "tabPage1";
         this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
         this.tabPage1.Size = new System.Drawing.Size(455, 178);
         this.tabPage1.TabIndex = 0;
         this.tabPage1.Text = "German Account Numbers";
         this.tabPage1.UseVisualStyleBackColor = true;
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
         // tabPage2
         // 
         this.tabPage2.Controls.Add(this.btnCreditCardNumberCheck);
         this.tabPage2.Controls.Add(this.label2);
         this.tabPage2.Controls.Add(this.labCreditCardResult);
         this.tabPage2.Controls.Add(this.labCreditCardNumber);
         this.tabPage2.Controls.Add(this.textCreditCardNumber);
         this.tabPage2.Controls.Add(this.cmbCreditCardType);
         this.tabPage2.Location = new System.Drawing.Point(4, 22);
         this.tabPage2.Name = "tabPage2";
         this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
         this.tabPage2.Size = new System.Drawing.Size(455, 178);
         this.tabPage2.TabIndex = 1;
         this.tabPage2.Text = "Credit Card Numbers";
         this.tabPage2.UseVisualStyleBackColor = true;
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
         this.tabPage1.ResumeLayout(false);
         this.tabPage1.PerformLayout();
         this.tabPage2.ResumeLayout(false);
         this.tabPage2.PerformLayout();
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
         this.splitContainer1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TabControl tabControl1;
      private System.Windows.Forms.TabPage tabPage1;
      private System.Windows.Forms.Label labGermanAccountResult;
      private System.Windows.Forms.Button btnCheckGermanAccount;
      private System.Windows.Forms.TextBox textBankCode;
      private System.Windows.Forms.Label labBankcode;
      private System.Windows.Forms.TextBox textGermanAccountNumber;
      private System.Windows.Forms.Label labAccountNumber;
      private System.Windows.Forms.TabPage tabPage2;
      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.Button btnClose;
      private System.Windows.Forms.Label labCreditCardResult;
      private System.Windows.Forms.Label labCreditCardNumber;
      private System.Windows.Forms.TextBox textCreditCardNumber;
      private System.Windows.Forms.ComboBox cmbCreditCardType;
      private System.Windows.Forms.Button btnCreditCardNumberCheck;
      private System.Windows.Forms.Label label2;
   }
}

