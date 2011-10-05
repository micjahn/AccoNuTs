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

using AccountNumberTools.AccountNumber.Contracts;
using AccountNumberTools.AccountNumber.Validation.Contracts;
using AccountNumberTools.AccountNumber.Validation.Internals;
using AccountNumberTools.Common.Contracts;

namespace AccountNumberTools.AccountNumber.Validation
{
   /// <summary>
   /// Main class for checking account numbers
   /// </summary>
   public class AccountNumberValidation : IAccountNumberValidation
   {
      /// <summary>
      /// Gets the mapping between country identifiers and the specific validation for the country
      /// </summary>
      public IDictionary<Country, IAccountNumberValidation> SpecificValidations { get; private set; }

      /// <summary>
      /// Initializes a new instance of the <see cref="AccountNumberValidation"/> class.
      /// </summary>
      public AccountNumberValidation()
      {
         SpecificValidations = new Dictionary<Country, IAccountNumberValidation>
                                  {
                                     {Country.Albania, new AlbaniaAccountNumberValidation()},
                                     {Country.Belgium, new BelgiumAccountNumberValidation()},
                                     {Country.Germany, new GermanAccountNumberValidation()},
                                     {Country.Norway, new NorwayAccountNumberValidation()},
                                     {Country.Poland, new PolandAccountNumberValidation()},
                                     {Country.Portugal, new PortugalAccountNumberValidation()}
                                  };
      }

      /// <summary>
      /// Determines whether the specified account number is valid. The given bank code will be
      /// mapped to an registered method which calculates the check digit. The account number
      /// is given as a full number including the hypothetical check digit.
      /// </summary>
      /// <param name="accountNumber">The account number including the hypothetical check digit.</param>
      /// <returns>
      ///   <c>true</c> if the specified account number is valid; otherwise, <c>false</c>.
      /// </returns>
      public bool IsValid(NationalAccountNumber accountNumber)
      {
         if (accountNumber == null)
            throw new ArgumentNullException("accountNumber", "Please provide an account number."); 
         
         if (!SpecificValidations.ContainsKey(accountNumber.Country))
            throw new ArgumentException(string.Format("The country {0} isn't supported.", accountNumber.Country), "accountNumber");

         var specificValidation = SpecificValidations[accountNumber.Country];

         return specificValidation.IsValid(accountNumber);
      }

      /// <summary>
      /// Calculates the check digit. The given bank code will be
      /// mapped to an registered method which calculates the check digit.
      /// The account number is given without a check digit.
      /// </summary>
      /// <param name="accountNumber">The account number without a check digit.</param>
      /// <returns>
      /// The calculated check digit for the given account number
      /// </returns>
      public string CalculateCheckDigit(NationalAccountNumber accountNumber)
      {
         if (accountNumber == null)
            throw new ArgumentNullException("accountNumber", "Please provide an account number.");

         if (!SpecificValidations.ContainsKey(accountNumber.Country))
            throw new ArgumentException(string.Format("The country {0} isn't supported.", accountNumber.Country), "accountNumber");

         var specificValidation = SpecificValidations[accountNumber.Country];

         return specificValidation.CalculateCheckDigit(accountNumber);
      }
   }
}
