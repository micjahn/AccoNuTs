//
//   Project:           AccountNumberTools - Tools for the work with account numbers
//   Project:           $URL$
//   Id:                $Id$
//
//   Copyright © 2011 Michael Jahn
//
//   This Software is weak copyleft open source. Please read the License.txt for details.
//

namespace AccountNumberTools.AccountNumber.Validation.Methods
{
   internal class ValidationMethod05 : ValidationMethodModuloBase
   {
      public ValidationMethod05()
      {
         WeightMask = "731";
         Modulo = 10;
      }
   }
}
