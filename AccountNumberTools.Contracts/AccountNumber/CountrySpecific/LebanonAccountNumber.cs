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
   /// represents a national account number of Lebanon
   /// </summary>
   [Serializable]
   public class LebanonAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="LebanonAccountNumber"/> class.
      /// </summary>
      public LebanonAccountNumber()
         : base(Country.Lebanon)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="LebanonAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public LebanonAccountNumber(NationalAccountNumber other)
         : base(other, Country.Lebanon)
      {
      }
   }
}
