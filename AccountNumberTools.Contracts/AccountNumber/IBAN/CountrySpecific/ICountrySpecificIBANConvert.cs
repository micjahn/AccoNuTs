﻿//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

using AccountNumberTools.AccountNumber.Contracts;

namespace AccountNumberTools.AccountNumber.IBAN.Contracts.CountrySpecific
{
   /// <summary>
   /// interface is used for country specific IBAN converter algorithms
   /// </summary>
   public interface ICountrySpecificIBANConvert
   {
      /// <summary>
      /// converts the parts of a national account number to an IBAN.
      /// There are different parts needed in dependency of the selected country
      /// </summary>
      /// <param name="nationalAccountNumber">The national account number.</param>
      /// <returns></returns>
      string ToIBAN(NationalAccountNumber nationalAccountNumber);

      /// <summary>
      /// converts an IBAN to the parts of a national account number
      /// </summary>
      /// <param name="iban">The iban.</param>
      /// <returns></returns>
      NationalAccountNumber FromIBAN(string iban);
   }
}
