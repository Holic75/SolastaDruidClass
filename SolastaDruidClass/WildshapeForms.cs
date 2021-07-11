using SolastaModApi;
using SolastaModApi.Extensions;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using HarmonyLib;


namespace SolastaDruidClass
{
	
										// CR 0.125:  poisonous_snake, flying snake, eagle matriarch, 
// CR 0.25 : wolf, 						//starving wolf
// CR 0.50 : AlphaWolf, BadlandsSpider, 
// CR 1.00 : Dire wolf, giant eagle,
										// CR 2.00 : tiger_drake, deepspider,

	
	
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


	internal class WildShaped_AlphaWolfBuilder : BaseDefinitionBuilder<MonsterDefinition>
    {
        const string WildShaped_AlphaWolfName = "WildShaped_AlphaWolf";
        const string WildShaped_AlphaWolfGuid = "7ba26ed3-443f-46ca-892b-bcdf4ad31b12";

        protected WildShaped_AlphaWolfBuilder(string name, string guid) : base(DatabaseHelper.MonsterDefinitions.AlphaWolf, name, guid)
        {
            Definition.SetDefaultFaction(DatabaseHelper.FactionDefinitions.Party.Name);
            Definition.SetFullyControlledWhenAllied(true);
            //   

        }

        public static MonsterDefinition CreateAndAddToDB(string name, string guid)
            => new WildShaped_AlphaWolfBuilder(name, guid).AddToDB();

        public static MonsterDefinition WildShaped_AlphaWolf = CreateAndAddToDB(WildShaped_AlphaWolfName, WildShaped_AlphaWolfGuid);


    }
	
	internal class WildShaped_BadlandsSpiderBuilder : BaseDefinitionBuilder<MonsterDefinition>
    {
        const string WildShaped_BadlandsSpiderName = "WildShaped_BadlandsSpider";
        const string WildShaped_BadlandsSpiderGuid = "c4892d10-a4de-48cd-a071-9525f33bd9e1";

        protected WildShaped_BadlandsSpiderBuilder(string name, string guid) : base(DatabaseHelper.MonsterDefinitions.BadlandsSpider, name, guid)
        {
            Definition.SetDefaultFaction(DatabaseHelper.FactionDefinitions.Party.Name);
            Definition.SetFullyControlledWhenAllied(true);
            //   

        }

        public static MonsterDefinition CreateAndAddToDB(string name, string guid)
            => new WildShaped_BadlandsSpiderBuilder(name, guid).AddToDB();

        public static MonsterDefinition WildShaped_BadlandsSpider = CreateAndAddToDB(WildShaped_BadlandsSpiderName, WildShaped_BadlandsSpiderGuid);


    }
	
	
	
	internal class WildShaped_DirewolfBuilder : BaseDefinitionBuilder<MonsterDefinition>
    {
        const string WildShaped_DirewolfName = "WildShaped_Direwolf";
        const string WildShaped_DirewolfGuid = "a7f0e7e3-1f93-449e-8ba2-717b9f883169";

        protected WildShaped_DirewolfBuilder(string name, string guid) : base(DatabaseHelper.MonsterDefinitions.Direwolf, name, guid)
        {
            Definition.SetDefaultFaction(DatabaseHelper.FactionDefinitions.Party.Name);
            Definition.SetFullyControlledWhenAllied(true);
            //   

        }

        public static MonsterDefinition CreateAndAddToDB(string name, string guid)
            => new WildShaped_DirewolfBuilder(name, guid).AddToDB();

        public static MonsterDefinition WildShaped_Direwolf = CreateAndAddToDB(WildShaped_DirewolfName, WildShaped_DirewolfGuid);


    }
	
	
	
	internal class WildShaped_Giant_EagleBuilder : BaseDefinitionBuilder<MonsterDefinition>
    {
        const string WildShaped_Giant_EagleName = "WildShaped_Giant_Eagle";
        const string WildShaped_Giant_EagleGuid = "be3292ff-66ef-4a39-89a0-1ebf1d8c04de";

        protected WildShaped_Giant_EagleBuilder(string name, string guid) : base(DatabaseHelper.MonsterDefinitions.Giant_Eagle, name, guid)
        {
            Definition.SetDefaultFaction(DatabaseHelper.FactionDefinitions.Party.Name);
            Definition.SetFullyControlledWhenAllied(true);
            //   

        }

        public static MonsterDefinition CreateAndAddToDB(string name, string guid)
            => new WildShaped_Giant_EagleBuilder(name, guid).AddToDB();

        public static MonsterDefinition WildShaped_Giant_Eagle = CreateAndAddToDB(WildShaped_Giant_EagleName, WildShaped_Giant_EagleGuid);


    }
	
	



}