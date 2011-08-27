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
using System.ComponentModel;

namespace AccountNumberTools.IBAN.Contracts
{
   /// <summary>
   /// a new class
   /// </summary>
   public abstract class AccountAndBankCodeNumber : NationalAccountNumber
   {
      /// <summary>
      /// Gets or sets the bank code.
      /// </summary>
      /// <value>
      /// The bank code.
      /// </value>
      [Category("Account")]
      public string BankCode { get; set; }

      /// <summary>
      /// Gets or sets the account number.
      /// </summary>
      /// <value>
      /// The account number.
      /// </value>
      [Category("Account")]
      public string AccountNumber { get; set; }

      /// <summary>
      /// Gets or sets the parts.
      /// </summary>
      /// <value>
      /// The parts.
      /// </value>
      [Browsable(false)]
      public override string[] Parts
      {
         get
         {
            return new[] { BankCode, AccountNumber };
         }
         set
         {
            if (value.Length > 0)
               BankCode = value[0];
            else
               BankCode = null;
            if (value.Length > 1)
               AccountNumber = value[1];
            else
               AccountNumber = null;
         }
      }

      private AccountAndBankCodeNumber()
         : base(Country.Albania)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="AccountAndBankCodeNumber"/> class.
      /// </summary>
      /// <param name="country">The country.</param>
      protected AccountAndBankCodeNumber(Country country)
         : base(country)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="AccountAndBankCodeNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      protected AccountAndBankCodeNumber(NationalAccountNumber other)
         : base(other)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="AccountAndBankCodeNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      /// <param name="newCountry">The new country.</param>
      protected AccountAndBankCodeNumber(NationalAccountNumber other, Country newCountry)
         : base(other, newCountry)
      {
      }
   }
}
