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
   /// represents a national account number of Dominican Republic
   /// </summary>
   public class DominicanRepublicAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="DominicanRepublicAccountNumber"/> class.
      /// </summary>
      public DominicanRepublicAccountNumber()
         : base(Country.DominicanRepublic)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="DominicanRepublicAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public DominicanRepublicAccountNumber(NationalAccountNumber other)
         : base(other, Country.DominicanRepublic)
      {
      }
   }
}
