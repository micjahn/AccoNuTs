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
using AccountNumberTools.AccountNumber.Contracts;
using AccountNumberTools.AccountNumber.Methods;

namespace AccountNumberTools.AccountNumber
{
   /// <summary>
   /// Mapping class for standard check methods
   /// </summary>
   public class CheckMethodCodeMapToMethodFactory : ICheckMethodCodeMapToMethod
   {
      private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

      private IDictionary<string, Type> map;
      private IDictionary<string, ICheckMethod> mapInstances;

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
      /// Initializes a new instance of the <see cref="CheckMethodCodeMapToMethodFactory"/> class.
      /// </summary>
      public CheckMethodCodeMapToMethodFactory()
      {
         mapInstances = new Dictionary<string, ICheckMethod>();
      }

      /// <summary>
      /// Resolves the specified check method by code.
      /// </summary>
      /// <param name="checkMethodCode">The check method code.</param>
      /// <returns></returns>
      public ICheckMethod Resolve(string checkMethodCode)
      {
         if (mapInstances.ContainsKey(checkMethodCode))
            return mapInstances[checkMethodCode];

         return CreateInstance(checkMethodCode);
      }

      private ICheckMethod CreateInstance(string checkMethodCode)
      {
         if (map == null)
            RegisterAll();

         var type = map[checkMethodCode];

         Log.InfoFormat("create instance for type {0}", type.FullName);

         var checkMethodInstance = (ICheckMethod)Activator.CreateInstance(type);

         mapInstances[checkMethodCode] = checkMethodInstance;

         return checkMethodInstance;
      }

      private void RegisterAll()
      {
         Log.Debug("method called to register standard check methods via reflection");

         lock (this)
         {
            if (map != null)
               return;

            var newMap = new Dictionary<string, Type>();

            foreach (var type in typeof(CheckMethodCodeMapToMethodFactory).Assembly.GetTypes())
            {
               // Find all CheckMethodXX classes and make some "magic" auto-registering
               if (typeof(ICheckMethod).IsAssignableFrom(type) &&
                   type.Name.Length == 13)
               {
                  var checkMethodCode = type.Name.Substring(11, 2);
                  newMap[checkMethodCode] = type;

                  Log.DebugFormat("found ICheckMethod implementing class {0}", type.FullName);
               }
            }

            map = newMap;
         }
      }
   }
}
