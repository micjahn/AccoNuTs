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
   /// represents a national account number of Denmark
   /// </summary>
   public class DenmarkAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="DenmarkAccountNumber"/> class.
      /// </summary>
      public DenmarkAccountNumber()
         : base(Country.Denmark)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="DenmarkAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public DenmarkAccountNumber(NationalAccountNumber other)
         : base(other, Country.Denmark)
      {
      }
   }
}
