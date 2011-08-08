//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

namespace AccountNumberTools.Contracts
{
   /// <summary>
   /// Interface for the implementation of a specific check method
   /// </summary>
   public interface ICheckMethod
   {
      /// <summary>
      /// Determines whether the specified account number is formal valid.
      /// </summary>
      /// <param name="accountNumber">The account number.</param>
      /// <returns>
      ///   <c>true</c> if the specified account number is formal valid; otherwise, <c>false</c>.
      /// </returns>
      bool IsValid(string accountNumber);

      /// <summary>
      /// Calculates the check digit for the given account number.
      /// </summary>
      /// <param name="accountNumber">The account number.</param>
      /// <returns></returns>
      string CalculateCheckDigit(string accountNumber);
   }
}
