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
   public class PolandAccountNumberValidationTests
   {
      internal IAccountNumberValidation SuT
      {
         get
         {
            return new PolandAccountNumberValidation();
         }
      }

      [TestCase("114", "02004", "123456")]
      public void Should_Be_Valid(string bankCode, string branchCode, string accountNumber)
      {
         var sut = SuT;

         Assert.IsTrue(sut.Validate(new PolandAccountNumber
                                      {
                                         AccountNumber = accountNumber,
                                         BankCode = bankCode,
                                         Branch = branchCode
                                      }, null
                          ));
      }

      [TestCase("1145", "02004", "123456")]
      [TestCase("114", "102004", "123456")]
      [TestCase("114", "02005", "123456")]
      public void Should_Be_InValid(string bankCode, string branchCode, string accountNumber)
      {
         var sut = SuT;

         Assert.IsFalse(sut.Validate(new PolandAccountNumber
                                      {
                                         AccountNumber = accountNumber,
                                         BankCode = bankCode,
                                         Branch = branchCode
                                      }, null
                          ));
      }
   }
}
