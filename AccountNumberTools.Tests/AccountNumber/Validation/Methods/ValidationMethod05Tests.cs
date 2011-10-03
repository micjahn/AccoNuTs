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

using AccountNumberTools.AccountNumber.Validation.Contracts;
using AccountNumberTools.AccountNumber.Validation.Methods;

namespace AccountNumberTools.Tests.Methods
{
   [TestFixture]
   public class ValidationMethod05Tests
   {
      internal IValidationMethod SuT
      {
         get
         {
            return new ValidationMethod05();
         }
      }

      [TestCase("4234322")]
      [TestCase("42343220")]
      [TestCase("423432242")]
      [TestCase("4234322783")]
      public void Should_Be_Valid(object accountNumber)
      {
         var sut = SuT;

         Assert.IsTrue(sut.IsValid(accountNumber.ToString()));
      }
   }
}
