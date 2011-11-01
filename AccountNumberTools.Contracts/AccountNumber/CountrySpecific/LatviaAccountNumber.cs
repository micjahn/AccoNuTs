//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

using System;

using AccountNumberTools.Common.Contracts;

namespace AccountNumberTools.AccountNumber.Contracts.CountrySpecific
{
   /// <summary>
   /// represents a national account number of Latvia
   /// </summary>
   [Serializable]
   public class LatviaAccountNumber : AccountAndBICNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="LatviaAccountNumber"/> class.
      /// </summary>
      public LatviaAccountNumber()
         : base(Country.Latvia)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="LatviaAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public LatviaAccountNumber(NationalAccountNumber other)
         : base(other, Country.Latvia)
      {
      }
   }
}
