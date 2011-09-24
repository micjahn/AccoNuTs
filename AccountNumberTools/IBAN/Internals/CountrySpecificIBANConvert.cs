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
using System.Collections.Generic;
using System.Text.RegularExpressions;

using AccountNumberTools.IBAN.Contracts;
using AccountNumberTools.IBAN.Contracts.CountrySpecific;
using System.Text;

namespace AccountNumberTools.IBAN.Internals
{
   /// <summary>
   /// base class for some specialized IBAN converter classes with some common methods and properties
   /// </summary>
   public abstract class CountrySpecificIBANConvert : ICountrySpecificIBANConvert
   {
      /*
       * A - 10
       * B - 11
       * C - 12
       * D - 13
       * E - 14
       * F - 15
       * G - 16
       * H - 17
       * I - 18
       * J - 19
       * K - 20
       * L - 21
       * M - 22
       * N - 23
       * O - 24
       * P - 25
       * Q - 26
       * R - 27
       * S - 28
       * T - 29
       * U - 30
       * V - 31
       * W - 32
       * X - 33
       * Y - 34
       * Z - 35
       */
      private static readonly IDictionary<char, int> characterMap;
      private static readonly Regex regexOnlyAllowedCharacters = new Regex("[^0-9a-zA-Z]+");
      private static readonly Regex regexOnlyIBANDigits = new Regex("[^0-9A-Z]+");

      /// <summary>
      /// Returns the 2-char country prefix for the IBAN
      /// </summary>
      protected abstract string IBANPrefix { get; }

      /// <summary>
      /// Gets the BBAN format string for calculating the check digit.
      /// Should be of the format {0:0...}{1:0...}131400 for DE-IBAN.
      /// Replace 1314 with the country specific numbers.
      /// 0 - replaced with the bank code
      /// 1 - replaced with the account number
      /// </summary>
      protected abstract string BBANFormatString { get; }

      /// <summary>
      /// Gets the IBAN format string.
      /// Should be of the format {0}{1:00}{2:0...}{3:0...}
      /// 0 - replaced with the IBAN country prefix
      /// 1 - replaced with the check digit
      /// 2 - replaced with the bank code
      /// 3 - replaced with the account number
      /// </summary>
      protected abstract string IBANFormatString { get; }

      /// <summary>
      /// Gets the length of the IBAN.
      /// </summary>
      protected abstract int IBANLength { get; }

      static CountrySpecificIBANConvert()
      {
         var nrA = Convert.ToInt32('A');
         characterMap = new Dictionary<char, int>();
         for (var index = 0; index < 26; index++)
         {
            characterMap.Add(Convert.ToChar(nrA + index), 10 + index);
         }
      }

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
      /// Converts the characters to numbers.
      /// </summary>
      /// <param name="val">The val.</param>
      /// <returns></returns>
      protected string ConvertCharactersToNumbers(string val)
      {
         var builder = new StringBuilder();
         foreach (var chr in val)
         {
            if (characterMap.ContainsKey(chr))
            {
               builder.Append(characterMap[chr]);
            }
            else
            {
               builder.Append(chr);
            }
         }
         return builder.ToString();
      }

      /// <summary>
      /// removes all digits which are not allowed within account numbers
      /// </summary>
      /// <param name="val">The val.</param>
      /// <returns></returns>
      protected string OnlyAllowedCharacters(string val)
      {
         if (val == null)
            return null;
         return regexOnlyAllowedCharacters.Replace(val, "");
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
