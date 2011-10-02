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

using AccountNumberTools.AccountNumber.Validation.Contracts;
using AccountNumberTools.Common.Contracts;

namespace AccountNumberTools.AccountNumber.Validation
{
   /// <summary>
   /// Mapping class for standard validation methods
   /// </summary>
   public class ValidationMethodCodeMapToMethodFactory : IValidationMethodCodeMapToMethod
   {
      private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

      private IDictionary<string, Type> map;
      private readonly IDictionary<string, IValidationMethod> mapInstances;

      /// <summary>
      /// Gets the mapping between check method code and class types
      /// </summary>
      public IDictionary<string, Type> Map
      {
         get
         {
            if (map == null)
               RegisterAll();
            return map;
         }
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="ValidationMethodCodeMapToMethodFactory"/> class.
      /// </summary>
      public ValidationMethodCodeMapToMethodFactory()
      {
         mapInstances = new Dictionary<string, IValidationMethod>();
      }

      /// <summary>
      /// Resolves the specified check method by code.
      /// </summary>
      /// <param name="validationMethodCode">The validation method code.</param>
      /// <returns></returns>
      public IValidationMethod Resolve(string validationMethodCode)
      {
         if (mapInstances.ContainsKey(validationMethodCode))
            return mapInstances[validationMethodCode];

         return CreateInstance(validationMethodCode);
      }

      private IValidationMethod CreateInstance(string validationMethodCode)
      {
         if (map == null)
            RegisterAll();

         var type = map[validationMethodCode];

         Log.InfoFormat("create instance for type {0}", type.FullName);

         var validationMethodInstance = (IValidationMethod)Activator.CreateInstance(type);

         mapInstances[validationMethodCode] = validationMethodInstance;

         return validationMethodInstance;
      }

      private void RegisterAll()
      {
         Log.Debug("method called to register standard validation methods via reflection");

         lock (this)
         {
            if (map != null)
               return;

            var newMap = new Dictionary<string, Type>();

            foreach (var type in typeof(ValidationMethodCodeMapToMethodFactory).Assembly.GetTypes())
            {
               // Find all ValidationMethodXX classes and make some "magic" auto-registering
               if (!typeof (IValidationMethod).IsAssignableFrom(type) ||
                    type.Name.Length != 18)
                  continue;

               var validationMethodCode = type.Name.Substring(16, 2);
               newMap[validationMethodCode] = type;

               Log.DebugFormat("found IValidationMethod implementing class {0}", type.FullName);
            }

            map = newMap;
         }
      }
   }
}
