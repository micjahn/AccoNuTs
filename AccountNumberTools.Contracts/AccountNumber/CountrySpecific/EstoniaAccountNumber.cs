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
   /// represents a national account number of Estonia
   /// </summary>
   public class EstoniaAccountNumber : AccountBankCodeAndBranchNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="EstoniaAccountNumber"/> class.
      /// </summary>
      public EstoniaAccountNumber()
         : base(Country.Estonia)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="EstoniaAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public EstoniaAccountNumber(NationalAccountNumber other)
         : base(other, Country.Estonia)
      {
      }
   }
}
