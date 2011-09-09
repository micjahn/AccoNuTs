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
      private IDictionary<string, Func<ICheckMethod>> map;
      private readonly IDictionary<string, ICheckMethod> mapInstances;

      /// <summary>
      /// Gets the mapping between check method code and class types
      /// </summary>
      public IDictionary<string, Func<ICheckMethod>> Map
      {
         get
         {
            return map ?? (map = new Dictionary<string, Func<ICheckMethod>>());
         }
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="CreditCardNetworkMapToMethodFactory"/> class.
      /// </summary>
      public CreditCardNetworkMapToMethodFactory()
      {
         mapInstances = new Dictionary<string, ICheckMethod>();
      }

      /// <summary>
      /// Resolves the specified check method for a credit card network.
      /// </summary>
      /// <param name="creditCardNetwork">The credit card network code.</param>
      /// <returns></returns>
      public ICheckMethod Resolve(string creditCardNetwork)
      {
         if (mapInstances.ContainsKey(creditCardNetwork))
            return mapInstances[creditCardNetwork];

         return CreateInstance(creditCardNetwork);
      }

      private ICheckMethod CreateInstance(string creditCardNetwork)
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

         tmpMap.Add(CreditCardNetwork.AmericanExpress, () => new CheckMethodLuhn(15, 15));
         tmpMap.Add(CreditCardNetwork.Bankcard, () => new CheckMethodLuhn(16, 16));
         tmpMap.Add(CreditCardNetwork.ChinaUnionPay, () => new CheckMethodLength(16, 16));
         tmpMap.Add(CreditCardNetwork.DinersClubCarteBlanche, () => new CheckMethodLuhn(14, 14));
         tmpMap.Add(CreditCardNetwork.DinersClubenRoute, () => new CheckMethodLength(15, 15));
         tmpMap.Add(CreditCardNetwork.DinersClubInternational, () => new CheckMethodLuhn(14, 14));
         tmpMap.Add(CreditCardNetwork.DinersClubUnitedStatesCanada, () => new CheckMethodLuhn(16, 16));
         tmpMap.Add(CreditCardNetwork.DiscoverCard, () => new CheckMethodLuhn(16, 16));
         tmpMap.Add(CreditCardNetwork.InstaPayment, () => new CheckMethodLuhn(16, 16));
         tmpMap.Add(CreditCardNetwork.JCB, () => new CheckMethodLuhn(16, 16));
         tmpMap.Add(CreditCardNetwork.Laser, () => new CheckMethodLuhn(16, 19));
         tmpMap.Add(CreditCardNetwork.Maestro, () => new CheckMethodLuhn(12, 19));
         tmpMap.Add(CreditCardNetwork.MasterCard, () => new CheckMethodLuhn(16, 16));
         tmpMap.Add(CreditCardNetwork.Solo, () => new CheckMethodLuhn(16, 19));
         tmpMap.Add(CreditCardNetwork.Switch, () => new CheckMethodLuhn(16, 19));
         tmpMap.Add(CreditCardNetwork.Visa, () => new CheckMethodLuhn(16, 16));
         tmpMap.Add(CreditCardNetwork.VisaElectron, () => new CheckMethodLuhn(16, 16));
         tmpMap.Add(CreditCardNetwork.Voyager, () => new CheckMethodLuhn(15, 15));
         // credit card families
         tmpMap.Add(CreditCardNetwork.FamilyVisa, () => new CheckMethodLuhn(16, 16));
         tmpMap.Add(CreditCardNetwork.FamilyMasterCard, () => new CheckMethodLuhn(14, 16));
         tmpMap.Add(CreditCardNetwork.FamilyAmericanExpress, () => new CheckMethodLuhn(16, 16));
      }
   }
}
