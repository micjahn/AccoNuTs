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
   /// represents a national account number of Netherlands
   /// </summary>
   public class NetherlandsAccountNumber : AccountAndBICNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="NetherlandsAccountNumber"/> class.
      /// </summary>
      public NetherlandsAccountNumber()
         : base(Country.Netherlands)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="NetherlandsAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public NetherlandsAccountNumber(NationalAccountNumber other)
         : base(other, Country.Netherlands)
      {
      }
   }
}
