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
   /// Interface for the mapping between a check method code and a check method implementation
   /// </summary>
   public interface ICheckMethodCodeMapToMethod
   {
      /// <summary>
      /// Resolves the specified check method by code.
      /// </summary>
      /// <param name="checkMethodCode">The check method code.</param>
      /// <returns></returns>
      ICheckMethod Resolve(string checkMethodCode);
   }
}
