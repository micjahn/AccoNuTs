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

using AccountNumberTools.AccountNumber.Validation.Contracts;
using AccountNumberTools.AccountNumber.Validation.Methods;

namespace AccountNumberTools.Tests.Methods
{
   /// <summary>
   /// a new class
   /// </summary>
   [TestFixture]
   public class ValidationMethodMod9710Tests
   {
      internal IValidationMethod SuT
      {
         get
         {
            return new ValidationMethodMod9710();
         }
      }

      [TestCase("2", "123", "12345678901", "54")]
      [TestCase("32", "401", "202003370", "54")]
      [TestCase("19", "22", "200015610", "36")]
      public void Should_Be_Valid(string bankCode, string branch, string accountNumber, string checkDigits)
      {
         var sut = SuT;

         Assert.IsTrue(sut.IsValid(
            String.Format("{0,4}{1,4}{2,11}{3,2}", bankCode, branch, accountNumber, checkDigits).Replace(' ', '0')));
      }
   }
}
