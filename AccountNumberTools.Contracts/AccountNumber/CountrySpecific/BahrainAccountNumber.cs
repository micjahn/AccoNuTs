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
   /// represents a national account number of Bahrain
   /// </summary>
   public class BahrainAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="BahrainAccountNumber"/> class.
      /// </summary>
      public BahrainAccountNumber()
         : base(Country.Bahrain)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="BahrainAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public BahrainAccountNumber(NationalAccountNumber other)
         : base(other, Country.Bahrain)
      {
      }
   }
}
