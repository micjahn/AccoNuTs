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

namespace AccountNumberTools.CreditCard.Contracts
{
   /// <summary>
   /// a list of identifiers for supported credit card networks
   /// </summary>
   public static class CreditCardNetwork
   {
      /// <summary>
      /// if that one is given the method will try to find the correct credit card network
      /// with the help of a table with credit card number prefixes
      /// </summary>
      public const string Automatic = "";
      /// <summary>
      /// 
      /// </summary>
      public const string AmericanExpress = "AMEX";
      /// <summary>
      /// 
      /// </summary>
      public const string Bankcard = "BACA";
      /// <summary>
      /// 
      /// </summary>
      public const string ChinaUnionPay = "CHUP";
      /// <summary>
      /// 
      /// </summary>
      public const string DinersClubCarteBlanche = "DCCB";
      /// <summary>
      /// 
      /// </summary>
      public const string DinersClubenRoute = "DCRO";
      /// <summary>
      /// 
      /// </summary>
      public const string DinersClubInternational = "DCIN";
      /// <summary>
      /// 
      /// </summary>
      public const string DinersClubUnitedStatesCanada = "DCUC";
      /// <summary>
      /// 
      /// </summary>
      public const string DiscoverCard = "DICA";
      /// <summary>
      /// 
      /// </summary>
      public const string InstaPayment = "INPA";
      /// <summary>
      /// 
      /// </summary>
      public const string JCB = "JCB";
      /// <summary>
      /// 
      /// </summary>
      public const string Laser = "LASE";
      /// <summary>
      /// 
      /// </summary>
      public const string Maestro = "MAES";
      /// <summary>
      /// 
      /// </summary>
      public const string MasterCard = "MACA";
      /// <summary>
      /// 
      /// </summary>
      public const string Solo = "SOLO";
      /// <summary>
      /// 
      /// </summary>
      public const string Switch = "SWIT";
      /// <summary>
      /// 
      /// </summary>
      public const string Visa = "VISA";
      /// <summary>
      /// 
      /// </summary>
      public const string VisaElectron = "VIEL";
      /// <summary>
      /// 
      /// </summary>
      public const string Voyager = "VOYA";

      /// <summary>
      /// 
      /// </summary>
      public const string FamilyVisa = "FAMV";
      /// <summary>
      /// 
      /// </summary>
      public const string FamilyAmericanExpress = "FAMA";
      /// <summary>
      /// 
      /// </summary>
      public const string FamilyMasterCard = "FAMM";
   }
}
