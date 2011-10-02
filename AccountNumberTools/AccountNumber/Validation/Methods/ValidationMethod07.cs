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
   internal class ValidationMethod07 : ValidationMethodModuloBase
   {
      public ValidationMethod07()
      {
         WeightMask = "23456789:";
         Modulo = 11;
      }
   }
}
