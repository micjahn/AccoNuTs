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
      private static readonly IDictionary<Country, ICountrySpecificIBANConvert> specificConverters;
      private static readonly IDictionary<string, Country> prefixCountryMapping;

      /// <summary>
      /// Initializes the <see cref="IBANConvert"/> class.
      /// </summary>
      static IBANConvert()
      {
         specificConverters = new Dictionary<Country, ICountrySpecificIBANConvert>
                                 {
                                    {Country.Austria, new AustriaIBANConvert()},
                                    {Country.Bahrain, new BahrainIBANConvert()},
                                    {Country.Belgium, new BelgiumIBANConvert()},
                                    {Country.Croatia, new CroatiaIBANConvert()},
                                    {Country.Denmark, new DenmarkIBANConvert()},
                                    {Country.DominicanRepublic, new DominicanRepublicIBANConvert()},
                                    {Country.FaroeIslands, new FaroeIslandsIBANConvert()},
                                    {Country.Finland, new FinlandIBANConvert()},
                                    {Country.Georgia, new GeorgiaIBANConvert()},
                                    {Country.Germany, new GermanIBANConvert()},
                                    {Country.Greenland, new GreenlandIBANConvert()},
                                    {Country.Kazakhstan, new KazakhstanIBANConvert()},
                                    {Country.Kuwait, new KuwaitIBANConvert()},
                                    {Country.Lebanon, new LebanonIBANConvert()},
                                    {Country.Liechtenstein, new LiechtensteinIBANConvert()},
                                    {Country.Lithuania, new LithuaniaIBANConvert()},
                                    {Country.Luxembourg, new LuxembourgIBANConvert()},
                                    {Country.Montenegro, new MontenegroIBANConvert()},
                                    {Country.Norway, new NorwayIBANConvert()},
                                    {Country.SaudiArabia, new SaudiArabiaIBANConvert()},
                                    {Country.Serbia, new SerbiaIBANConvert()},
                                    {Country.Sweden, new SwedenIBANConvert()},
                                    {Country.Switzerland, new SwitzerlandIBANConvert()},
                                    {Country.UnitedArabEmirates, new UnitedArabEmiratesIBANConvert()}
                                 };

         prefixCountryMapping = new Dictionary<string, Country>
                                   {
                                      {AustriaIBANConvert.Prefix, Country.Austria},
                                      {BahrainIBANConvert.Prefix, Country.Bahrain},
                                      {BelgiumIBANConvert.Prefix, Country.Belgium},
                                      {CroatiaIBANConvert.Prefix, Country.Croatia},
                                      {DenmarkIBANConvert.Prefix, Country.Denmark},
                                      {DominicanRepublicIBANConvert.Prefix, Country.DominicanRepublic},
                                      {FaroeIslandsIBANConvert.Prefix, Country.FaroeIslands},
                                      {FinlandIBANConvert.Prefix, Country.Finland},
                                      {GeorgiaIBANConvert.Prefix, Country.Georgia},
                                      {GermanIBANConvert.Prefix, Country.Germany},
                                      {GreenlandIBANConvert.Prefix, Country.Greenland},
                                      {KazakhstanIBANConvert.Prefix, Country.Kazakhstan},
                                      {KuwaitIBANConvert.Prefix, Country.Kuwait},
                                      {LebanonIBANConvert.Prefix, Country.Lebanon},
                                      {LiechtensteinIBANConvert.Prefix, Country.Liechtenstein},
                                      {LithuaniaIBANConvert.Prefix, Country.Lithuania},
                                      {LuxembourgIBANConvert.Prefix, Country.Luxembourg},
                                      {MontenegroIBANConvert.Prefix, Country.Montenegro},
                                      {NorwayIBANConvert.Prefix, Country.Norway},
                                      {SaudiArabiaIBANConvert.Prefix, Country.SaudiArabia},
                                      {SerbiaIBANConvert.Prefix, Country.Serbia},
                                      {SwedenIBANConvert.Prefix, Country.Sweden},
                                      {SwitzerlandIBANConvert.Prefix, Country.Switzerland},
                                      {UnitedArabEmiratesIBANConvert.Prefix, Country.UnitedArabEmirates}
                                   };
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
