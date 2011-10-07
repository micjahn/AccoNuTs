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
using System.IO;
#if SILVERLIGHT
using Ionic.Zlib;
#else
using System.IO.Compression;
#endif
using System.Text;

using AccountNumberTools.AccountNumber.Validation.Contracts;

namespace AccountNumberTools.AccountNumber.Validation
{
   /// <summary>
   /// Mapping class for standard check methods
   /// </summary>
   public class BankCodeMapToValidationMethodCodeByBankCodeFile : IBankCodeMapToValidationMethodCode
   {
#if SILVERLIGHT
      private static readonly DanielVaughan.Logging.ILog Log = DanielVaughan.Logging.LogManager.GetLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#else
      private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#endif

      private IDictionary<string, string> map;

      private string FileName { get; set; }

      /// <summary>
      /// Gets the mapping between check method code and class types
      /// </summary>
      public IDictionary<string, string> Map
      {
         get
         {
            if (map == null)
               CreateMap();
            return map;
         }
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="BankCodeMapToValidationMethodCodeByBankCodeFile"/> class.
      /// </summary>
      public BankCodeMapToValidationMethodCodeByBankCodeFile()
      {
         using (var stream = GetType().Assembly.GetManifestResourceStream("Bankcodes.zip"))
         using (var gzipstream = new GZipStream(stream, CompressionMode.Decompress))
         {
            CreateMap(gzipstream);
         }
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="BankCodeMapToValidationMethodCodeByBankCodeFile"/> class.
      /// </summary>
      /// <param name="fileName">Name of the file.</param>
      public BankCodeMapToValidationMethodCodeByBankCodeFile(string fileName)
      {
         FileName = fileName;
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="BankCodeMapToValidationMethodCodeByBankCodeFile"/> class.
      /// </summary>
      /// <param name="stream">The stream.</param>
      public BankCodeMapToValidationMethodCodeByBankCodeFile(Stream stream)
      {
         CreateMap(stream);
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="BankCodeMapToValidationMethodCodeByBankCodeFile"/> class.
      /// </summary>
      /// <param name="streamReader">The stream reader.</param>
      public BankCodeMapToValidationMethodCodeByBankCodeFile(StreamReader streamReader)
      {
         CreateMap(streamReader);
      }

      /// <summary>
      /// Resolves the check method code for a given bank code.
      /// </summary>
      /// <param name="bankCode">The bank code.</param>
      /// <returns></returns>
      public string Resolve(string bankCode)
      {
         if (map == null)
            CreateMap();

         return map.ContainsKey(bankCode) ? map[bankCode] : null;
      }

      private void CreateMap()
      {
         using (var streamReader = File.OpenText(FileName))
         {
            CreateMap(streamReader);
         }
      }

      private void CreateMap(Stream stream)
      {
         using (var streamReader = new StreamReader(stream, Encoding.UTF8))
         {
            CreateMap(streamReader);
         }
      }

      private void CreateMap(StreamReader streamReader)
      {
         Log.Debug("method called to register check method code with bank code");
         if (!String.IsNullOrEmpty(FileName))
            Log.DebugFormat("file name: {0}", FileName);
         else
            Log.Debug("registering via stream");

         lock (this)
         {
            if (map != null)
               return;

            var newMap = new Dictionary<string, string>();

            while (!streamReader.EndOfStream)
            {
               var oneLine = streamReader.ReadLine();
               if (oneLine == null)
                  break;
               if (oneLine.Length != 168)
                  throw new InvalidOperationException(String.Format("Line length doesn't meet the needs of 168 characters. ({0} - {1})", oneLine, oneLine.Length));

               var bankCode = oneLine.Substring(0, 8);
               var checkMethodCode = oneLine.Substring(150, 2);
               newMap[bankCode] = checkMethodCode;
            }

            Log.DebugFormat("registered {0} bank codes with check method codes", newMap.Count);

            map = newMap;
         }
      }
   }
}
