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
using System.Windows.Forms;

using AccountNumberTools.AccountNumber.Contracts;
using AccountNumberTools.CreditCard.Contracts;
using AccountNumberTools.IBAN.Contracts;
using AccountNumberTools.IBAN;

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
            return ibanConverter ?? (ibanConverter = new IBANConvert());
         }
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="MainForm"/> class.
      /// </summary>
      public MainForm()
      {
         InitializeComponent();
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         foreach (var fieldInfo in typeof(CreditCardNetwork).GetFields())
         {
            cmbCreditCardType.Items.Add(fieldInfo.Name);
         }
         cmbCreditCardType.SelectedIndex = 0;

         foreach (var val in Enum.GetValues(typeof(Country)))
            cmbCountry.Items.Add(val);
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
         var country = (Country)cmbCountry.SelectedItem;
         try
         {
            propertyGridIBAN.SelectedObject = IBANTools.CreateCountrySpecificAccountNumber(country);
         }
         catch (ArgumentException exc)
         {
            MessageBox.Show(this, exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void btnConvertToIBAN_Click(object sender, EventArgs e)
      {
         if (propertyGridIBAN.SelectedObject == null)
            return;

         textIBAN.Text = IBANConverter.ToIBAN((NationalAccountNumber)propertyGridIBAN.SelectedObject);
      }
   }
}
