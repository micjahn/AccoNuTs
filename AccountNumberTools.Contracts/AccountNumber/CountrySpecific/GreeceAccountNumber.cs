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
   /// represents a national account number of Greece
   /// </summary>
   [Serializable]
   public class GreeceAccountNumber : AccountBankCodeAndBranchNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="GreeceAccountNumber"/> class.
      /// </summary>
      public GreeceAccountNumber()
         : base(Country.Greece)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="GreeceAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public GreeceAccountNumber(NationalAccountNumber other)
         : base(other, Country.Greece)
      {
      }
   }
}
