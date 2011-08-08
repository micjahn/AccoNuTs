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
using System.Reflection;
using System.IO;

using NUnit.Framework;

namespace AccountNumberTools.Tests
{
   /// <summary>
   /// config class for the common configuration of the nunit logging
   /// </summary>
   [SetUpFixture]
   public sealed class NUnitTestConfiguration
   {
      /// <summary>
      /// reconfigures log4net
      /// </summary>
      [SetUp]
      public void SetUp()
      {
         if (log4net.LogManager.GetRepository().Configured)
            log4net.LogManager.GetRepository().ResetConfiguration();
         log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(
            Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "log4net.config")));
      }
   }
}
