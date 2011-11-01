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
   /// represents a national account number of Spain
   /// </summary>
   [Serializable]
   public class SpainAccountNumber : AccountBankCodeAndBranchNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="SpainAccountNumber"/> class.
      /// </summary>
      public SpainAccountNumber()
         : base(Country.Spain)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="SpainAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public SpainAccountNumber(NationalAccountNumber other)
         : base(other, Country.Spain)
      {
      }
   }
}
