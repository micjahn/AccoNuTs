//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

using AccountNumberTools.AccountNumber.Contracts;
using AccountNumberTools.AccountNumber.Validation.Contracts;

namespace AccountNumberTools.AccountNumber.Validation.Extensions
{
   /// <summary>
   /// 
   /// </summary>
   public static class NationalAccountNumberValidationExtensions
   {
      private static readonly IAccountNumberValidation validation;

      static NationalAccountNumberValidationExtensions()
      {
         validation = new AccountNumberValidation();
      }

      /// <summary>
      /// Determines whether the specified national account number is valid.
      /// </summary>
      /// <param name="nationalAccountNumber">The national account number.</param>
      /// <returns>
      ///   <c>true</c> if the specified national account number is valid; otherwise, <c>false</c>.
      /// </returns>
      public static bool IsValid(this NationalAccountNumber nationalAccountNumber)
      {
         return validation.IsValid(nationalAccountNumber);
      }

      /// <summary>
      /// Calculates the check digit.
      /// </summary>
      /// <param name="nationalAccountNumber">The national account number.</param>
      /// <returns></returns>
      public static string CalculateCheckDigit(this NationalAccountNumber nationalAccountNumber)
      {
         return validation.CalculateCheckDigit(nationalAccountNumber);
      }
   }
}
