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

namespace AccountNumberTools.AccountNumber.Contracts
{
   /// <summary>
   /// represents the base class for a country specific account number which consists of
   /// a BIC, a branch code and an account number
   /// </summary>
   [Serializable]
   public class AccountBICAndBranchNumber : AccountAndBICNumber
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
            return new[] { BIC, Branch, AccountNumber };
         }
         set
         {
            BIC = value.Length > 0 ? value[0] : null;
            Branch = value.Length > 1 ? value[1] : null;
            AccountNumber = value.Length > 2 ? value[2] : null;
         }
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="AccountBICAndBranchNumber"/> class.
      /// </summary>
      /// <param name="country">The country.</param>
      protected AccountBICAndBranchNumber(Country country)
         : base(country)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="AccountBICAndBranchNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      protected AccountBICAndBranchNumber(NationalAccountNumber other)
         : base(other)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="AccountBICAndBranchNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      /// <param name="newCountry">The new country.</param>
      protected AccountBICAndBranchNumber(NationalAccountNumber other, Country newCountry)
         : base(other, newCountry)
      {
      }
   }
}
