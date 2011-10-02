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
   /// represents a national account number of Liechtenstein
   /// </summary>
   public class LiechtensteinAccountNumber : AccountAndBankCodeNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="LiechtensteinAccountNumber"/> class.
      /// </summary>
      public LiechtensteinAccountNumber()
         : base(Country.Liechtenstein)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="LiechtensteinAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public LiechtensteinAccountNumber(NationalAccountNumber other)
         : base(other, Country.Liechtenstein)
      {
      }
   }
}
