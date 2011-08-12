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

namespace AccountNumberTools.Tests
{
   /// <summary>
   /// a new class
   /// </summary>
   [TestFixture]
   public class CreditCardNetworkMapToMethodFactoryTests
   {
      internal ICreditCardNetworkMapToMethod SuT
      {
         get
         {
            return new CreditCardNetworkMapToMethodFactory();
         }
      }

      [TestCase(CreditCardNetwork.AmericanExpress)]
      [TestCase(CreditCardNetwork.Bankcard)]
      [TestCase(CreditCardNetwork.ChinaUnionPay)]
      [TestCase(CreditCardNetwork.DinersClubCarteBlanche)]
      [TestCase(CreditCardNetwork.DinersClubenRoute)]
      [TestCase(CreditCardNetwork.DinersClubInternational)]
      [TestCase(CreditCardNetwork.DinersClubUnitedStatesCanada)]
      [TestCase(CreditCardNetwork.DiscoverCard)]
      [TestCase(CreditCardNetwork.InstaPayment)]
      [TestCase(CreditCardNetwork.JCB)]
      [TestCase(CreditCardNetwork.Laser)]
      [TestCase(CreditCardNetwork.Maestro)]
      [TestCase(CreditCardNetwork.MasterCard)]
      [TestCase(CreditCardNetwork.Solo)]
      [TestCase(CreditCardNetwork.Switch)]
      [TestCase(CreditCardNetwork.Visa)]
      [TestCase(CreditCardNetwork.VisaElectron)]
      public void Should_Find_A_Check_Method_For_Code(string creditCardNetworkCode)
      {
         var sut = SuT;

         Assert.IsNotNull(sut.Resolve(creditCardNetworkCode));
      }
   }
}
