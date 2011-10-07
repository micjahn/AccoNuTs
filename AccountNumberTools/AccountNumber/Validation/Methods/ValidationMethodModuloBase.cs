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
   /// base class for modulo based check methods
   /// </summary>
   public class ValidationMethodModuloBase : IValidationMethod
   {
#if SILVERLIGHT
      private static readonly DanielVaughan.Logging.ILog Log = DanielVaughan.Logging.LogManager.GetLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#else
      private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#endif

      /// <summary>
      /// Gets or sets a digit by digit weight mask which is automatically repeated if necessary
      /// </summary>
      /// <value>
      /// The weight mask.
      /// </value>
      protected string WeightMask { get; set; }

      /// <summary>
      /// Gets or sets the modulo value for the calculation. Typically 10 or 11.
      /// </summary>
      /// <value>
      /// The modulo.
      /// </value>
      protected int Modulo { get; set; }

      /// <summary>
      /// Initializes a new instance of the <see cref="ValidationMethod00"/> class.
      /// </summary>
      public ValidationMethodModuloBase()
      {
         WeightMask = "1";
         Modulo = 10;
      }

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

         ValidationMethodsTools.SplitNumber(accountNumber, 1, out number, out checkdigit);

         var calculatedCheckDigit = CalculateCheckDigitInternal(number).ToString();

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

      /// <summary>
      /// Calculates the check digit.
      /// </summary>
      /// <param name="accountNumber">The account number.</param>
      /// <returns></returns>
      virtual protected int CalculateCheckDigitInternal(string accountNumber)
      {
         var sum = 0;
         var weightIndex = 0;

         for (var index = accountNumber.Length - 1; index >= 0; index--)
         {
            var digit = accountNumber[index];
            var weight = WeightMask[weightIndex];
            var product = (digit - '0') * (weight - '0');

            Log.InfoFormat("digit: {0}; weight: {1}; product: {2}", digit, weight, product);

            sum += ModifyProductBeforeSum(product);

            weightIndex++;
            if (weightIndex >= WeightMask.Length)
               weightIndex = 0;
         }
         Log.InfoFormat("Sum: {0}; Sum % {1}: {2}; {1} - Sum % {1}: {3}", sum, Modulo, sum % Modulo, Modulo - (sum % Modulo));

         return CalculateCheckDigitFromSum(sum);
      }

      /// <summary>
      /// Used to make some modifications to the product of digit and weight before is added to the sum
      /// </summary>
      /// <param name="product">The product.</param>
      /// <returns></returns>
      virtual protected int ModifyProductBeforeSum(int product)
      {
         return product;
      }

      /// <summary>
      /// Used to make some modifications to the product of digit and weight before is added to the sum
      /// </summary>
      /// <param name="sum">The sum.</param>
      /// <returns></returns>
      virtual protected int CalculateCheckDigitFromSum(int sum)
      {
         return ((Modulo - (sum % Modulo)) % Modulo);
      }
   }
}
