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
   /// class for checking norway account numbers
   /// </summary>
   internal class NorwayAccountNumberValidation : IAccountNumberValidation
   {
      private readonly IValidationMethod validationMethod;

      /// <summary>
      /// Initializes a new instance of the <see cref="NorwayAccountNumberValidation"/> class.
      /// </summary>
      public NorwayAccountNumberValidation()
         : this(new ValidationMethodMod11Norway())
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="NorwayAccountNumberValidation"/> class.
      /// </summary>
      /// <param name="validationMethod">The validation method which should be used.</param>
      public NorwayAccountNumberValidation(IValidationMethod validationMethod)
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
      /// * account number can have 7 digits max (including 1 check digit)
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

         var norwayAccountNumber = new NorwayAccountNumber(accountNumber);

         if (String.IsNullOrEmpty(norwayAccountNumber.AccountNumber))
            throw new ArgumentException("The account number is missing.", "accountNumber");
         if (String.IsNullOrEmpty(norwayAccountNumber.BankCode))
            throw new ArgumentException("The bank code is missing.", "accountNumber");

         if (norwayAccountNumber.BankCode.Length > 4)
            return false;
         if (norwayAccountNumber.AccountNumber.Length > 7)
            return false;

         var bankCodeWithAccountNumber =
            String.Format("{0,4}{1,7}", norwayAccountNumber.BankCode, norwayAccountNumber.AccountNumber).Replace(' ', '0');

         return validationMethod.IsValid(bankCodeWithAccountNumber);
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

         var norwayAccountNumber = new NorwayAccountNumber(accountNumber);

         if (String.IsNullOrEmpty(norwayAccountNumber.BankCode))
            throw new ArgumentException("The bank code is missing.", "accountNumber");
         if (String.IsNullOrEmpty(norwayAccountNumber.AccountNumber))
            throw new ArgumentException("The account number is missing.", "accountNumber");

         var bankCodeWithBranch =
            String.Format("{0,4}{1,6}", norwayAccountNumber.BankCode, norwayAccountNumber.AccountNumber).Replace(' ', '0');

         return validationMethod.CalculateCheckDigit(bankCodeWithBranch);
      }
   }
}
