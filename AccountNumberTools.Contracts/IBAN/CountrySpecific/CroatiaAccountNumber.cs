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
   /// represents a national account number of Croatia
   /// </summary>
   public class CroatiaAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="CroatiaAccountNumber"/> class.
      /// </summary>
      public CroatiaAccountNumber()
         : base(Country.Croatia)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="CroatiaAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public CroatiaAccountNumber(NationalAccountNumber other)
         : base(other, Country.Croatia)
      {
      }
   }
}
