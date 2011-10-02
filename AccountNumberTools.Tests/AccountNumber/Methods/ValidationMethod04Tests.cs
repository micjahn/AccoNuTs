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

using AccountNumberTools.Common.Contracts;
using AccountNumberTools.AccountNumber.Validation.Methods;

namespace AccountNumberTools.Tests.Methods
{
   [TestFixture]
   public class ValidationMethod04Tests
   {
      internal IValidationMethod SuT
      {
         get
         {
            return new ValidationMethod04();
         }
      }

      [TestCase("4234324")]
      [TestCase("42343226")]
      [TestCase("423432241")]
      [TestCase("4234322783")]
      public void Should_Be_Valid(object accountNumber)
      {
         var sut = SuT;

         Assert.IsTrue(sut.IsValid(accountNumber.ToString()));
      }
   }
}
