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
using AccountNumberTools.AccountNumber.Contracts;
using AccountNumberTools.AccountNumber.Contracts.CountrySpecific;
using AccountNumberTools.AccountNumber.Validation.Contracts;
using AccountNumberTools.AccountNumber.Validation.Methods;

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
      /// <returns>
      ///   <c>true</c> if the specified account number is valid; otherwise, <c>false</c>.
      /// </returns>
      public bool IsValid(NationalAccountNumber accountNumber)
      {
         if (accountNumber == null)
            throw new ArgumentNullException("accountNumber", "Please provide an account number.");

         var albaniaAccountNumber = new AlbaniaAccountNumber(accountNumber);

         if (String.IsNullOrEmpty(albaniaAccountNumber.AccountNumber))
            throw new ArgumentException("The account number is missing.", "accountNumber");
         if (String.IsNullOrEmpty(albaniaAccountNumber.BankCode))
            throw new ArgumentException("The bank code is missing.", "accountNumber");
         if (String.IsNullOrEmpty(albaniaAccountNumber.Branch))
            throw new ArgumentException("The branch code is missing.", "accountNumber");

         if (albaniaAccountNumber.BankCode.Length > 3)
            return false;
         if (albaniaAccountNumber.Branch.Length > 5)
            return false;
         if (albaniaAccountNumber.AccountNumber.Length > 16)
            return false;

         var bankCodeWithBranch =
            String.Format("{0,3}{1,5}", albaniaAccountNumber.BankCode, albaniaAccountNumber.Branch).Replace(' ', '0');

         return validationMethod.IsValid(bankCodeWithBranch);
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
