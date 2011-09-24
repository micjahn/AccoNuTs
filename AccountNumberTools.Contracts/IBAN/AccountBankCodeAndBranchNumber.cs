//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

using System.ComponentModel;

namespace AccountNumberTools.IBAN.Contracts
{
   /// <summary>
   /// a new class
   /// </summary>
   public class AccountBankCodeAndBranchNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Gets or sets the branch
      /// </summary>
      /// <value>
      /// The bank code.
      /// </value>
      [Category("Account")]
      public string Branch { get; set; }

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
            return new[] { BankCode, Branch, AccountNumber };
         }
         set
         {
            BankCode = value.Length > 0 ? value[0] : null;
            Branch = value.Length > 1 ? value[1] : null;
            AccountNumber = value.Length > 2 ? value[2] : null;
         }
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="AccountBankCodeAndBranchNumber"/> class.
      /// </summary>
      /// <param name="country">The country.</param>
      protected AccountBankCodeAndBranchNumber(Country country)
         : base(country)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="AccountBankCodeAndBranchNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      protected AccountBankCodeAndBranchNumber(NationalAccountNumber other)
         : base(other)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="AccountBankCodeAndBranchNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      /// <param name="newCountry">The new country.</param>
      protected AccountBankCodeAndBranchNumber(NationalAccountNumber other, Country newCountry)
         : base(other, newCountry)
      {
      }
   }
}
