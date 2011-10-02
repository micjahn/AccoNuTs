//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

using AccountNumberTools.Common.Contracts;

namespace AccountNumberTools.AccountNumber.Contracts.CountrySpecific
{
   /// <summary>
   /// represents a national account number of Romania
   /// </summary>
   public class RomaniaAccountNumber : AccountAndBICNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="RomaniaAccountNumber"/> class.
      /// </summary>
      public RomaniaAccountNumber()
         : base(Country.Romania)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="RomaniaAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public RomaniaAccountNumber(NationalAccountNumber other)
         : base(other, Country.Romania)
      {
      }
   }
}
