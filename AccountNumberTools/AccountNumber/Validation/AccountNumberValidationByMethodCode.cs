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

using AccountNumberTools.AccountNumber.Validation.Contracts;

namespace AccountNumberTools.AccountNumber.Validation
{
   /// <summary>
   /// Main class for checking account numbers with specific validation methods
   /// </summary>
   public class AccountNumberValidationByMethodCode : IAccountNumberValidationByMethodCode
   {
      /// <summary>
      /// Gets or sets the check method code map to method.
      /// </summary>
      /// <value>
      /// The check method code map to method.
      /// </value>
      public IValidationMethodCodeMapToMethod ValidationMethodCodeMapToMethod { get; set; }

      /// <summary>
      /// Initializes a new instance of the <see cref="AccountNumberValidation"/> class.
      /// </summary>
      public AccountNumberValidationByMethodCode()
         : this(new ValidationMethodCodeMapToMethodFactory())
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="AccountNumberValidation"/> class.
      /// </summary>
      /// <param name="validationMethodCodeMapToMethod">The check method code map to method.</param>
      public AccountNumberValidationByMethodCode(IValidationMethodCodeMapToMethod validationMethodCodeMapToMethod)
      {
         ValidationMethodCodeMapToMethod = validationMethodCodeMapToMethod;
      }

      /// <summary>
      /// Determines whether the specified account number is valid. The account number
      /// is given as a full number including the hypothetical check digit.
      /// </summary>
      /// <param name="accountNumber">The account number including the hypothetical check digit.</param>
      /// <param name="checkMethodCode">The code for a registered check method</param>
      /// <returns>
      ///   <c>true</c> if the specified account number is valid; otherwise, <c>false</c>.
      /// </returns>
      public bool IsValid(string accountNumber, string checkMethodCode)
      {
         if (string.IsNullOrEmpty(checkMethodCode))
            throw new ArgumentNullException("checkMethodCode", "Please provide the code for a check method.");
         if (string.IsNullOrEmpty(accountNumber))
            throw new ArgumentNullException("accountNumber", "Please provide the account number.");

         if (ValidationMethodCodeMapToMethod == null)
            throw new InvalidOperationException("Please provide an instanz for the mapping between a check method code and a check method.");

         var checkMethod = ValidationMethodCodeMapToMethod.Resolve(checkMethodCode);
         if (checkMethod == null)
            throw new InvalidOperationException(String.Format("The check method code {0} could not be mapped to a check method implementation.", checkMethodCode));

         return checkMethod.IsValid(accountNumber);
      }

      /// <summary>
      /// Calculates the check digit. The given bank code will be
      /// mapped to an registered method which calculates the check digit.
      /// The account number is given without a check digit.
      /// </summary>
      /// <param name="accountNumber">The account number without a check digit.</param>
      /// <param name="checkMethodCode">The code for a registered check method</param>
      /// <returns>
      /// The calculated check digit for the given account number
      /// </returns>
      public string CalculateCheckDigit(string accountNumber, string checkMethodCode)
      {
         if (string.IsNullOrEmpty(checkMethodCode))
            throw new ArgumentNullException("checkMethodCode", "Please provide a code for a check method.");
         if (string.IsNullOrEmpty(accountNumber))
            throw new ArgumentNullException("accountNumber", "Please provide an account number.");

         if (ValidationMethodCodeMapToMethod == null)
            throw new InvalidOperationException("Please provide an instanz for the mapping between a check method code and a check method.");

         var checkMethod = ValidationMethodCodeMapToMethod.Resolve(checkMethodCode);
         if (checkMethod == null)
            throw new InvalidOperationException(String.Format("The check method code {0} could not be mapped to a check method implementation.", checkMethodCode));

         return checkMethod.CalculateCheckDigit(accountNumber);
      }
   }
}
