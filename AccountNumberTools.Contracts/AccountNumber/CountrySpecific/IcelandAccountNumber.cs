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

using AccountNumberTools.Common.Contracts;

namespace AccountNumberTools.AccountNumber.Contracts.CountrySpecific
{
   /// <summary>
   /// represents a national account number of Iceland
   /// </summary>
   [Serializable]
   public class IcelandAccountNumber : AccountBankCodeAndBranchNumber
   {
      /// <summary>
      /// Gets or sets the bank code.
      /// </summary>
      /// <value>
      /// The bank code.
      /// </value>
      [Category("Account")]
      public string HoldersNationalId { get; set; }

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
            return new[] { BankCode, Branch, AccountNumber, HoldersNationalId };
         }
         set
         {
            BankCode = value.Length > 0 ? value[0] : null;
            Branch = value.Length > 1 ? value[1] : null;
            AccountNumber = value.Length > 2 ? value[2] : null;
            HoldersNationalId = value.Length > 3 ? value[3] : null;
         }
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="IcelandAccountNumber"/> class.
      /// </summary>
      public IcelandAccountNumber()
         : base(Country.Iceland)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="IcelandAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public IcelandAccountNumber(NationalAccountNumber other)
         : base(other, Country.Iceland)
      {
      }
   }
}
