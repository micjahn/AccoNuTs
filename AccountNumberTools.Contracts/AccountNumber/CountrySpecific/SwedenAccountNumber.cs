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
   /// represents a national account number of Sweden
   /// </summary>
   public class SwedenAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="SwedenAccountNumber"/> class.
      /// </summary>
      public SwedenAccountNumber()
         : base(Country.Sweden)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="SwedenAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public SwedenAccountNumber(NationalAccountNumber other)
         : base(other, Country.Sweden)
      {
      }
   }
}
