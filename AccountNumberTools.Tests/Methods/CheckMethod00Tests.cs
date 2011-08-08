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
   public class CheckMethod00Tests
   {
      internal ICheckMethod SuT
      {
         get
         {
            return new CheckMethod00();
         }
      }

      [TestCase("9290701")]
      [TestCase("539290858")]
      [TestCase("1501824")]
      [TestCase("1501832")]
      public void Should_Be_Valid(object accountNumber)
      {
         var sut = SuT;

         Assert.IsTrue(sut.IsValid(accountNumber.ToString()));
      }
   }
}
