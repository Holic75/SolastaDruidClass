using SolastaModApi;
using SolastaModApi.Extensions;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using HarmonyLib;

namespace SolastaDruidClass
{

    //Level 2 - equavalent with wildfire level 2
    //Wayfarer spirit companion - air based version of wildfire spirit
    //Focusing on movement rather than fire damage
    //Gust attack to shove enemies
    // similar teleport without fire damage

    //
    //Level 6 - equavalent with land level 6
    ////Give caster extra movement longer jump and restrained immunity etc
    // 

    //Level 10 - equavalent with stars level 10
    //flight while spirit is active,  
    //
    // 
    //Level 14 - equavalent with stars level 14
    //resistant to damage  ( make caster harder to hit while spirit is active



    public static class DruidSubClassCircleOfWanderers
    {
        const string DruidSubClassCircleOfWanderersName = "DruidSubclassCircleOfWanderers";
        const string DruidSubClassCircleOfWanderersGuid = "3d08c24e-f16f-4c57-ae30-ce02084c5077";

        public static void BuildandAddSubclass()
        {
            var subclassGuiPresentation = new GuiPresentationBuilder(
                    "Subclass/&DruidSubclassCircleOfWanderersDescription",
                    "Subclass/&DruidSubclassCircleOfWanderersTitle")
                    .SetSpriteReference(DatabaseHelper.CharacterSubclassDefinitions.TraditionLoremaster.GuiPresentation.SpriteReference)
                    .Build();

            var definition = new CharacterSubclassDefinitionBuilder(DruidSubClassCircleOfWanderersName, DruidSubClassCircleOfWanderersGuid);
            definition.SetGuiPresentation(subclassGuiPresentation)
            // circle of Wanderers level 2 
            .AddFeatureAtLevel(WanderersAutopreparedSpellsBuilder.WanderersAutopreparedSpells, 2)
            .AddFeatureAtLevel(SummonWandererSpiritPowerBuilder.SummonWandererSpirit, 2)
           
            // Wanderers's  level 6
            .AddFeatureAtLevel(WanderersFeatureSetBuilder.WanderersFeatureSet, 6)
            //   level 10
            .AddFeatureAtLevel(WanderersFeatureSet_level10Builder.WanderersFeatureSet_level10, 10)
             //    level 14
             .AddFeatureAtLevel(WanderersFeatureSet_level14Builder.WanderersFeatureSet_level14, 14)
             // level 18
             .AddFeatureAtLevel(SummonWandererSpiritPower_5Builder.SummonWandererSpiritPower_5,18)
           .AddToDB();

        }

    }
        internal class WanderersFeatureSetBuilder : BaseDefinitionBuilder<FeatureDefinitionFeatureSet>
        {
            const string WanderersFeatureSetName = "WanderersFeatureSet";
            const string WanderersFeatureSetGuid = "f24f5bcf-2ad0-4b20-b748-a4c45aff2ea7";

            protected WanderersFeatureSetBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetGreenmageWardenOfTheForest, name, guid)
            {
                Definition.GuiPresentation.Title = "Feat/&WanderersFeatureSetTitle";
                Definition.GuiPresentation.Description = "Feat/&WanderersFeatureSetDescription";

                Definition.FeatureSet.Clear(); 
                  Definition.FeatureSet.Add(SummonWandererSpiritPower_2Builder.SummonWandererSpiritPower_2);
                Definition.FeatureSet.Add(DatabaseHelper.FeatureDefinitionMovementAffinitys.MovementAffinityBootsOfStriding);
            Definition.FeatureSet.Add(DatabaseHelper.FeatureDefinitionConditionAffinitys.ConditionAffinityRestrainedmmunity); 

        }

            public static FeatureDefinitionFeatureSet CreateAndAddToDB(string name, string guid)
                => new WanderersFeatureSetBuilder(name, guid).AddToDB();

