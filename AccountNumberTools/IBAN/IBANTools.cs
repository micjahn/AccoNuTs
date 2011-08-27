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

namespace AccountNumberTools.IBAN
{
   /// <summary>
   /// contains some small helper methods
   /// </summary>
   public static class IBANTools
   {
      private static IDictionary<Country, Func<NationalAccountNumber>> countrySpecificObjectCreators;

      static IBANTools()
      {
         countrySpecificObjectCreators = new Dictionary<Country, Func<NationalAccountNumber>>();

         countrySpecificObjectCreators.Add(Country.Albania, () => new AlbaniaAccountNumber());
         countrySpecificObjectCreators.Add(Country.Andorra, () => new AndorraAccountNumber());
         countrySpecificObjectCreators.Add(Country.Austria, () => new AustriaAccountNumber());
         countrySpecificObjectCreators.Add(Country.Bahrain, () => new BahrainAccountNumber());
         countrySpecificObjectCreators.Add(Country.Belgium, () => new BelgiumAccountNumber());
         countrySpecificObjectCreators.Add(Country.BosniaAndHerzegovina, () => new BosniaAndHerzegovinaAccountNumber());
         countrySpecificObjectCreators.Add(Country.Bulgaria, () => new BulgariaAccountNumber());
         countrySpecificObjectCreators.Add(Country.Croatia, () => new CroatiaAccountNumber());
         countrySpecificObjectCreators.Add(Country.Cyprus, () => new CyprusAccountNumber());
         countrySpecificObjectCreators.Add(Country.CzechRepublic, () => new CzechRepublicAccountNumber());
         countrySpecificObjectCreators.Add(Country.Denmark, () => new DenmarkAccountNumber());
         countrySpecificObjectCreators.Add(Country.DominicanRepublic, () => new DominicanRepublicAccountNumber());
         countrySpecificObjectCreators.Add(Country.Estonia, () => new EstoniaAccountNumber());
         countrySpecificObjectCreators.Add(Country.FaroeIslands, () => new FaroeIslandsAccountNumber());
         countrySpecificObjectCreators.Add(Country.Finland, () => new FinlandAccountNumber());
         countrySpecificObjectCreators.Add(Country.France, () => new FranceAccountNumber());
         countrySpecificObjectCreators.Add(Country.Georgia, () => new GeorgiaAccountNumber());
         countrySpecificObjectCreators.Add(Country.Germany, () => new GermanyAccountNumber());
         countrySpecificObjectCreators.Add(Country.Gibraltar, () => new GibraltarAccountNumber());
         countrySpecificObjectCreators.Add(Country.Greece, () => new GreeceAccountNumber());
         countrySpecificObjectCreators.Add(Country.Greenland, () => new GreenlandAccountNumber());
         countrySpecificObjectCreators.Add(Country.Hungary, () => new HungaryAccountNumber());
         countrySpecificObjectCreators.Add(Country.Iceland, () => new IcelandAccountNumber());
         countrySpecificObjectCreators.Add(Country.Ireland, () => new IrelandAccountNumber());
         countrySpecificObjectCreators.Add(Country.Israel, () => new IsraelAccountNumber());
         countrySpecificObjectCreators.Add(Country.Italy, () => new ItalyAccountNumber());
         countrySpecificObjectCreators.Add(Country.Kazakhstan, () => new KazakhstanAccountNumber());
         countrySpecificObjectCreators.Add(Country.Kuwait, () => new KuwaitAccountNumber());
         countrySpecificObjectCreators.Add(Country.Latvia, () => new LatviaAccountNumber());
         countrySpecificObjectCreators.Add(Country.Lebanon, () => new LebanonAccountNumber());
         countrySpecificObjectCreators.Add(Country.Liechtenstein, () => new LiechtensteinAccountNumber());
         countrySpecificObjectCreators.Add(Country.Lithuania, () => new LithuaniaAccountNumber());
         countrySpecificObjectCreators.Add(Country.Luxembourg, () => new LuxembourgAccountNumber());
         countrySpecificObjectCreators.Add(Country.Macedonia, () => new MacedoniaAccountNumber());
         countrySpecificObjectCreators.Add(Country.Malta, () => new MaltaAccountNumber());
         countrySpecificObjectCreators.Add(Country.Mauritania, () => new MauritaniaAccountNumber());
         countrySpecificObjectCreators.Add(Country.Mauritius, () => new MauritiusAccountNumber());
         countrySpecificObjectCreators.Add(Country.Monaco, () => new MonacoAccountNumber());
         countrySpecificObjectCreators.Add(Country.Montenegro, () => new MontenegroAccountNumber());
         countrySpecificObjectCreators.Add(Country.Netherlands, () => new NetherlandsAccountNumber());
         countrySpecificObjectCreators.Add(Country.Norway, () => new NorwayAccountNumber());
         countrySpecificObjectCreators.Add(Country.Poland, () => new PolandAccountNumber());
         countrySpecificObjectCreators.Add(Country.Portugal, () => new PortugalAccountNumber());
         countrySpecificObjectCreators.Add(Country.Romania, () => new RomaniaAccountNumber());
         countrySpecificObjectCreators.Add(Country.SanMarino, () => new SanMarinoAccountNumber());
         countrySpecificObjectCreators.Add(Country.SaudiArabia, () => new SaudiArabiaAccountNumber());
         countrySpecificObjectCreators.Add(Country.Serbia, () => new SerbiaAccountNumber());
         countrySpecificObjectCreators.Add(Country.Slovakia, () => new SlovakiaAccountNumber());
         countrySpecificObjectCreators.Add(Country.Slovenia, () => new SloveniaAccountNumber());
         countrySpecificObjectCreators.Add(Country.Spain, () => new SpainAccountNumber());
         countrySpecificObjectCreators.Add(Country.Sweden, () => new SwedenAccountNumber());
         countrySpecificObjectCreators.Add(Country.Switzerland, () => new SwitzerlandAccountNumber());
         countrySpecificObjectCreators.Add(Country.Tunisia, () => new TunisiaAccountNumber());
         countrySpecificObjectCreators.Add(Country.Turkey, () => new TurkeyAccountNumber());
         countrySpecificObjectCreators.Add(Country.UnitedArabEmirates, () => new UnitedArabEmiratesAccountNumber());
         countrySpecificObjectCreators.Add(Country.UnitedKingdom, () => new UnitedKingdomAccountNumber());
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
