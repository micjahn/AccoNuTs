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
   /// represents a national account number of Finland
   /// </summary>
   public class FinlandAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="FinlandAccountNumber"/> class.
      /// </summary>
      public FinlandAccountNumber()
         : base(Country.Finland)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="FinlandAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public FinlandAccountNumber(NationalAccountNumber other)
         : base(other, Country.Finland)
      {
      }
   }
}
