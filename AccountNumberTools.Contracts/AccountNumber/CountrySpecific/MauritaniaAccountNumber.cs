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
   /// represents a national account number of Mauritania
   /// </summary>
   [Serializable]
   public class MauritaniaAccountNumber : AccountBankCodeAndBranchNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="MauritaniaAccountNumber"/> class.
      /// </summary>
      public MauritaniaAccountNumber()
         : base(Country.Mauritania)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="MauritaniaAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public MauritaniaAccountNumber(NationalAccountNumber other)
         : base(other, Country.Mauritania)
      {
      }
   }
}
