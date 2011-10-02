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
   /// represents a national account number of Malta
   /// </summary>
   public class MaltaAccountNumber : AccountBICAndBranchNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="MaltaAccountNumber"/> class.
      /// </summary>
      public MaltaAccountNumber()
         : base(Country.Malta)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="MaltaAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public MaltaAccountNumber(NationalAccountNumber other)
         : base(other, Country.Malta)
      {
      }
   }
}
