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
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AccountNumberTools.AccountNumber.Contracts;
using AccountNumberTools.AccountNumber.IBAN;
using AccountNumberTools.AccountNumber.IBAN.Extensions;
using AccountNumberTools.AccountNumber.Validation.Contracts;
using AccountNumberTools.AccountNumber.Validation.Extensions;
using AccountNumberTools.Common.Contracts;
using AccountNumberTools.CreditCard.Contracts;
using AccountNumberTools.CreditCard.Extensions;

namespace AccountNumberCheck
{
   public partial class MainForm : Form
   {
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
         {
            cmbCountry.Items.Add(val);
            cmbCountryValidation.Items.Add(val);
         }
         cmbCountryValidation.SelectedItem = Country.Germany;
      }

      private void btnCheckGermanAccount_Click(object sender, EventArgs e)
      {
         var accountNumber = ((NationalAccountNumber) propertyGridNationalAccountNumberValidation.SelectedObject);
         var validationErrors = new List<ValidationError>();
         var result = accountNumber.Validate(validationErrors);
         if (result)
            labGermanAccountResult.Text = "Ok";
         else
         {
            labGermanAccountResult.Text = "Fail";
            var errors = new StringBuilder();
            foreach (var validationError in validationErrors)
               errors.AppendLine(validationError.Message);
            txtValidationErrors.Text = errors.ToString();
         }
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

         if (textCreditCardNumber.Text.IsValid(creditCardNetwork))
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

         textIBAN.Text = ((NationalAccountNumber)propertyGridIBAN.SelectedObject).ToIBAN();
      }

      private void cmbCountryValidation_SelectedIndexChanged(object sender, EventArgs e)
      {
         var country = (Country)cmbCountryValidation.SelectedItem;
         try
         {
            propertyGridNationalAccountNumberValidation.SelectedObject = IBANTools.CreateCountrySpecificAccountNumber(country);
         }
         catch (ArgumentException exc)
         {
            MessageBox.Show(this, exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
   }
}
