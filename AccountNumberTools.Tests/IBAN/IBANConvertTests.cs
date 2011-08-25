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
using NUnit.Framework;

using AccountNumberTools.IBAN.Contracts;
using AccountNumberTools.IBAN.Contracts.CountrySpecific;

namespace AccountNumberTools.IBAN.Tests
{
   /// <summary>
   /// test class for IBAN converting related methods
   /// </summary>
   [TestFixture]
   public class IBANConvertTests
   {
      internal IIBANConvert SuT
      {
         get
         {
            return new IBANConvert();
         }
      }

      private NationalAccountNumber CreateCountrySpecificObject(Country country, string[] parts)
      {
         switch (country)
         {
            case Country.Germany:
               return new GermanAccountNumber { Parts = parts };
            default:
               throw new ArgumentException("Country isn't supported yet.", country.ToString());
         }
      }

      [TestCase("DE43300800000228028003", Country.Germany, "300 800 00", "2280 280 03")]
      public void Should_Convert_A_National_Account_Number_To_An_IBAN(string expectedIBAN, Country country, params string[] parts)
      {
         var sut = SuT;

         var result = SuT.ToIBAN(country, CreateCountrySpecificObject(country, parts));

         Assert.AreEqual(expectedIBAN, result);
      }

      [TestCase("DE43 3008 0000 0228 0280 03", Country.Germany, "30080000", "228028003")]
      public void Should_Convert_An_IBAN_To_A_National_Account_Number(string givenIBAN, Country country, params string[] parts)
      {
         var sut = SuT;

         var result = SuT.FromIBAN(country, givenIBAN);

         for (var index = 0; index < parts.Length && index < result.Parts.Length; index++)
         {
            Assert.AreEqual(parts[index], result.Parts[index]);
         }
      }
   }
}
