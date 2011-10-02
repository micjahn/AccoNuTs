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

using AccountNumberTools.AccountNumber.Validation.Contracts;

namespace AccountNumberTools.AccountNumber.Internals
{
   /// <summary>
   /// A dummy implementation of IBankCodeMapToCheckMethod which is used if no other one is given.
   /// </summary>
   internal class BankCodeMapToCheckMethodDummy : IBankCodeMapToCheckMethodCode
   {
      private static IBankCodeMapToCheckMethodCode instance;

      internal static IBankCodeMapToCheckMethodCode Instance
      { 
         get
         {
            // no lock, it doesn't matter
            return instance ?? (instance = new BankCodeMapToCheckMethodDummy());
         }
      }
      
      /// <summary>
      /// This is only a dummy implementation which is used if no other one is given.
      /// </summary>
      /// <param name="bankCode">The bank code.</param>
      /// <returns></returns>
      /// <exception cref="InvalidOperationException">It is thrown every time the method is called</exception>
      public string Resolve(string bankCode)
      {
         throw new InvalidOperationException("Please specify a correct instance of IBankCodeMapToCheckMethod before you use this function.");
      }
   }
}
