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
   /// represents a national account number of Austria
   /// </summary>
   public class AustriaAccountNumber  : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="AustriaAccountNumber"/> class.
      /// </summary>
      public AustriaAccountNumber()
         : base(Country.Austria)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="AustriaAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public AustriaAccountNumber(NationalAccountNumber other)
         : base(other, Country.Austria)
      {
      }
   }
}
