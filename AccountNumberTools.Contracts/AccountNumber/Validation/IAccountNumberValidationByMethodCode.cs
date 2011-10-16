//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

namespace AccountNumberTools.AccountNumber.Validation.Contracts
{
   /// <summary>
   /// Primary interface to check for formal valid account numbers with the specification of a check digit calculation method
   /// </summary>
   public interface IAccountNumberValidationByMethodCode
   {
      /// <summary>
      /// Determines whether the specified account number is valid. The account number
      /// is given as a full number including the hypothetical check digit.
      /// </summary>
      /// <param name="accountNumber">The account number including the hypothetical check digit.</param>
      /// <param name="validationMethodCode">The code for a registered validation method</param>
      /// <returns>
      ///   <c>true</c> if the specified account number is valid; otherwise, <c>false</c>.
      /// </returns>
      bool IsValid(string accountNumber, string validationMethodCode);

      /// <summary>
      /// Calculates the check digit. The given bank code will be
      /// mapped to an registered method which calculates the check digit.
      /// The account number is given without a check digit.
      /// </summary>
      /// <param name="accountNumber">The account number without a check digit.</param>
      /// <param name="validationMethodCode">The code for a registered validation method</param>
      /// <returns>The calculated check digit for the given account number</returns>
      string CalculateCheckDigit(string accountNumber, string validationMethodCode);
   }
}
