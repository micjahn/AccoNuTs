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
   /// class for checking german account numbers
   /// </summary>
   internal class BelgiumAccountNumberValidation : IAccountNumberValidation
   {
      private readonly IValidationMethod mod97ValidationMethod;

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
      /// <param name="mod97ValidationMethod">The bank code mapping method.</param>
      public BelgiumAccountNumberValidation(IValidationMethod mod97ValidationMethod)
      {
         if (mod97ValidationMethod == null)
            throw new ArgumentNullException("mod97ValidationMethod");
         this.mod97ValidationMethod = mod97ValidationMethod;
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
      /// <returns>
      ///   <c>true</c> if the specified account number is valid; otherwise, <c>false</c>.
      /// </returns>
      public bool IsValid(NationalAccountNumber accountNumber)
      {
         if (accountNumber == null)
            throw new ArgumentNullException("accountNumber", "Please provide an account number.");

         var belgiumAccountNumber = new BelgiumAccountNumber(accountNumber);

         if (String.IsNullOrEmpty(belgiumAccountNumber.AccountNumber))
            throw new ArgumentException("The account number is missing.", "accountNumber");
         if (String.IsNullOrEmpty(belgiumAccountNumber.BankCode))
            throw new ArgumentException("The bank code is missing.", "accountNumber");

         if (belgiumAccountNumber.BankCode.Length > 3)
            return false;
         if (belgiumAccountNumber.AccountNumber.Length > 9)
            return false;

         var accountNumberWithBankCode =
            String.Format("{0,3}{1,9}", belgiumAccountNumber.BankCode, belgiumAccountNumber.AccountNumber).Replace(' ', '0');

         return mod97ValidationMethod.IsValid(accountNumberWithBankCode);
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

         var digits = mod97ValidationMethod.CalculateCheckDigit(accountNumberWithBankCode);

         return digits.Length < 2 ? "0" + digits : digits;
      }
   }
}
