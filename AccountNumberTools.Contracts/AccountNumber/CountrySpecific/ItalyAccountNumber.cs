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
   /// represents a national account number of Italy
   /// </summary>
   public class ItalyAccountNumber : AccountBankCodeAndBranchNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="ItalyAccountNumber"/> class.
      /// </summary>
      public ItalyAccountNumber()
         : base(Country.Italy)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="ItalyAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public ItalyAccountNumber(NationalAccountNumber other)
         : base(other, Country.Italy)
      {
      }
   }
}
