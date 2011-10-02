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
   /// represents a national account number of Greenland
   /// </summary>
   public class GreenlandAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="GreenlandAccountNumber"/> class.
      /// </summary>
      public GreenlandAccountNumber()
         : base(Country.Greenland)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="GreenlandAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public GreenlandAccountNumber(NationalAccountNumber other)
         : base(other, Country.Greenland)
      {
      }
   }
}
