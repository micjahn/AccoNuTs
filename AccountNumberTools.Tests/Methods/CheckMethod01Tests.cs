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

using AccountNumberTools.Contracts;
using AccountNumberTools.Methods;

namespace AccountNumberTools.Tests.Methods
{
   [TestFixture]
   public class CheckMethod01Tests
   {
      internal ICheckMethod SuT
      {
         get
         {
            return new CheckMethod01();
         }
      }

      [TestCase("4234322")]
      [TestCase("42343220")]
      [TestCase("423432248")]
      [TestCase("4234322787")]
      public void Should_Be_Valid(object accountNumber)
      {
         var sut = SuT;

         Assert.IsTrue(sut.IsValid(accountNumber.ToString()));
      }
   }
}
