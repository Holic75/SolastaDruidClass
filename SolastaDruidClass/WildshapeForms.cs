using SolastaModApi;
using SolastaModApi.Extensions;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using HarmonyLib;


namespace SolastaDruidClass
{

    // CR 0.125:  poisonous_snake, flying snake, eagle matriarch, 
    // CR 0.25 : wolf, 						//starving wolf
    // CR 0.50 : AlphaWolf, BadlandsSpider, black bear
    // CR 1.00 : Dire wolf, giant eagle, brown bear
    // CR 2.00 : tiger_drake, deepspider, giant beetle

    internal class WildshapeOptionFamilyBuilder : BaseDefinitionBuilder<CharacterFamilyDefinition>
    {
        const string WildshapeOptionFamilyName = "WildshapeOption";
        const string WildshapeOptionFamilyGuid = "3cd1ea83-3cd4-4c13-8be6-83bb778063b4";

        protected WildshapeOptionFamilyBuilder(string name, string guid) : base(DatabaseHelper.CharacterFamilyDefinitions.Beast, name, guid)
        {

             


        }

        public static CharacterFamilyDefinition CreateAndAddToDB(string name, string guid)
            => new WildshapeOptionFamilyBuilder(name, guid).AddToDB();

        public static CharacterFamilyDefinition WildshapeOptionFamily = CreateAndAddToDB(WildshapeOptionFamilyName, WildshapeOptionFamilyGuid);


    }



    internal class WildShaped_WolfBuilder : BaseDefinitionBuilder<MonsterDefinition>
    {
        const string WildShaped_WolfName = "WildShaped_Wolf";
        const string WildShaped_WolfGuid = "288c3fda-d6a3-47ef-acd8-0b52140647c8";

        protected WildShaped_WolfBuilder(string name, string guid) : base(DatabaseHelper.MonsterDefinitions.Wolf, name, guid)
        {
            Definition.SetDefaultFaction(DatabaseHelper.FactionDefinitions.Party.Name);
            Definition.SetFullyControlledWhenAllied(true);
            //   
            Definition.SetCharacterFamily(WildshapeOptionFamilyBuilder.WildshapeOptionFamily.Name);

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
            Definition.SetCharacterFamily(WildshapeOptionFamilyBuilder.WildshapeOptionFamily.Name);


            Definition.Features.Clear();
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionSenses.SenseNormalVision);
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionMoveModes.MoveModeMove8);
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionAbilityCheckAffinitys.AbilityCheckAffinityKeenHearing);
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionAbilityCheckAffinitys.AbilityCheckAffinityKeenSmell);
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionCombatAffinitys.CombatAffinityPackTactics);

            Definition.AttackIterations.Clear();
            MonsterAttackIteration monsterAttackIteration = new MonsterAttackIteration();

            Traverse.Create(monsterAttackIteration).Field("monsterAttackDefinition").SetValue(DatabaseHelper.MonsterAttackDefinitions.Attack_Wolf_Bite);

            Traverse.Create(monsterAttackIteration).Field("number").SetValue(1);

            Definition.AttackIterations.AddRange(new List<MonsterAttackIteration> { monsterAttackIteration });
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
            Definition.SetCharacterFamily(WildshapeOptionFamilyBuilder.WildshapeOptionFamily.Name);

        }

        public static MonsterDefinition CreateAndAddToDB(string name, string guid)
            => new WildShaped_BadlandsSpiderBuilder(name, guid).AddToDB();

        public static MonsterDefinition WildShaped_BadlandsSpider = CreateAndAddToDB(WildShaped_BadlandsSpiderName, WildShaped_BadlandsSpiderGuid);


    }

    internal class WildShaped_BlackBearBuilder : BaseDefinitionBuilder<MonsterDefinition>
    {
        const string WildShaped_BlackBearName = "WildShaped_BlackBear";
        const string WildShaped_BlackBearGuid = "e1f3d2bb-7a93-4e52-b137-4da57c8f30b3";

        protected WildShaped_BlackBearBuilder(string name, string guid) : base(DatabaseHelper.MonsterDefinitions.BlackBear, name, guid)
        {
            Definition.SetDefaultFaction(DatabaseHelper.FactionDefinitions.Party.Name);
            Definition.SetFullyControlledWhenAllied(true);
            //   
            Definition.SetCharacterFamily(WildshapeOptionFamilyBuilder.WildshapeOptionFamily.Name);

        }

        public static MonsterDefinition CreateAndAddToDB(string name, string guid)
            => new WildShaped_BlackBearBuilder(name, guid).AddToDB();

        public static MonsterDefinition WildShaped_BlackBear = CreateAndAddToDB(WildShaped_BlackBearName, WildShaped_BlackBearGuid);


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
            Definition.SetCharacterFamily(WildshapeOptionFamilyBuilder.WildshapeOptionFamily.Name);

           
            
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
            Definition.SetCharacterFamily(WildshapeOptionFamilyBuilder.WildshapeOptionFamily.Name);

        }

        public static MonsterDefinition CreateAndAddToDB(string name, string guid)
            => new WildShaped_Giant_EagleBuilder(name, guid).AddToDB();

        public static MonsterDefinition WildShaped_Giant_Eagle = CreateAndAddToDB(WildShaped_Giant_EagleName, WildShaped_Giant_EagleGuid);


    }


    internal class WildShaped_BrownBearBuilder : BaseDefinitionBuilder<MonsterDefinition>
    {
        const string WildShaped_BrownBearName = "WildShaped_BrownBear";
        const string WildShaped_BrownBearGuid = "3fd71b7e-794b-491b-8116-c7ff6da387ea";

        protected WildShaped_BrownBearBuilder(string name, string guid) : base(DatabaseHelper.MonsterDefinitions.BrownBear, name, guid)
        {
            Definition.SetDefaultFaction(DatabaseHelper.FactionDefinitions.Party.Name);
            Definition.SetFullyControlledWhenAllied(true);
            //   
            Definition.SetCharacterFamily(WildshapeOptionFamilyBuilder.WildshapeOptionFamily.Name);

        }

        public static MonsterDefinition CreateAndAddToDB(string name, string guid)
            => new WildShaped_BrownBearBuilder(name, guid).AddToDB();

        public static MonsterDefinition WildShaped_BrownBear = CreateAndAddToDB(WildShaped_BrownBearName, WildShaped_BrownBearGuid);


    }


}