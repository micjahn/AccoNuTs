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
using AccountNumberTools.Common.Internals;

namespace AccountNumberTools.AccountNumber.Validation.Internals
{
   /// <summary>
   /// class for checking portugal account numbers
   /// </summary>
   internal class PortugalAccountNumberValidation : IAccountNumberValidation
   {
      private readonly IValidationMethod validationMethod;

      /// <summary>
      /// Initializes a new instance of the <see cref="PortugalAccountNumberValidation"/> class.
      /// </summary>
      public PortugalAccountNumberValidation()
         : this(new ValidationMethodMod9710())
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="PortugalAccountNumberValidation"/> class.
      /// </summary>
      /// <param name="validationMethod">The validation method which should be used.</param>
      public PortugalAccountNumberValidation(IValidationMethod validationMethod)
      {
         if (validationMethod == null)
            throw new ArgumentNullException("validationMethod");
         this.validationMethod = validationMethod;
      }

      /// <summary>
      /// Determines whether the specified account number is valid. The account number
      /// is given as a full number including the hypothetical check digit.
      /// validation steps:
      /// * bank code can have 4 digits max
      /// * branch code can have 4 digits max
      /// * account number can have 13 digits max (including 2 check digits)
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

         var portugalAccountNumber = new PortugalAccountNumber(accountNumber);

         if (String.IsNullOrEmpty(portugalAccountNumber.BankCode))
            throw new ArgumentException("The bank code is missing.", "accountNumber");
         if (String.IsNullOrEmpty(portugalAccountNumber.Branch))
            throw new ArgumentException("The branch code is missing.", "accountNumber");
         if (String.IsNullOrEmpty(portugalAccountNumber.AccountNumber))
            throw new ArgumentException("The account number is missing.", "accountNumber");

         if (portugalAccountNumber.BankCode.Length > 4)
            return false;
         if (portugalAccountNumber.Branch.Length > 4)
            return false;
         if (portugalAccountNumber.AccountNumber.Length > 13)
            return false;

         var fullAccountNumber =
            String.Format("{0,4}{1,4}{2,13}", portugalAccountNumber.BankCode, portugalAccountNumber.Branch, portugalAccountNumber.AccountNumber).Replace(' ', '0');

         return validationMethod.IsValid(fullAccountNumber);
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

         var portugalAccountNumber = new PortugalAccountNumber(accountNumber);

         if (String.IsNullOrEmpty(portugalAccountNumber.BankCode))
            throw new ArgumentException("The bank code is missing.", "accountNumber");
         if (String.IsNullOrEmpty(portugalAccountNumber.Branch))
            throw new ArgumentException("The branch code is missing.", "accountNumber");
         if (String.IsNullOrEmpty(portugalAccountNumber.AccountNumber))
            throw new ArgumentException("The account number is missing.", "accountNumber");

         var fullAccountNumber =
            String.Format("{0,4}{1,4}{2,11}", portugalAccountNumber.BankCode, portugalAccountNumber.Branch, portugalAccountNumber.AccountNumber).Replace(' ', '0');

         return validationMethod.CalculateCheckDigit(fullAccountNumber);
      }
   }
}
