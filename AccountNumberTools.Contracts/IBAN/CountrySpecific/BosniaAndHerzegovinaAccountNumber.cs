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
   /// represents a national account number of Bosnia and Herzegovina
   /// </summary>
   public class BosniaAndHerzegovinaAccountNumber : AccountBankCodeAndBranchNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="BosniaAndHerzegovinaAccountNumber"/> class.
      /// </summary>
      public BosniaAndHerzegovinaAccountNumber()
         : base(Country.BosniaAndHerzegovina)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="BosniaAndHerzegovinaAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public BosniaAndHerzegovinaAccountNumber(NationalAccountNumber other)
         : base(other, Country.BosniaAndHerzegovina)
      {
      }
   }
}
