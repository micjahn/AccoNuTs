﻿//
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
   /// represents a national account number of Cyprus
   /// </summary>
   public class CyprusAccountNumber : AccountBankCodeAndBranchNumber
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="CyprusAccountNumber"/> class.
      /// </summary>
      public CyprusAccountNumber()
         : base(Country.Cyprus)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="CyprusAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public CyprusAccountNumber(NationalAccountNumber other)
         : base(other, Country.Cyprus)
      {
      }
   }
}