﻿//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

using System;

using AccountNumberTools.IBAN.Contracts;

namespace AccountNumberTools.IBAN.Internals
{
   /// <summary>
   /// a new class
   /// </summary>
   public abstract class AccountAndBankCodeNumberIBANConvert : CountrySpecificIBANConvert
   {
      private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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

         var bankCode = OnlyNumbers(abAccountNumber.BankCode);
         var accountNumber = OnlyNumbers(abAccountNumber.AccountNumber);

         if (String.IsNullOrEmpty(bankCode))
            throw new ArgumentException("The bank code is missing.");
         if (String.IsNullOrEmpty(accountNumber))
            throw new ArgumentException("The account number is missing.");

         var numBankCode = Convert.ToInt64(bankCode);
         var numAccountNumber = Convert.ToInt64(accountNumber);
         var bban = String.Format(BBANFormatString, numBankCode, numAccountNumber);

         Log.DebugFormat("calculating checksum for bban {0}", bban);

         var modulo = 98 - CalculateModulo(bban);
         var iban = String.Format(IBANFormatString, IBANPrefix, modulo, numBankCode, numAccountNumber);

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
            throw new ArgumentException(String.Format("{0} isn't a valid iban.", iban));

         var result = CreateInstance(null);
         result.BankCode = CutBankCode(cleanIBAN);
         result.AccountNumber = CutAccountNumber(cleanIBAN);

         return result;
      }

      /// <summary>
      /// Cuts the bank code out of the IBAN.
      /// </summary>
      /// <param name="cleanIBAN">The clean IBAN.</param>
      /// <returns></returns>
      protected abstract string CutBankCode(string cleanIBAN);

      /// <summary>
      /// Cuts the account number out of the IBAN.
      /// </summary>
      /// <param name="cleanIBAN">The clean IBAN.</param>
      /// <returns></returns>
      protected abstract string CutAccountNumber(string cleanIBAN);

      /// <summary>
      /// Should create a new instance of the country specific account number
      /// </summary>
      /// <param name="other">another instance which should be wrapped. can be null</param>
      /// <returns></returns>
      protected abstract AccountAndBankCodeNumber CreateInstance(NationalAccountNumber other);
   }
}