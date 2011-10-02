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
   /// represents a national account number of Ireland
   /// </summary>
   public class IrelandAccountNumber : AccountBICAndBranchNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="IrelandAccountNumber"/> class.
      /// </summary>
      public IrelandAccountNumber()
         : base(Country.Ireland)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="IrelandAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public IrelandAccountNumber(NationalAccountNumber other)
         : base(other, Country.Ireland)
      {
      }
   }
}
