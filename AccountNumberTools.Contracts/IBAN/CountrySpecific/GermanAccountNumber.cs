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
using System.ComponentModel;

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
      [Category("Account")]
      public string BankCode { get; set; }
      /// <summary>
      /// Gets or sets the account number.
      /// </summary>
      /// <value>
      /// The account number.
      /// </value>
      [Category("Account")]
      public string AccountNumber { get; set; }

      /// <summary>
      /// Gets or sets the parts.
      /// </summary>
      /// <value>
      /// The parts.
      /// </value>
      [Browsable(false)]
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

      /// <summary>
      /// Initializes a new instance of the <see cref="GermanAccountNumber"/> class.
      /// </summary>
      public GermanAccountNumber()
         : base(Country.Germany)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="GermanAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public GermanAccountNumber(NationalAccountNumber other)
         : base(other, Country.Germany)
      {
      }
   }
}
