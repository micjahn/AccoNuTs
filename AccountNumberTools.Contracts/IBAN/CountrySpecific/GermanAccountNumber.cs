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

namespace AccountNumberTools.IBAN.Contracts.CountrySpecific
{
   /// <summary>
   /// represents a national german account number
   /// </summary>
   public class GermanAccountNumber : NationalAccountNumber
   {
      /// <summary>
      /// Gets or sets the bank code.
      /// </summary>
      /// <value>
      /// The bank code.
      /// </value>
      public string BankCode { get; set; }
      /// <summary>
      /// Gets or sets the account number.
      /// </summary>
      /// <value>
      /// The account number.
      /// </value>
      public string AccountNumber { get; set; }

      /// <summary>
      /// Gets or sets the parts.
      /// </summary>
      /// <value>
      /// The parts.
      /// </value>
      public override string[] Parts
      {
         get
         {
            return new [] { BankCode, AccountNumber };
         }
         set
         {
            if (value.Length > 0)
               BankCode = value[0];
            else
               BankCode = null;
            if (value.Length > 1)
               AccountNumber = value[1];
            else
               AccountNumber = null;
         }
      }
   }
}
