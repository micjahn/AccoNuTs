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
   /// represents a national account number of Faroe
   /// </summary>
   public class FaroeIslandsAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="FaroeIslandsAccountNumber"/> class.
      /// </summary>
      public FaroeIslandsAccountNumber()
         : base(Country.FaroeIslands)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="FaroeIslandsAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public FaroeIslandsAccountNumber(NationalAccountNumber other)
         : base(other, Country.FaroeIslands)
      {
      }
   }
}
