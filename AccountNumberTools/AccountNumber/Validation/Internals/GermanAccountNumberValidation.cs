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
using AccountNumberTools.AccountNumber.Internals;
using AccountNumberTools.AccountNumber.Validation.Contracts;

namespace AccountNumberTools.AccountNumber.Validation.Internals
{
   /// <summary>
   /// class for checking german account numbers
   /// </summary>
   internal class GermanAccountNumberValidation : IAccountNumberValidation
   {
      private readonly IAccountNumberValidationByMethodCode accountNumberValidationByMethodCode;
      private IBankCodeMapToValidationMethodCode bankCodeMappingMethod;

      /// <summary>
      /// Gets or sets the bank code mapping method.
      /// </summary>
      /// <value>
      /// The bank code mapping method.
      /// </value>
      public IBankCodeMapToValidationMethodCode BankCodeMappingMethod
      {
         get
         {
            return bankCodeMappingMethod ?? BankCodeMapToValidationMethodDummy.Instance;
         }
         set
         {
            bankCodeMappingMethod = value;
         }
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="GermanAccountNumberValidation"/> class.
      /// </summary>
      public GermanAccountNumberValidation()
         : this(new BankCodeMapToValidationMethodCodeByBankCodeFile(), new AccountNumberValidationByMethodCode())
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="GermanAccountNumberValidation"/> class.
      /// </summary>
      /// <param name="bankCodeMappingMethod">The bank code mapping method.</param>
      public GermanAccountNumberValidation(IBankCodeMapToValidationMethodCode bankCodeMappingMethod)
         : this(bankCodeMappingMethod, new AccountNumberValidationByMethodCode())
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="GermanAccountNumberValidation"/> class.
      /// </summary>
      /// <param name="accountNumberValidationByMethodCode">The check method code map to method.</param>
      public GermanAccountNumberValidation(IAccountNumberValidationByMethodCode accountNumberValidationByMethodCode)
         : this(new BankCodeMapToValidationMethodCodeByBankCodeFile(), accountNumberValidationByMethodCode)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="GermanAccountNumberValidation"/> class.
      /// </summary>
      /// <param name="bankCodeMappingMethod">The bank code mapping method.</param>
      /// <param name="accountNumberValidationByMethodCode">The check method code map to method.</param>
      public GermanAccountNumberValidation(IBankCodeMapToValidationMethodCode bankCodeMappingMethod, IAccountNumberValidationByMethodCode accountNumberValidationByMethodCode)
      {
         BankCodeMappingMethod = bankCodeMappingMethod;
         this.accountNumberValidationByMethodCode = accountNumberValidationByMethodCode;
      }

      /// <summary>
      /// Determines whether the specified account number is valid. The given bank code will be
      /// mapped to an registered method which calculates the check digit. The account number
      /// is given as a full number including the hypothetical check digit.
      /// </summary>
      /// <param name="accountNumber">The account number including the hypothetical check digit.</param>
      /// <returns>
      ///   <c>true</c> if the specified account number is valid; otherwise, <c>false</c>.
      /// </returns>
      public bool IsValid(NationalAccountNumber accountNumber)
      {
         if (accountNumber == null)
            throw new ArgumentNullException("accountNumber", "Please provide an account number.");

         var germanAccountNumber = new GermanyAccountNumber(accountNumber);

         var checkMethodCode = BankCodeMappingMethod.Resolve(germanAccountNumber.BankCode);
         if (string.IsNullOrEmpty(checkMethodCode))
            throw new ArgumentException(String.Format("Can't resolve the check method for the given bank code {0}.", germanAccountNumber.BankCode), "accountNumber");

         return accountNumberValidationByMethodCode.IsValid(germanAccountNumber.AccountNumber, checkMethodCode);
      }

      /// <summary>
      /// Calculates the check digit. The given bank code will be
      /// mapped to an registered method which calculates the check digit.
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

         var germanAccountNumber = new GermanyAccountNumber(accountNumber);

         var checkMethodCode = BankCodeMappingMethod.Resolve(germanAccountNumber.BankCode);
         if (string.IsNullOrEmpty(checkMethodCode))
            throw new ArgumentException(String.Format("Can't resolve the check method for the given bank code {0}.", germanAccountNumber.BankCode), "accountNumber");

         return accountNumberValidationByMethodCode.CalculateCheckDigit(germanAccountNumber.AccountNumber, checkMethodCode);
      }
   }
}
