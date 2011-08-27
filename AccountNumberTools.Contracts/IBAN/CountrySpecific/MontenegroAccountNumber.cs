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
   /// represents a national account number of Montenegro
   /// </summary>
   public class MontenegroAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="MontenegroAccountNumber"/> class.
      /// </summary>
      public MontenegroAccountNumber()
         : base(Country.Montenegro)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="MontenegroAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public MontenegroAccountNumber(NationalAccountNumber other)
         : base(other, Country.Montenegro)
      {
      }
   }
}
