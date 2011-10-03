//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

using AccountNumberTools.AccountNumber.Validation.Contracts;

namespace AccountNumberTools.CreditCard.Contracts
{
   /// <summary>
   /// interface to resolve the check method code for a given credit card network code
   /// </summary>
   public interface ICreditCardNetworkMapToMethod
   {
      /// <summary>
      /// Resolves the specified check method for a credit card network.
      /// </summary>
      /// <param name="creditCardNetwork">The credit card network code.</param>
      /// <returns></returns>
      IValidationMethod Resolve(string creditCardNetwork);
   }
}
