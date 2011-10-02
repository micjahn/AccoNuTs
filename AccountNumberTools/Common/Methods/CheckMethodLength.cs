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

namespace AccountNumberTools.Common.Methods
{
   /// <summary>
   /// Simple class to check only the length of a given number
   /// </summary>
   public class ValidationMethodLength : IValidationMethod
   {
      private int minLength;
      private int maxLength;

      /// <summary>
      /// Initializes a new instance of the <see cref="ValidationMethodLength"/> class.
      /// </summary>
      /// <param name="minLength">Length of the min.</param>
      /// <param name="maxLength">Length of the max.</param>
      public ValidationMethodLength(int minLength, int maxLength)
      {
         this.minLength = minLength;
         this.maxLength = maxLength;
      }

      /// <summary>
      /// Checks, if the credit card number is within the range of minLength and maxLength
      /// </summary>
      /// <param name="creditCardNumber">The credit card number.</param>
      /// <returns>
      ///   <c>true</c> if the specified credit card number is formal valid; otherwise, <c>false</c>.
      /// </returns>
      public bool IsValid(string creditCardNumber)
      {
         return creditCardNumber.Length >= minLength && creditCardNumber.Length <= maxLength;
      }

      /// <summary>
      /// Gives always String.Empty
      /// </summary>
      /// <param name="creditCardNumber">The credit card number.</param>
      /// <returns></returns>
      public string CalculateCheckDigit(string creditCardNumber)
      {
         return String.Empty;
      }
   }
}
