//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

using AccountNumberTools.Common.Contracts;

namespace AccountNumberTools.AccountNumber.Contracts.CountrySpecific
{
   /// <summary>
   /// represents a national account number of Turkey
   /// </summary>
   public class TurkeyAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="TurkeyAccountNumber"/> class.
      /// </summary>
      public TurkeyAccountNumber()
         : base(Country.Turkey)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="TurkeyAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public TurkeyAccountNumber(NationalAccountNumber other)
         : base(other, Country.Turkey)
      {
      }
   }
}
