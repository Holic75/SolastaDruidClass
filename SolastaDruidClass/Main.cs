using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using UnityModManagerNet;
using SolastaModApi;
using SolastaModApi.Extensions;
using ModKit;
using ModKit.Utility;
using System.Collections.Generic;
using HarmonyLib;

namespace SolastaDruidClass
{
    public static class Main
    {
        public static readonly string MOD_FOLDER = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        [Conditional("DEBUG")]
        internal static void Log(string msg) => Logger.Log(msg);
        internal static void Error(Exception ex) => Logger?.Error(ex.ToString());
        internal static void Error(string msg) => Logger?.Error(msg);
        internal static void Warning(string msg) => Logger?.Warning(msg);
        internal static UnityModManager.ModEntry.ModLogger Logger { get; private set; }
        internal static MenuManager Menu { get; private set; }


        internal static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {

                Logger = modEntry.Logger;

                Translations.Load(MOD_FOLDER);

                var harmony = new Harmony(modEntry.Info.Id);
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception ex)
            {
                Error(ex);
                throw;
            }

            return true;
        }

        internal static void OnGameReady()
        {
            DruidClassBuilder.BuildAndAddClassToDB();


            /*StockUnitDescription druidstaff_stock = new StockUnitDescription();
            druidstaff_stock.SetInitialized(true);
            druidstaff_stock.SetItemDefinition(DH_StaffOfWoodlandsBuilder.DH_StaffOfWoodlands);
            druidstaff_stock.SetStackCount(1);
            druidstaff_stock.SetInitialAmount(1);
            druidstaff_stock.SetMaxAmount(1);
            druidstaff_stock.SetReassortAmount(1);
            druidstaff_stock.SetReassortRateType(RuleDefinitions.DurationType.Day);
            druidstaff_stock.SetReassortRateValue(1);
            druidstaff_stock.SetMinAmount(1);

            var halman = DatabaseHelper.MerchantDefinitions.Store_Merchant_Antiquarians_Halman_Summer;

            halman.StockUnitDescriptions.Add(druidstaff_stock);*/
        }



        public static Guid ModGuidNamespace = new Guid("4e224e9c-dbee-44a0-b6b3-47bff8be8ec0");
        

    }

}

