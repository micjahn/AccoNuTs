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

using AccountNumberTools.Common.Contracts;
using AccountNumberTools.Common.Methods;
using AccountNumberTools.CreditCard.Methods;
using AccountNumberTools.CreditCard.Contracts;

namespace AccountNumberTools.CreditCard
{
   /// <summary>
   /// Mapping class for standard check methods for credit card networks
   /// </summary>
   public class CreditCardNetworkMapToMethodFactory : ICreditCardNetworkMapToMethod
   {
      private IDictionary<string, Func<IValidationMethod>> map;
      private readonly IDictionary<string, IValidationMethod> mapInstances;

      /// <summary>
      /// Gets the mapping between check method code and class types
      /// </summary>
      public IDictionary<string, Func<IValidationMethod>> Map
      {
         get
         {
            return map ?? (map = new Dictionary<string, Func<IValidationMethod>>());
         }
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="CreditCardNetworkMapToMethodFactory"/> class.
      /// </summary>
      public CreditCardNetworkMapToMethodFactory()
      {
         mapInstances = new Dictionary<string, IValidationMethod>();
      }

      /// <summary>
      /// Resolves the specified check method for a credit card network.
      /// </summary>
      /// <param name="creditCardNetwork">The credit card network code.</param>
      /// <returns></returns>
      public IValidationMethod Resolve(string creditCardNetwork)
      {
         if (mapInstances.ContainsKey(creditCardNetwork))
            return mapInstances[creditCardNetwork];

         return CreateInstance(creditCardNetwork);
      }

      private IValidationMethod CreateInstance(string creditCardNetwork)
      {
         if (map == null)
            RegisterAll();

         if (!map.ContainsKey(creditCardNetwork))
            throw new KeyNotFoundException(String.Format("Credit card network code {0} not supported.", creditCardNetwork));

         var createInstanceFunc = map[creditCardNetwork];

         var checkMethodInstance = createInstanceFunc();

         mapInstances[creditCardNetwork] = checkMethodInstance;

         return checkMethodInstance;
      }

      /// <summary>
      /// Register all known credit card network codes with an instance creation function
      /// </summary>
      virtual protected void RegisterAll()
      {
         var tmpMap = Map;

         tmpMap.Add(CreditCardNetwork.AmericanExpress, () => new ValidationMethodLuhn(15, 15));
         tmpMap.Add(CreditCardNetwork.Bankcard, () => new ValidationMethodLuhn(16, 16));
         tmpMap.Add(CreditCardNetwork.ChinaUnionPay, () => new ValidationMethodLength(16, 16));
         tmpMap.Add(CreditCardNetwork.DinersClubCarteBlanche, () => new ValidationMethodLuhn(14, 14));
         tmpMap.Add(CreditCardNetwork.DinersClubenRoute, () => new ValidationMethodLength(15, 15));
         tmpMap.Add(CreditCardNetwork.DinersClubInternational, () => new ValidationMethodLuhn(14, 14));
         tmpMap.Add(CreditCardNetwork.DinersClubUnitedStatesCanada, () => new ValidationMethodLuhn(16, 16));
         tmpMap.Add(CreditCardNetwork.DiscoverCard, () => new ValidationMethodLuhn(16, 16));
         tmpMap.Add(CreditCardNetwork.InstaPayment, () => new ValidationMethodLuhn(16, 16));
         tmpMap.Add(CreditCardNetwork.JCB, () => new ValidationMethodLuhn(16, 16));
         tmpMap.Add(CreditCardNetwork.Laser, () => new ValidationMethodLuhn(16, 19));
         tmpMap.Add(CreditCardNetwork.Maestro, () => new ValidationMethodLuhn(12, 19));
         tmpMap.Add(CreditCardNetwork.MasterCard, () => new ValidationMethodLuhn(16, 16));
         tmpMap.Add(CreditCardNetwork.Solo, () => new ValidationMethodLuhn(16, 19));
         tmpMap.Add(CreditCardNetwork.Switch, () => new ValidationMethodLuhn(16, 19));
         tmpMap.Add(CreditCardNetwork.Visa, () => new ValidationMethodLuhn(16, 16));
         tmpMap.Add(CreditCardNetwork.VisaElectron, () => new ValidationMethodLuhn(16, 16));
         tmpMap.Add(CreditCardNetwork.Voyager, () => new ValidationMethodLuhn(15, 15));
         // credit card families
         tmpMap.Add(CreditCardNetwork.FamilyVisa, () => new ValidationMethodLuhn(16, 16));
         tmpMap.Add(CreditCardNetwork.FamilyMasterCard, () => new ValidationMethodLuhn(14, 16));
         tmpMap.Add(CreditCardNetwork.FamilyAmericanExpress, () => new ValidationMethodLuhn(16, 16));
      }
   }
}
