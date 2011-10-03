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
   public class ValidationMethodMod97Tests
   {
      internal IValidationMethod SuT
      {
         get
         {
            return new ValidationMethodMod97();
         }
      }

      [TestCase("539", "0075470", "34")]
      [TestCase("539", "75470", "34")]
      public void Should_Be_Valid(string bankCode, string accountNumber, string checkDigits)
      {
         var sut = SuT;

         Assert.IsTrue(sut.IsValid(
            String.Format("{0,3}{1,7}{2,2}", bankCode, accountNumber, checkDigits).Replace(' ', '0')));
      }
   }
}
