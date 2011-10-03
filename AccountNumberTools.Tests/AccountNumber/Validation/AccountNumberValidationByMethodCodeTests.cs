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

using AccountNumberTools.AccountNumber.Validation.Contracts;

namespace AccountNumberTools.AccountNumber.Validation.Tests
{
   /// <summary>
   /// a new class
   /// </summary>
   [TestFixture]
   public class AccountNumberValidationByMethodCodeTests
   {
      internal AccountNumberValidationByMethodCode SuT
      {
         get
         {
            return new AccountNumberValidationByMethodCode();
         }
      }

      [Test]
      public void Should_Calculate_A_Digit_With_Method01()
      {
         IAccountNumberValidationByMethodCode sut = SuT;

         Assert.AreEqual("7", sut.CalculateCheckDigit("423432278", "01"));
      }

      [Test]
      public void Should_Validate_An_Account_Number_With_Method_01()
      {
         IAccountNumberValidationByMethodCode sut = SuT;

         Assert.IsTrue(sut.IsValid("4234322787", "01"));
      }
   }
}
