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
   /// represents a national account number of Germany
   /// </summary>
   public class GermanyAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="GermanyAccountNumber"/> class.
      /// </summary>
      public GermanyAccountNumber()
         : base(Country.Germany)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="GermanyAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public GermanyAccountNumber(NationalAccountNumber other)
         : base(other, Country.Germany)
      {
      }
   }
}
