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

namespace AccountNumberTools.IBAN.Contracts
{
   /// <summary>
   /// represents the parts of a national account number
   /// </summary>
   public abstract class NationalAccountNumber
   {
      /// <summary>
      /// Gets or sets the parts.
      /// </summary>
      /// <value>
      /// The parts.
      /// </value>
      public abstract string[] Parts { get; set; }

      /// <summary>
      /// Initializes a new instance of the <see cref="NationalAccountNumber"/> class.
      /// </summary>
      public NationalAccountNumber()
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="NationalAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      public NationalAccountNumber(NationalAccountNumber other)
      {
         Parts = other.Parts;
      }
   }
}
