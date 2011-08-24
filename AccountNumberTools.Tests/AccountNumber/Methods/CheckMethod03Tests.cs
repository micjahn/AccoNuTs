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
using AccountNumberTools.AccountNumber.Methods;

namespace AccountNumberTools.Tests.Methods
{
   [TestFixture]
   public class CheckMethod03Tests
   {
      internal ICheckMethod SuT
      {
         get
         {
            return new CheckMethod03();
         }
      }

      [TestCase("4234324")]
      [TestCase("42343228")]
      [TestCase("423432244")]
      [TestCase("4234322785")]
      public void Should_Be_Valid(object accountNumber)
      {
         var sut = SuT;

         Assert.IsTrue(sut.IsValid(accountNumber.ToString()));
      }
   }
}
