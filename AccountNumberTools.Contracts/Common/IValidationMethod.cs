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
   /// Interface for the implementation of a specific check method
   /// </summary>
   public interface IValidationMethod
   {
      /// <summary>
      /// Determines whether the specified number is formal valid. The implementation should make
      /// the necessary steps to ensure that the number meets the requirements.
      /// </summary>
      /// <param name="number">The number which should be checked.</param>
      /// <returns>
      ///   <c>true</c> if the specified number is formal valid; otherwise, <c>false</c>.
      /// </returns>
      bool IsValid(string number);

      /// <summary>
      /// Calculates the check digit for the given number.
      /// </summary>
      /// <param name="number">The number.</param>
      /// <returns>the calculated check digit(s)</returns>
      string CalculateCheckDigit(string number);
   }
}
