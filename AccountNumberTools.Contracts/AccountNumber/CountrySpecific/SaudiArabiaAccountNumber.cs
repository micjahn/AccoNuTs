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
   /// represents a national account number of Saudi Arabia
   /// </summary>
   [Serializable]
   public class SaudiArabiaAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="SaudiArabiaAccountNumber"/> class.
      /// </summary>
      public SaudiArabiaAccountNumber()
         : base(Country.SaudiArabia)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="SaudiArabiaAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public SaudiArabiaAccountNumber(NationalAccountNumber other)
         : base(other, Country.SaudiArabia)
      {
      }
   }
}
