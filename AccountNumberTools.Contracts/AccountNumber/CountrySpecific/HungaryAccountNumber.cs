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
   /// represents a national account number of Hungary
   /// </summary>
   [Serializable]
   public class HungaryAccountNumber : AccountBankCodeAndBranchNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="HungaryAccountNumber"/> class.
      /// </summary>
      public HungaryAccountNumber()
         : base(Country.Hungary)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="HungaryAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public HungaryAccountNumber(NationalAccountNumber other)
         : base(other, Country.Hungary)
      {
      }
   }
}
