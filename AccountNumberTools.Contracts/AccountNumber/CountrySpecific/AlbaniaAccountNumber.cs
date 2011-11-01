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
   /// represents a national account number of Albania
   /// </summary>
   [Serializable]
   public class AlbaniaAccountNumber : AccountBankCodeAndBranchNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="AlbaniaAccountNumber"/> class.
      /// </summary>
      public AlbaniaAccountNumber()
         : base(Country.Albania)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="AlbaniaAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public AlbaniaAccountNumber(NationalAccountNumber other)
         : base(other, Country.Albania)
      {
      }
   }
}
