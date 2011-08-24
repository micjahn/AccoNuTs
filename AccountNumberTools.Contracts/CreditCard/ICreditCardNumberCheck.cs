//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

namespace AccountNumberTools.CreditCard.Contracts
{
   /// <summary>
   /// Interface for the implementation of a specific check method
   /// </summary>
   public interface ICreditCardNumberCheck
   {
      /// <summary>
      /// Determines whether the specified credit card number is formal valid.
      /// </summary>
      /// <param name="creditCardNumber">The credit card number.</param>
      /// <param name="creditCardNetwork">The credit card network.</param>
      /// <returns>
      ///   <c>true</c> if the specified credit card number is formal valid; otherwise, <c>false</c>.
      /// </returns>
      bool IsValid(string creditCardNumber, string creditCardNetwork);

      /// <summary>
      /// Calculates the check digit for the given credit card number.
      /// </summary>
      /// <param name="creditCardNumber">The credit card number.</param>
      /// <param name="creditCardNetwork">The credit card network.</param>
      /// <returns></returns>
      string CalculateCheckDigit(string creditCardNumber, string creditCardNetwork);
   }
}
