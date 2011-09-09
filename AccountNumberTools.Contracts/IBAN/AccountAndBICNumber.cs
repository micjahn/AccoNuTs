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
   public abstract class AccountAndBICNumber : NationalAccountNumber
   {
      /// <summary>
      /// Gets or sets the BIC.
      /// </summary>
      /// <value>
      /// The BIC.
      /// </value>
      [Category("Account")]
      public string BIC { get; set; }

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
            return new[] { BIC, AccountNumber };
         }
         set
         {
            BIC = value.Length > 0 ? value[0] : null;
         AccountNumber = value.Length > 1 ? value[1] : null;
         }
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="AccountAndBICNumber"/> class.
      /// </summary>
      /// <param name="country">The country.</param>
      protected AccountAndBICNumber(Country country)
         : base(country)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="AccountAndBICNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      protected AccountAndBICNumber(NationalAccountNumber other)
         : base(other)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="AccountAndBICNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      /// <param name="newCountry">The new country.</param>
      protected AccountAndBICNumber(NationalAccountNumber other, Country newCountry)
         : base(other, newCountry)
      {
      }
   }
}
