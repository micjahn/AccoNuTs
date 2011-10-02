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
   /// converts between a Bulgaria national account number and the Bulgaria IBAN
   /// BGkk BBBB SSSS DDCC CCCC CC
   /// </summary>
   public class BulgariaIBANConvert : CountrySpecificIBANConvert
   {
      private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

      /// <summary>
      /// 
      /// </summary>
      public const string Prefix = "BG";

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
      protected override string BBANFormatString { get { return "{0,4}{1,4}{2,2}{3,8}111600"; } }

      /// <summary>
      /// Gets the IBAN format string.
      /// Should be of the format {0}{1:00}{2:0...}{3:0...}
      /// 0 - replaced with the IBAN country prefix
      /// 1 - replaced with the check digit
      /// 2 - replaced with the bank code
      /// 3 - replaced with the account number
      /// </summary>
      protected override string IBANFormatString { get { return "{0}{1:00}{2,4}{3,4}{4,2}{5,8}"; } }

      /// <summary>
      /// Gets the length of the IBAN.
      /// </summary>
      protected override int IBANLength { get { return 22; } }

      /// <summary>
      /// Cuts the bic code out of the IBAN.
      /// </summary>
      /// <param name="cleanIBAN">The clean IBAN.</param>
      /// <returns></returns>
      protected string CutBIC(string cleanIBAN)
      {
         return cleanIBAN.Substring(4, 4).TrimStart('0');
      }

      /// <summary>
      /// Cuts the sort code out of the IBAN.
      /// </summary>
      /// <param name="cleanIBAN">The clean IBAN.</param>
      /// <returns></returns>
      protected string CutBranch(string cleanIBAN)
      {
         return cleanIBAN.Substring(8, 4).TrimStart('0');
      }

      /// <summary>
      /// Cuts the account type out of the IBAN.
      /// </summary>
      /// <param name="cleanIBAN">The clean IBAN.</param>
      /// <returns></returns>
      protected string CutAccountType(string cleanIBAN)
      {
         return cleanIBAN.Substring(12, 2).TrimStart('0');
      }

      /// <summary>
      /// Cuts the account number out of the IBAN.
      /// </summary>
      /// <param name="cleanIBAN">The clean IBAN.</param>
      /// <returns></returns>
      protected string CutAccountNumber(string cleanIBAN)
      {
         return cleanIBAN.Substring(14, 8).TrimStart('0');
      }

      /// <summary>
      /// Should create a new instance of the country specific account number
      /// </summary>
      /// <param name="other">another instance which should be wrapped. can be null</param>
      /// <returns></returns>
      protected BulgariaAccountNumber CreateInstance(NationalAccountNumber other)
      {
         return other == null ? new BulgariaAccountNumber() : new BulgariaAccountNumber(other);
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

         var bic = OnlyAllowedCharacters(abAccountNumber.BIC);
         var accountNumber = OnlyAllowedCharacters(abAccountNumber.AccountNumber);
         var branch = OnlyAllowedCharacters(abAccountNumber.Branch);
         var accountType = OnlyAllowedCharacters(abAccountNumber.AccountType);

         if (String.IsNullOrEmpty(bic))
            throw new ArgumentException("The bic code is missing.");
         if (String.IsNullOrEmpty(branch))
            throw new ArgumentException("The branch code is missing.");
         if (String.IsNullOrEmpty(accountNumber))
            throw new ArgumentException("The account number is missing.");
         if (String.IsNullOrEmpty(accountType))
            throw new ArgumentException("The account type is missing.");

         var bban = String.Format(BBANFormatString, bic, branch, accountType, accountNumber);
         bban = bban.Replace(' ', '0');
         bban = ConvertCharactersToNumbers(bban);

         Log.DebugFormat("calculating checksum for bban {0}", bban);

         var modulo = 98 - CalculateModulo(bban);
         var iban = String.Format(IBANFormatString, IBANPrefix, modulo, bic, branch, accountType, accountNumber);
         iban = iban.Replace(' ', '0');

         Log.DebugFormat("generated IBAN: {0}", iban);

         if (iban.Length != IBANLength)
            throw new InvalidOperationException(String.Format("Couldn't generate a valid IBAN from the bic {0}, branch {1}, the account number {2} and the account type {3}.", bic, branch, accountNumber, accountType));

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
         result.BIC = CutBIC(cleanIBAN);
         result.AccountNumber = CutAccountNumber(cleanIBAN);
         result.Branch = CutBranch(cleanIBAN);
         result.AccountType = CutAccountType(cleanIBAN);

         if (String.IsNullOrEmpty(result.BIC))
            result.BIC = "0";
         if (String.IsNullOrEmpty(result.AccountNumber))
            result.AccountNumber = "0";
         if (String.IsNullOrEmpty(result.Branch))
            result.Branch = "0";
         if (String.IsNullOrEmpty(result.AccountType))
            result.AccountType = "0";

         return result;
      }

   }
}
