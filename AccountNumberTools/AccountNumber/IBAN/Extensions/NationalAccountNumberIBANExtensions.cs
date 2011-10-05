//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

using AccountNumberTools.AccountNumber.Contracts;
using AccountNumberTools.AccountNumber.IBAN.Contracts;

namespace AccountNumberTools.AccountNumber.IBAN.Extensions
{
   /// <summary>
   /// 
   /// </summary>
   public static class NationalAccountNumberIBANExtensions
   {
      private static readonly IIBANConvert conversion;

      static NationalAccountNumberIBANExtensions()
      {
         conversion = new IBANConvert();
      }

      /// <summary>
      /// Converts a national account number to an IBAN
      /// </summary>
      /// <param name="nationalAccountNumber">The national account number.</param>
      /// <returns></returns>
      public static string ToIBAN(this NationalAccountNumber nationalAccountNumber)
      {
         return conversion.ToIBAN(nationalAccountNumber);
      }

      /// <summary>
      /// Converts a string, which represents an IBAN to an national account number
      /// </summary>
      /// <param name="iban">The iban.</param>
      /// <returns></returns>
      public static NationalAccountNumber FromIBAN(this string iban)
      {
         return conversion.FromIBAN(iban);
      }
   }
}
