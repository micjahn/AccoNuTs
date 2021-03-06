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
   /// represents a national account number of Israel
   /// </summary>
   [Serializable]
   public class IsraelAccountNumber : AccountBankCodeAndBranchNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="IsraelAccountNumber"/> class.
      /// </summary>
      public IsraelAccountNumber()
         : base(Country.Israel)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="IsraelAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public IsraelAccountNumber(NationalAccountNumber other)
         : base(other, Country.Israel)
      {
      }
   }
}
