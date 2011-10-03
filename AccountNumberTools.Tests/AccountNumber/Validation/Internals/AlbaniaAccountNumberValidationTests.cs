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
   public class AlbaniaAccountNumberValidationTests
   {
      internal IAccountNumberValidation SuT
      {
         get
         {
            return new AlbaniaAccountNumberValidation();
         }
      }

      [TestCase("212", "11009", "0000000235698741")]
      [TestCase("212", "11009", "235698741")]
      public void Should_Be_Valid(string bankCode, string branchCode, string accountNumber)
      {
         var sut = SuT;

         Assert.IsTrue(sut.IsValid(new AlbaniaAccountNumber
                                      {
                                         AccountNumber = accountNumber,
                                         BankCode = bankCode,
                                         Branch = branchCode
                                      }
                          ));
      }

      [TestCase("2123", "11009", "0000000235698741")]
      [TestCase("212", "111009", "0000000235698741")]
      [TestCase("212", "11008", "0000000235698741")]
      public void Should_Be_InValid(string bankCode, string branchCode, string accountNumber)
      {
         var sut = SuT;

         Assert.IsFalse(sut.IsValid(new AlbaniaAccountNumber
                                      {
                                         AccountNumber = accountNumber,
                                         BankCode = bankCode,
                                         Branch = branchCode
                                      }
                          ));
      }
   }
}
