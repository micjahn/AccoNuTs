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
   /// represents a national account number of Portugal
   /// </summary>
   [Serializable]
   public class PortugalAccountNumber : AccountBankCodeAndBranchNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="PortugalAccountNumber"/> class.
      /// </summary>
      public PortugalAccountNumber()
         : base(Country.Portugal)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="PortugalAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public PortugalAccountNumber(NationalAccountNumber other)
         : base(other, Country.Portugal)
      {
      }
   }
}
