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
   public class ValidationMethodWeightedMod10Tests
   {
      internal IValidationMethod SuT
      {
         get
         {
            return new ValidationMethodWeightedMod10();
         }
      }

      [TestCase("212", "1100", "9")]
      public void Should_Be_Valid(string bankCode, string branchCode, string checkDigit)
      {
         var sut = SuT;

         Assert.IsTrue(sut.IsValid(
            String.Format("{0,3}{1,4}{2,1}", bankCode, branchCode, checkDigit).Replace(' ', '0')));
      }
   }
}
