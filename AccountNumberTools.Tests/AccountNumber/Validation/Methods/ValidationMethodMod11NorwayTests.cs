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
   public class ValidationMethodMod11NorwayTests
   {
      internal IValidationMethod SuT
      {
         get
         {
            return new ValidationMethodMod11Norway();
         }
      }

      [TestCase("6318", "050356", "2")]
      public void Should_Be_Valid(string bankCode, string accountNumber, string checkDigit)
      {
         var sut = SuT;

         Assert.IsTrue(sut.IsValid(
            String.Format("{0,4}{1,6}{2,1}", bankCode, accountNumber, checkDigit).Replace(' ', '0')));
      }
   }
}
