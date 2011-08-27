//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

namespace AccountNumberTools.IBAN.Contracts.CountrySpecific
{
   /// <summary>
   /// represents a national account number of France
   /// </summary>
   public class FranceAccountNumber : AccountBankCodeAndBranchNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="FranceAccountNumber"/> class.
      /// </summary>
      public FranceAccountNumber()
         : base(Country.France)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="FranceAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public FranceAccountNumber(NationalAccountNumber other)
         : base(other, Country.France)
      {
      }
   }
}
