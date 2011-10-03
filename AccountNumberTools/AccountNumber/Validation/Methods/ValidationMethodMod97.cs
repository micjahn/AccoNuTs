//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

using AccountNumberTools.AccountNumber.Validation.Contracts;
using AccountNumberTools.Common.Internals;

namespace AccountNumberTools.AccountNumber.Validation.Methods
{
   /// <summary>
   /// class which calculates check digits with a mod 97 algorithm
   /// </summary>
   public class ValidationMethodMod97 : IValidationMethod
   {
      private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

      /// <summary>
      /// Determines whether the specified account number is valid.
      /// </summary>
      /// <param name="accountNumber">The account number.</param>
      /// <returns>
      ///   <c>true</c> if the specified account number is valid; otherwise, <c>false</c>.
      /// </returns>
      virtual public bool IsValid(string accountNumber)
      {
         string number;
         string checkdigit;

         ValidationMethodsTools.SplitNumber(accountNumber, 2, out number, out checkdigit);

         var calculatedCheckDigit = CalculateCheckDigitInternal(number).ToString("00");

         return calculatedCheckDigit.Equals(checkdigit);
      }

      /// <summary>
      /// Calculates the check digit for a given account number.
      /// </summary>
      /// <param name="accountNumber">The account number.</param>
      /// <returns></returns>
      virtual public string CalculateCheckDigit(string accountNumber)
      {
         return CalculateCheckDigitInternal(accountNumber).ToString();
      }

      private static int CalculateCheckDigitInternal(string accountNumber)
      {
         if (accountNumber.Length == 0)
            return 0;

         var firstDigits = accountNumber.Substring(0, accountNumber.Length - 1);
         var lastDigit = int.Parse(accountNumber.Substring(accountNumber.Length - 1));

         var checkDigits = (CalculateCheckDigitInternal(firstDigits) * 10 + lastDigit) % 97;
         
         Log.InfoFormat("Check digits: {0}", checkDigits);

         return checkDigits;
      }
   }
}
