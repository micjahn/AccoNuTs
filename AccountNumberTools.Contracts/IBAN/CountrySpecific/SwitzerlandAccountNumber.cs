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
   /// represents a national account number of Switzerland
   /// </summary>
   public class SwitzerlandAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="SwitzerlandAccountNumber"/> class.
      /// </summary>
      public SwitzerlandAccountNumber()
         : base(Country.Switzerland)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="SwitzerlandAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public SwitzerlandAccountNumber(NationalAccountNumber other)
         : base(other, Country.Switzerland)
      {
      }
   }
}
