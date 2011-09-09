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
   /// interface defines a method to resolve credit card network identifiers for given credit card numbers
   /// </summary>
   public interface ICreditCardNumberMapToNetwork
   {
      /// <summary>
      /// Resolves the specified credit card network.
      /// </summary>
      /// <param name="creditCardNumber">The credit card number.</param>
      /// <returns>the identifier for the credit card network</returns>
      string Resolve(string creditCardNumber);
   }
}
