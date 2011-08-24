//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

namespace AccountNumberTools.AccountNumber.Methods
{
   internal class CheckMethod07 : CheckMethodModuloBase
   {
      public CheckMethod07()
      {
         WeightMask = "23456789:";
         Modulo = 11;
      }
   }
}
