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

namespace AccountNumberTools.Common.Internals
{
   internal static class CheckMethodsTools
   {
      private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
   }
}
