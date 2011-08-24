//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

using System;

using AccountNumberTools.Common.Contracts;
using AccountNumberTools.Common.Internals;

namespace AccountNumberTools.CreditCard.Methods
{
   /// <summary>
   /// class to check a given credit number against the Luhn (mod 10) algorithm with a length check
   /// </summary>
   public class CheckMethodLuhn : ICheckMethod
   {
      private readonly int[] doubleAndCrossSum = new int[] { 0, 2, 4, 6, 8, 1, 3, 5, 7, 9 };
      private int minLength;
      private int maxLength;

      /// <summary>
      /// Initializes a new instance of the <see cref="CheckMethodLuhn"/> class.
      /// </summary>
      /// <param name="minLength">Length of the min.</param>
      /// <param name="maxLength">Length of the max.</param>
      public CheckMethodLuhn(int minLength, int maxLength)
      {
         this.minLength = minLength;
         this.maxLength = maxLength;
      }

      /// <summary>
      /// Determines whether the specified credit card number is formal valid.
      /// </summary>
      /// <param name="creditCardNumber">The credit card number.</param>
      /// <returns>
      ///   <c>true</c> if the specified credit card number is formal valid; otherwise, <c>false</c>.
      /// </returns>
      public bool IsValid(string creditCardNumber)
      {
         if (creditCardNumber.Length < minLength || creditCardNumber.Length > maxLength)
            return false;

         string number;
         string checkdigit;

         CheckMethodsTools.SplitNumber(creditCardNumber, 1, out number, out checkdigit);

         var calculatedCheckDigit = CalculateCheckDigitInternal(number).ToString();

         return calculatedCheckDigit.Equals(checkdigit);
      }

      /// <summary>
      /// Calculates the check digit for the given credit card number.
      /// </summary>
      /// <param name="creditCardNumber">The credit card number.</param>
      /// <returns></returns>
      public string CalculateCheckDigit(string creditCardNumber)
      {
         return CalculateCheckDigitInternal(creditCardNumber).ToString();
      }

      /// <summary>
      /// Calculates the check digit for the given credit card number.
      /// </summary>
      /// <param name="creditCardNumber">The credit card number.</param>
      /// <returns></returns>
      public int CalculateCheckDigitInternal(string creditCardNumber)
      {
         // no need to check for the range 0 to 9 because it should be cleaned up before
         // in CreditCardNumberCheck class

         var checksum = 0;

         for (var index = creditCardNumber.Length - 2; index >= 0; index -= 2)
         {
            var digit = creditCardNumber[index] - 48;
            checksum += digit;
         }
         for (var index = creditCardNumber.Length - 1; index >= 0; index -= 2)
         {
            var digit = doubleAndCrossSum[creditCardNumber[index] - 48];
            checksum += digit;
         }

         return (10 - (checksum % 10)) % 10;
      }
   }
}
