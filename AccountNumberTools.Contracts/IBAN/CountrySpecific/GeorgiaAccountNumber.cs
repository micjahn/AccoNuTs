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
   /// represents a national account number of Georgia
   /// </summary>
   public class GeorgiaAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="GeorgiaAccountNumber"/> class.
      /// </summary>
      public GeorgiaAccountNumber()
         : base(Country.Georgia)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="GeorgiaAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public GeorgiaAccountNumber(NationalAccountNumber other)
         : base(other, Country.Georgia)
      {
      }
   }
}
