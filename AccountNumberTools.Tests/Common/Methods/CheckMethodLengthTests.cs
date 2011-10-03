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
   /// <summary>
   /// a new class
   /// </summary>
   [TestFixture]
   public class CheckMethodLengthTests
   {
      internal IValidationMethod GetSuT(int min, int max)
      {
         return new ValidationMethodLength(min, max);
      }

      [TestCase("12345", 5, 5, true)]
      [TestCase("12345", 6, 6, false)]
      [TestCase("12345", 4, 4, false)]
      [TestCase("12345", 1, 10, true)]
      public void Should_Be_Valid(string creditCardNumber, int min, int max, bool expectedResult)
      {
         var sut = GetSuT(min, max);

         Assert.AreEqual(expectedResult, sut.IsValid(creditCardNumber));
      }
   }
}
