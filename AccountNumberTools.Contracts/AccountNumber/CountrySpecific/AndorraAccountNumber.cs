﻿//
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
   /// represents a national account number of Andorra
   /// </summary>
   [Serializable]
   public class AndorraAccountNumber : AccountBankCodeAndBranchNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="AndorraAccountNumber"/> class.
      /// </summary>
      public AndorraAccountNumber()
         : base(Country.Andorra)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="AndorraAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public AndorraAccountNumber(NationalAccountNumber other)
         : base(other, Country.Andorra)
      {
      }
   }
}
