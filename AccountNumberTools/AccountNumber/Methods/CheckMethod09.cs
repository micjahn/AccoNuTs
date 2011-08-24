//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

using AccountNumberTools.Common.Contracts;

namespace AccountNumberTools.AccountNumber.Methods
{
   /// <summary>
   /// check method which does nothing. IsValid is always true, CalculateCheckDigit gives string.empty
   /// </summary>
   internal class CheckMethod09 : ICheckMethod
   {
      /// <summary>
      /// Gives always true
      /// </summary>
      /// <param name="accountNumber">The account number.</param>
      /// <returns>true</returns>
      public bool IsValid(string accountNumber)
      {
         return true;
      }

      /// <summary>
      /// Gives always String.Empty
      /// </summary>
      /// <param name="accountNumber">The account number.</param>
      /// <returns>String.Empty</returns>
      public string CalculateCheckDigit(string accountNumber)
      {
         return string.Empty;
      }
   }
}
