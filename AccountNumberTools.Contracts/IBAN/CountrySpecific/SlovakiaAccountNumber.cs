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

namespace AccountNumberTools.IBAN.Contracts.CountrySpecific
{
   /// <summary>
   /// represents a national account number of Slovakia
   /// </summary>
   public class SlovakiaAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Gets or sets the sort code.
      /// </summary>
      /// <value>
      /// The bank code.
      /// </value>
      [Category("Account")]
      public string SortCode { get; set; }

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
            return new[] { BankCode, SortCode, AccountNumber };
         }
         set
         {
            BankCode = value.Length > 0 ? value[0] : null;
            SortCode = value.Length > 1 ? value[1] : null;
            AccountNumber = value.Length > 2 ? value[2] : null;
         }
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="SlovakiaAccountNumber"/> class.
      /// </summary>
      public SlovakiaAccountNumber()
         : base(Country.Slovakia)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="SlovakiaAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public SlovakiaAccountNumber(NationalAccountNumber other)
         : base(other, Country.Slovakia)
      {
      }
   }
}
