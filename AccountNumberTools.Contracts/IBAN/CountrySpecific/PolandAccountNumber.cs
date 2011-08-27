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
   /// represents a national account number of Poland
   /// </summary>
   public class PolandAccountNumber : AccountBankCodeAndBranchNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="PolandAccountNumber"/> class.
      /// </summary>
      public PolandAccountNumber()
         : base(Country.Poland)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="PolandAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public PolandAccountNumber(NationalAccountNumber other)
         : base(other, Country.Poland)
      {
      }
   }
}
