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
   /// represents a national account number of Gibraltar
   /// </summary>
   [Serializable]
   public class GibraltarAccountNumber : AccountAndBICNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="GibraltarAccountNumber"/> class.
      /// </summary>
      public GibraltarAccountNumber()
         : base(Country.Gibraltar)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="GibraltarAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public GibraltarAccountNumber(NationalAccountNumber other)
         : base(other, Country.Gibraltar)
      {
      }
   }
}
