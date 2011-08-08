﻿//
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
   internal class CheckMethod06 : CheckMethodModuloBase
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="CheckMethod06"/> class.
      /// </summary>
      public CheckMethod06()
      {
         WeightMask = "234567";
         Modulo = 11;
      }

      /// <summary>
      /// Used to make some modifications to the product of digit and weight before is added to the sum
      /// </summary>
      /// <param name="sum">The sum.</param>
      /// <returns></returns>
      protected override int CalculateCheckDigitFromSum(int sum)
      {
         var result = base.CalculateCheckDigitFromSum(sum);
         if (result > 9)
            return 0;
         return result;
      }
   }
}
