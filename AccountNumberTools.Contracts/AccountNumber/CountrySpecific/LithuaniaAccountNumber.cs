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
   /// represents a national account number of Lithuania
   /// </summary>
   public class LithuaniaAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="LithuaniaAccountNumber"/> class.
      /// </summary>
      public LithuaniaAccountNumber()
         : base(Country.Lithuania)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="LithuaniaAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public LithuaniaAccountNumber(NationalAccountNumber other)
         : base(other, Country.Lithuania)
      {
      }
   }
}
