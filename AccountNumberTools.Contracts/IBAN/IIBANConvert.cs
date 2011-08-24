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

namespace AccountNumberTools.IBAN.Contracts
{
   /// <summary>
   /// interface for converting from and to IBAN numbers
   /// </summary>
   public interface IIBANConvert
   {
      /// <summary>
      /// converts the parts of a national account number to an IBAN.
      /// There are different parts needed in dependency of the selected country
      /// </summary>
      /// <param name="country">The country.</param>
      /// <param name="nationalAccountNumber">The national account number.</param>
      /// <returns></returns>
      string ToIBAN(Country country, NationalAccountNumber nationalAccountNumber);

      /// <summary>
      /// converts an IBAN to the parts of a national account number
      /// </summary>
      /// <param name="country">The country.</param>
      /// <param name="iban">The iban.</param>
      /// <returns></returns>
      NationalAccountNumber FromIBAN(Country country, string iban);
   }
}
