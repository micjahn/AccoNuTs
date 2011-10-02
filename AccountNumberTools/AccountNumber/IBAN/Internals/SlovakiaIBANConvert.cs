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

using AccountNumberTools.AccountNumber.Contracts;
using AccountNumberTools.AccountNumber.Contracts.CountrySpecific;

namespace AccountNumberTools.AccountNumber.IBAN.Internals
{
   /// <summary>
   /// converts between a Slovakia national account number and the Slovakia IBAN
   /// SKkk BBBB SSSS SSCC CCCC CCCC
   /// </summary>
   public class SlovakiaIBANConvert : CountrySpecificIBANConvert
   {
      private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

      /// <summary>
      /// 
      /// </summary>
      public const string Prefix = "SK";

      /// <summary>
      /// Returns the 2-char country prefix for the IBAN
      /// </summary>
      protected override string IBANPrefix { get { return Prefix; } }

      /// <summary>
      /// Gets the BBAN format string for calculating the check digit.
      /// Should be of the format {0:0...}{1:0...}131400 for DE-IBAN.
      /// Replace 1314 with the country specific numbers.
      /// 0 - replaced with the bank code
      /// 1 - replaced with the account number
      /// </summary>
      protected override string BBANFormatString { get { return "{0,4}{1,6}{2,10}282000"; } }

      /// <summary>
      /// Gets the IBAN format string.
      /// Should be of the format {0}{1:00}{2:0...}{3:0...}
      /// 0 - replaced with the IBAN country prefix
      /// 1 - replaced with the check digit
      /// 2 - replaced with the bank code
      /// 3 - replaced with the account number
      /// </summary>
      protected override string IBANFormatString { get { return "{0}{1:00}{2,4}{3,6}{4,10}"; } }

      /// <summary>
      /// Gets the length of the IBAN.
      /// </summary>
      protected override int IBANLength { get { return 24; } }

      /// <summary>
      /// Cuts the bank code out of the IBAN.
      /// </summary>
      /// <param name="cleanIBAN">The clean IBAN.</param>
      /// <returns></returns>
      protected string CutBankCode(string cleanIBAN)
      {
         return cleanIBAN.Substring(4, 4).TrimStart('0');
      }

      /// <summary>
      /// Cuts the sort code out of the IBAN.
      /// </summary>
      /// <param name="cleanIBAN">The clean IBAN.</param>
      /// <returns></returns>
      protected string CutSort(string cleanIBAN)
      {
         return cleanIBAN.Substring(8, 6).TrimStart('0');
      }

      /// <summary>
      /// Cuts the account number out of the IBAN.
      /// </summary>
      /// <param name="cleanIBAN">The clean IBAN.</param>
      /// <returns></returns>
      protected string CutAccountNumber(string cleanIBAN)
      {
         return cleanIBAN.Substring(14, 10).TrimStart('0');
      }

      /// <summary>
      /// Should create a new instance of the country specific account number
      /// </summary>
      /// <param name="other">another instance which should be wrapped. can be null</param>
      /// <returns></returns>
      protected SlovakiaAccountNumber CreateInstance(NationalAccountNumber other)
      {
         return other == null ? new SlovakiaAccountNumber() : new SlovakiaAccountNumber(other);
      }

      /// <summary>
      /// converts the parts of a national account number to an IBAN.
      /// There are different parts needed in dependency of the selected country
      /// </summary>
      /// <param name="nationalAccountNumber">The national account number.</param>
      /// <returns></returns>
      public override string ToIBAN(NationalAccountNumber nationalAccountNumber)
      {
         if (nationalAccountNumber == null)
            throw new ArgumentNullException("nationalAccountNumber");

         var abAccountNumber = CreateInstance(nationalAccountNumber);

         var bankCode = OnlyAllowedCharacters(abAccountNumber.BankCode);
         var accountNumber = OnlyAllowedCharacters(abAccountNumber.AccountNumber);
         var sortCode = OnlyAllowedCharacters(abAccountNumber.SortCode);

         if (String.IsNullOrEmpty(bankCode))
            throw new ArgumentException("The bank code is missing.");
         if (String.IsNullOrEmpty(sortCode))
            throw new ArgumentException("The sort code is missing.");
         if (String.IsNullOrEmpty(accountNumber))
            throw new ArgumentException("The account number is missing.");

         var bban = String.Format(BBANFormatString, bankCode, sortCode, accountNumber);
         bban = bban.Replace(' ', '0');
         bban = ConvertCharactersToNumbers(bban);

         Log.DebugFormat("calculating checksum for bban {0}", bban);

         var modulo = 98 - CalculateModulo(bban);
         var iban = String.Format(IBANFormatString, IBANPrefix, modulo, bankCode, sortCode, accountNumber);
         iban = iban.Replace(' ', '0');

         Log.DebugFormat("generated IBAN: {0}", iban);

         if (iban.Length != IBANLength)
            throw new InvalidOperationException(String.Format("Couldn't generate a valid IBAN from the bankcode {0} and the account number {1}.", bankCode, accountNumber));

         return iban;
      }

      /// <summary>
      /// converts an IBAN to the parts of a national account number
      /// </summary>
      /// <param name="iban">The iban.</param>
      /// <returns></returns>
      public override NationalAccountNumber FromIBAN(string iban)
      {
         var cleanIBAN = OnlyIBANDigits(iban);
         if (String.IsNullOrEmpty(cleanIBAN))
            throw new ArgumentNullException("iban");

         if (cleanIBAN.Length != IBANLength)
            throw new ArgumentException(String.Format("{0} isn't a valid iban. It should be {1} characters long but has only {2}.", cleanIBAN, IBANLength, cleanIBAN.Length));

         var result = CreateInstance(null);
         result.BankCode = CutBankCode(cleanIBAN);
         result.AccountNumber = CutAccountNumber(cleanIBAN);
         result.SortCode = CutSort(cleanIBAN);

         if (String.IsNullOrEmpty(result.BankCode))
            result.BankCode = "0";
         if (String.IsNullOrEmpty(result.AccountNumber))
            result.AccountNumber = "0";
         if (String.IsNullOrEmpty(result.SortCode))
            result.SortCode = "0";

         return result;
      }

   }
}
