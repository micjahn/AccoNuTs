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
   /// represents a national account number of Mauritius
   /// </summary>
   public class MauritiusAccountNumber : AccountBankCodeAndBranchNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="MauritiusAccountNumber"/> class.
      /// </summary>
      public MauritiusAccountNumber()
         : base(Country.Mauritius)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="MauritiusAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public MauritiusAccountNumber(NationalAccountNumber other)
         : base(other, Country.Mauritius)
      {
      }
   }
}
