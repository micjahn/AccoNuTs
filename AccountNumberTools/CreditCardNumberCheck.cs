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

using AccountNumberTools.Contracts;
using AccountNumberTools.Internals;

namespace AccountNumberTools
{
   /// <summary>
   /// Main class for checking credit card numbers
   /// </summary>
   public class CreditCardNumberCheck : ICreditCardNumberCheck
   {
      private Regex cleanUpRegex;
      private ICreditCardNumberMapToNetwork creditCardNumberMapToNetwork;

      private Regex CleanUpRegex
      {
         get
         {
            if (cleanUpRegex == null)
            {
               cleanUpRegex = new Regex("[^0-9]", RegexOptions.Compiled);
            }
            return cleanUpRegex;
         }
      }

      /// <summary>
      /// Gets or sets the credit card number mapping method.
      /// </summary>
      /// <value>
      /// The credit card number mapping method.
      /// </value>
      public ICreditCardNumberMapToNetwork CreditCardNumberMapToNetwork
      {
         get
         {
            return creditCardNumberMapToNetwork ?? CreditCardNumberMapToNetworkDummy.Instance;
         }
         set
         {
            creditCardNumberMapToNetwork = value;
         }
      }

      /// <summary>
      /// Gets or sets the credit card network code map to method.
      /// </summary>
      /// <value>
      /// The credit card network code map to method.
      /// </value>
      public ICreditCardNetworkMapToMethod CreditCardNetworkMapToMethod { get; set; }

      /// <summary>
      /// Initializes a new instance of the <see cref="CreditCardNumberCheck"/> class.
      /// </summary>
      public CreditCardNumberCheck()
      {
         CreditCardNetworkMapToMethod = new CreditCardNetworkMapToMethodFactory();
         CreditCardNumberMapToNetwork = new CreditCardNumberMapToNetwork();
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="CreditCardNumberCheck"/> class.
      /// </summary>
      /// <param name="creditCardNetworkMapToMethod">The credit card network code map to method.</param>
      public CreditCardNumberCheck(ICreditCardNetworkMapToMethod creditCardNetworkMapToMethod)
      {
         CreditCardNetworkMapToMethod = creditCardNetworkMapToMethod;
         CreditCardNumberMapToNetwork = new CreditCardNumberMapToNetwork();
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="CreditCardNumberCheck"/> class.
      /// </summary>
      /// <param name="creditCardNetworkMapToMethod">The credit card network code map to method.</param>
      public CreditCardNumberCheck(ICreditCardNetworkMapToMethod creditCardNetworkMapToMethod, ICreditCardNumberMapToNetwork creditCardNumberMapToNetwork)
      {
         CreditCardNetworkMapToMethod = creditCardNetworkMapToMethod;
         CreditCardNumberMapToNetwork = creditCardNumberMapToNetwork;
      }

      /// <summary>
      /// Determines whether the specified credit card number is formal valid.
      /// </summary>
      /// <param name="creditCardNumber">The credit card number.</param>
      /// <param name="creditCardNetwork">The credit card network.</param>
      /// <exception cref="ArgumentNullException">is thrown, if an argument isn't provided</exception>
      /// <exception cref="ArgumentException">is thrown, if the credit card network can't be automatically detected</exception>
      /// <exception cref="InvalidOperationException">is thrown, if there is a problem with the mapping of the network to a check method</exception>
      /// <returns>
      ///   <c>true</c> if the specified credit card number is formal valid; otherwise, <c>false</c>.
      /// </returns>
      public bool IsValid(string creditCardNumber, string creditCardNetwork)
      {
         if (creditCardNetwork == null)
            throw new ArgumentNullException("creditCardNetwork");
         if (string.IsNullOrEmpty(creditCardNumber))
            throw new ArgumentNullException("creditCardNumber", "Please provide a credit card number.");

         if (CreditCardNetworkMapToMethod == null)
            throw new InvalidOperationException("Please provide an instanz for the mapping between a credit card network code and a check method.");

         creditCardNumber = CleanUp(creditCardNumber);

         if (creditCardNetwork == CreditCardNetwork.Automatic)
         {
            creditCardNetwork = CreditCardNumberMapToNetwork.Resolve(creditCardNumber);
            if (string.IsNullOrEmpty(creditCardNetwork))
               throw new ArgumentException("Please provide a specific credit card network identifier because it can not be resolved from the given credit card number.", "creditCardNetwork");
         }

         var checkMethod = CreditCardNetworkMapToMethod.Resolve(creditCardNetwork);
         if (checkMethod == null)
            throw new InvalidOperationException(String.Format("The credit card network code {0} could not be mapped to a check method implementation.", creditCardNetwork));

         return checkMethod.IsValid(creditCardNumber);
      }

      /// <summary>
      /// Calculates the check digit for the given credit card number.
      /// </summary>
      /// <param name="creditCardNumber">The credit card number.</param>
      /// <param name="creditCardNetwork">The credit card network.</param>
      /// <exception cref="ArgumentNullException">is thrown, if an argument isn't provided</exception>
      /// <exception cref="ArgumentException">is thrown, if the credit card network can't be automatically detected</exception>
      /// <exception cref="InvalidOperationException">is thrown, if there is a problem with the mapping of the network to a check method</exception>
      /// <returns></returns>
      public string CalculateCheckDigit(string creditCardNumber, string creditCardNetwork)
      {
         if (creditCardNetwork == null)
            throw new ArgumentNullException("creditCardNetwork", "Please provide a credit card network code for a check method.");
         if (string.IsNullOrEmpty(creditCardNumber))
            throw new ArgumentNullException("creditCardNumber", "Please provide a credit card number.");

         if (CreditCardNetworkMapToMethod == null)
            throw new InvalidOperationException("Please provide an instanz for the mapping between a check method code and a check method.");

         creditCardNumber = CleanUp(creditCardNumber);

         if (creditCardNetwork == CreditCardNetwork.Automatic)
         {
            creditCardNetwork = CreditCardNumberMapToNetwork.Resolve(creditCardNumber);
            if (string.IsNullOrEmpty(creditCardNetwork))
               throw new ArgumentException("Please provide a specific credit card network identifier because it can not be resolved from the given credit card number.", "creditCardNetwork");
         }

         var checkMethod = CreditCardNetworkMapToMethod.Resolve(creditCardNetwork);
         if (checkMethod == null)
            throw new InvalidOperationException(String.Format("The credit card network code {0} could not be mapped to a check method implementation.", creditCardNetwork));

         return checkMethod.CalculateCheckDigit(creditCardNumber);
      }

      private string CleanUp(string creditCardNumber)
      {
         return CleanUpRegex.Replace(creditCardNumber, String.Empty);
      }
   }
}
