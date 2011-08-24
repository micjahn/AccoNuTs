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

using AccountNumberTools.Common.Internals;

namespace AccountNumberTools.AccountNumber.Methods
{
   internal class CheckMethod00 : CheckMethodModuloBase
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="CheckMethod00"/> class.
      /// </summary>
      public CheckMethod00()
      {
         WeightMask = "21";
         Modulo = 10;
      }

      /// <summary>
      /// Used to make some modifications to the product of digit and weight before is added to the sum
      /// </summary>
      /// <param name="product">The product.</param>
      /// <returns></returns>
      override protected int ModifyProductBeforeSum(int product)
      {
         return CheckMethodsTools.CalculateCrossSum(product);
      }
   }
}
