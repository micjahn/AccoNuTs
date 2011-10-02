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
   /// Interface to resolve the validation method code for a given bank code
   /// </summary>
   public interface IBankCodeMapToValidationMethodCode
   {
      /// <summary>
      /// Resolves the validation method code for a given bank code.
      /// </summary>
      /// <param name="bankCode">The bank code.</param>
      /// <returns></returns>
      string Resolve(string bankCode);
   }
}
