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

using AccountNumberTools.IBAN;
using AccountNumberTools.IBAN.Contracts;

namespace AccountNumberTools.Tests.IBAN
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
               var result = IBANTools.CreateCountrySpecificAccountNumber((Country)val);
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
            var result = IBANTools.CreateCountrySpecificAccountNumber((Country)val);
            Assert.IsNotNull(result);
         }
      }

      [TestCase("AL47212110090000000235698741", Country.Albania, "212", "1100", "90000000235698741")]
      [TestCase("AD1200012030200359100100", Country.Andorra, "1", "2030", "200359100100")]
      [TestCase("AT611904300234573201", Country.Austria, "19043", "234573201")]
      [TestCase("BH88BMAG00001299123456", Country.Bahrain, "BMAG", "1299123456")]
      [TestCase("BE68539007547034", Country.Belgium, "539", "7547034")]
      [TestCase("BA391290079401028494", Country.BosniaAndHerzegovina, "129", "7", "9401028494")]
      [TestCase("BG80BNBG96611020345678", Country.Bulgaria, "BNBG", "9661", "10", "20345678")]
      [TestCase("HR1210010051863000160", Country.Croatia, "1001005", "1863000160")]
      [TestCase("CY17002001280000001200527600", Country.Cyprus, "2", "128", "1200527600")]
      [TestCase("CZ6508000000192000145399", Country.CzechRepublic, "800", "19", "2000145399")]
      [TestCase("DK5000400440116243", Country.Denmark, "40", "440116243")]
      [TestCase("DO28BAGR00000001212453611324", Country.DominicanRepublic, "BAGR", "1212453611324")]
      [TestCase("EE382200221020145685", Country.Estonia, "22", "0", "221020145685")]
      [TestCase("FO2000400440116243", Country.FaroeIslands, "40", "440116243")]
      [TestCase("FI2112345600000785", Country.Finland, "123456", "785")]
      [TestCase("FR1420041010050500013M02606", Country.France, "20041", "1005", "500013M02606")]
      [TestCase("GE29NB0000000101904917", Country.Georgia, "NB", "101904917")]
      [TestCase("DE43300800000228028003", Country.Germany, "300 800 00", "2280 280 03")]
      [TestCase("GI75NWBK000000007099453", Country.Gibraltar, "NWBK", "7099453")]
      [TestCase("GR1601101250000000012300695", Country.Greece, "11", "125", "12300695")]
      [TestCase("GL2000400440116243", Country.Greenland, "40", "440116243")]
      [TestCase("HU42117730161111101800000000", Country.Hungary, "117", "73016", "1111101800000000")]
      [TestCase("IS140159260076545510730339", Country.Iceland, "159", "26", "7654", "5510730339")]
      [TestCase("IE29AIBK93115212345678", Country.Ireland, "AIBK", "931152", "12345678")]
      [TestCase("IL620108000000099999999", Country.Israel, "10", "800", "99999999")]
      [TestCase("IT60X0542811101000000123456", Country.Italy, "X05428", "11101", "123456")]
      [TestCase("KZ75125KZT2069100100", Country.Kazakhstan, "125", "KZT 2069100100")]
      [TestCase("KW81CBKU0000000000001234560101", Country.Kuwait, "CBKU", "1234560101")]
      [TestCase("LV80BANK0000435195001", Country.Latvia, "BANK", "435195001")]
      [TestCase("LB62099900000001001901229114", Country.Lebanon, "999", "1001901229114")]
      [TestCase("LI21088100002324013AA", Country.Liechtenstein, "8810", "2324013AA")]
      [TestCase("LT121000011101001000", Country.Lithuania, "10000", "11101001000")]
      [TestCase("LU360029152460050000", Country.Luxembourg, "2", "9152460050000")]
      [TestCase("MK07250120000058984", Country.Macedonia, "250", "120000058984")]
      [TestCase("MT84MALT011000012345MTLCAST001S", Country.Malta, "MALT", "1100", "12345MTLCAST001S")]
      [TestCase("MR1300020001010000123456753", Country.Mauritania, "20", "101", "123456753")]
      [TestCase("MU17BOMM0101101030300200000MUR", Country.Mauritius, "BOMM01", "1", "101030300200000MUR")]
      [TestCase("MC1112739000700011111000H79", Country.Monaco, "12739", "70", "11111000H79")]
      [TestCase("ME25505000012345678951", Country.Montenegro, "505", "12345678951")]
      [TestCase("NL91ABNA0417164300", Country.Netherlands, "ABNA", "417164300")]
      [TestCase("NO9386011117947", Country.Norway, "8601", "1117947")]
      [TestCase("PL27114020040000300201355387", Country.Poland, "114", "200", "40000300201355387")]
      [TestCase("PT50000201231234567890154", Country.Portugal, "2", "123", "1234567890154")]
      [TestCase("RO49AAAA1B31007593840000", Country.Romania, "AAAA", "1B31007593840000")]
      [TestCase("SA0380000000608010167519", Country.SaudiArabia, "80", "608010167519")]
      [TestCase("RS35260005601001611379", Country.Serbia, "260", "5601001611379")]
      [TestCase("SK3112000000198742637541", Country.Slovakia, "1200", "19", "8742637541")]
      [TestCase("SI56191000000123438", Country.Slovenia, "19", "100", "123438")]
      [TestCase("ES9121000418450200051332", Country.Spain, "2100", "418", "450200051332")]
      [TestCase("SE4550000000058398257466", Country.Sweden, "500", "58398257466")]
      [TestCase("CH9300762011623852957", Country.Switzerland, "762", "11623852957")]
      [TestCase("TN5914207207100707129648", Country.Tunisia, "14", "207", "207100707129648")]
      [TestCase("TR330006100519786457841326", Country.Turkey, "61", "519786457841326")]
      [TestCase("AE070331234567890123456", Country.UnitedArabEmirates, "33", "1234567890123456")]
      [TestCase("GB29NWBK60161331926819", Country.UnitedKingdom, "NWBK", "601613", "31926819")]
      public void Should_Convert_A_National_Account_Number_To_An_IBAN(string expectedIBAN, Country country, params string[] parts)
      {
         var sut = SuT;

         var result = sut.ToIBAN(IBANTools.CreateCountrySpecificAccountNumber(country, parts));

         Assert.AreEqual(expectedIBAN, result);
      }

      [TestCase("AL47 2121 1009 0000 0002 3569 8741", Country.Albania, "212", "1100", "90000000235698741")]
      [TestCase("AD12 0001 2030 2003 5910 0100", Country.Andorra, "1", "2030", "200359100100")]
      [TestCase("AT61 1904 3002 3457 3201", Country.Austria, "19043", "234573201")]
      [TestCase("BH88 BMAG 0000 1299 1234 56", Country.Bahrain, "BMAG", "1299123456")]
      [TestCase("BE68 5390 0754 7034", Country.Belgium, "539", "7547034")]
      [TestCase("BA39 1290 0794 0102 8494", Country.BosniaAndHerzegovina, "129", "7", "9401028494")]
      [TestCase("BG80 BNBG 9661 1020 3456 78", Country.Bulgaria, "BNBG", "9661", "10", "20345678")]
      [TestCase("HR12 1001 0051 8630 0016 0", Country.Croatia, "1001005", "1863000160")]
      [TestCase("CY17 0020 0128 0000 0012 0052 7600", Country.Cyprus, "2", "128", "1200527600")]
      [TestCase("CZ65 0800 0000 1920 0014 5399", Country.CzechRepublic, "800", "19", "2000145399")]
      [TestCase("DK50 0040 0440 1162 43", Country.Denmark, "40", "440116243")]
      [TestCase("DO28 BAGR 0000 0001 2124 5361 1324", Country.DominicanRepublic, "BAGR", "1212453611324")]
      [TestCase("EE38 2200 2210 2014 5685", Country.Estonia, "22", "0", "221020145685")]
      [TestCase("FO20 0040 0440 1162 43", Country.FaroeIslands, "40", "440116243")]
      [TestCase("FI21 1234 5600 0007 85", Country.Finland, "123456", "785")]
      [TestCase("FR14 2004 1010 0505 0001 3M02 606", Country.France, "20041", "1005", "500013M02606")]
      [TestCase("GE29 NB00 0000 0101 9049 17", Country.Georgia, "NB", "101904917")]
      [TestCase("DE43 3008 0000 0228 0280 03", Country.Germany, "30080000", "228028003")]
      [TestCase("GI75 NWBK 0000 0000 7099 453", Country.Gibraltar, "NWBK", "7099453")]
      [TestCase("GR16 0110 1250 0000 0001 2300 695", Country.Greece, "11", "125", "12300695")]
      [TestCase("GL20 0040 0440 1162 43", Country.Greenland, "40", "440116243")]
      [TestCase("HU42 1177 3016 1111 1018 0000 0000", Country.Hungary, "117", "73016", "1111101800000000")]
      [TestCase("IS14 0159 2600 7654 5510 7303 39", Country.Iceland, "159", "26", "7654", "5510730339")]
      [TestCase("IE29 AIBK 9311 5212 3456 78", Country.Ireland, "AIBK", "931152", "12345678")]
      [TestCase("IL62 0108 0000 0009 9999 999", Country.Israel, "10", "800", "99999999")]
      [TestCase("IT60 X054 2811 1010 0000 0123 456", Country.Italy, "X05428", "11101", "123456")]
      [TestCase("KZ75 125K ZT20 6910 0100", Country.Kazakhstan, "125", "KZT2069100100")]
      [TestCase("KW81 CBKU 0000 0000 0000 1234 5601 01", Country.Kuwait, "CBKU", "1234560101")]
      [TestCase("LV80 BANK 0000 4351 9500 1", Country.Latvia, "BANK", "435195001")]
      [TestCase("LB62 0999 0000 0001 0019 0122 9114", Country.Lebanon, "999", "1001901229114")]
      [TestCase("LI21 0881 0000 2324 013A A", Country.Liechtenstein, "8810", "2324013AA")]
      [TestCase("LT12 1000 0111 0100 1000", Country.Lithuania, "10000", "11101001000")]
      [TestCase("LU36 0029 1524 6005 0000", Country.Luxembourg, "2", "9152460050000")]
      [TestCase("MK07 2501 2000 0058 984", Country.Macedonia, "250", "120000058984")]
      [TestCase("MT84 MALT 0110 0001 2345 MTLC AST0 01S", Country.Malta, "MALT", "1100", "12345MTLCAST001S")]
      [TestCase("MR13 0002 0001 0100 0012 3456 753", Country.Mauritania, "20", "101", "123456753")]
      [TestCase("MU17 BOMM 0101 1010 3030 0200 000M UR", Country.Mauritius, "BOMM01", "1", "101030300200000MUR")]
      [TestCase("MC11 1273 9000 7000 1111 1000 H79", Country.Monaco, "12739", "70", "11111000H79")]
      [TestCase("ME25 5050 0001 2345 6789 51", Country.Montenegro, "505", "12345678951")]
      [TestCase("ME73 2600 0560 1001 6113 79", Country.Montenegro, "260", "5601001611379")]
      [TestCase("NL91 ABNA 0417 1643 00", Country.Netherlands, "ABNA", "417164300")]
      [TestCase("NO93 8601 1117 947", Country.Norway, "8601", "1117947")]
      [TestCase("PL27 1140 2004 0000 3002 0135 5387", Country.Poland, "114", "200", "40000300201355387")]
      [TestCase("PT50 0002 0123 1234 5678 9015 4", Country.Portugal, "2", "123", "1234567890154")]
      [TestCase("RO49 AAAA 1B31 0075 9384 0000", Country.Romania, "AAAA", "1B31007593840000")]
      [TestCase("SA03 8000 0000 6080 1016 7519", Country.SaudiArabia, "80", "608010167519")]
      [TestCase("RS35 2600 0560 1001 6113 79", Country.Serbia, "260", "5601001611379")]
      [TestCase("SK31 1200 0000 1987 4263 7541", Country.Slovakia, "1200", "19", "8742637541")]
      [TestCase("SI56 1910 0000 0123 438", Country.Slovenia, "19", "100", "123438")]
      [TestCase("ES91 2100 0418 4502 0005 1332", Country.Spain, "2100", "418", "450200051332")]
      [TestCase("SE45 5000 0000 0583 9825 7466", Country.Sweden, "500", "58398257466")]
      [TestCase("CH93 0076 2011 6238 5295 7", Country.Switzerland, "762", "11623852957")]
      [TestCase("TN59 1420 7207 1007 0712 9648", Country.Tunisia, "14", "207", "207100707129648")]
      [TestCase("TR33 0006 1005 1978 6457 8413 26", Country.Turkey, "61", "519786457841326")]
      [TestCase("AE07 0331 2345 6789 0123 456", Country.UnitedArabEmirates, "33", "1234567890123456")]
      [TestCase("GB29 NWBK 6016 1331 9268 19", Country.UnitedKingdom, "NWBK", "601613", "31926819")]
      public void Should_Convert_An_IBAN_To_A_National_Account_Number(string givenIBAN, Country country, params string[] parts)
      {
         var sut = SuT;

         var result = sut.FromIBAN(givenIBAN);

         Assert.AreEqual(country, result.Country);
         for (var index = 0; index < parts.Length && index < result.Parts.Length; index++)
         {
            Assert.AreEqual(parts[index], result.Parts[index]);
         }
      }
   }
}
