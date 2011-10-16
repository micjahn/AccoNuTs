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
using System.Globalization;

using AccountNumberTools.Contracts.Properties;

namespace AccountNumberTools.AccountNumber.Validation.Contracts
{
   /// <summary>
   /// represents a single validation error message
   /// </summary>
   public class ValidationError
   {
      private string message;

      public static Func<ValidationErrorCodes, string> ExternalRetrieveMessageTextHandler;

      /// <summary>
      /// Gets the validation error code.
      /// </summary>
      public ValidationErrorCodes ValidationErrorCode { get; private set; }

      /// <summary>
      /// Gets the message.
      /// </summary>
      public string Message
      {
         get
         {
            if (String.IsNullOrEmpty(message) && 
                ValidationErrorCode != ValidationErrorCodes.GenericMessageBasedError)
               message = RetrieveMessageText(ValidationErrorCode);
            return message;
         }
         private set
         {
            message = value;
         }
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="ValidationError"/> class.
      /// </summary>
      /// <param name="validationErrorCode">The validation error code.</param>
      public ValidationError(ValidationErrorCodes validationErrorCode)
      {
         ValidationErrorCode = validationErrorCode;
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="ValidationError"/> class.
      /// </summary>
      /// <param name="message">The message.</param>
      public ValidationError(string message)
      {
         ValidationErrorCode = ValidationErrorCodes.GenericMessageBasedError;
         Message = message;
      }

      private static string RetrieveMessageText(ValidationErrorCodes validationErrorCode)
      {
         if (ExternalRetrieveMessageTextHandler != null)
         {
            string result = ExternalRetrieveMessageTextHandler(validationErrorCode);
            if (!String.IsNullOrEmpty(result))
               return result;
         }

         return Resources.ResourceManager.GetString(validationErrorCode.ToString(), CultureInfo.CurrentUICulture);
      }
   }
}
