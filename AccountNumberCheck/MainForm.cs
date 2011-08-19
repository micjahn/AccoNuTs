//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AccountNumberTools;
using AccountNumberTools.Contracts;

namespace AccountNumberCheck
{
   public partial class MainForm : Form
   {
      private IAccountNumberCheckWithBankCode germanAccountNumberCheck;
      private ICreditCardNumberCheck creditCardNumberCheck;

      private IAccountNumberCheckWithBankCode GermanAccountNumberCheck
      {
         get
         {
            if (germanAccountNumberCheck == null)
               germanAccountNumberCheck = new AccountNumberTools.AccountNumberCheck();
            return germanAccountNumberCheck;
         }
      }

      private ICreditCardNumberCheck CreditCardNumberCheck
      {
         get
         {
            if (creditCardNumberCheck == null)
               creditCardNumberCheck = new AccountNumberTools.CreditCardNumberCheck();
            return creditCardNumberCheck;
         }
      }

      public MainForm()
      {
         InitializeComponent();
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         foreach (var fieldInfo in typeof(CreditCardNetwork).GetFields())
         {
            cmbCreditCardType.Items.Add(fieldInfo.Name);
         }
         cmbCreditCardType.SelectedIndex = 0;
      }

      private void btnCheckGermanAccount_Click(object sender, EventArgs e)
      {
         if (GermanAccountNumberCheck.IsValid(textGermanAccountNumber.Text, textBankCode.Text))
            labGermanAccountResult.Text = "Ok";
         else
            labGermanAccountResult.Text = "Fail";
      }

      private void btnCreditCardNumberCheck_Click(object sender, EventArgs e)
      {
         var creditCardNetwork = CreditCardNetwork.Automatic;
         foreach (var fieldInfo in typeof(CreditCardNetwork).GetFields())
         {
            if (fieldInfo.Name == cmbCreditCardType.SelectedItem.ToString())
            {
               creditCardNetwork = fieldInfo.GetRawConstantValue().ToString();
               break;
            }
         }

         if (CreditCardNumberCheck.IsValid(textCreditCardNumber.Text, creditCardNetwork))
            labCreditCardResult.Text = "Ok";
         else
            labCreditCardResult.Text = "Fail";
      }
   }
}
