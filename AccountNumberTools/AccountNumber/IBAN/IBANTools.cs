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

using AccountNumberTools.AccountNumber.Contracts;
using AccountNumberTools.AccountNumber.Contracts.CountrySpecific;
using AccountNumberTools.Common.Contracts;

namespace AccountNumberTools.AccountNumber.IBAN
{
   /// <summary>
   /// contains some small helper methods
   /// </summary>
   public static class IBANTools
   {
      private static readonly IDictionary<Country, Func<NationalAccountNumber>> countrySpecificObjectCreators;

      static IBANTools()
      {
         countrySpecificObjectCreators = new Dictionary<Country, Func<NationalAccountNumber>>
                                            {
                                               {Country.Albania, () => new AlbaniaAccountNumber()},
                                               {Country.Andorra, () => new AndorraAccountNumber()},
                                               {Country.Austria, () => new AustriaAccountNumber()},
                                               {Country.Bahrain, () => new BahrainAccountNumber()},
                                               {Country.Belgium, () => new BelgiumAccountNumber()},
                                               {Country.BosniaAndHerzegovina, () => new BosniaAndHerzegovinaAccountNumber()},
                                               {Country.Bulgaria, () => new BulgariaAccountNumber()},
                                               {Country.Croatia, () => new CroatiaAccountNumber()},
                                               {Country.Cyprus, () => new CyprusAccountNumber()},
                                               {Country.CzechRepublic, () => new CzechRepublicAccountNumber()},
                                               {Country.Denmark, () => new DenmarkAccountNumber()},
                                               {Country.DominicanRepublic, () => new DominicanRepublicAccountNumber()},
                                               {Country.Estonia, () => new EstoniaAccountNumber()},
                                               {Country.FaroeIslands, () => new FaroeIslandsAccountNumber()},
                                               {Country.Finland, () => new FinlandAccountNumber()},
                                               {Country.France, () => new FranceAccountNumber()},
                                               {Country.Georgia, () => new GeorgiaAccountNumber()},
                                               {Country.Germany, () => new GermanyAccountNumber()},
                                               {Country.Gibraltar, () => new GibraltarAccountNumber()},
                                               {Country.Greece, () => new GreeceAccountNumber()},
                                               {Country.Greenland, () => new GreenlandAccountNumber()},
                                               {Country.Hungary, () => new HungaryAccountNumber()},
                                               {Country.Iceland, () => new IcelandAccountNumber()},
                                               {Country.Ireland, () => new IrelandAccountNumber()},
                                               {Country.Israel, () => new IsraelAccountNumber()},
                                               {Country.Italy, () => new ItalyAccountNumber()},
                                               {Country.Kazakhstan, () => new KazakhstanAccountNumber()},
                                               {Country.Kuwait, () => new KuwaitAccountNumber()},
                                               {Country.Latvia, () => new LatviaAccountNumber()},
                                               {Country.Lebanon, () => new LebanonAccountNumber()},
                                               {Country.Liechtenstein, () => new LiechtensteinAccountNumber()},
                                               {Country.Lithuania, () => new LithuaniaAccountNumber()},
                                               {Country.Luxembourg, () => new LuxembourgAccountNumber()},
                                               {Country.Macedonia, () => new MacedoniaAccountNumber()},
                                               {Country.Malta, () => new MaltaAccountNumber()},
                                               {Country.Mauritania, () => new MauritaniaAccountNumber()},
                                               {Country.Mauritius, () => new MauritiusAccountNumber()},
                                               {Country.Monaco, () => new MonacoAccountNumber()},
                                               {Country.Montenegro, () => new MontenegroAccountNumber()},
                                               {Country.Netherlands, () => new NetherlandsAccountNumber()},
                                               {Country.Norway, () => new NorwayAccountNumber()},
                                               {Country.Poland, () => new PolandAccountNumber()},
                                               {Country.Portugal, () => new PortugalAccountNumber()},
                                               {Country.Romania, () => new RomaniaAccountNumber()},
                                               {Country.SanMarino, () => new SanMarinoAccountNumber()},
                                               {Country.SaudiArabia, () => new SaudiArabiaAccountNumber()},
                                               {Country.Serbia, () => new SerbiaAccountNumber()},
                                               {Country.Slovakia, () => new SlovakiaAccountNumber()},
                                               {Country.Slovenia, () => new SloveniaAccountNumber()},
                                               {Country.Spain, () => new SpainAccountNumber()},
                                               {Country.Sweden, () => new SwedenAccountNumber()},
                                               {Country.Switzerland, () => new SwitzerlandAccountNumber()},
                                               {Country.Tunisia, () => new TunisiaAccountNumber()},
                                               {Country.Turkey, () => new TurkeyAccountNumber()},
                                               {Country.UnitedArabEmirates, () => new UnitedArabEmiratesAccountNumber()},
                                               {Country.UnitedKingdom, () => new UnitedKingdomAccountNumber()}
                                            };
      }

      /// <summary>
      /// Creates the country specific account number.
      /// </summary>
      /// <param name="country">The country.</param>
      /// <returns></returns>
      public static NationalAccountNumber CreateCountrySpecificAccountNumber(Country country)
      {
         if (!countrySpecificObjectCreators.ContainsKey(country))
            throw new ArgumentException(String.Format("The country {0} isn't supported.", country));

         return countrySpecificObjectCreators[country]();
      }

      /// <summary>
      /// Creates the country specific account number.
      /// </summary>
      /// <param name="country">The country.</param>
      /// <param name="parts">The parts.</param>
      /// <returns></returns>
      public static NationalAccountNumber CreateCountrySpecificAccountNumber(Country country, string[] parts)
      {
         var accountNumber = CreateCountrySpecificAccountNumber(country);
         accountNumber.Parts = parts;
         return accountNumber;
      }
   }
}
