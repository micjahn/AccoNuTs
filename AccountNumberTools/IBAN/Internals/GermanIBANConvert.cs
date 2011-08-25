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

using AccountNumberTools.IBAN.Contracts;
using AccountNumberTools.IBAN.Contracts.CountrySpecific;

namespace AccountNumberTools.IBAN.Internals
{
   /// <summary>
   /// a new class
   /// </summary>
   public class GermanIBANConvert : CountrySpecificIBANConvert
   {
      private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

      /// <summary>
      /// converts the parts of a national account number to an IBAN.
      /// There are different parts needed in dependency of the selected country
      /// </summary>
      /// <param name="nationalAccountNumber">The national account number.</param>
      /// <returns></returns>
      public override string ToIBAN(NationalAccountNumber nationalAccountNumber)
      {
         // DEpp bbbb bbbb kkkk kkkk kk
         if (nationalAccountNumber == null)
            throw new ArgumentNullException("nationalAccountNumber");

         var germanAccountNumber = new GermanAccountNumber(nationalAccountNumber);

         var bankCode = OnlyNumbers(germanAccountNumber.BankCode);
         var accountNumber = OnlyNumbers(germanAccountNumber.AccountNumber);

         if (String.IsNullOrEmpty(bankCode))
            throw new ArgumentException("The bank code is missing.");
         if (String.IsNullOrEmpty(accountNumber))
            throw new ArgumentException("The account number is missing.");

         var numBankCode = Convert.ToInt64(bankCode);
         var numAccountNumber = Convert.ToInt64(accountNumber);
         var bban = String.Format("{0:00000000}{1:0000000000}131400", numBankCode, numAccountNumber);

         Log.DebugFormat("calculating checksum for bban {0}", bban);

         var modulo = 98 - CalculateModulo(bban);
         var iban = String.Format("DE{0:00}{1:00000000}{2:0000000000}", modulo, numBankCode, numAccountNumber);

         Log.DebugFormat("generated IBAN: {0}", iban);

         if (iban.Length != 22)
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

         if (cleanIBAN.Length != 22)
            throw new ArgumentException(String.Format("{0} isn't a valid german iban.", iban));

         var result = new GermanAccountNumber();
         result.BankCode = cleanIBAN.Substring(4, 8);
         result.AccountNumber = cleanIBAN.Substring(12, 10).TrimStart('0');

         return result;
      }
   }
}
