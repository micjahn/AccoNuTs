﻿//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

using System;
using System.Collections.Generic;

using AccountNumberTools.AccountNumber.Validation.Contracts;

namespace AccountNumberTools.Common.Internals
{
   internal static class ValidationMethodsTools
   {
#if SILVERLIGHT
      private static readonly DanielVaughan.Logging.ILog Log = DanielVaughan.Logging.LogManager.GetLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#else
      private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#endif

      /// <summary>
      /// Splits a given number into a left and right part. Necessary for checking a given account number where the last digit is the check digit
      /// </summary>
      /// <param name="accountNumber">The account number.</param>
      /// <param name="rightCount">The right count.</param>
      /// <param name="rightPart">The right part.</param>
      /// <param name="leftPart">The left part.</param>
      public static void SplitNumber(string accountNumber, int rightCount, out string rightPart, out string leftPart)
      {
         if (String.IsNullOrEmpty(accountNumber))
            throw new ArgumentNullException("accountNumber");
         if (accountNumber.Length < rightCount)
            throw new InvalidOperationException("Account number is to short");

         rightPart = accountNumber.Substring(0, accountNumber.Length - rightCount);
         leftPart = accountNumber.Substring(accountNumber.Length - rightCount, rightCount);

         Log.InfoFormat("AccountNumber: {0} splitted into {1} and check digit {2}", accountNumber, rightPart, leftPart);
      }

      /// <summary>
      /// Calculates the cross sum.
      /// </summary>
      /// <param name="number">The number.</param>
      /// <returns></returns>
      public static int CalculateCrossSum(int number)
      {
         var localNumber = number;
         var querSumme = 0;
         while (localNumber > 0)
         {
            querSumme = querSumme + (localNumber % 10);
            localNumber = localNumber / 10;
         }

         Log.InfoFormat("Number: {0} checksum: {1}", number, querSumme);

         return querSumme;
      }

      /// <summary>
      /// Calculates the modulo for very big numbers
      /// </summary>
      /// <param name="bigNumber">the number</param>
      /// <param name="modulo">The modulo.</param>
      /// <returns></returns>
      public static int CalculateModulo(string bigNumber, int modulo)
      {
         var remainer = 0;
         while (bigNumber.Length >= 7)
         {
            remainer = int.Parse(remainer + bigNumber.Substring(0, 7)) % modulo;
            bigNumber = bigNumber.Substring(7);
         }
         return int.Parse(remainer + bigNumber) % modulo;
      }

      /// <summary>
      /// Adds the validation error message.
      /// </summary>
      /// <param name="validationErrors">The validation errors.</param>
      /// <param name="message">The message.</param>
      public static void AddValidationErrorMessage(this ICollection<ValidationError> validationErrors, string message)
      {
         if (validationErrors != null)
            validationErrors.Add(new ValidationError(message));
      }

      /// <summary>
      /// Adds the validation error message.
      /// </summary>
      /// <param name="validationErrors">The validation errors.</param>
      /// <param name="validationErrorCode">The error code.</param>
      public static void AddValidationErrorMessage(this ICollection<ValidationError> validationErrors, ValidationErrorCodes validationErrorCode)
      {
         if (validationErrors != null)
            validationErrors.Add(new ValidationError(validationErrorCode));
      }

      /// <summary>
      /// Validates the member.
      /// </summary>
      /// <param name="member">The member.</param>
      /// <param name="maxLength">Length of the max.</param>
      /// <param name="validationErrors">The validation errors.</param>
      /// <param name="missingCode">The missing code.</param>
      /// <param name="tooLongCode">The too long code.</param>
      public static void ValidateMember(string member, int maxLength, ICollection<ValidationError> validationErrors, ValidationErrorCodes missingCode, ValidationErrorCodes tooLongCode)
      {
         if (String.IsNullOrEmpty(member))
            validationErrors.AddValidationErrorMessage(missingCode);
         else
            if (member.Length > maxLength)
               validationErrors.AddValidationErrorMessage(tooLongCode);
      }
   }
}
