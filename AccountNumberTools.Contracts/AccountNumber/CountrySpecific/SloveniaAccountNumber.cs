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
   /// represents a national account number of Slovenia
   /// </summary>
   [Serializable]
   public class SloveniaAccountNumber : AccountBankCodeAndBranchNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="SloveniaAccountNumber"/> class.
      /// </summary>
      public SloveniaAccountNumber()
         : base(Country.Slovenia)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="SloveniaAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public SloveniaAccountNumber(NationalAccountNumber other)
         : base(other, Country.Slovenia)
      {
      }
   }
}
