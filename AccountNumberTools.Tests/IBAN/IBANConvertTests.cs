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

      [Test]
      public void Should_Create_Correct_Country_Specific_Account_Number_Objects()
      {
         foreach (var val in Enum.GetValues(typeof(Country)))
         {
            try
            {
               var result = (NationalAccountNumber)IBANTools.CreateCountrySpecificAccountNumber((Country)val);
               Assert.AreEqual(val, result.Country);
            }
            catch (ArgumentException)
            {
               // unsupported countries doesn't matter here
            }
         }
      }

      [Test]
      public void Should_Create_Account_Number_Objects_For_Every_Country()
      {
         foreach (var val in Enum.GetValues(typeof(Country)))
         {
            var result = (NationalAccountNumber)IBANTools.CreateCountrySpecificAccountNumber((Country)val);
            Assert.IsNotNull(result);
         }
      }

      [TestCase("DE43300800000228028003", Country.Germany, "300 800 00", "2280 280 03")]
      [TestCase("RS35260005601001611379", Country.Serbia, "260", "5601001611379")]
      [TestCase("SE4550000000058398257466", Country.Sweden, "500", "58398257466")]
      [TestCase("CH9300762011623852957", Country.Switzerland, "762", "11623852957")]
      [TestCase("AE070331234567890123456", Country.UnitedArabEmirates, "33", "1234567890123456")]
      public void Should_Convert_A_National_Account_Number_To_An_IBAN(string expectedIBAN, Country country, params string[] parts)
      {
         var sut = SuT;

         var result = SuT.ToIBAN(IBANTools.CreateCountrySpecificAccountNumber(country, parts));

         Assert.AreEqual(expectedIBAN, result);
      }

      [TestCase("DE43 3008 0000 0228 0280 03", Country.Germany, "30080000", "228028003")]
      [TestCase("RS35 2600 0560 1001 6113 79", Country.Serbia, "260", "5601001611379")]
      [TestCase("SE45 5000 0000 0583 9825 7466", Country.Sweden, "500", "58398257466")]
      [TestCase("CH93 0076 2011 6238 5295 7", Country.Switzerland, "762", "11623852957")]
      [TestCase("AE07 0331 2345 6789 0123 456", Country.UnitedArabEmirates, "33", "1234567890123456")]
      public void Should_Convert_An_IBAN_To_A_National_Account_Number(string givenIBAN, Country country, params string[] parts)
      {
         var sut = SuT;

         var result = SuT.FromIBAN(givenIBAN);

         Assert.AreEqual(country, result.Country);
         for (var index = 0; index < parts.Length && index < result.Parts.Length; index++)
         {
            Assert.AreEqual(parts[index], result.Parts[index]);
         }
      }
   }
}
