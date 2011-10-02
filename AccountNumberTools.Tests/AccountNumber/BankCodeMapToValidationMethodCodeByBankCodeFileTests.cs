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

namespace AccountNumberTools.AccountNumber.Validation.Tests
{
   /// <summary>
   /// a new class
   /// </summary>
   [TestFixture]
   public class BankCodeMapToValidationMethodCodeByBankCodeFileTests
   {
      internal BankCodeMapToValidationMethodCodeByBankCodeFile SuT
      {
         get
         {
            return new BankCodeMapToValidationMethodCodeByBankCodeFile(@"Data\BLZ_20110606.txt");
         }
      }

      [Test]
      public void Should_Find_A_Method_Code_For_10090000()
      {
         var sut = SuT;

         Assert.AreEqual("06", sut.Resolve("10090000"));
      }
   }
}
