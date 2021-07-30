using SolastaModApi;
using SolastaModApi.Extensions;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using HarmonyLib;

namespace SolastaDruidClass
{
  
    public static class DruidSubClassCircleOfLand
    {
        const string DruidSubClassCircleOfLandName = "DruidSubclassCircleOfLand";
        const string DruidSubClassCircleOfLandGuid = "9ff4743d-015b-4a89-b2e4-cacd5866b153";

        public static void BuildandAddSubclass()
        {
            var subclassGuiPresentation = new GuiPresentationBuilder(
                    "Subclass/&DruidSubclassCircleOfLandDescription",
                    "Subclass/&DruidSubclassCircleOfLandTitle")
                    .SetSpriteReference(DatabaseHelper.CharacterSubclassDefinitions.TraditionGreenmage.GuiPresentation.SpriteReference)
                    .Build();

            var definition = new CharacterSubclassDefinitionBuilder(DruidSubClassCircleOfLandName, DruidSubClassCircleOfLandGuid);
                    definition.SetGuiPresentation(subclassGuiPresentation)
                    // circle of land level 2 extra spells
                    .AddFeatureAtLevel(NaturalRecoveryBuilder.NaturalRecovery, 2)  
                    .AddFeatureAtLevel(SubclassCircleSpellsBuilder.SubclassCircleSpells, 2)  
                    .AddFeatureAtLevel(SubclassExtraCantripBuilder.SubclassExtraCantrip,4) 
                    // land's stride
                    .AddFeatureAtLevel(LandsStrideFeatureSetBuilder.LandsStrideFeatureSet, 6)  
                    // nature's ward
                    .AddFeatureAtLevel(NaturesWardFeatureSetBuilder.NaturesWardFeatureSet, 10)
                    // nature's sanctuary 
                     .AddFeatureAtLevel(CircleOfLandCantripsBuilder.CircleOfLandCantrips, 14)  
                   .AddToDB();
             
        }
    }

    internal class NaturalRecoveryBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string Name = "NaturalRecoveryBuilder";
        const string Guid = "72bf9d07-8eb2-4e08-95a0-a217e8504a85";

        protected NaturalRecoveryBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionPowers.PowerWizardArcaneRecovery, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&NaturalRecoveryBuilderTitle";
           // Definition.GuiPresentation.Description = "Feature/&NaturalRecoveryBuilderDescription";

