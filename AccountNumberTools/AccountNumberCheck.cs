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

using AccountNumberTools.Contracts;
using AccountNumberTools.Internals;

namespace AccountNumberTools
{
   /// <summary>
   /// Main class for checking account numbers
   /// </summary>
   public class AccountNumberCheck : IAccountNumberCheckWithBankCode, IAccountNumberCheckWithMethodCode
   {
      private IBankCodeMapToCheckMethodCode bankCodeMappingMethod;

      /// <summary>
      /// Gets or sets the bank code mapping method.
      /// </summary>
      /// <value>
      /// The bank code mapping method.
      /// </value>
      public IBankCodeMapToCheckMethodCode BankCodeMappingMethod
      {
         get
         {
            return bankCodeMappingMethod ?? BankCodeMapToCheckMethodDummy.Instance;
         }
         set
         {
            bankCodeMappingMethod = value;
         }
      }

      /// <summary>
      /// Gets or sets the check method code map to method.
      /// </summary>
      /// <value>
      /// The check method code map to method.
      /// </value>
      public ICheckMethodCodeMapToMethod CheckMethodCodeMapToMethod { get; set; }

      /// <summary>
      /// Initializes a new instance of the <see cref="AccountNumberCheck"/> class.
      /// </summary>
      public AccountNumberCheck()
      {
         CheckMethodCodeMapToMethod = new CheckMethodCodeMapToMethodFactory();
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="AccountNumberCheck"/> class.
      /// </summary>
      /// <param name="bankCodeMappingMethod">The bank code mapping method.</param>
      public AccountNumberCheck(IBankCodeMapToCheckMethodCode bankCodeMappingMethod)
      {
         BankCodeMappingMethod = bankCodeMappingMethod;
         CheckMethodCodeMapToMethod = new CheckMethodCodeMapToMethodFactory();
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="AccountNumberCheck"/> class.
      /// </summary>
      /// <param name="checkMethodCodeMapToMethod">The check method code map to method.</param>
      public AccountNumberCheck(ICheckMethodCodeMapToMethod checkMethodCodeMapToMethod)
      {
         CheckMethodCodeMapToMethod = checkMethodCodeMapToMethod;
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="AccountNumberCheck"/> class.
      /// </summary>
      /// <param name="bankCodeMappingMethod">The bank code mapping method.</param>
      /// <param name="checkMethodCodeMapToMethod">The check method code map to method.</param>
      public AccountNumberCheck(IBankCodeMapToCheckMethodCode bankCodeMappingMethod, ICheckMethodCodeMapToMethod checkMethodCodeMapToMethod)
      {
         BankCodeMappingMethod = bankCodeMappingMethod;
         CheckMethodCodeMapToMethod = checkMethodCodeMapToMethod;
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
      bool IAccountNumberCheckWithMethodCode.IsValid(string accountNumber, string checkMethodCode)
      {
         if (string.IsNullOrEmpty(checkMethodCode))
            throw new ArgumentException("Please provide the code for a check method.", "checkMethodCode");
         if (string.IsNullOrEmpty(accountNumber))
            throw new ArgumentException("Please provide the account number.", "accountNumber");

         if (CheckMethodCodeMapToMethod == null)
            throw new InvalidOperationException("Please provide an instanz for the mapping between a check method code and a check method.");

         var checkMethod = CheckMethodCodeMapToMethod.Resolve(checkMethodCode);
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
      string IAccountNumberCheckWithMethodCode.CalculateCheckDigit(string accountNumber, string checkMethodCode)
      {
         if (string.IsNullOrEmpty(checkMethodCode))
            throw new ArgumentException("Please provide the code for a check method.", "checkMethodCode");
         if (string.IsNullOrEmpty(accountNumber))
            throw new ArgumentException("Please provide the account number.", "accountNumber");

         if (CheckMethodCodeMapToMethod == null)
            throw new InvalidOperationException("Please provide an instanz for the mapping between a check method code and a check method.");

         var checkMethod = CheckMethodCodeMapToMethod.Resolve(checkMethodCode);
         if (checkMethod == null)
            throw new InvalidOperationException(String.Format("The check method code {0} could not be mapped to a check method implementation.", checkMethodCode));

         return checkMethod.CalculateCheckDigit(accountNumber);
      }

      /// <summary>
      /// Determines whether the specified account number is valid. The given bank code will be
      /// mapped to an registered method which calculates the check digit. The account number
      /// is given as a full number including the hypothetical check digit.
      /// </summary>
      /// <param name="accountNumber">The account number including the hypothetical check digit.</param>
      /// <param name="bankCode">The bank code.</param>
      /// <returns>
      ///   <c>true</c> if the specified account number is valid; otherwise, <c>false</c>.
      /// </returns>
      bool IAccountNumberCheckWithBankCode.IsValid(string accountNumber, string bankCode)
      {
         if (string.IsNullOrEmpty(bankCode))
            throw new ArgumentException("Please provide bank code.", "bankCode");
         if (string.IsNullOrEmpty(accountNumber))
            throw new ArgumentException("Please provide the account number.", "accountNumber"); 
         
         return ((IAccountNumberCheckWithMethodCode)this).IsValid(accountNumber, BankCodeMappingMethod.Resolve(bankCode));
      }

      /// <summary>
      /// Calculates the check digit. The given bank code will be
      /// mapped to an registered method which calculates the check digit.
      /// The account number is given without a check digit.
      /// </summary>
      /// <param name="accountNumber">The account number without a check digit.</param>
      /// <param name="bankCode">The bank code.</param>
      /// <returns>
      /// The calculated check digit for the given account number
      /// </returns>
      string IAccountNumberCheckWithBankCode.CalculateCheckDigit(string accountNumber, string bankCode)
      {
         if (string.IsNullOrEmpty(bankCode))
            throw new ArgumentException("Please provide bank code.", "bankCode");
         if (string.IsNullOrEmpty(accountNumber))
            throw new ArgumentException("Please provide the account number.", "accountNumber");
         
         return ((IAccountNumberCheckWithMethodCode)this).CalculateCheckDigit(accountNumber, BankCodeMappingMethod.Resolve(bankCode));
      }
   }
}
