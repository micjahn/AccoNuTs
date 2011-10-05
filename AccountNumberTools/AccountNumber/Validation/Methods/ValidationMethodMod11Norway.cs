//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

using AccountNumberTools.Common.Internals;

namespace AccountNumberTools.AccountNumber.Validation.Methods
{
   internal class ValidationMethodMod11Norway : ValidationMethodModuloBase
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="ValidationMethodMod11Norway"/> class.
      /// </summary>
      public ValidationMethodMod11Norway()
      {
         WeightMask = "12345672345";
         Modulo = 11;
      }

      /// <summary>
      /// Determines whether the specified account number is valid.
      /// </summary>
      /// <param name="accountNumber">The account number.</param>
      /// <returns>
      ///   <c>true</c> if the specified account number is valid; otherwise, <c>false</c>.
      /// </returns>
      override public bool IsValid(string accountNumber)
      {
         string number;
         string checkdigit;

         ValidationMethodsTools.SplitNumber(accountNumber, 1, out number, out checkdigit);

         accountNumber = number + '0';
         var calculatedCheckDigit = CalculateCheckDigitInternal(accountNumber).ToString();

         return calculatedCheckDigit.Equals(checkdigit);
      }
   }
}
