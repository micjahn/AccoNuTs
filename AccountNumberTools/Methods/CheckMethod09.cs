//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

using AccountNumberTools.Contracts;

namespace AccountNumberTools.Methods
{
   /// <summary>
   /// a new class
   /// </summary>
   public class CheckMethod09 : ICheckMethod
   {
      /// <summary>
      /// Determines whether the specified account number is valid.
      /// </summary>
      /// <param name="accountNumber">The account number.</param>
      /// <returns>
      ///   <c>true</c> if the specified account number is valid; otherwise, <c>false</c>.
      /// </returns>
      public bool IsValid(string accountNumber)
      {
         return true;
      }

      /// <summary>
      /// Calculates the check digit.
      /// </summary>
      /// <param name="accountNumber">The account number.</param>
      /// <returns></returns>
      public string CalculateCheckDigit(string accountNumber)
      {
         return string.Empty;
      }
   }
}
