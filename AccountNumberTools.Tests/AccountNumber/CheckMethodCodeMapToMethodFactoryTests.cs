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

namespace AccountNumberTools.AccountNumber.Tests
{
   /// <summary>
   /// a new class
   /// </summary>
   [TestFixture]
   public class CheckMethodCodeMapToMethodFactoryTests
   {
      internal CheckMethodCodeMapToMethodFactory SuT
      {
         get
         {
            return new CheckMethodCodeMapToMethodFactory();
         }
      }

      [Test]
      public void Should_Register_Default_Methods_Without_Errors()
      {
         var sut = SuT;

         Assert.Greater(sut.Map.Count, 0);
      }

      [Test]
      public void Should_Find_A_Check_Method_For_Code_01()
      {
         var sut = SuT;

         Assert.IsNotNull(sut.Resolve("01"));
      }
   }
}
