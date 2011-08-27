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

      private AccountBICAndBranchNumber()
         : base(Country.Albania)
      {
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