            public static FeatureDefinitionFeatureSet WanderersFeatureSet = CreateAndAddToDB(WanderersFeatureSetName, WanderersFeatureSetGuid);
        }

    internal class WanderersFeatureSet_level10Builder : BaseDefinitionBuilder<FeatureDefinitionFeatureSet>
    {
        const string WanderersFeatureSet_level10Name = "WanderersFeatureSet_level10";
        const string WanderersFeatureSet_level10Guid = "0991c151-05f9-4419-9a32-bfca3277cef2";

        protected WanderersFeatureSet_level10Builder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetGreenmageWardenOfTheForest, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&WanderersFeatureSet_level10Title";
            Definition.GuiPresentation.Description = "Feat/&WanderersFeatureSet_level10Description";

            Definition.FeatureSet.Clear();
            Definition.FeatureSet.Add(SummonWandererSpiritPower_3Builder.SummonWandererSpiritPower_3); 

        }

        public static FeatureDefinitionFeatureSet CreateAndAddToDB(string name, string guid)
            => new WanderersFeatureSet_level10Builder(name, guid).AddToDB();

        public static FeatureDefinitionFeatureSet WanderersFeatureSet_level10 = CreateAndAddToDB(WanderersFeatureSet_level10Name, WanderersFeatureSet_level10Guid);
    }

    internal class WanderersFeatureSet_level14Builder : BaseDefinitionBuilder<FeatureDefinitionFeatureSet>
    {
        const string WanderersFeatureSet_level14Name = "WanderersFeatureSet_level14";
        const string WanderersFeatureSet_level14Guid = "b4adcdb1-533a-4996-b48d-59fd682cdf68";

        protected WanderersFeatureSet_level14Builder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetGreenmageWardenOfTheForest, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&WanderersFeatureSet_level14Title";
            Definition.GuiPresentation.Description = "Feat/&WanderersFeatureSet_level14Description";

            Definition.FeatureSet.Clear();
            Definition.FeatureSet.Add(SummonWandererSpiritPower_4Builder.SummonWandererSpiritPower_4); 

        }

        public static FeatureDefinitionFeatureSet CreateAndAddToDB(string name, string guid)
            => new WanderersFeatureSet_level14Builder(name, guid).AddToDB();

        public static FeatureDefinitionFeatureSet WanderersFeatureSet_level14 = CreateAndAddToDB(WanderersFeatureSet_level14Name, WanderersFeatureSet_level14Guid);
    }
    public class WanderersAutopreparedSpellsBuilder : BaseDefinitionBuilder<FeatureDefinitionAutoPreparedSpells>
        {
            const string WanderersAutopreparedSpellsName = "WanderersAutopreparedSpells";
            const string WanderersAutopreparedSpellsGuid = "b1acb100-e7ff-46ff-8c3a-10076f3e7734";

            protected WanderersAutopreparedSpellsBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionAutoPreparedSpellss.AutoPreparedSpellsDomainBattle, name, guid)
            {


                Definition.GuiPresentation.Title = "Feat/&WanderersAutoPreparedSpellsTitle";
                Definition.GuiPresentation.Description = "Feat/&WanderersAutoPreparedSpellsDescription";


                FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_3 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
                autoPreparedSpellsGroup_Level_3.ClassLevel = 3;
                autoPreparedSpellsGroup_Level_3.SpellsList = (new List<SpellDefinition> {
                 //   DatabaseHelper.SpellDefinitions.Invisibility
                 DatabaseHelper.SpellDefinitions.Blur
                 ,DatabaseHelper.SpellDefinitions.MistyStep
                 //,spikegrowth
                 });

                FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_5 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
                autoPreparedSpellsGroup_Level_5.ClassLevel = 5;
                autoPreparedSpellsGroup_Level_5.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.Fly
               ,DatabaseHelper.SpellDefinitions.Haste
           });


                FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_7 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
                autoPreparedSpellsGroup_Level_7.ClassLevel = 7;
                autoPreparedSpellsGroup_Level_7.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.FreedomOfMovement
               ,DatabaseHelper.SpellDefinitions.DimensionDoor 
           });

                FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_9 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
                autoPreparedSpellsGroup_Level_9.ClassLevel = 9;
                autoPreparedSpellsGroup_Level_9.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.HoldMonster
               ,DatabaseHelper.SpellDefinitions.Banishment
           });


                CharacterClassDefinition Druid = DatabaseRepository.GetDatabase<CharacterClassDefinition>().TryGetElement("DHDruid", "a2112af0-636f-4b72-acdc-07c921bcea6d");

                //const string DruidClassName = "DHDruid";
                // const string DruidClassGuid = "a2112af0-636f-4b72-acdc-07c921bcea6d";
                Definition.SetSpellcastingClass(Druid);
                Definition.AutoPreparedSpellsGroups.Clear();
                Definition.AutoPreparedSpellsGroups.AddRange(new List<FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup>
                {
               autoPreparedSpellsGroup_Level_3,
               autoPreparedSpellsGroup_Level_5,
               autoPreparedSpellsGroup_Level_7,
               autoPreparedSpellsGroup_Level_9
                });

            }


            public static FeatureDefinitionAutoPreparedSpells CreateAndAddToDB(string name, string guid)
                => new WanderersAutopreparedSpellsBuilder(name, guid).AddToDB();

            public static FeatureDefinitionAutoPreparedSpells WanderersAutopreparedSpells = CreateAndAddToDB(WanderersAutopreparedSpellsName, WanderersAutopreparedSpellsGuid);
        }











 

















}
