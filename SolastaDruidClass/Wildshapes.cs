using SolastaModApi;
using SolastaModApi.Extensions;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using HarmonyLib;


namespace SolastaDruidClass
{
    internal class WildShaped_WolfBuilder : BaseDefinitionBuilder<MonsterDefinition>
    {
        const string WildShaped_WolfName = "WildShaped_Wolf";
        const string WildShaped_WolfGuid = "288c3fda-d6a3-47ef-acd8-0b52140647c8";

        protected WildShaped_WolfBuilder(string name, string guid) : base(DatabaseHelper.MonsterDefinitions.Wolf, name, guid)
        {
            Definition.SetDefaultFaction(DatabaseHelper.FactionDefinitions.Party.Name);
            Definition.SetFullyControlledWhenAllied(true);
            //   

        }

        public static MonsterDefinition CreateAndAddToDB(string name, string guid)
            => new WildShaped_WolfBuilder(name, guid).AddToDB();

        public static MonsterDefinition WildShaped_Wolf = CreateAndAddToDB(WildShaped_WolfName, WildShaped_WolfGuid);


    }


}