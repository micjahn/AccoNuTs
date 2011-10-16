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
   /// class for checking albania account numbers
   /// </summary>
   internal class AlbaniaAccountNumberValidation : IAccountNumberValidation
   {
      private readonly IValidationMethod validationMethod;

      /// <summary>
      /// Initializes a new instance of the <see cref="AlbaniaAccountNumberValidation"/> class.
      /// </summary>
      public AlbaniaAccountNumberValidation()
         : this(new ValidationMethodWeightedMod10())
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="AlbaniaAccountNumberValidation"/> class.
      /// </summary>
      /// <param name="validationMethod">The validation method which should be used.</param>
      public AlbaniaAccountNumberValidation(IValidationMethod validationMethod)
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
      /// * branch code can have 5 digits max (including 1 check digit)
      /// * account number can have 16 digits max
      /// * check digit is valid
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

         var albaniaAccountNumber = new AlbaniaAccountNumber(accountNumber);

         ValidationMethodsTools.ValidateMember(albaniaAccountNumber.AccountNumber, 16, validationErrors, ValidationErrorCodes.AccountNumberMissing, ValidationErrorCodes.AccountNumberTooLong);
         ValidationMethodsTools.ValidateMember(albaniaAccountNumber.BankCode, 3, validationErrors, ValidationErrorCodes.BankCodeMissing, ValidationErrorCodes.BankCodeTooLong);
         ValidationMethodsTools.ValidateMember(albaniaAccountNumber.Branch, 5, validationErrors, ValidationErrorCodes.BranchCodeMissing, ValidationErrorCodes.BranchCodeTooLong);

         if (validationErrors.Count > 0)
            return false;

         var bankCodeWithBranch =
            String.Format("{0,3}{1,5}", albaniaAccountNumber.BankCode, albaniaAccountNumber.Branch).Replace(' ', '0');

         if (!validationMethod.IsValid(bankCodeWithBranch))
            validationErrors.AddValidationErrorMessage("The validation of the check digit failed.");

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

         var albaniaAccountNumber = new AlbaniaAccountNumber(accountNumber);

         if (String.IsNullOrEmpty(albaniaAccountNumber.BankCode))
            throw new ArgumentException("The bank code is missing.", "accountNumber");
         if (String.IsNullOrEmpty(albaniaAccountNumber.Branch))
            throw new ArgumentException("The branch code is missing.", "accountNumber");

         var bankCodeWithBranch =
            String.Format("{0,3}{1,4}", albaniaAccountNumber.BankCode, albaniaAccountNumber.Branch).Replace(' ', '0');

         return validationMethod.CalculateCheckDigit(bankCodeWithBranch);
      }
   }
}
