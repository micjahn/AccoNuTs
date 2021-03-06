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
using System.Collections.Generic;

using AccountNumberTools.AccountNumber.Contracts;
using AccountNumberTools.AccountNumber.IBAN.Contracts;
using AccountNumberTools.AccountNumber.IBAN.Contracts.CountrySpecific;
using AccountNumberTools.AccountNumber.IBAN.Internals;
using AccountNumberTools.Common.Contracts;

namespace AccountNumberTools.AccountNumber.IBAN
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
                                    {Country.Albania, new AlbaniaIBANConvert()},
                                    {Country.Andorra, new AndorraIBANConvert()},
                                    {Country.Austria, new AustriaIBANConvert()},
                                    {Country.Bahrain, new BahrainIBANConvert()},
                                    {Country.Belgium, new BelgiumIBANConvert()},
                                    {Country.BosniaAndHerzegovina, new BosniaAndHerzegovinaIBANConvert()},
                                    {Country.Bulgaria, new BulgariaIBANConvert()},
                                    {Country.Croatia, new CroatiaIBANConvert()},
                                    {Country.Cyprus, new CyprusIBANConvert()},
                                    {Country.CzechRepublic, new CzechRepublicIBANConvert()},
                                    {Country.Denmark, new DenmarkIBANConvert()},
                                    {Country.DominicanRepublic, new DominicanRepublicIBANConvert()},
                                    {Country.Estonia, new EstoniaIBANConvert()},
                                    {Country.FaroeIslands, new FaroeIslandsIBANConvert()},
                                    {Country.Finland, new FinlandIBANConvert()},
                                    {Country.France, new FranceIBANConvert()},
                                    {Country.Georgia, new GeorgiaIBANConvert()},
                                    {Country.Germany, new GermanIBANConvert()},
                                    {Country.Gibraltar, new GibraltarIBANConvert()},
                                    {Country.Greece, new GreeceIBANConvert()},
                                    {Country.Greenland, new GreenlandIBANConvert()},
                                    {Country.Hungary, new HungaryIBANConvert()},
                                    {Country.Iceland, new IcelandIBANConvert()},
                                    {Country.Ireland, new IrelandIBANConvert()},
                                    {Country.Israel, new IsraelIBANConvert()},
                                    {Country.Italy, new ItalyIBANConvert()},
                                    {Country.Kazakhstan, new KazakhstanIBANConvert()},
                                    {Country.Kuwait, new KuwaitIBANConvert()},
                                    {Country.Latvia, new LatviaIBANConvert()},
                                    {Country.Lebanon, new LebanonIBANConvert()},
                                    {Country.Liechtenstein, new LiechtensteinIBANConvert()},
                                    {Country.Lithuania, new LithuaniaIBANConvert()},
                                    {Country.Luxembourg, new LuxembourgIBANConvert()},
                                    {Country.Macedonia, new MacedoniaIBANConvert()},
                                    {Country.Malta, new MaltaIBANConvert()},
                                    {Country.Mauritania, new MauritaniaIBANConvert()},
                                    {Country.Mauritius, new MauritiusIBANConvert()},
                                    {Country.Monaco, new MonacoIBANConvert()},
                                    {Country.Montenegro, new MontenegroIBANConvert()},
                                    {Country.Netherlands, new NetherlandsIBANConvert()},
                                    {Country.Norway, new NorwayIBANConvert()},
                                    {Country.Poland, new PolandIBANConvert()},
                                    {Country.Portugal, new PortugalIBANConvert()},
                                    {Country.Romania, new RomaniaIBANConvert()},
                                    {Country.SaudiArabia, new SaudiArabiaIBANConvert()},
                                    {Country.Serbia, new SerbiaIBANConvert()},
                                    {Country.Slovakia, new SlovakiaIBANConvert()},
                                    {Country.Slovenia, new SloveniaIBANConvert()},
                                    {Country.Spain, new SpainIBANConvert()},
                                    {Country.Sweden, new SwedenIBANConvert()},
                                    {Country.Switzerland, new SwitzerlandIBANConvert()},
                                    {Country.Tunisia, new TunisiaIBANConvert()},
                                    {Country.Turkey, new TurkeyIBANConvert()},
                                    {Country.UnitedArabEmirates, new UnitedArabEmiratesIBANConvert()},
                                    {Country.UnitedKingdom, new UnitedKingdomIBANConvert()}
                                 };

         prefixCountryMapping = new Dictionary<string, Country>
                                   {
                                      {AlbaniaIBANConvert.Prefix, Country.Albania},
                                      {AndorraIBANConvert.Prefix, Country.Andorra},
                                      {AustriaIBANConvert.Prefix, Country.Austria},
                                      {BahrainIBANConvert.Prefix, Country.Bahrain},
                                      {BelgiumIBANConvert.Prefix, Country.Belgium},
                                      {BosniaAndHerzegovinaIBANConvert.Prefix, Country.BosniaAndHerzegovina},
                                      {BulgariaIBANConvert.Prefix, Country.Bulgaria},
                                      {CroatiaIBANConvert.Prefix, Country.Croatia},
                                      {CyprusIBANConvert.Prefix, Country.Cyprus},
                                      {CzechRepublicIBANConvert.Prefix, Country.CzechRepublic},
                                      {DenmarkIBANConvert.Prefix, Country.Denmark},
                                      {DominicanRepublicIBANConvert.Prefix, Country.DominicanRepublic},
                                      {EstoniaIBANConvert.Prefix, Country.Estonia},
                                      {FaroeIslandsIBANConvert.Prefix, Country.FaroeIslands},
                                      {FinlandIBANConvert.Prefix, Country.Finland},
                                      {FranceIBANConvert.Prefix, Country.France},
                                      {GeorgiaIBANConvert.Prefix, Country.Georgia},
                                      {GermanIBANConvert.Prefix, Country.Germany},
                                      {GibraltarIBANConvert.Prefix, Country.Gibraltar},
                                      {GreeceIBANConvert.Prefix, Country.Greece},
                                      {GreenlandIBANConvert.Prefix, Country.Greenland},
                                      {HungaryIBANConvert.Prefix, Country.Hungary},
                                      {IcelandIBANConvert.Prefix, Country.Iceland},
                                      {IrelandIBANConvert.Prefix, Country.Ireland},
                                      {IsraelIBANConvert.Prefix, Country.Israel},
                                      {ItalyIBANConvert.Prefix, Country.Italy},
                                      {KazakhstanIBANConvert.Prefix, Country.Kazakhstan},
                                      {KuwaitIBANConvert.Prefix, Country.Kuwait},
                                      {LatviaIBANConvert.Prefix, Country.Latvia},
                                      {LebanonIBANConvert.Prefix, Country.Lebanon},
                                      {LiechtensteinIBANConvert.Prefix, Country.Liechtenstein},
                                      {LithuaniaIBANConvert.Prefix, Country.Lithuania},
                                      {LuxembourgIBANConvert.Prefix, Country.Luxembourg},
                                      {MacedoniaIBANConvert.Prefix, Country.Macedonia},
                                      {MaltaIBANConvert.Prefix, Country.Malta},
                                      {MauritaniaIBANConvert.Prefix, Country.Mauritania},
                                      {MauritiusIBANConvert.Prefix, Country.Mauritius},
                                      {MontenegroIBANConvert.Prefix, Country.Montenegro},
                                      {MonacoIBANConvert.Prefix, Country.Monaco},
                                      {NetherlandsIBANConvert.Prefix, Country.Netherlands},
                                      {NorwayIBANConvert.Prefix, Country.Norway},
                                      {PolandIBANConvert.Prefix, Country.Poland},
                                      {PortugalIBANConvert.Prefix, Country.Portugal},
                                      {RomaniaIBANConvert.Prefix, Country.Romania},
                                      {SaudiArabiaIBANConvert.Prefix, Country.SaudiArabia},
                                      {SerbiaIBANConvert.Prefix, Country.Serbia},
                                      {SlovakiaIBANConvert.Prefix, Country.Slovakia},
                                      {SloveniaIBANConvert.Prefix, Country.Slovenia},
                                      {SpainIBANConvert.Prefix, Country.Spain},
                                      {SwedenIBANConvert.Prefix, Country.Sweden},
                                      {SwitzerlandIBANConvert.Prefix, Country.Switzerland},
                                      {TunisiaIBANConvert.Prefix, Country.Tunisia},
                                      {TurkeyIBANConvert.Prefix, Country.Turkey},
                                      {UnitedArabEmiratesIBANConvert.Prefix, Country.UnitedArabEmirates},
                                      {UnitedKingdomIBANConvert.Prefix, Country.UnitedKingdom}
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
