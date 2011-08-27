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
   /// represents a national account number of Bulgaria
   /// </summary>
   public class BulgariaAccountNumber : AccountBICAndBranchNumber
   {
      /// <summary>
      /// Gets or sets the branch
      /// </summary>
      /// <value>
      /// The bank code.
      /// </value>
      [Category("Account")]
      public string AccountType { get; set; }
      
      /// <summary>
      /// Initializes a new instance of the <see cref="BulgariaAccountNumber"/> class.
      /// </summary>
      public BulgariaAccountNumber()
         : base(Country.Bulgaria)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="BulgariaAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public BulgariaAccountNumber(NationalAccountNumber other)
         : base(other, Country.Bulgaria)
      {
      }
   }
}
