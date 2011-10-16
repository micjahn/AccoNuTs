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
   /// enumeration of possible validation errors
   /// </summary>
   public enum ValidationErrorCodes
   {
      /// <summary>validation error not listed in the enumeration, take a look at the message</summary>
      GenericMessageBasedError = 0,
      /// <summary></summary>
      AccountNumberMissing,
      /// <summary></summary>
      AccountNumberTooLong,
      /// <summary></summary>
      BankCodeMissing,
      /// <summary></summary>
      BankCodeTooLong,
      /// <summary></summary>
      BranchCodeMissing,
      /// <summary></summary>
      BranchCodeTooLong
   }
}
