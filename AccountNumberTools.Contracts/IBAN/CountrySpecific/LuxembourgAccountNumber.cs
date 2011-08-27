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
   /// represents a national account number of Luxembourg
   /// </summary>
   public class LuxembourgAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="LuxembourgAccountNumber"/> class.
      /// </summary>
      public LuxembourgAccountNumber()
         : base(Country.Luxembourg)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="LuxembourgAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public LuxembourgAccountNumber(NationalAccountNumber other)
         : base(other, Country.Luxembourg)
      {
      }
   }
}
