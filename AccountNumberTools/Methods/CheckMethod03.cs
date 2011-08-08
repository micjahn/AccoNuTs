//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

namespace AccountNumberTools.Methods
{
   internal class CheckMethod03 : CheckMethodModuloBase
   {
      public CheckMethod03()
      {
         WeightMask = "21";
         Modulo = 10;
      }
   }
}
