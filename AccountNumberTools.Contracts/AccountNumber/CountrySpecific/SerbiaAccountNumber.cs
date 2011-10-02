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
   /// represents a national account number of Serbia
   /// </summary>
   public class SerbiaAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="SerbiaAccountNumber"/> class.
      /// </summary>
      public SerbiaAccountNumber()
         : base(Country.Serbia)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="SerbiaAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public SerbiaAccountNumber(NationalAccountNumber other)
         : base(other, Country.Serbia)
      {
      }
   }
}
