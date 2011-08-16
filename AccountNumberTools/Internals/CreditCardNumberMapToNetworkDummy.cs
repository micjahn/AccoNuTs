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

namespace AccountNumberTools.Internals
{
   /// <summary>
   /// A dummy implementation of ICreditCardNumberMapToNetwork which is used if no other one is given.
   /// </summary>
   internal class CreditCardNumberMapToNetworkDummy : ICreditCardNumberMapToNetwork
   {
      private static ICreditCardNumberMapToNetwork instance;

      internal static ICreditCardNumberMapToNetwork Instance
      { 
         get
         {
            // no lock, it doesn't matter
            return instance ?? (instance = new CreditCardNumberMapToNetworkDummy());
         }
      }
      
      /// <summary>
      /// This is only a dummy implementation which is used if no other one is given.
      /// </summary>
      /// <param name="creditCardNumber">The credit card number.</param>
      /// <returns></returns>
      /// <exception cref="InvalidOperationException">It is thrown every time the method is called</exception>
      public string Resolve(string creditCardNumber)
      {
         throw new InvalidOperationException("Please specify a correct instance of ICreditCardNumberMapToNetwork before you use this function.");
      }
   }
}
