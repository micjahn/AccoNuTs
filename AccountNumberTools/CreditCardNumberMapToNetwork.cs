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
using System.Text.RegularExpressions;
using System.Reflection;
using System.IO;

using AccountNumberTools.Contracts;

namespace AccountNumberTools.Internals
{
   /// <summary>
   /// An implementation of ICreditCardNumberMapToNetwork which uses a static mapping resource compiled into the assembly
   /// </summary>
   internal class CreditCardNumberMapToNetwork : ICreditCardNumberMapToNetwork
   {
      private IDictionary<string, Regex> mapNetworkToRegex;

      /// <summary>
      /// Resolves the network base on a static resource
      /// </summary>
      /// <param name="creditCardNumber">The credit card number.</param>
      /// <returns></returns>
      public string Resolve(string creditCardNumber)
      {
         if (mapNetworkToRegex == null)
            CreateMapping();

         foreach (var entry in mapNetworkToRegex)
         {
            if (entry.Value.IsMatch(creditCardNumber))
            {
               return entry.Key;
            }
         }

         return String.Empty;
      }

      private void CreateMapping()
      {
         mapNetworkToRegex = new Dictionary<string, Regex>();
         using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AccountNumberTools.Data.IINPrefixes.txt"))
         {
            if (stream == null)
               throw new InvalidOperationException("Can't load the iin mapping resource from assembly.");

            using (var reader = new StreamReader(stream))
            {
               var oneLine = String.Empty;
               while (!String.IsNullOrEmpty(oneLine = reader.ReadLine()))
               {
                  var oneLineParts = oneLine.Split(':');
                  if (oneLineParts.Length != 2)
                     throw new InvalidOperationException("Mapping file has incorrect data.");

                  mapNetworkToRegex[oneLineParts[0]] = new Regex(oneLineParts[1], RegexOptions.Compiled);
               }
            }
         }
      }
   }
}
