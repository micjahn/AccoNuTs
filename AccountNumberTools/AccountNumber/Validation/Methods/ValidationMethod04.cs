﻿//
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
   internal class ValidationMethod04 : ValidationMethodModuloBase
   {
      public ValidationMethod04()
      {
         WeightMask = "234567";
         Modulo = 11;
      }
   }
}
