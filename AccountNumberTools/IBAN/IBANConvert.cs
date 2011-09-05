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
      private static IDictionary<string, Country> prefixCountryMapping;

      /// <summary>
      /// Initializes the <see cref="IBANConvert"/> class.
      /// </summary>
      static IBANConvert()
      {
         specificConverters = new Dictionary<Country, ICountrySpecificIBANConvert>();
         specificConverters.Add(Country.Germany, new GermanIBANConvert());
         specificConverters.Add(Country.Montenegro, new MontenegroIBANConvert());
         specificConverters.Add(Country.Norway, new NorwayIBANConvert());
         specificConverters.Add(Country.SaudiArabia, new SaudiArabiaIBANConvert());
         specificConverters.Add(Country.Serbia, new SerbiaIBANConvert());
         specificConverters.Add(Country.Sweden, new SwedenIBANConvert());
         specificConverters.Add(Country.Switzerland, new SwitzerlandIBANConvert());
         specificConverters.Add(Country.UnitedArabEmirates, new UnitedArabEmiratesIBANConvert());

         prefixCountryMapping = new Dictionary<string, Country>();
         prefixCountryMapping.Add(GermanIBANConvert.Prefix, Country.Germany);
         prefixCountryMapping.Add(MontenegroIBANConvert.Prefix, Country.Montenegro);
         prefixCountryMapping.Add(NorwayIBANConvert.Prefix, Country.Norway);
         prefixCountryMapping.Add(SaudiArabiaIBANConvert.Prefix, Country.SaudiArabia);
         prefixCountryMapping.Add(SerbiaIBANConvert.Prefix, Country.Serbia);
         prefixCountryMapping.Add(SwedenIBANConvert.Prefix, Country.Sweden);
         prefixCountryMapping.Add(SwitzerlandIBANConvert.Prefix, Country.Switzerland);
         prefixCountryMapping.Add(UnitedArabEmiratesIBANConvert.Prefix, Country.UnitedArabEmirates);
      }

      /// <summary>
      /// converts the parts of a national account number to an IBAN.
      /// There are different parts needed in dependency of the selected country
      /// </summary>
      /// <param name="nationalAccountNumber">The national account number.</param>
      /// <returns></returns>
      public string ToIBAN(NationalAccountNumber nationalAccountNumber)
      {
         if (nationalAccountNumber == null)
            throw new ArgumentNullException("nationalAccountNumber");

         if (!specificConverters.ContainsKey(nationalAccountNumber.Country))
            throw new ArgumentException(String.Format("The country {0} isn't supported.", nationalAccountNumber.Country), "nationalAccountNumber");

         return specificConverters[nationalAccountNumber.Country].ToIBAN(nationalAccountNumber);
      }

      /// <summary>
      /// converts an IBAN to the parts of a national account number
      /// </summary>
      /// <param name="iban">The iban.</param>
      /// <returns></returns>
      public NationalAccountNumber FromIBAN(string iban)
      {
         if (String.IsNullOrEmpty(iban) || iban.Length < 2)
            throw new ArgumentNullException("iban");

         var ibanPrefix = iban.Substring(0, 2);
         if (!prefixCountryMapping.ContainsKey(ibanPrefix))
            throw new ArgumentException(String.Format("The country {0} isn't supported.", ibanPrefix), "iban");
         
         var country = prefixCountryMapping[ibanPrefix];
         if (!specificConverters.ContainsKey(country))
            throw new ArgumentException(String.Format("The country {0} isn't supported.", country), "iban");

         return specificConverters[country].FromIBAN(iban);
      }
   }
}
