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
using System.Collections.Generic;

using AccountNumberTools.IBAN.Contracts;
using AccountNumberTools.IBAN.Contracts.CountrySpecific;
using AccountNumberTools.IBAN.Internals;

namespace AccountNumberTools.IBAN
{
   /// <summary>
   /// implementation of the IBAN converter
   /// </summary>
   public class IBANConvert : IIBANConvert
   {
      private static IDictionary<Country, ICountrySpecificIBANConvert> specificConverters;

      /// <summary>
      /// Initializes the <see cref="IBANConvert"/> class.
      /// </summary>
      static IBANConvert()
      {
         specificConverters = new Dictionary<Country, ICountrySpecificIBANConvert>();
         specificConverters.Add(Country.Germany, new GermanIBANConvert());
      }

      /// <summary>
      /// converts the parts of a national account number to an IBAN.
      /// There are different parts needed in dependency of the selected country
      /// </summary>
      /// <param name="country">The country.</param>
      /// <param name="nationalAccountNumber">The national account number.</param>
      /// <returns></returns>
      public string ToIBAN(Country country, NationalAccountNumber nationalAccountNumber)
      {
         if (nationalAccountNumber == null)
            throw new ArgumentNullException("nationalAccountNumber");

         if (!specificConverters.ContainsKey(country))
            throw new ArgumentException(String.Format("The country {0} isn't supported.", country), "country");

         return specificConverters[country].ToIBAN(nationalAccountNumber);
      }

      /// <summary>
      /// converts an IBAN to the parts of a national account number
      /// </summary>
      /// <param name="country">The country.</param>
      /// <param name="iban">The iban.</param>
      /// <returns></returns>
      public NationalAccountNumber FromIBAN(Country country, string iban)
      {
         if (String.IsNullOrEmpty(iban))
            throw new ArgumentNullException("iban");

         if (!specificConverters.ContainsKey(country))
            throw new ArgumentException(String.Format("The country {0} isn't supported.", country), "country");

         return specificConverters[country].FromIBAN(iban);
      }
   }
}
