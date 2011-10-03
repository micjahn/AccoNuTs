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

using AccountNumberTools.AccountNumber.Contracts.CountrySpecific;
using AccountNumberTools.AccountNumber.Validation.Contracts;

namespace AccountNumberTools.AccountNumber.Validation.Internals.Tests
{
   /// <summary>
   /// a new class
   /// </summary>
   [TestFixture]
   public class BelgiumAccountNumberValidationTests
   {
      internal IAccountNumberValidation SuT
      {
         get
         {
            return new BelgiumAccountNumberValidation();
         }
      }

      [TestCase("539", "0075470", "34")]
      [TestCase("539", "75470", "34")]
      public void Should_Be_Valid(string bankCode, string accountNumber, string checkDigits)
      {
         var sut = SuT;

         Assert.IsTrue(sut.IsValid(new BelgiumAccountNumber
                                      {
                                         AccountNumber = accountNumber + checkDigits,
                                         BankCode = bankCode
                                      }
                          ));
      }

      [TestCase("5396", "0075470", "34")]
      [TestCase("539", "12375470", "34")]
      [TestCase("539", "0075470", "35")]
      public void Should_Be_InValid(string bankCode, string accountNumber, string checkDigits)
      {
         var sut = SuT;

         Assert.IsFalse(sut.IsValid(new BelgiumAccountNumber
                                      {
                                         AccountNumber = accountNumber + checkDigits,
                                         BankCode = bankCode
                                      }
                          ));
      }
   }
}
