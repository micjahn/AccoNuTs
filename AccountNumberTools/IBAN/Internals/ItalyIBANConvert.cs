//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

using AccountNumberTools.IBAN.Contracts;
using AccountNumberTools.IBAN.Contracts.CountrySpecific;

namespace AccountNumberTools.IBAN.Internals
{
   /// <summary>
   /// converts between a Italy national account number and the Italy IBAN
   /// ITkk KAAA AABB BBBC CCCC CCCC CCC
   /// </summary>
   public class ItalyIBANConvert : AccountBankCodeAndBranchIBANConvert
   {
      /// <summary>
      /// 
      /// </summary>
      public const string Prefix = "IT";

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
      protected override string BBANFormatString { get { return "{0,6}{1,5}{2,12}182900"; } }

      /// <summary>
      /// Gets the IBAN format string.
      /// Should be of the format {0}{1:00}{2:0...}{3:0...}
      /// 0 - replaced with the IBAN country prefix
      /// 1 - replaced with the check digit
      /// 2 - replaced with the bank code
      /// 3 - replaced with the account number
      /// </summary>
      protected override string IBANFormatString { get { return "{0}{1:00}{2,6}{3,5}{4,12}"; } }

      /// <summary>
      /// Gets the length of the IBAN.
      /// </summary>
      protected override int IBANLength { get { return 27; } }

      /// <summary>
      /// Cuts the bank code out of the IBAN.
      /// </summary>
      /// <param name="cleanIBAN">The clean IBAN.</param>
      /// <returns></returns>
      protected override string CutBankCode(string cleanIBAN)
      {
         return cleanIBAN.Substring(4, 6).TrimStart('0');
      }

      /// <summary>
      /// Cuts the branch out of the IBAN.
      /// </summary>
      /// <param name="cleanIBAN">The clean IBAN.</param>
      /// <returns></returns>
      protected override string CutBranch(string cleanIBAN)
      {
         return cleanIBAN.Substring(10, 5).TrimStart('0');
      }

      /// <summary>
      /// Cuts the account number out of the IBAN.
      /// </summary>
      /// <param name="cleanIBAN">The clean IBAN.</param>
      /// <returns></returns>
      protected override string CutAccountNumber(string cleanIBAN)
      {
         return cleanIBAN.Substring(15, 12).TrimStart('0');
      }

      /// <summary>
      /// Should create a new instance of the country specific account number
      /// </summary>
      /// <param name="other">another instance which should be wrapped. can be null</param>
      /// <returns></returns>
      protected override AccountBankCodeAndBranchNumber CreateInstance(NationalAccountNumber other)
      {
         return other == null ? new ItalyAccountNumber() : new ItalyAccountNumber(other);
      }
   }
}
