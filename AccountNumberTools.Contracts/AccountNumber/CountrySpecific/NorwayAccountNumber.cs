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
   /// represents a national account number of Norway
   /// </summary>
   public class NorwayAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="NorwayAccountNumber"/> class.
      /// </summary>
      public NorwayAccountNumber()
         : base(Country.Norway)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="NorwayAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public NorwayAccountNumber(NationalAccountNumber other)
         : base(other, Country.Norway)
      {
      }
   }
}
