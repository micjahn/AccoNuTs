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
   /// represents a national account number of Kazakhstan
   /// </summary>
   [Serializable]
   public class KazakhstanAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="KazakhstanAccountNumber"/> class.
      /// </summary>
      public KazakhstanAccountNumber()
         : base(Country.Kazakhstan)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="KazakhstanAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public KazakhstanAccountNumber(NationalAccountNumber other)
         : base(other, Country.Kazakhstan)
      {
      }
   }
}
