//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

using System.ComponentModel;

using AccountNumberTools.Common.Contracts;

namespace AccountNumberTools.AccountNumber.Contracts
{
   /// <summary>
   /// represents the parts of a national account number
   /// </summary>
   public abstract class NationalAccountNumber
   {
      /// <summary>
      /// Gets the country.
      /// </summary>
      [Category("Country")]
      public Country Country { get; private set; }

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
      /// <param name="country">The country.</param>
      protected NationalAccountNumber(Country country)
      {
         Country = country;
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="NationalAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      protected NationalAccountNumber(NationalAccountNumber other)
      {
         Country = other.Country;
         Parts = other.Parts;
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="NationalAccountNumber"/> class.
      /// </summary>
      /// <param name="other">The other.</param>
      /// <param name="newCountry">The new country.</param>
      protected NationalAccountNumber(NationalAccountNumber other, Country newCountry)
      {
         Country = newCountry;
         Parts = other.Parts;
      }
   }
}
