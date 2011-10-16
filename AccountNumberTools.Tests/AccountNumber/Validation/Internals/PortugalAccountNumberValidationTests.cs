﻿//
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
   public class PortugalAccountNumberValidationTests
   {
      internal IAccountNumberValidation SuT
      {
         get
         {
            return new PortugalAccountNumberValidation();
         }
      }

      [TestCase("2", "123", "1234567890154")]
      [TestCase("32", "401", "20200337054")]
      [TestCase("19", "22", "20001561036")]
      public void Should_Be_Valid(string bankCode, string branchCode, string accountNumber)
      {
         var sut = SuT;

         Assert.IsTrue(sut.Validate(new PortugalAccountNumber
                                      {
                                         AccountNumber = accountNumber,
                                         BankCode = bankCode,
                                         Branch = branchCode
                                      }, null
                          ));
      }

      [TestCase("21234", "123", "1234567890154")]
      [TestCase("2", "12345", "1234567890154")]
      [TestCase("2", "123", "12345678901545")]
      [TestCase("2", "123", "1234567890155")]
      public void Should_Be_InValid(string bankCode, string branchCode, string accountNumber)
      {
         var sut = SuT;

         Assert.IsFalse(sut.Validate(new PortugalAccountNumber
                                      {
                                         AccountNumber = accountNumber,
                                         BankCode = bankCode,
                                         Branch = branchCode
                                      }, null
                          ));
      }
   }
}
