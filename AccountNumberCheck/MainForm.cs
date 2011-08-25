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

using AccountNumberTools.AccountNumber.Contracts;
using AccountNumberTools.CreditCard.Contracts;
using AccountNumberTools.IBAN.Contracts;
using AccountNumberTools.IBAN.Contracts.CountrySpecific;

namespace AccountNumberCheck
{
   public partial class MainForm : Form
   {
      private IAccountNumberCheckWithBankCode germanAccountNumberCheck;
      private ICreditCardNumberCheck creditCardNumberCheck;
      private IIBANConvert ibanConverter;

      private IAccountNumberCheckWithBankCode GermanAccountNumberCheck
      {
         get
         {
            return germanAccountNumberCheck ?? (germanAccountNumberCheck = new AccountNumberTools.AccountNumber.AccountNumberCheck());
         }
      }

      private ICreditCardNumberCheck CreditCardNumberCheck
      {
         get
         {
            return creditCardNumberCheck ?? (creditCardNumberCheck = new AccountNumberTools.CreditCard.CreditCardNumberCheck());
         }
      }

      private IIBANConvert IBANConverter
      {
         get
         {
            return ibanConverter ?? (ibanConverter = new AccountNumberTools.IBAN.IBANConvert());
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

         cmbCountry.Items.Add(Country.Germany);
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

      private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
      {
         switch ((Country)cmbCountry.SelectedItem)
         {
            case Country.Germany:
               propertyGridIBAN.SelectedObject = new GermanAccountNumber();
               break;
            default:
               MessageBox.Show(this, "Country isn't supported.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               break;
         }
      }

      private void btnConvertToIBAN_Click(object sender, EventArgs e)
      {
         if (propertyGridIBAN.SelectedObject == null)
            return;

         textIBAN.Text = IBANConverter.ToIBAN((Country)cmbCountry.SelectedItem, (NationalAccountNumber)propertyGridIBAN.SelectedObject);
      }
   }
}
