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
   public class NorwayAccountNumberValidationTests
   {
      internal IAccountNumberValidation SuT
      {
         get
         {
            return new NorwayAccountNumberValidation();
         }
      }

      [TestCase("6318", "0503562")]
      [TestCase("6318", "5678905")]
      public void Should_Be_Valid(string bankCode, string accountNumber)
      {
         var sut = SuT;

         Assert.IsTrue(sut.Validate(new NorwayAccountNumber
                                      {
                                         AccountNumber = accountNumber,
                                         BankCode = bankCode,
                                      }, null
                          ));
      }

      [TestCase("63181", "0503562")]
      [TestCase("6318", "10503562")]
      [TestCase("6318", "0503564")]
      public void Should_Be_InValid(string bankCode, string accountNumber)
      {
         var sut = SuT;

         Assert.IsFalse(sut.Validate(new NorwayAccountNumber
                                      {
                                         AccountNumber = accountNumber,
                                         BankCode = bankCode
                                      }, null
                          ));
      }
   }
}
