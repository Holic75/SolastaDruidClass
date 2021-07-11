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

        public static CharacterSubclassDefinition Build()
        {
            var subclassGuiPresentation = new GuiPresentationBuilder(
                    "Subclass/&DruidSubclassCircleOfLandDescription",
                    "Subclass/&DruidSubclassCircleOfLandTitle")
                    .SetSpriteReference(DatabaseHelper.CharacterSubclassDefinitions.TraditionGreenmage.GuiPresentation.SpriteReference)
                    .Build();

            CharacterSubclassDefinition definition = new CharacterSubclassDefinitionBuilder(DruidSubClassCircleOfLandName, DruidSubClassCircleOfLandGuid)
                    definition.SetGuiPresentation(subclassGuiPresentation)
                //    .AddFeatureAtLevel(, 3)  
                //    .AddFeatureAtLevel(, 3)  
                //    .AddFeatureAtLevel(, 6)  
                //    .AddFeatureAtLevel(, 6)  
                //    .AddFeatureAtLevel(, 9)  
                //    .AddFeatureAtLevel(, 10)  
                    .AddToDB();

            return definition;
        }
    }
	
	

    internal class SubclassCircleSpellsBuilder : BaseDefinitionBuilder<FeatureDefinitionFeatureSet>
    {
        const string SubclassCircleSpellsName = "SubclassCircleSpells";
        const string SubclassCircleSpellsGuid = "";

        protected SubclassCircleSpellsBuilder(string name, string guid) : base(name, guid)
        {
           // Definition.GuiPresentation.Title = "Feat/&SubclassCircleSpellsTitle";
           // Definition.GuiPresentation.Description = "Feat/&SubclassCircleSpellsDescription";
             

        }

        public static FeatureDefinitionMovementAffinity CreateAndAddToDB(string name, string guid)
            => new SubclassCircleSpellsBuilder(name, guid).AddToDB();

        public static FeatureDefinitionMovementAffinity SubclassCircleSpells = CreateAndAddToDB(SubclassCircleSpellsName, SubclassCircleSpellsGuid);
    }
 

public class SubclassAutopreparedSpellsBuilder : BaseDefinitionBuilder<FeatureDefinitionAutoPreparedSpells>
    {
        const string SubclassAutopreparedSpellsName = "SubclassAutopreparedSpells";
        const string SubclassAutopreparedSpellsGuid = "";

        protected SubclassAutopreparedSpellsBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionAutoPreparedSpellss.AutoPreparedSpellsDomainBattle, name, guid)
        {


            Definition.GuiPresentation.Title = "Feat/&AutoPreparedSpellsTitle";
            Definition.GuiPresentation.Description = "Feat/&AutoPreparedSpellsDescription";

            CharacterClassDefinition artificer = DatabaseRepository.GetDatabase<CharacterClassDefinition>().TryGetElement("ClassTinkerer", GuidHelper.Create(SolastaArtificerMod.Main.ModGuidNamespace, "ClassTinkerer").ToString());

            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_3 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_3.ClassLevel = 3;
            autoPreparedSpellsGroup_Level_3.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.Thunderwave,
                DatabaseHelper.SpellDefinitions.MagicMissile
            });

            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_5 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_5.ClassLevel = 5;
            autoPreparedSpellsGroup_Level_5.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.Shatter,
                DatabaseHelper.SpellDefinitions.Blur
            });


            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_9 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_9.ClassLevel = 9;
            autoPreparedSpellsGroup_Level_9.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.LightningBolt
                ,DatabaseHelper.SpellDefinitions.HypnoticPattern
            });

            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_13 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_13.ClassLevel = 13;
            autoPreparedSpellsGroup_Level_13.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.FireShield
                ,DatabaseHelper.SpellDefinitions.GreaterInvisibility
            });

            FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup autoPreparedSpellsGroup_Level_17 = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup();
            autoPreparedSpellsGroup_Level_17.ClassLevel = 17;
            autoPreparedSpellsGroup_Level_17.SpellsList = (new List<SpellDefinition> {
                DatabaseHelper.SpellDefinitions.DimensionDoor
                ,DatabaseHelper.SpellDefinitions.WallOfFire
                ,DatabaseHelper.SpellDefinitions.WallOfForce
                ,DatabaseHelper.SpellDefinitions.WindWall
                ,ImplementWallOfForceBuilder.ImplementWallOfForce
            });

            //  added extra spells to balance spells don't have test the "imple mented"=true flag yet
            //blur for mirror image
            // dimension door for passwall
            // wall of fire and wind wall for wall of force



            Definition.SetSpellcastingClass(artificer);
            Definition.AutoPreparedSpellsGroups.Clear();
            Definition.AutoPreparedSpellsGroups.AddRange(new List<FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup>
            {
                autoPreparedSpellsGroup_Level_3,
                autoPreparedSpellsGroup_Level_5,
                autoPreparedSpellsGroup_Level_9,
                autoPreparedSpellsGroup_Level_13,
                autoPreparedSpellsGroup_Level_17
            });

        }




        public static FeatureDefinitionAutoPreparedSpells CreateAndAddToDB(string name, string guid)
            => new SubclassAutopreparedSpellsBuilder(name, guid).AddToDB();

        public static FeatureDefinitionAutoPreparedSpells SubclassAutopreparedSpells = CreateAndAddToDB(SubclassAutopreparedSpellsName, SubclassAutopreparedSpellsGuid);
    }

   
    internal class SubclassMovementAffinitiesBuilder : BaseDefinitionBuilder<FeatureDefinitionMovementAffinity>
    {
        const string SubclassMovementAffinitiesName = "SubclassMovementAffinities";
        const string SubclassMovementAffinitiesGuid = "";

        protected SubclassMovementAffinitiesBuilder(string name, string guid) : base(name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&SubclassMovementTitle";
            Definition.GuiPresentation.Description = "Feat/&SubclassMovementDescription";
            
			// entangle immune etc

        }

        public static FeatureDefinitionMovementAffinity CreateAndAddToDB(string name, string guid)
            => new SubclassMovementAffinitiesBuilder(name, guid).AddToDB();

        public static FeatureDefinitionMovementAffinity SubclassMovementAffinities = CreateAndAddToDB(SubclassMovementAffinitiesName, SubclassMovementAffinitiesGuid);
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