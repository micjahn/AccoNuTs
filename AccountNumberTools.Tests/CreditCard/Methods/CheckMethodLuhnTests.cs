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
using AccountNumberTools.CreditCard.Methods;

namespace AccountNumberTools.Tests.Methods
{
   /// <summary>
   /// a new class
   /// </summary>
   [TestFixture]
   public class CheckMethodLuhnTests
   {
      internal ICheckMethod GetSuT(int min, int max)
      {
         return new CheckMethodLuhn(min, max);
      }

      [TestCase("49927398716", 11, 11, true)]
      [TestCase("49927398716", 12, 12, false)]
      [TestCase("49927398716", 10, 10, false)]
      [TestCase("49927398717", 11, 11, false)]
      public void Should_Be_Valid(string creditCardNumber, int min, int max, bool expectedResult)
      {
         var sut = GetSuT(min, max);

         Assert.AreEqual(expectedResult, sut.IsValid(creditCardNumber));
      }
   }
}
