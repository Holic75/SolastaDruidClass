using SolastaModApi;
using SolastaModApi.Extensions;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using HarmonyLib;

namespace SolastaDruidClass
{

    //Similar to symbiotic entity, 
    //          Shepards spirit totem, 
    //          circle of spirits, 
    //       circle of the shifter
    //
    //   Level 2
    //3forms to choose from
    //
    //Best/boar defence
    //Wolf/tiger attack
    //Stag/etc support -> limited 10min battle aura
    //Advantage on con savs
    //
    //Advantage on any interaction with beasts/limited form of animalfriendship,maybe 1 or 10 minutes?
    //Level 6
    //Extra attack in line with moon druid getting wildshpaes with multi attack
    //Or add beast features like pack tactics, multi attack , spider climb , charge etc
    //
    //Level 10
    //Two forms active at the same time
    //
    //Level 14
    //Status immunities similar to spores
    //Or damage resistance like stars
    //


    public static class DruidSubClassCircleOfShifters
    {
        const string DruidSubClassCircleOfShiftersName = "DruidSubclassCircleOfShifters";
        const string DruidSubClassCircleOfShiftersGuid = "fed33975-da89-482d-bd4c-3b95ab914d8a";

        public static void BuildandAddSubclass()
        {
            var subclassGuiPresentation = new GuiPresentationBuilder(
                    "Subclass/&DruidSubclassCircleOfShiftersDescription",
                    "Subclass/&DruidSubclassCircleOfShiftersTitle")
                    .SetSpriteReference(DatabaseHelper.CharacterSubclassDefinitions.RangerShadowTamer.GuiPresentation.SpriteReference)
                    .Build();

            var definition = new CharacterSubclassDefinitionBuilder(DruidSubClassCircleOfShiftersName, DruidSubClassCircleOfShiftersGuid);
            definition.SetGuiPresentation(subclassGuiPresentation)
            // circle of Shifters level 2 
            .AddFeatureAtLevel(ShiftersAutopreparedSpellsBuilder.ShiftersAutopreparedSpells, 2)
            .AddFeatureAtLevel(ShiftersFeatureSetBuilder.ShiftersFeatureSet, 2)

            // Shifters's  level 6
            .AddFeatureAtLevel(ShiftersFeatureSetBuilder.ShiftersFeatureSet, 6)
            //   level 10
            .AddFeatureAtLevel(ShiftersFeatureSet_level10Builder.ShiftersFeatureSet_level10, 10)
             //    level 14
             .AddFeatureAtLevel(ShiftersFeatureSet_level14Builder.ShiftersFeatureSet_level14, 14)
             // level 18
        //     .AddFeatureAtLevel(., 18)
           .AddToDB();

        }

    }
    internal class ShiftersFeatureSetBuilder : BaseDefinitionBuilder<FeatureDefinitionFeatureSet>
    {
        const string ShiftersFeatureSetName = "ShiftersFeatureSet";
        const string ShiftersFeatureSetGuid = "4c7e2e4f-92f6-48b1-8c51-70e7fc53bfce";

        protected ShiftersFeatureSetBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetGreenmageWardenOfTheForest, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&ShiftersFeatureSetTitle";
            Definition.GuiPresentation.Description = "Feat/&ShiftersFeatureSetDescription";

            Definition.FeatureSet.Clear();
            Definition.FeatureSet.Add(SummonShifterForm_WolfFormPowerBuilder.SummonShifterForm_WolfForm);
            Definition.FeatureSet.Add(SummonShifterForm_BearFormPowerBuilder.SummonShifterForm_BearForm);
            Definition.FeatureSet.Add(SummonShifterForm_StagFormPowerBuilder.SummonShifterForm_StagForm);

        }

        public static FeatureDefinitionFeatureSet CreateAndAddToDB(string name, string guid)
            => new ShiftersFeatureSetBuilder(name, guid).AddToDB();

