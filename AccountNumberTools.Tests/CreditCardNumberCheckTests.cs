//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

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
   }
}
