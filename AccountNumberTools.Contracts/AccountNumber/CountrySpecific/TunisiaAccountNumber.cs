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
   /// represents a national account number of Tunisia
   /// </summary>
   public class TunisiaAccountNumber : AccountBankCodeAndBranchNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="TunisiaAccountNumber"/> class.
      /// </summary>
      public TunisiaAccountNumber()
         : base(Country.Tunisia)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="TunisiaAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public TunisiaAccountNumber(NationalAccountNumber other)
         : base(other, Country.Tunisia)
      {
      }
   }
}