            //Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.MonsterDefinitions.Wolf.GuiPresentation.SpriteReference);



        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new NaturalRecoveryBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPower NaturalRecovery = CreateAndAddToDB(Name, Guid);
    }

    internal class SubclassExtraCantripBuilder : BaseDefinitionBuilder<FeatureDefinitionPointPool>
    {
        const string SubclassExtraCantripName = "SubclassExtraCantrip";
        const string SubclassExtraCantripGuid = "71b34c54-00ad-4b55-9174-07fc4f979fcb";

        protected SubclassExtraCantripBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionPointPools.PointPoolLoreMasterArcaneLore, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&SubclassExtraCantripTitle";
            Definition.GuiPresentation.Description = "Feat/&SubclassExtraCantripDescription";

            Definition.SetPoolAmount(1); 

        }

        public static FeatureDefinitionPointPool CreateAndAddToDB(string name, string guid)
            => new SubclassExtraCantripBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPointPool SubclassExtraCantrip = CreateAndAddToDB(SubclassExtraCantripName, SubclassExtraCantripGuid);
    }
    internal class CircleOfLandCantripsBuilder : BaseDefinitionBuilder<FeatureDefinitionBonusCantrips>
    {
        const string CircleOfLandCantripsName = "CircleOfLandCantrips";
        const string CircleOfLandCantripsGuid = "e1e96daa-1ce0-4d42-8aff-8c63657d21e5";

        protected CircleOfLandCantripsBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionBonusCantripss.BonusCantripsDomainOblivion, name, guid)
        {

            Definition.GuiPresentation.Title = "Feat/&CircleOfLandCantripsTitle";
            Definition.GuiPresentation.Description = "Feat/&CircleOfLandCantripsDescription";
            //Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.SpellDefinitions.MagicMissile.GuiPresentation.SpriteReference);

            Definition.BonusCantrips.Clear();
            //   Definition.BonusCantrips.Add(CommandProtectorConstructBuilder.CommandProtectorConstruct);
            //Definition.BonusCantrips.Add();
            Definition.BonusCantrips.Add(NaturesWardCantripBuilder.NaturesWardCantrip); 

        }

        public static FeatureDefinitionBonusCantrips CreateAndAddToDB(string name, string guid)
            => new CircleOfLandCantripsBuilder(name, guid).AddToDB();

        public static FeatureDefinitionBonusCantrips CircleOfLandCantrips = CreateAndAddToDB(CircleOfLandCantripsName, CircleOfLandCantripsGuid);


    }
    internal class LandsStrideFeatureSetBuilder : BaseDefinitionBuilder<FeatureDefinitionFeatureSet>
    {
        const string LandsStrideFeatureSetName = "LandsStrideFeatureSet";
        const string LandsStrideFeatureSetGuid = "efad62ce-35f4-4906-8459-990e19f154a5";

        protected LandsStrideFeatureSetBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetGreenmageWardenOfTheForest, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&LandsStrideFeatureSetTitle";
            Definition.GuiPresentation.Description = "Feat/&LandsStrideFeatureSetDescription";

            Definition.FeatureSet.Clear();
            Definition.FeatureSet.Add(SubclassEntangleImmunityBuilder.SubclassEntangleImmunity);
            Definition.FeatureSet.Add(SubclassMovementAffinitiesBuilder.SubclassMovementAffinities);
          //  Definition.FeatureSet.Add();
          // Definition.FeatureSet.Add();
        }

        public static FeatureDefinitionFeatureSet CreateAndAddToDB(string name, string guid)
            => new LandsStrideFeatureSetBuilder(name, guid).AddToDB();

        public static FeatureDefinitionFeatureSet LandsStrideFeatureSet = CreateAndAddToDB(LandsStrideFeatureSetName, LandsStrideFeatureSetGuid);
    }

    internal class NaturesWardFeatureSetBuilder : BaseDefinitionBuilder<FeatureDefinitionFeatureSet>
    {
        const string NaturesWardFeatureSetName = "NaturesWardFeatureSet";
        const string NaturesWardFeatureSetGuid = "d28098d3-5c9c-4e56-80b6-7c5ba381a42e";

        protected NaturesWardFeatureSetBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetGreenmageWardenOfTheForest, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&NaturesWardFeatureSetTitle";
            Definition.GuiPresentation.Description = "Feat/&NaturesWardFeatureSetDescription";

            Definition.FeatureSet.Clear();
            Definition.FeatureSet.Add(SubclassCharmImmunityBuilder.SubclassCharmImmunity);
            Definition.FeatureSet.Add(SubclassFrightenedImmunityBuilder.SubclassFrightenedImmunity);
            Definition.FeatureSet.Add(DatabaseHelper.FeatureDefinitionConditionAffinitys.ConditionAffinityPoisonImmunity);
            Definition.FeatureSet.Add(DatabaseHelper.FeatureDefinitionConditionAffinitys.ConditionAffinityDiseaseImmunity);
        }

        public static FeatureDefinitionFeatureSet CreateAndAddToDB(string name, string guid)
            => new NaturesWardFeatureSetBuilder(name, guid).AddToDB();

        public static FeatureDefinitionFeatureSet NaturesWardFeatureSet = CreateAndAddToDB(NaturesWardFeatureSetName, NaturesWardFeatureSetGuid);
    }


    internal class SubclassCircleSpellsBuilder : BaseDefinitionBuilder<FeatureDefinitionFeatureSet>
    {
        const string SubclassCircleSpellsName = "SubclassCircleSpells";
        const string SubclassCircleSpellsGuid = "698b6ea8-6e0e-4f06-98e3-814a7dc21e53";

        protected SubclassCircleSpellsBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionFeatureSets.TerrainTypeAffinityRangerNaturalExplorerChoice, name, guid)
        {
             Definition.GuiPresentation.Title = "Feat/&SubclassCircleSpellsTitle";
             Definition.GuiPresentation.Description = "Feat/&SubclassCircleSpellsDescription";

            Definition.FeatureSet.Clear();
            Definition.FeatureSet.Add(ArcticAutopreparedSpellsBuilder.ArcticAutopreparedSpells);
            Definition.FeatureSet.Add(CoastAutopreparedSpellsBuilder.CoastAutopreparedSpells);
            Definition.FeatureSet.Add(DesertAutopreparedSpellsBuilder.DesertAutopreparedSpells);
            Definition.FeatureSet.Add(ForestAutopreparedSpellsBuilder.ForestAutopreparedSpells);
            Definition.FeatureSet.Add(GrasslandAutopreparedSpellsBuilder.GrasslandAutopreparedSpells);
            Definition.FeatureSet.Add(MountainAutopreparedSpellsBuilder.MountainAutopreparedSpells);
            Definition.FeatureSet.Add(SwampAutopreparedSpellsBuilder.SwampAutopreparedSpells);
            Definition.FeatureSet.Add(UnderdarkAutopreparedSpellsBuilder.UnderdarkAutopreparedSpells);
         //   Definition.FeatureSet.Add(ArcticAutopreparedSpellsBuilder.ArcticAutopreparedSpells);
        }

        public static FeatureDefinitionFeatureSet CreateAndAddToDB(string name, string guid)
            => new SubclassCircleSpellsBuilder(name, guid).AddToDB();

        public static FeatureDefinitionFeatureSet SubclassCircleSpells = CreateAndAddToDB(SubclassCircleSpellsName, SubclassCircleSpellsGuid);
    }


    internal class SubclassMovementAffinitiesBuilder : BaseDefinitionBuilder<FeatureDefinitionMovementAffinity>
   {
       const string SubclassMovementAffinitiesName = "CircleLandSubclassMovementAffinity";
       const string SubclassMovementAffinitiesGuid = "9edd2200-4e0c-4f1e-a21e-edac6532e2b9";

       protected SubclassMovementAffinitiesBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionMovementAffinitys.MovementAffinityFreedomOfMovement, name, guid)
       {
           Definition.GuiPresentation.Title = "Feat/&LandSubclassMovementTitle";
           Definition.GuiPresentation.Description = "Feat/&LandSubclassMovementDescription";
       
            // entangle immune etc
            Definition.SetImmuneDifficultTerrain(true);
            Definition.SetMinimalBaseSpeed (0);
            Definition.SetHeavyArmorImmunity(false);

       }

       public static FeatureDefinitionMovementAffinity CreateAndAddToDB(string name, string guid)
           => new SubclassMovementAffinitiesBuilder(name, guid).AddToDB();

       public static FeatureDefinitionMovementAffinity SubclassMovementAffinities = CreateAndAddToDB(SubclassMovementAffinitiesName, SubclassMovementAffinitiesGuid);
   }



    internal class SubclassEntangleImmunityBuilder : BaseDefinitionBuilder<FeatureDefinitionConditionAffinity>
    {
        const string SubclassEntangleImmunityName = "SubclassEntangleImmunity";
        const string SubclassEntangleImmunityGuid = "20833a61-c3c7-4f9c-814a-8cce4ee23e4b";

        protected SubclassEntangleImmunityBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionConditionAffinitys.ConditionAffinityRestrainedmmunity,name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&SubclassEntangleImmunityTitle";
            Definition.GuiPresentation.Description = "Feat/&SubclassEntangleImmunityDescription";

            // entangle immune etc
            Definition.SetConditionType(DatabaseHelper.ConditionDefinitions.ConditionRestrainedByEntangle.Name);
            Definition.SetConditionAffinityType(RuleDefinitions.ConditionAffinityType.Immunity);


        }

        public static FeatureDefinitionConditionAffinity CreateAndAddToDB(string name, string guid)
            => new SubclassEntangleImmunityBuilder(name, guid).AddToDB();

        public static FeatureDefinitionConditionAffinity SubclassEntangleImmunity = CreateAndAddToDB(SubclassEntangleImmunityName, SubclassEntangleImmunityGuid);
    }


    internal class SubclassCharmImmunityBuilder : BaseDefinitionBuilder<FeatureDefinitionConditionAffinity>
    {
        const string SubclassCharmImmunityName = "SubclassCharmImmunity";
        const string SubclassCharmImmunityGuid = "55d4a966-db43-4c5e-9c04-434510ababa9";

        protected SubclassCharmImmunityBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionConditionAffinitys.ConditionAffinityProtectedFromEvilCharmImmunity, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&SubclassCharmImmunityTitle";
            Definition.GuiPresentation.Description = "Feat/&SubclassCharmImmunityDescription";

            // entangle immune etc

            Traverse.Create(Definition).Field("otherCharacterFamilyRestrictions").SetValue(new List<string> 
            {  DatabaseHelper.CharacterFamilyDefinitions.Fey.Name,
                DatabaseHelper.CharacterFamilyDefinitions.Elemental.Name
            });
            //   
            

        }

        public static FeatureDefinitionConditionAffinity CreateAndAddToDB(string name, string guid)
            => new SubclassCharmImmunityBuilder(name, guid).AddToDB();

        public static FeatureDefinitionConditionAffinity SubclassCharmImmunity = CreateAndAddToDB(SubclassCharmImmunityName, SubclassCharmImmunityGuid);
    }

    internal class SubclassFrightenedImmunityBuilder : BaseDefinitionBuilder<FeatureDefinitionConditionAffinity>
    {
        const string SubclassFrightenedImmunityName = "SubclassFrightenedImmunity";
        const string SubclassFrightenedImmunityGuid = "0973473d-2a81-4635-aafa-86bff2f1d779";

        protected SubclassFrightenedImmunityBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionConditionAffinitys.ConditionAffinityProtectedFromEvilFrightenedImmunity, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&SubclassFrightenedImmunityTitle";
            Definition.GuiPresentation.Description = "Feat/&SubclassFrightenedImmunityDescription";

            // entangle immune etc

            Traverse.Create(Definition).Field("otherCharacterFamilyRestrictions").SetValue(new List<string>
            {  DatabaseHelper.CharacterFamilyDefinitions.Fey.Name,
                DatabaseHelper.CharacterFamilyDefinitions.Elemental.Name
            });
            //   


        }

        public static FeatureDefinitionConditionAffinity CreateAndAddToDB(string name, string guid)
            => new SubclassFrightenedImmunityBuilder(name, guid).AddToDB();

        public static FeatureDefinitionConditionAffinity SubclassFrightenedImmunity = CreateAndAddToDB(SubclassFrightenedImmunityName, SubclassFrightenedImmunityGuid);
    }


    internal class NaturesWardCantripBuilder : BaseDefinitionBuilder<SpellDefinition>
    {
        const string NaturesWardCantripName = "NaturesWardCantrip";
        const string NaturesWardCantripGuid = "9438f9c0-4577-4c65-a54e-34e1847b1f21";

        protected NaturesWardCantripBuilder(string name, string guid) : base(DatabaseHelper.SpellDefinitions.AnimalFriendship, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&NaturesWardCantripTitle";
            Definition.GuiPresentation.Description = "Feat/&NaturesWardCantripDescription";

            Definition.SetCastingTime(RuleDefinitions.ActivationTime.Reaction);
            Definition.SetSpellLevel(0);


        }

        public static SpellDefinition CreateAndAddToDB(string name, string guid)
            => new NaturesWardCantripBuilder(name, guid).AddToDB();

        public static SpellDefinition NaturesWardCantrip = CreateAndAddToDB(NaturesWardCantripName, NaturesWardCantripGuid);
    }

    public class ArcticAutopreparedSpellsBuilder : BaseDefinitionBuilder<FeatureDefinitionAutoPreparedSpells>
    {
        const string ArcticAutopreparedSpellsName = "ArcticAutopreparedSpells";
        const string ArcticAutopreparedSpellsGuid = "a0240de0-797e-4f66-a154-0e3a864926fc";

        protected ArcticAutopreparedSpellsBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionAutoPreparedSpellss.AutoPreparedSpellsDomainBattle, name, guid)
        {


            Definition.GuiPresentation.Title = "Feat/&ArcticAutopreparedSpellsTitle";
            Definition.GuiPresentation.Description = "Feat/&ArcticAutopreparedSpellsDescription";


            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_3 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_3.ClassLevel = 3;
            autoPreparedSpellsGroup_Level_3.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.HoldPerson
             //  ,DatabaseHelper.SpellDefinitions.spikegrowth
             
           });

            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_5 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_5.ClassLevel = 5;
            autoPreparedSpellsGroup_Level_5.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.SleetStorm
               ,DatabaseHelper.SpellDefinitions.Slow
        
           });


            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_7 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_7.ClassLevel = 7;
            autoPreparedSpellsGroup_Level_7.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.FreedomOfMovement
               ,DatabaseHelper.SpellDefinitions.IceStorm
              
           });

            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_9 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_9.ClassLevel = 9;
            autoPreparedSpellsGroup_Level_9.SpellsList = (new List<SpellDefinition> {
            //    DatabaseHelper.SpellDefinitions.communewithnature,
               DatabaseHelper.SpellDefinitions.ConeOfCold
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
            => new ArcticAutopreparedSpellsBuilder(name, guid).AddToDB();

        public static FeatureDefinitionAutoPreparedSpells ArcticAutopreparedSpells = CreateAndAddToDB(ArcticAutopreparedSpellsName, ArcticAutopreparedSpellsGuid);
    }

    public class CoastAutopreparedSpellsBuilder : BaseDefinitionBuilder<FeatureDefinitionAutoPreparedSpells>
    {
        const string CoastAutopreparedSpellsName = "CoastAutopreparedSpells";
        const string CoastAutopreparedSpellsGuid = "51e003be-0043-4fe4-977e-03c05e48771d";

        protected CoastAutopreparedSpellsBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionAutoPreparedSpellss.AutoPreparedSpellsDomainBattle, name, guid)
        {


            Definition.GuiPresentation.Title = "Feat/&CoastAutoPreparedSpellsTitle";
            Definition.GuiPresentation.Description = "Feat/&CoastAutoPreparedSpellsDescription";


            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_3 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_3.ClassLevel = 3;
            autoPreparedSpellsGroup_Level_3.SpellsList = (new List<SpellDefinition> {
            //    DatabaseHelper.SpellDefinitions.MirrorImage,
               DatabaseHelper.SpellDefinitions.MistyStep 
           });

            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_5 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_5.ClassLevel = 5;
            autoPreparedSpellsGroup_Level_5.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.WaterBreathing
               ,DatabaseHelper.SpellDefinitions. WaterWalk
           });


            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_7 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_7.ClassLevel = 7;
            autoPreparedSpellsGroup_Level_7.SpellsList = (new List<SpellDefinition> {
             //   DatabaseHelper.SpellDefinitions.controlwater,
               DatabaseHelper.SpellDefinitions.FreedomOfMovement
           });

            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_9 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_9.ClassLevel = 9;
            autoPreparedSpellsGroup_Level_9.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.ConjureElemental
            //   ,DatabaseHelper.SpellDefinitions.scrying
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
            => new CoastAutopreparedSpellsBuilder(name, guid).AddToDB();

        public static FeatureDefinitionAutoPreparedSpells CoastAutopreparedSpells = CreateAndAddToDB(CoastAutopreparedSpellsName, CoastAutopreparedSpellsGuid);
    }

    public class DesertAutopreparedSpellsBuilder : BaseDefinitionBuilder<FeatureDefinitionAutoPreparedSpells>
    {
        const string DesertAutopreparedSpellsName = "DesertAutopreparedSpells";
        const string DesertAutopreparedSpellsGuid = "4eef0cc3-1fdf-4bb6-b848-aaa04c93d64c";

        protected DesertAutopreparedSpellsBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionAutoPreparedSpellss.AutoPreparedSpellsDomainBattle, name, guid)
        {


            Definition.GuiPresentation.Title = "Feat/&DesertAutoPreparedSpellsTitle";
            Definition.GuiPresentation.Description = "Feat/&DesertAutoPreparedSpellsDescription";


            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_3 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_3.ClassLevel = 3;
            autoPreparedSpellsGroup_Level_3.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.Blur
               ,DatabaseHelper.SpellDefinitions.Silence
           });

            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_5 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_5.ClassLevel = 5;
            autoPreparedSpellsGroup_Level_5.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.CreateFood
               ,DatabaseHelper.SpellDefinitions.ProtectionFromEnergy 
           });


            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_7 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_7.ClassLevel = 7;
            autoPreparedSpellsGroup_Level_7.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.Blight
             //  ,DatabaseHelper.SpellDefinitions.hallucinatoryterrain
           });

            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_9 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_9.ClassLevel = 9;
            autoPreparedSpellsGroup_Level_9.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.InsectPlague
             //  ,DatabaseHelper.SpellDefinitions.wallofstone
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
            => new DesertAutopreparedSpellsBuilder(name, guid).AddToDB();

        public static FeatureDefinitionAutoPreparedSpells DesertAutopreparedSpells = CreateAndAddToDB(DesertAutopreparedSpellsName, DesertAutopreparedSpellsGuid);
    }

    public class ForestAutopreparedSpellsBuilder : BaseDefinitionBuilder<FeatureDefinitionAutoPreparedSpells>
    {
        const string ForestAutopreparedSpellsName = "ForestAutopreparedSpells";
        const string ForestAutopreparedSpellsGuid = "222c5acc-e208-4489-b670-6cef917d7270";

        protected ForestAutopreparedSpellsBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionAutoPreparedSpellss.AutoPreparedSpellsDomainBattle, name, guid)
        {


            Definition.GuiPresentation.Title = "Feat/&ForestAutoPreparedSpellsTitle";
            Definition.GuiPresentation.Description = "Feat/&ForestAutoPreparedSpellsDescription";


            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_3 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_3.ClassLevel = 3;
            autoPreparedSpellsGroup_Level_3.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.Barkskin
               ,DatabaseHelper.SpellDefinitions. SpiderClimb
           });

            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_5 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_5.ClassLevel = 5;
            autoPreparedSpellsGroup_Level_5.SpellsList = (new List<SpellDefinition> {
            //    DatabaseHelper.SpellDefinitions.callLightning
            //   ,DatabaseHelper.SpellDefinitions.plantgrowth
           });


            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_7 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_7.ClassLevel = 7;
            autoPreparedSpellsGroup_Level_7.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.FreedomOfMovement
             //  ,DatabaseHelper.SpellDefinitions.divination
           });

            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_9 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_9.ClassLevel = 9;
            autoPreparedSpellsGroup_Level_9.SpellsList = (new List<SpellDefinition> {
            //    DatabaseHelper.SpellDefinitions.communewithnature
            //   ,DatabaseHelper.SpellDefinitions.treestride
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
            => new ForestAutopreparedSpellsBuilder(name, guid).AddToDB();

        public static FeatureDefinitionAutoPreparedSpells ForestAutopreparedSpells = CreateAndAddToDB(ForestAutopreparedSpellsName, ForestAutopreparedSpellsGuid);
    }

    public class GrasslandAutopreparedSpellsBuilder : BaseDefinitionBuilder<FeatureDefinitionAutoPreparedSpells>
    {
        const string GrasslandAutopreparedSpellsName = "GrasslandAutopreparedSpells";
        const string GrasslandAutopreparedSpellsGuid = "dcdf0fc7-8132-47d4-a029-2fcf45aeb881";

        protected GrasslandAutopreparedSpellsBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionAutoPreparedSpellss.AutoPreparedSpellsDomainBattle, name, guid)
        {


            Definition.GuiPresentation.Title = "Feat/&GrasslandAutoPreparedSpellsTitle";
            Definition.GuiPresentation.Description = "Feat/&GrasslandAutoPreparedSpellsDescription";


            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_3 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_3.ClassLevel = 3;
            autoPreparedSpellsGroup_Level_3.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.Invisibility
               ,DatabaseHelper.SpellDefinitions.PassWithoutTrace
           });

            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_5 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_5.ClassLevel = 5;
            autoPreparedSpellsGroup_Level_5.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.Daylight
               ,DatabaseHelper.SpellDefinitions.Haste
           });


            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_7 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_7.ClassLevel = 7;
            autoPreparedSpellsGroup_Level_7.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.FreedomOfMovement
             //  ,DatabaseHelper.SpellDefinitions.divination
           });

            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_9 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_9.ClassLevel = 9;
            autoPreparedSpellsGroup_Level_9.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.InsectPlague
            //   ,DatabaseHelper.SpellDefinitions.dream
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
            => new GrasslandAutopreparedSpellsBuilder(name, guid).AddToDB();

        public static FeatureDefinitionAutoPreparedSpells GrasslandAutopreparedSpells = CreateAndAddToDB(GrasslandAutopreparedSpellsName, GrasslandAutopreparedSpellsGuid);
    }

    public class MountainAutopreparedSpellsBuilder : BaseDefinitionBuilder<FeatureDefinitionAutoPreparedSpells>
    {
        const string MountainAutopreparedSpellsName = "MountainAutopreparedSpells";
        const string MountainAutopreparedSpellsGuid = "dbd12c42-207e-4c74-a689-d0ef7e556fca";

        protected MountainAutopreparedSpellsBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionAutoPreparedSpellss.AutoPreparedSpellsDomainBattle, name, guid)
        {


            Definition.GuiPresentation.Title = "Feat/&MountainAutoPreparedSpellsTitle";
            Definition.GuiPresentation.Description = "Feat/&MountainAutoPreparedSpellsDescription";


            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_3 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_3.ClassLevel = 3;
            autoPreparedSpellsGroup_Level_3.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.SpiderClimb
             //  ,DatabaseHelper.SpellDefinitions.spikegrowth
           });

            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_5 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_5.ClassLevel = 5;
            autoPreparedSpellsGroup_Level_5.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.LightningBolt
             //  ,DatabaseHelper.SpellDefinitions.meldintostone
           });


            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_7 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_7.ClassLevel = 7;
            autoPreparedSpellsGroup_Level_7.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.Stoneskin
            //   ,DatabaseHelper.SpellDefinitions.stoneshape
           });

            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_9 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_9.ClassLevel = 9;
            autoPreparedSpellsGroup_Level_9.SpellsList = (new List<SpellDefinition> {
            //    DatabaseHelper.SpellDefinitions.passwall
            //   ,DatabaseHelper.SpellDefinitions.wallofstone
             
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
            => new MountainAutopreparedSpellsBuilder(name, guid).AddToDB();

        public static FeatureDefinitionAutoPreparedSpells MountainAutopreparedSpells = CreateAndAddToDB(MountainAutopreparedSpellsName, MountainAutopreparedSpellsGuid);
    }

    public class SwampAutopreparedSpellsBuilder : BaseDefinitionBuilder<FeatureDefinitionAutoPreparedSpells>
    {
        const string SwampAutopreparedSpellsName = "SwampAutopreparedSpells";
        const string SwampAutopreparedSpellsGuid = "066dd77a-b46d-4a03-ad0a-16548354290f";

        protected SwampAutopreparedSpellsBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionAutoPreparedSpellss.AutoPreparedSpellsDomainBattle, name, guid)
        {


            Definition.GuiPresentation.Title = "Feat/&SwampAutoPreparedSpellsTitle";
            Definition.GuiPresentation.Description = "Feat/&SwampAutoPreparedSpellsDescription";


            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_3 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_3.ClassLevel = 3;
            autoPreparedSpellsGroup_Level_3.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.Darkness
               ,DatabaseHelper.SpellDefinitions.AcidArrow
           });

            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_5 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_5.ClassLevel = 5;
            autoPreparedSpellsGroup_Level_5.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.WaterWalk
               ,DatabaseHelper.SpellDefinitions.StinkingCloud
           });


            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_7 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_7.ClassLevel = 7;
            autoPreparedSpellsGroup_Level_7.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.FreedomOfMovement
            //  ,DatabaseHelper.SpellDefinitions.locatecreature
           });

            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_9 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_9.ClassLevel = 9;
            autoPreparedSpellsGroup_Level_9.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.InsectPlague
             //  ,DatabaseHelper.SpellDefinitions.scrying
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
            => new SwampAutopreparedSpellsBuilder(name, guid).AddToDB();

        public static FeatureDefinitionAutoPreparedSpells SwampAutopreparedSpells = CreateAndAddToDB(SwampAutopreparedSpellsName, SwampAutopreparedSpellsGuid);
    }

    public class UnderdarkAutopreparedSpellsBuilder : BaseDefinitionBuilder<FeatureDefinitionAutoPreparedSpells>
    {
        const string UnderdarkAutopreparedSpellsName = "UnderdarkAutopreparedSpells";
        const string UnderdarkAutopreparedSpellsGuid = "8df12290-9a92-4353-a1ec-ee34339a75d4";

        protected UnderdarkAutopreparedSpellsBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionAutoPreparedSpellss.AutoPreparedSpellsDomainBattle, name, guid)
        {


            Definition.GuiPresentation.Title = "Feat/&UnderdarkAutoPreparedSpellsTitle";
            Definition.GuiPresentation.Description = "Feat/&UnderdarkAutoPreparedSpellsDescription";


            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_3 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_3.ClassLevel = 3;
            autoPreparedSpellsGroup_Level_3.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.SpiderClimb
             //  ,DatabaseHelper.SpellDefinitions.Web
           });

            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_5 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_5.ClassLevel = 5;
            autoPreparedSpellsGroup_Level_5.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.StinkingCloud
            //   ,DatabaseHelper.SpellDefinitions.gaseousform
           });


            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_7 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_7.ClassLevel = 7;
            autoPreparedSpellsGroup_Level_7.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.GreaterInvisibility
            //   ,DatabaseHelper.SpellDefinitions.stoneshape
           });

            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_9 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_9.ClassLevel = 9;
            autoPreparedSpellsGroup_Level_9.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.CloudKill
               ,DatabaseHelper.SpellDefinitions.InsectPlague
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
            => new UnderdarkAutopreparedSpellsBuilder(name, guid).AddToDB();

        public static FeatureDefinitionAutoPreparedSpells UnderdarkAutopreparedSpells = CreateAndAddToDB(UnderdarkAutopreparedSpellsName, UnderdarkAutopreparedSpellsGuid);
    }





    //    internal class WandOfWildshapeBuilder : BaseDefinitionBuilder<ItemDefinition>
    //    {
    //        const string WandOfWildshapeName = "WandOfWildshape";
    //        const string WandOfWildshapeGuid = "12ec71f9-5e79-46aa-8683-f948f2540a2d";
    //
    //        protected WandOfWildshapeBuilder(string name, string guid) : base(DatabaseHelper.ItemDefinitions.WandMagicMissile, name, guid)
    //        {
    //            Definition.GuiPresentation.Title = "Item/&WandOfWildshapeTitle";
    //            Definition.GuiPresentation.Description = "Item/&WandOfWildshapeDescription";
    //
    //            Definition.SetInDungeonEditor(true);
    //
    //            DeviceFunctionDescription wildshapefunction = new DeviceFunctionDescription();
    //            wildshapefunction.SetCanOverchargeSpell(false);
    //            wildshapefunction.SetDurationType(RuleDefinitions.DurationType.UntilLongRest);
    //            wildshapefunction.SetFeatureDefinitionPower(WildShapePowerBuilder.WildShapePower);
    //            wildshapefunction.SetParentUsage(EquipmentDefinitions.ItemUsage.ByFunction);
    //            wildshapefunction.SetRechargeRate(RuleDefinitions.RechargeRate.LongRest);
    //            wildshapefunction.SetType(DeviceFunctionDescription.FunctionType.Power);
    //            wildshapefunction.SetUseAffinity(DeviceFunctionDescription.FunctionUseAffinity.IterationPerRecharge);
    //            wildshapefunction.SetUseAmount(6);
    //
    //            UsableDeviceDescription usableDeviceDescription = new UsableDeviceDescription();
    //            usableDeviceDescription.SetUsage(EquipmentDefinitions.ItemUsage.ByFunction);
    //            usableDeviceDescription.SetChargesCapitalNumber(5);
    //            usableDeviceDescription.SetRechargeRate(RuleDefinitions.RechargeRate.LongRest);
    //            usableDeviceDescription.SetRechargeNumber(0);
    //            usableDeviceDescription.SetRechargeDie(RuleDefinitions.DieType.D1);
    //            usableDeviceDescription.SetRechargeBonus(5);
    //            usableDeviceDescription.SetOutOfChargesConsequence(EquipmentDefinitions.ItemOutOfCharges.Persist);
    //            usableDeviceDescription.SetMagicAttackBonus(5);
    //            usableDeviceDescription.SetSaveDC(13);
    //
    //            Traverse.Create(usableDeviceDescription).Field("deviceFunctions").SetValue(new List<DeviceFunctionDescription> { wildshapefunction });
    //
    //            Traverse.Create(usableDeviceDescription).Field("itemTags").SetValue(new List<string> { "Consumable" });
    //
    //            Definition.UsableDeviceDescription.DeviceFunctions.Clear();
    //            Definition.UsableDeviceDescription.DeviceFunctions.Add(wildshapefunction);
    //
    //             
    //        }
    //
    //        public static ItemDefinition CreateAndAddToDB(string name, string guid)
    //            => new WandOfWildshapeBuilder(name, guid).AddToDB();
    //
    //        public static ItemDefinition WandOfWildshape = CreateAndAddToDB(WandOfWildshapeName, WandOfWildshapeGuid);
    //    }

    //  internal class DummySavingThrowAffinityBuilder : BaseDefinitionBuilder<FeatureDefinitionSavingThrowAffinity>
    //  {
    //      const string DummySavingThrowAffinityName = "DummySavingThrowAffinityBuilder";
    //      const string DummySavingThrowAffinityGuid = "";
    //
    //      protected DummySavingThrowAffinityBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionSavingThrowAffinitys., name, guid)
    //      {
    //          Definition.GuiPresentation.Title = "Feature/&DummySavingThrowAffinityBuilder";
    //          Definition.GuiPresentation.Description = "Feature/&DummySavingThrowAffinityBuilder";
    //
    //           Definition.AffinityGroups.Clear();
    //          
    //		
    //		
    //          Definition.AffinityGroups.Add();
    //      }
    //
    //      public static FeatureDefinitionSavingThrowAffinity CreateAndAddToDB(string name, string guid)
    //          => new DummySavingThrowAffinityBuilder(name, guid).AddToDB();
    //
    //      public static FeatureDefinitionSavingThrowAffinity DummySavingThrowAffinityBuilder = CreateAndAddToDB(DummySavingThrowAffinityName, DummySavingThrowAffinityGuid);
    //  }
    //
    //  internal class DummyFightingStyleBuilder : BaseDefinitionBuilder<FeatureDefinitionFightingStyleChoice>
    //  {
    //      const string DummyFightingStyleName = "DummyFightingStyle";
    //      const string DummyFightingStyleGuid = "";
    // 
    //      protected DummyFightingStyleBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionFightingStyleChoices.FightingStyleCleric, name, guid)
    //      {
    //          Definition.GuiPresentation.Title = "Feature/&DummyFightingStyleTitle";
    //          Definition.GuiPresentation.Description = ;
    // 
    //          Definition.FightingStyles.Clear();
    //          Definition.FightingStyles.Add();
    //      }
    // 
    //      public static FeatureDefinitionFightingStyleChoice CreateAndAddToDB(string name, string guid)
    //          => new DummyFightingStyleBuilder(name, guid).AddToDB();
    // 
    //      public static FeatureDefinitionFightingStyleChoice DummyFightingStyle = CreateAndAddToDB(DummyFightingStyleName, DummyFightingStyleGuid);
    //  }
    //
    //
    //
    //  internal class DummyMovementAffinityBuilder : BaseDefinitionBuilder<FeatureDefinitionMovementAffinity>
    //  {
    //      const string Name = "DummyMovementAffinityBuilder";
    //      const string Guid = "";
    //
    //      protected DruidClassBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionMovementAffinitys., name, guid)
    //      {
    //          Definition.GuiPresentation.Title = "Feature/&DummyMovementAffinityBuilder";
    //          Definition.GuiPresentation.Description = "Feature/&DummyMovementAffinityBuilder";
    //      }
    //
    //      public static FeatureDefinitionMovementAffinity CreateAndAddToDB(string name, string guid)
    //          => new DummyMovementAffinityBuilder(name, guid).AddToDB();
    //
    //      public static FeatureDefinitionMovementAffinity 
    //          = CreateAndAddToDB(Name, Guid);
    //  }
    //
    //   
    //  internal class DummyPowerBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    //  {
    //      const string Name = "DummyPowerBuilder";
    //      const string Guid = "";
    //
    //      protected DummyPowerBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionPowers., name, guid)
    //      {
    //          Definition.GuiPresentation.Title = "Feature/&DummyPowerBuilderTitle";
    //          Definition.GuiPresentation.Description = "Feature/&DummyPowerBuilderDescription";
    //
    //          Definition.SetRechargeRate(RuleDefinitions.RechargeRate.None);
    //          Definition.SetActivationTime(RuleDefinitions.ActivationTime.Permanent);
    //          Definition.SetCostPerUse(1);
    //          Definition.SetFixedUsesPerRecharge(0);
    //          Definition.SetShortTitleOverride("Feature/&DummyPowerBuilderTitle");
    //          Definition.SetEffectDescription(new EffectDescription());
    //      }
    //
    //      public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
    //          => new DummyPowerBuilder(name, guid).AddToDB();
    //
    //      public static FeatureDefinitionPower DummyPowerBuilder
    //          = CreateAndAddToDB(Name, Guid);
    //  }
    //
    //
    //  internal class DummyConditionBuilder : BaseDefinitionBuilder<ConditionDefinition>
    //  {
    //      const string DummyConditionName = "DummyCondition";
    //      const string DummyConditionGuid = "";
    //
    //      protected DummyConditionBuilder(string name, string guid) : base(DatabaseHelper.ConditionDefinitions., name, guid)
    //      {
    //          Definition.GuiPresentation.Title = "Feature/&DummyConditionTitle";
    //          Definition.GuiPresentation.Description = "Feature/&DummyConditionDescription";
    //
    //          Definition.SetAllowMultipleInstances(false);
    //          Definition.Features.Clear();
    //          
    //		Definition.SetDurationType(RuleDefinitions.DurationType.Minute);
    //          Definition.SetDurationParameter(1);
    //      }
    //
    //      public static ConditionDefinition CreateAndAddToDB(string name, string guid)
    //          => new DummyConditionBuilder(name, guid).AddToDB();
    //
    //      public static ConditionDefinition DummyCondition
    //          = CreateAndAddToDB(DummyConditionName, DummyConditionGuid);
    //  }
    //
    //  /// </summary>
    //   internal class DummyAttackModifierBuilder : BaseDefinitionBuilder<FeatureDefinitionAttackModifier>
    //  {
    //      const string DummyAttackModifierName = "DummyAttackModifier";
    //      const string DummyAttackModifierGuid = "";
    //
    //      protected DummyAttackModifierBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionAttackModifiers., name, guid)
    //      {
    //          Definition.GuiPresentation.Title = "Feature/&DummyAttackModifierTitle";
    //          Definition.GuiPresentation.Description = "Feature/&DummyAttackModifierDescription";
    //
    //          Definition.SetAttackRollModifier(0);
    //          Definition.SetDamageRollModifier(0);
    //
    //	}
    //
    //      public static FeatureDefinitionAttackModifier CreateAndAddToDB(string name, string guid)
    //          => new DummyAttackModifierBuilder(name, guid).AddToDB();
    //
    //      public static FeatureDefinitionAttackModifier DummyAttackModifier
    //          = CreateAndAddToDB(DummyAttackModifierName, DummyAttackModifierGuid);
    //  }
    //
    //
    //  internal class DummyItemBuilder : BaseDefinitionBuilder<ItemDefinition>
    //  {
    //       const string DummyItemName = "DummyItem";
    //       const string DummyItemGuid = "";
    //
    //       protected DummyItemBuilder(string name, string guid) : base(DatabaseHelper.ItemDefinitions., name, guid)
    //       {
    //           Definition.GuiPresentation.Title = "Item/&DummyItemTitle";
    //           Definition.GuiPresentation.Description = "Item/&DummyItemDescription";
    //
    //       }
    //
    //       public static ItemDefinition CreateAndAddToDB(string name, string guid)
    //           => new DummyItemBuilder(name, guid).AddToDB();
    //
    //       public static ItemDefinition HideClothes
    //           = CreateAndAddToDB(DummyItemName, DummyItemGuid);
    //   }
}