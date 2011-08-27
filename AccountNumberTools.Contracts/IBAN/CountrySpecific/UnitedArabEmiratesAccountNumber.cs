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
   /// represents a national account number of United Arab Emirates
   /// </summary>
   public class UnitedArabEmiratesAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="UnitedArabEmiratesAccountNumber"/> class.
      /// </summary>
      public UnitedArabEmiratesAccountNumber()
         : base(Country.UnitedArabEmirates)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="UnitedArabEmiratesAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public UnitedArabEmiratesAccountNumber(NationalAccountNumber other)
         : base(other, Country.UnitedArabEmirates)
      {
      }
   }
}
