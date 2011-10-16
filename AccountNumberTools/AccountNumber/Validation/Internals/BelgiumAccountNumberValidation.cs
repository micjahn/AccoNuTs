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
using System.Collections.Generic;

using AccountNumberTools.AccountNumber.Contracts;
using AccountNumberTools.AccountNumber.Contracts.CountrySpecific;
using AccountNumberTools.AccountNumber.Validation.Contracts;
using AccountNumberTools.AccountNumber.Validation.Methods;
using AccountNumberTools.Common.Internals;

namespace AccountNumberTools.AccountNumber.Validation.Internals
{
   /// <summary>
   /// class for checking belgium account numbers
   /// </summary>
   internal class BelgiumAccountNumberValidation : IAccountNumberValidation
   {
      private readonly IValidationMethod validationMethod;

      /// <summary>
      /// Initializes a new instance of the <see cref="BelgiumAccountNumberValidation"/> class.
      /// </summary>
      public BelgiumAccountNumberValidation()
         : this(new ValidationMethodMod97())
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="BelgiumAccountNumberValidation"/> class.
      /// </summary>
      /// <param name="validationMethod">The validation method which should be used.</param>
      public BelgiumAccountNumberValidation(IValidationMethod validationMethod)
      {
         if (validationMethod == null)
            throw new ArgumentNullException("validationMethod");
         this.validationMethod = validationMethod;
      }

      /// <summary>
      /// Determines whether the specified account number is valid. The account number
      /// is given as a full number including the hypothetical check digit.
      /// validation steps:
      /// * bank code can have 3 digits max
      /// * account number can have 9 digits max (including the 2 check digits)
      /// * check digits are valid
      /// </summary>
      /// <param name="accountNumber">The account number including the hypothetical check digit.</param>
      /// <param name="validationErrors">Collection is filled up with the validation error messages</param>
      /// <returns>
      ///   <c>true</c> if the specified account number is valid; otherwise, <c>false</c>.
      /// </returns>
      public bool Validate(NationalAccountNumber accountNumber, ICollection<ValidationError> validationErrors)
      {
         if (accountNumber == null)
            throw new ArgumentNullException("accountNumber", "Please provide an account number.");

         validationErrors = validationErrors ?? new List<ValidationError>();

         var belgiumAccountNumber = new BelgiumAccountNumber(accountNumber);

         ValidationMethodsTools.ValidateMember(belgiumAccountNumber.AccountNumber, 9, validationErrors, ValidationErrorCodes.AccountNumberMissing, ValidationErrorCodes.AccountNumberTooLong);
         ValidationMethodsTools.ValidateMember(belgiumAccountNumber.BankCode, 3, validationErrors, ValidationErrorCodes.BankCodeMissing, ValidationErrorCodes.BankCodeTooLong);

         if (validationErrors.Count > 0)
            return false;

         var accountNumberWithBankCode =
            String.Format("{0,3}{1,9}", belgiumAccountNumber.BankCode, belgiumAccountNumber.AccountNumber).Replace(' ', '0');

         if (!validationMethod.IsValid(accountNumberWithBankCode))
            validationErrors.AddValidationErrorMessage("The validation of the check digits failed.");

         return validationErrors.Count == 0;
      }

      /// <summary>
      /// Calculates the check digit.
      /// The account number is given without a check digit.
      /// </summary>
      /// <param name="accountNumber">The account number without a check digit.</param>
      /// <returns>
      /// The calculated check digit for the given account number
      /// </returns>
      public string CalculateCheckDigit(NationalAccountNumber accountNumber)
      {
         if (accountNumber == null)
            throw new ArgumentNullException("accountNumber", "Please provide an account number.");

         var belgiumAccountNumber = new BelgiumAccountNumber(accountNumber);

         if (String.IsNullOrEmpty(belgiumAccountNumber.AccountNumber))
            throw new ArgumentException("The account number is missing.", "accountNumber");
         if (String.IsNullOrEmpty(belgiumAccountNumber.BankCode))
            throw new ArgumentException("The bank code is missing.", "accountNumber");

         var accountNumberWithBankCode = 
            String.Format("{0,3}{1,7}", belgiumAccountNumber.BankCode, belgiumAccountNumber.AccountNumber).Replace(' ', '0');

         var digits = validationMethod.CalculateCheckDigit(accountNumberWithBankCode);

         return digits.Length < 2 ? "0" + digits : digits;
      }
   }
}