        public static FeatureDefinitionFeatureSet ShiftersFeatureSet = CreateAndAddToDB(ShiftersFeatureSetName, ShiftersFeatureSetGuid);
    }

    internal class ShiftersFeatureSet_level6Builder : BaseDefinitionBuilder<FeatureDefinitionFeatureSet>
    {
        const string ShiftersFeatureSet_level6Name = "ShiftersFeatureSet_level6";
        const string ShiftersFeatureSet_level6Guid = "39f68e37-f399-4fa7-9416-bc310d05642d";

        protected ShiftersFeatureSet_level6Builder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetGreenmageWardenOfTheForest, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&ShiftersFeatureSet_level6Title";
            Definition.GuiPresentation.Description = "Feat/&ShiftersFeatureSet_level6Description";

            Definition.FeatureSet.Clear();
            Definition.FeatureSet.Add(DatabaseHelper.FeatureDefinitionAttackModifiers.AttackModifierMartialSpellBladeMagicWeapon);
            //Definition.FeatureSet.Add(DatabaseHelper);
            Definition.FeatureSet.Add(DatabaseHelper.FeatureDefinitionAbilityCheckAffinitys.AbilityCheckAffinityGreenmageArmor);
            Definition.FeatureSet.Add(DatabaseHelper.FeatureDefinitionAbilityCheckAffinitys.AbilityCheckAffinityKeenSight);

        }

        public static FeatureDefinitionFeatureSet CreateAndAddToDB(string name, string guid)
            => new ShiftersFeatureSet_level6Builder(name, guid).AddToDB();

        public static FeatureDefinitionFeatureSet ShiftersFeatureSet_level6 = CreateAndAddToDB(ShiftersFeatureSet_level6Name, ShiftersFeatureSet_level6Guid);
    }

    internal class ShiftersFeatureSet_level10Builder : BaseDefinitionBuilder<FeatureDefinitionFeatureSet>
    {
        const string ShiftersFeatureSet_level10Name = "ShiftersFeatureSet_level10";
        const string ShiftersFeatureSet_level10Guid = "65c102e3-014a-4f3e-8b3b-78036168ea78";

        protected ShiftersFeatureSet_level10Builder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetGreenmageWardenOfTheForest, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&ShiftersFeatureSet_level10Title";
            Definition.GuiPresentation.Description = "Feat/&ShiftersFeatureSet_level10Description";

            Definition.FeatureSet.Clear();
            //  Definition.FeatureSet.Add(DatabaseHelper.FeatureDefinitionAttributeModifiers.AttributeModifierDomainBattleExtraAttack);
            Definition.FeatureSet.Add(SummonShifterForm_WolfAndBearFormPowerBuilder.SummonShifterForm_WolfAndBearForm);
            Definition.FeatureSet.Add(SummonShifterForm_WolfAndStagFormPowerBuilder.SummonShifterForm_WolfAndStagForm);
            Definition.FeatureSet.Add(SummonShifterForm_BearAndStagFormPowerBuilder.SummonShifterForm_BearAndStagForm);

        }

        public static FeatureDefinitionFeatureSet CreateAndAddToDB(string name, string guid)
            => new ShiftersFeatureSet_level10Builder(name, guid).AddToDB();

        public static FeatureDefinitionFeatureSet ShiftersFeatureSet_level10 = CreateAndAddToDB(ShiftersFeatureSet_level10Name, ShiftersFeatureSet_level10Guid);
    }

    internal class ShiftersFeatureSet_level14Builder : BaseDefinitionBuilder<FeatureDefinitionFeatureSet>
    {
        const string ShiftersFeatureSet_level14Name = "ShiftersFeatureSet_level14";
        const string ShiftersFeatureSet_level14Guid = "ee0f0418-4fea-4910-86e4-8640c4234e40";

        protected ShiftersFeatureSet_level14Builder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetGreenmageWardenOfTheForest, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&ShiftersFeatureSet_level14Title";
            Definition.GuiPresentation.Description = "Feat/&ShiftersFeatureSet_level14Description";

            Definition.FeatureSet.Clear();
           // Definition.FeatureSet.Add();
        }

        public static FeatureDefinitionFeatureSet CreateAndAddToDB(string name, string guid)
            => new ShiftersFeatureSet_level14Builder(name, guid).AddToDB();

        public static FeatureDefinitionFeatureSet ShiftersFeatureSet_level14 = CreateAndAddToDB(ShiftersFeatureSet_level14Name, ShiftersFeatureSet_level14Guid);
    }


    internal class CircleOfShiftersCantripsBuilder : BaseDefinitionBuilder<FeatureDefinitionBonusCantrips>
    {
        const string CircleOfShiftersCantripsName = "CircleOfShiftersCantrips";
        const string CircleOfShiftersCantripsGuid = "12116d65-0ca8-455f-b791-6378a49fbf36";

        protected CircleOfShiftersCantripsBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionBonusCantripss.BonusCantripsDomainOblivion, name, guid)
        {

            Definition.GuiPresentation.Title = "Feat/&CircleOfShiftersCantripsTitle";
            Definition.GuiPresentation.Description = "Feat/&CircleOfShiftersCantripsDescription"; 

            Definition.BonusCantrips.Clear(); 
            Definition.BonusCantrips.Add(EnhanceAbilityCantripBuilder.EnhanceAbilityCantrip);

        }

        public static FeatureDefinitionBonusCantrips CreateAndAddToDB(string name, string guid)
            => new CircleOfShiftersCantripsBuilder(name, guid).AddToDB();

        public static FeatureDefinitionBonusCantrips CircleOfShiftersCantrips = CreateAndAddToDB(CircleOfShiftersCantripsName, CircleOfShiftersCantripsGuid);


    }

    internal class EnhanceAbilityCantripBuilder : BaseDefinitionBuilder<SpellDefinition>
    {
        const string EnhanceAbilityCantripName = "EnhanceAbilityCantrip";
        const string EnhanceAbilityCantripGuid = "f0559110-8a95-4426-88fc-28dd9b5b3b7f";

        protected EnhanceAbilityCantripBuilder(string name, string guid) : base(DatabaseHelper.SpellDefinitions.EnhanceAbility, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&EnhanceAbilityCantripTitle";
            Definition.GuiPresentation.Description = "Feat/&EnhanceAbilityCantripDescription";
             
            Definition.SetSpellLevel(0);


        }

        public static SpellDefinition CreateAndAddToDB(string name, string guid)
            => new EnhanceAbilityCantripBuilder(name, guid).AddToDB();

        public static SpellDefinition EnhanceAbilityCantrip = CreateAndAddToDB(EnhanceAbilityCantripName, EnhanceAbilityCantripGuid);
    }
	
	
	
	
    public class ShiftersAutopreparedSpellsBuilder : BaseDefinitionBuilder<FeatureDefinitionAutoPreparedSpells>
    {
        const string ShiftersAutopreparedSpellsName = "ShiftersAutopreparedSpells";
        const string ShiftersAutopreparedSpellsGuid = "ee7bc6b5-6aca-4251-805c-a6b7ce9e2f68";

        protected ShiftersAutopreparedSpellsBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionAutoPreparedSpellss.AutoPreparedSpellsDomainBattle, name, guid)
        {


            Definition.GuiPresentation.Title = "Feat/&ShiftersAutoPreparedSpellsTitle";
            Definition.GuiPresentation.Description = "Feat/&ShiftersAutoPreparedSpellsDescription";


            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_3 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_3.ClassLevel = 3;
            autoPreparedSpellsGroup_Level_3.SpellsList = (new List<SpellDefinition> {
                 //   DatabaseHelper.SpellDefinitions.Invisibility
                 DatabaseHelper.SpellDefinitions.EnhanceAbility
                 ,DatabaseHelper.SpellDefinitions.SpiderClimb
                 //,spikegrowth
                 });

            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_5 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_5.ClassLevel = 5;
            autoPreparedSpellsGroup_Level_5.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.VampiricTouchIntelligence
               ,DatabaseHelper.SpellDefinitions.ConjureAnimals
           });


            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_7 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_7.ClassLevel = 7;
            autoPreparedSpellsGroup_Level_7.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.Stoneskin
               ,DatabaseHelper.SpellDefinitions.Fly
           });

            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_9 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_9.ClassLevel = 9;
            autoPreparedSpellsGroup_Level_9.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.InsectPlague
               ,DatabaseHelper.SpellDefinitions.MindTwist
           });


            CharacterClassDefinition Druid = DatabaseRepository.GetDatabase<CharacterClassDefinition>().TryGetElement("Druid", "a2112af0-636f-4b72-acdc-07c921bcea6d");

            //const string DruidClassName = "Druid";
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
            => new ShiftersAutopreparedSpellsBuilder(name, guid).AddToDB();

        public static FeatureDefinitionAutoPreparedSpells ShiftersAutopreparedSpells = CreateAndAddToDB(ShiftersAutopreparedSpellsName, ShiftersAutopreparedSpellsGuid);
    }





}
