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
   internal class CheckMethod01 : CheckMethodModuloBase
   {
      public CheckMethod01()
      {
         WeightMask = "371";
      }
   }
}
