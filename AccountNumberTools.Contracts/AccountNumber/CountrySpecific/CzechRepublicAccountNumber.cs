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

using AccountNumberTools.Common.Contracts;

namespace AccountNumberTools.AccountNumber.Contracts.CountrySpecific
{
   /// <summary>
   /// represents a national account number of Czech Republic 
   /// </summary>
   [Serializable]
   public class CzechRepublicAccountNumber : AccountBankCodeAndBranchNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="CzechRepublicAccountNumber"/> class.
      /// </summary>
      public CzechRepublicAccountNumber()
         : base(Country.CzechRepublic)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="CzechRepublicAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public CzechRepublicAccountNumber(NationalAccountNumber other)
         : base(other, Country.CzechRepublic)
      {
      }
   }
}
