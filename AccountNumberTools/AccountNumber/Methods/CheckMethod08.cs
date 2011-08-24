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

using AccountNumberTools.Common.Internals;

namespace AccountNumberTools.AccountNumber.Methods
{
   internal class CheckMethod08 : CheckMethodModuloBase
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="CheckMethod08"/> class.
      /// </summary>
      public CheckMethod08()
      {
         WeightMask = "21";
         Modulo = 10;
      }

      /// <summary>
      /// Determines whether the specified account number is valid.
      /// </summary>
      /// <param name="accountNumber">The account number.</param>
      /// <returns>
      ///   <c>true</c> if the specified account number is valid; otherwise, <c>false</c>.
      /// </returns>
      public override bool IsValid(string accountNumber)
      {
         if (accountNumber.Length < 5 || accountNumber[0] < '7')
            return true;
         return base.IsValid(accountNumber);
      }

      /// <summary>
      /// Calculates the check digit for a given account number.
      /// </summary>
      /// <param name="accountNumber">The account number.</param>
      /// <returns></returns>
      public override string CalculateCheckDigit(string accountNumber)
      {
         if (accountNumber.Length < 5 || accountNumber[0] < '7')
            return String.Empty;
         return base.CalculateCheckDigit(accountNumber);
      }

      /// <summary>
      /// Used to make some modifications to the product of digit and weight before is added to the sum
      /// </summary>
      /// <param name="product">The product.</param>
      /// <returns></returns>
      override protected int ModifyProductBeforeSum(int product)
      {
         return CheckMethodsTools.CalculateCrossSum(product);
      }
   }
}
