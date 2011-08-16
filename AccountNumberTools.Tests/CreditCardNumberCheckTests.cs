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

using NUnit.Framework;

using AccountNumberTools.Contracts;

namespace AccountNumberTools.Tests
{
   /// <summary>
   /// a new class
   /// </summary>
   [TestFixture]
   public class CreditCardNumberCheckTests
   {
      internal ICreditCardNumberCheck SuT
      {
         get
         {
            return new CreditCardNumberCheck();
         }
      }

      internal ICollection<KeyValuePair<string, string>> NetworkToCreditCardNumberSamples
      {
         get
         {
            return new List<KeyValuePair<string, string>>
            {
               // MasterCard
               new KeyValuePair<string, string>(CreditCardNetwork.MasterCard, "5206838343732784"),
               new KeyValuePair<string, string>(CreditCardNetwork.MasterCard, "5436439486083622"),
               new KeyValuePair<string, string>(CreditCardNetwork.MasterCard, "5132558243746515"),
               new KeyValuePair<string, string>(CreditCardNetwork.MasterCard, "5439082917664938"),
               new KeyValuePair<string, string>(CreditCardNetwork.MasterCard, "5124799418875248"),
               new KeyValuePair<string, string>(CreditCardNetwork.MasterCard, "5425598610097254"),
               new KeyValuePair<string, string>(CreditCardNetwork.MasterCard, "5378522854148257"),
               new KeyValuePair<string, string>(CreditCardNetwork.MasterCard, "5146784944360844"),
               new KeyValuePair<string, string>(CreditCardNetwork.MasterCard, "5330261033412816"),
               new KeyValuePair<string, string>(CreditCardNetwork.MasterCard, "5575355745956039"),
               // Visa
               new KeyValuePair<string, string>(CreditCardNetwork.Visa, "4716128437687151"),
               new KeyValuePair<string, string>(CreditCardNetwork.Visa, "4532870989726240"),
               new KeyValuePair<string, string>(CreditCardNetwork.Visa, "4024007194287032"),
               new KeyValuePair<string, string>(CreditCardNetwork.Visa, "4556849948437454"),
               new KeyValuePair<string, string>(CreditCardNetwork.Visa, "4539838595079455"),
               new KeyValuePair<string, string>(CreditCardNetwork.Visa, "4539311260344208"),
               new KeyValuePair<string, string>(CreditCardNetwork.Visa, "4539327701442948"),
               new KeyValuePair<string, string>(CreditCardNetwork.Visa, "4929037324953282"),
               new KeyValuePair<string, string>(CreditCardNetwork.Visa, "4556268503393079"),
               new KeyValuePair<string, string>(CreditCardNetwork.Visa, "4556337164901361"),
               // American Express
               new KeyValuePair<string, string>(CreditCardNetwork.AmericanExpress, "342123175639647"),
               new KeyValuePair<string, string>(CreditCardNetwork.AmericanExpress, "341692283811984"),
               new KeyValuePair<string, string>(CreditCardNetwork.AmericanExpress, "372030585630756"),
               new KeyValuePair<string, string>(CreditCardNetwork.AmericanExpress, "341048845978656"),
               new KeyValuePair<string, string>(CreditCardNetwork.AmericanExpress, "342221590778584"),
               // Discover
               new KeyValuePair<string, string>(CreditCardNetwork.DiscoverCard, "6011256174067167"),
               new KeyValuePair<string, string>(CreditCardNetwork.DiscoverCard, "6011017768880757"),
               new KeyValuePair<string, string>(CreditCardNetwork.DiscoverCard, "6011999771597272"),
               new KeyValuePair<string, string>(CreditCardNetwork.DiscoverCard, "6011478013209277"),
               new KeyValuePair<string, string>(CreditCardNetwork.DiscoverCard, "6011462239135466"),
               // Diners Club
               new KeyValuePair<string, string>(CreditCardNetwork.DinersClubInternational, "36083201554510"),
               new KeyValuePair<string, string>(CreditCardNetwork.DinersClubCarteBlanche, "30086103919265"),
               new KeyValuePair<string, string>(CreditCardNetwork.DinersClubCarteBlanche, "30078223591058"),
               new KeyValuePair<string, string>(CreditCardNetwork.DinersClubCarteBlanche, "30017658027485"),
               new KeyValuePair<string, string>(CreditCardNetwork.DinersClubenRoute, "201431428015154"),
               new KeyValuePair<string, string>(CreditCardNetwork.DinersClubenRoute, "201443515370608"),
               new KeyValuePair<string, string>(CreditCardNetwork.DinersClubenRoute, "201401051467261"),
               new KeyValuePair<string, string>(CreditCardNetwork.DinersClubenRoute, "201478664138372"),
               new KeyValuePair<string, string>(CreditCardNetwork.DinersClubenRoute, "201432662059692"),
               // Voyager
               new KeyValuePair<string, string>(CreditCardNetwork.Voyager, "869920981177644"),
               new KeyValuePair<string, string>(CreditCardNetwork.Voyager, "869993562322632"),
               new KeyValuePair<string, string>(CreditCardNetwork.Voyager, "869918830838473"),
               new KeyValuePair<string, string>(CreditCardNetwork.Voyager, "869972708732359"),
               new KeyValuePair<string, string>(CreditCardNetwork.Voyager, "869948767257579"),
            };
         }
      }

      [Test]
      public void Should_Calculate_A_Digit_With_Visa()
      {
         ICreditCardNumberCheck sut = SuT;

         Assert.AreEqual("6", sut.CalculateCheckDigit("4992739871", CreditCardNetwork.Visa));
      }

      [Test]
      public void Should_Validate_An_Account_Number_With_Method_Visa()
      {
         ICreditCardNumberCheck sut = SuT;

         Assert.IsTrue(sut.IsValid("0499273987100006", CreditCardNetwork.Visa));
      }

      [Test]
      public void Should_Validate_An_Account_Number_With_Method_Visa_To_False()
      {
         ICreditCardNumberCheck sut = SuT;

         Assert.IsFalse(sut.IsValid("0499273987100007", CreditCardNetwork.Visa));
      }

      [Test]
      public void Should_Validate_An_Account_Number_With_Non_Digits_With_Method_Visa()
      {
         ICreditCardNumberCheck sut = SuT;

         Assert.IsTrue(sut.IsValid("0499-2739-8710-0006", CreditCardNetwork.Visa));
      }

      [Test]
      public void Should_Validate_An_Account_Number_With_Automatic()
      {
         ICreditCardNumberCheck sut = SuT;

         Assert.IsTrue(sut.IsValid("4556-3371-6490-1361", CreditCardNetwork.Automatic));
      }

      [Test]
      public void Should_Validate_Against_A_List_Of_Numbers()
      {
         ICreditCardNumberCheck sut = SuT;

         foreach (var entry in NetworkToCreditCardNumberSamples)
         {
            Assert.IsTrue(sut.IsValid(entry.Value, entry.Key));
         }
      }

      [Test]
      public void Should_Validate_Against_A_List_Of_Numbers_Automatically()
      {
         ICreditCardNumberCheck sut = SuT;

         foreach (var entry in NetworkToCreditCardNumberSamples)
         {
            try
            {
               Assert.IsTrue(sut.IsValid(entry.Value, CreditCardNetwork.Automatic));
            }
            catch (ArgumentException exc)
            {
               throw new ArgumentException(entry.Value, exc);
            }
         }
      }
   }
}
