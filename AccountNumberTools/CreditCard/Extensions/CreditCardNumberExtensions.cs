//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

using AccountNumberTools.CreditCard.Contracts;

namespace AccountNumberTools.CreditCard.Extensions
{
   /// <summary>
   /// 
   /// </summary>
   public static class CreditCardNumberExtensions
   {
      private static readonly ICreditCardNumberCheck creditCardNumberCheck;

      static CreditCardNumberExtensions()
      {
         creditCardNumberCheck = new CreditCardNumberCheck();
      }

      /// <summary>
      /// Determines whether the specified credit card number is valid.
      /// </summary>
      /// <param name="creditCardNumber">The credit card number.</param>
      /// <returns>
      ///   <c>true</c> if the specified credit card number is valid; otherwise, <c>false</c>.
      /// </returns>
      public static bool IsValid(this string creditCardNumber)
      {
         return creditCardNumberCheck.IsValid(creditCardNumber, CreditCardNetwork.Automatic);
      }

      /// <summary>
      /// Determines whether the specified credit card number is valid.
      /// </summary>
      /// <param name="creditCardNumber">The credit card number.</param>
      /// <param name="creditCardNetwork">The credit card network.</param>
      /// <returns>
      ///   <c>true</c> if the specified credit card number is valid; otherwise, <c>false</c>.
      /// </returns>
      public static bool IsValid(this string creditCardNumber, string creditCardNetwork)
      {
         return creditCardNumberCheck.IsValid(creditCardNumber, creditCardNetwork);
      }

      /// <summary>
      /// Calculates the check digit.
      /// </summary>
      /// <param name="creditCardNumber">The credit card number.</param>
      /// <returns></returns>
      public static string CalculateCheckDigit(this string creditCardNumber)
      {
         return creditCardNumberCheck.CalculateCheckDigit(creditCardNumber, CreditCardNetwork.Automatic);
      }

      /// <summary>
      /// Calculates the check digit.
      /// </summary>
      /// <param name="creditCardNumber">The credit card number.</param>
      /// <param name="creditCardNetwork">The credit card network.</param>
      /// <returns></returns>
      public static string CalculateCheckDigit(this string creditCardNumber, string creditCardNetwork)
      {
         return creditCardNumberCheck.CalculateCheckDigit(creditCardNumber, creditCardNetwork);
      }
   }
}
