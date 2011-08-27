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
   /// represents a national account number of Macedonia
   /// </summary>
   public class MacedoniaAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="MacedoniaAccountNumber"/> class.
      /// </summary>
      public MacedoniaAccountNumber()
         : base(Country.Macedonia)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="MacedoniaAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public MacedoniaAccountNumber(NationalAccountNumber other)
         : base(other, Country.Macedonia)
      {
      }
   }
}
