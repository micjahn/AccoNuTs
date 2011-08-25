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
using System.Text.RegularExpressions;

using AccountNumberTools.IBAN.Contracts;
using AccountNumberTools.IBAN.Contracts.CountrySpecific;

namespace AccountNumberTools.IBAN.Internals
{
   /// <summary>
   /// a new class
   /// </summary>
   public class CountrySpecificIBANConvert : ICountrySpecificIBANConvert
   {
      private static readonly Regex regexOnlyNumbers = new Regex("[^0-9]+");
      private static readonly Regex regexOnlyIBANDigits = new Regex("[^0-9A-Z]+");

      /// <summary>
      /// converts the parts of a national account number to an IBAN.
      /// There are different parts needed in dependency of the selected country
      /// </summary>
      /// <param name="nationalAccountNumber">The national account number.</param>
      /// <returns></returns>
      virtual public string ToIBAN(NationalAccountNumber nationalAccountNumber)
      {
         throw new NotImplementedException();
      }

      /// <summary>
      /// converts an IBAN to the parts of a national account number
      /// </summary>
      /// <param name="iban">The iban.</param>
      /// <returns></returns>
      virtual public NationalAccountNumber FromIBAN(string iban)
      {
         throw new NotImplementedException();
      }

      /// <summary>
      /// removes all non-numeric digits
      /// </summary>
      /// <param name="val">The val.</param>
      /// <returns></returns>
      protected string OnlyNumbers(string val)
      {
         if (val == null)
            return null;
         return regexOnlyNumbers.Replace(val, "");
      }

      /// <summary>
      /// removes all characters which are not allowed within an IBAN
      /// </summary>
      /// <param name="val">The val.</param>
      /// <returns></returns>
      protected string OnlyIBANDigits(string val)
      {
         if (val == null)
            return null;
         return regexOnlyIBANDigits.Replace(val, "");
      }

      /// <summary>
      /// Calculates the modulo for very big numbers
      /// </summary>
      /// <param name="bban">The bban.</param>
      /// <returns></returns>
      protected int CalculateModulo(string bban)
      {
         var remainer = 0;
         while (bban.Length >= 7)
         {
            remainer = int.Parse(remainer + bban.Substring(0, 7)) % 97;
            bban = bban.Substring(7);
         }
         return int.Parse(remainer + bban) % 97;
      }
   }
}
