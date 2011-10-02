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
   /// represents a national account number of Belgium
   /// </summary>
   public class BelgiumAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="BelgiumAccountNumber"/> class.
      /// </summary>
      public BelgiumAccountNumber()
         : base(Country.Belgium)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="BelgiumAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public BelgiumAccountNumber(NationalAccountNumber other)
         : base(other, Country.Belgium)
      {
      }
   }
}
