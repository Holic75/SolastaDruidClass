using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using UnityModManagerNet;
using SolastaModApi;
using ModKit;
using ModKit.Utility;
using System.Collections.Generic;


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
        internal static ModManager<Core, Settings> Mod { get; private set; }
        internal static MenuManager Menu { get; private set; }
        internal static Settings Settings { get { return Mod.Settings; } }

        internal static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();

                Logger = modEntry.Logger;

                Translations.Load(MOD_FOLDER);

                Mod = new ModManager<Core, Settings>();
                Mod.Enable(modEntry, assembly);
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
            SummoningWildshapeViaPolymorph.Create();
            DruidClassBuilder.BuildAndAddClassToDB();


            CharacterClassDefinition Druid = DatabaseRepository.GetDatabase<CharacterClassDefinition>().TryGetElement("DHDruid", "a2112af0-636f-4b72-acdc-07c921bcea6d");


            var itemlist = new List<ItemDefinition>
            {
            DatabaseHelper.ItemDefinitions.WandOfLightningBolts,
            //DatabaseHelper.ItemDefinitions.StaffOfMetis,              // devs removed class restrictions for HF 1.1.11 so not needed now
            DatabaseHelper.ItemDefinitions.StaffOfHealing,
            DatabaseHelper.ItemDefinitions.StaffOfFire,
            DatabaseHelper.ItemDefinitions.GreenmageArmor,
            DatabaseHelper.ItemDefinitions.ArcaneShieldstaff,
            DatabaseHelper.ItemDefinitions.WizardClothes_Alternate
            };

            foreach (ItemDefinition item in itemlist)
            {
                // if (item.RequiredAttunementClasses != null)
                // {
                item.RequiredAttunementClasses.Add(Druid);
                // };
            };
        }



        public static Guid ModGuidNamespace = new Guid("4e224e9c-dbee-44a0-b6b3-47bff8be8ec0");
        

    }

}

