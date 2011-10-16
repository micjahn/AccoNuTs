//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

using System.Collections.Generic;

using AccountNumberTools.AccountNumber.Contracts;

namespace AccountNumberTools.AccountNumber.Validation.Contracts
{
   /// <summary>
   /// Primary interface to check for formal valid account numbers with the specification of a bank code
   /// </summary>
   public interface IAccountNumberValidation
   {
      /// <summary>
      /// Determines whether the specified account number is valid. The given bank code will be
      /// mapped to an registered method which calculates the check digit. The account number
      /// is given as a full number including the hypothetical check digit.
      /// </summary>
      /// <param name="accountNumber">The account number including the hypothetical check digit.</param>
      /// <param name="validationErrors">Collection is filled up with the validation error messages</param>
      /// <returns>
      ///   <c>true</c> if the specified account number is valid; otherwise, <c>false</c>.
      /// </returns>
      bool Validate(NationalAccountNumber accountNumber, ICollection<ValidationError> validationErrors);

      /// <summary>
      /// Calculates the check digit. The given bank code will be
      /// mapped to an registered method which calculates the check digit.
      /// The account number is given without a check digit.
      /// </summary>
      /// <param name="accountNumber">The account number without a check digit.</param>
      /// <returns>The calculated check digit for the given account number</returns>
      string CalculateCheckDigit(NationalAccountNumber accountNumber);
   }
}
