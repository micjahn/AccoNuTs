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

namespace AccountNumberTools.AccountNumber.Validation.Contracts
{
   /// <summary>
   /// Interface for the mapping between a validation method code and a validation method implementation
   /// </summary>
   public interface IValidationMethodCodeMapToMethod
   {
      /// <summary>
      /// Resolves the specified validation method by code.
      /// </summary>
      /// <param name="validationMethodCode">The validation method code.</param>
      /// <returns></returns>
      IValidationMethod Resolve(string validationMethodCode);
   }
}
