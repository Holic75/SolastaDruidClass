using SolastaModApi;
using SolastaModApi.Extensions;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using HarmonyLib;

namespace SolastaDruidClass
{
    internal class DruidClassBuilder : CharacterClassDefinitionBuilder
    {
        const string DruidClassName = "DruidClass";
        const string DruidClassGuid = "a2112af0-636f-4b72-acdc-07c921bcea6d";
        const string DruidClassSubclassesGuid = "46ae0591-296d-4f6c-80b0-4e198c999076";

        //protected DruidClassBuilder(string name, string guid) : base(DatabaseHelper.CharacterClassDefinitions.Cleric, name, guid)
        protected DruidClassBuilder(string name, string guid) : base( name, guid)
        {
            Definition.GuiPresentation.Title = "Class/&DruidClassTitle";
            Definition.GuiPresentation.Description = "Class/&DruidClassDescription";
            Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.CharacterSubclassDefinitions.TraditionGreenmage.GuiPresentation.SpriteReference);

            Definition.SetClassAnimationId(AnimationDefinitions.ClassAnimationId.Cleric);
            Definition.SetClassPictogramReference(DatabaseHelper.CharacterClassDefinitions.Cleric.ClassPictogramReference);
            Definition.SetDefaultBattleDecisions(DatabaseHelper.CharacterClassDefinitions.Cleric.DefaultBattleDecisions);
            Definition.SetHitDice(RuleDefinitions.DieType.D8);
            Definition.SetIngredientGatheringOdds(DatabaseHelper.CharacterClassDefinitions.Ranger.IngredientGatheringOdds);
            Definition.SetRequiresDeity(false);


// Druid
// [‒]
// Hit Points
// Hit Dice: 1d8
// Hit Points at 1st Level: 8 + your Constitution modifier
// Hit Points at Higher Levels: 1d8 (or 5) + your Constitution modifier per Druid level after 1st
// Proficiencies
// Armor: light armor, medium armor, shields (druids will not wear armor or use shields made of metal)
// Weapons: clubs, daggers, darts, javelins, maces, quarterstaffs, scimitars, sickles, slings, spears
// Tools: Herbalism kit
// Saving Throws: Intelligence, Wisdom
// Skills: Choose 2 from Arcana, Animal Handling, Insight, Medicine, Nature, Perception, Religion, and Survival.
// Starting Equipment
// You start with the following items, plus anything provided by your background.
// 
// (a) a wooden shield or (b) any simple weapon
// (a) a scimitar or (b) any simple melee weapon
// Leather armor, an explorer's pack, and a druidic focus
// Alternatively, you may start with 2d4 × 10 gp to buy your own equipment.


            Definition.AbilityScoresPriority.AddRange(DatabaseHelper.CharacterClassDefinitions.Cleric.AbilityScoresPriority);
            Definition.FeatAutolearnPreference.AddRange(DatabaseHelper.CharacterClassDefinitions.Cleric.FeatAutolearnPreference);
            Definition.PersonalityFlagOccurences.AddRange(DatabaseHelper.CharacterClassDefinitions.Cleric.PersonalityFlagOccurences);
            Definition.SkillAutolearnPreference.AddRange(DatabaseHelper.CharacterClassDefinitions.Cleric.SkillAutolearnPreference);
            Definition.ToolAutolearnPreference.AddRange(DatabaseHelper.CharacterClassDefinitions.Cleric.ToolAutolearnPreference);


            Definition.EquipmentRows.AddRange(DatabaseHelper.CharacterClassDefinitions.Cleric.EquipmentRows);
            Definition.EquipmentRows.Clear();
            List<CharacterClassDefinition.HeroEquipmentOption> list = new List<CharacterClassDefinition.HeroEquipmentOption>();
            List<CharacterClassDefinition.HeroEquipmentOption> list2 = new List<CharacterClassDefinition.HeroEquipmentOption>();
            list.Add(EquipmentOptionsBuilder.Option(DatabaseHelper.ItemDefinitions.Quarterstaff, EquipmentDefinitions.OptionWeapon, 1));
            list2.Add(EquipmentOptionsBuilder.Option(DatabaseHelper.ItemDefinitions.Scimitar, EquipmentDefinitions.OptionWeaponMartialChoice, 1));
            List<CharacterClassDefinition.HeroEquipmentOption> list3 = new List<CharacterClassDefinition.HeroEquipmentOption>();
            List<CharacterClassDefinition.HeroEquipmentOption> list4 = new List<CharacterClassDefinition.HeroEquipmentOption>();
            list3.Add(EquipmentOptionsBuilder.Option(DatabaseHelper.ItemDefinitions.Handaxe, EquipmentDefinitions.OptionWeapon, 2));
            list4.Add(EquipmentOptionsBuilder.Option(DatabaseHelper.ItemDefinitions.Mace, EquipmentDefinitions.OptionWeaponSimpleChoice, 1));
            this.AddEquipmentRow(list, list2);
            this.AddEquipmentRow(list3, list4);
            this.AddEquipmentRow(new List<CharacterClassDefinition.HeroEquipmentOption>
            {
                EquipmentOptionsBuilder.Option(DatabaseHelper.ItemDefinitions.Javelin, EquipmentDefinitions.OptionWeapon, 4),
                EquipmentOptionsBuilder.Option(DatabaseHelper.ItemDefinitions.ExplorerPack, EquipmentDefinitions.OptionStarterPack, 1),
             //   EquipmentOptionsBuilder.Option(DummyItemBuilder.HideClothes, EquipmentDefinitions.OptionStarterPack, 1),
            });


// Level                           - cantrip
// 	                               - 2
// 1st	Druidic,                   -
// 		Spellcasting               -
// 2nd	Wild Shape,                -
// 		Wild Companion,            -
// 		Druid Circle               -
// 3rd	—                          -
// 4th	Wild Shape Improvement,    - 3
// 		Ability Score Improvement, -
// 		Cantrip Versatility        -
// 5th	—                          -
// 6th	Druid Circle feature       -
// 7th	—                          -
// 8th	Wild Shape Improvement,    -
// 	 	Ability Score Improvement  -
// 9th	—                          -
// 10th	Druid Circle feature       - 4
// 11th	—                          -
// 12th	Ability Score Improvement  -
// 13th	—                          -
// 14th	Druid Circle feature       -
// 15th	—                          -
// 16th	Ability Score Improvement  -
// 17th	—                          -
// 18th	Timeless Body,             -
// 		Beast Spells               -
// 19th	Ability Score Improvement  -
// 20th	Archdruid                  -
	


            Definition.FeatureUnlocks.Clear();
        //    Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.FeatureDefinitionProficiencys., 1));  
        //    Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.FeatureDefinitionProficiencys.ProficiencyClericArmor, 1));  
        //    Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.FeatureDefinitionProficiencys., 1));  
        //    Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DruidClassSkillPointPoolBuilder.DruidClassSkillPointPool, 1));  
        //    Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DummyPowerBuilder.DummyPower, 1));
        //    Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DummyFightingStyleBuilder., 1));
        //    Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.FeatureDefinitionPowers., 2));
        //    Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(., 2));  
            
			//Subclass feature at level 3
            var subclassChoicesGuiPresentation = new GuiPresentation();
            subclassChoicesGuiPresentation.Title = "Subclass/&DruidSubclassCircleTitle";
            subclassChoicesGuiPresentation.Description = "Subclass/&DruidSubclassCircleDescription";
            DruidFeatureDefinitionSubclassChoice = this.BuildSubclassChoice(2, "Circle", false, "SubclassChoiceDruidCircleArchetypes", subclassChoicesGuiPresentation, DruidClassSubclassesGuid);
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(WildShapePowerBuilder.WildShapePower, 2));
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(EndWildShapePowerBuilder.EndWildShapePower, 2));

            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetAbilityScoreChoice, 4));
            //    Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.FeatureDefinitionAttributeModifiers., 5));
            //    Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DruidClassBuilder., 5));
            //    Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(WildShapePowerBuilder, 2));
            //    
            //	//SubclassFeature at level 6
            //    Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.., 7));
            //    Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(., 7));
            //    Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.., 7)); 
            //    Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetAbilityScoreChoice, 8));
            //    Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.., 9)); // 
            //Subclass feature at level 10

            //Above level 10 features 
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetAbilityScoreChoice, 12));
             
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetAbilityScoreChoice, 16));
             
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetAbilityScoreChoice, 19));
             

        }

        public static void BuildAndAddClassToDB()
        {
            var DruidClass = new DruidClassBuilder(DruidClassName, DruidClassGuid).AddToDB();
             CharacterSubclassDefinition characterSubclassDefinition = DruidSubClassCircleOfLand.Build();
            DruidFeatureDefinitionSubclassChoice.Subclasses.Add(characterSubclassDefinition.Name);
            
			//circle of aspects/shifter/lycanthropy (use conditions to alter PC's body in different ways for gish druid)
			
			//CharacterSubclassDefinition  = .Build();
            //DruidFeatureDefinitionSubclassChoice.Subclasses.Add(.Name);
			
			// circle of summons/companion druid fey battle buddy using wildfire companion and primal companions as templates
			
            //CharacterSubclassDefinition  = .Build();
            //DruidFeatureDefinitionSubclassChoice.Subclasses.Add(.Name);
        }

        private static FeatureDefinitionSubclassChoice DruidFeatureDefinitionSubclassChoice;
    }

  

    internal class DruidClassSkillPointPoolBuilder : BaseDefinitionBuilder<FeatureDefinitionPointPool>
    {
        const string DruidClassSkillPointPoolName = "DruidClassSkillPointPool";
        const string DruidClassSkillPointPoolGuid = "8f2cb82d-6bf9-4a72-a3e1-286a1e2b5662";

        protected DruidClassSkillPointPoolBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionPointPools.PointPoolClericSkillPoints, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&DruidClassSkillPointPoolTitle";
            Definition.GuiPresentation.Description = "Feature/&DruidClassSkillPointPoolDescription";

            Definition.SetPoolAmount(2);
            Definition.SetPoolType(HeroDefinitions.PointsPoolType.Skill);
            Definition.RestrictedChoices.Clear();
            Definition.RestrictedChoices.AddRange(new string[] { "AnimalHandling", "Athletics", "Intimidation", "Nature", "Perception", "Survival", });
        }

        public static FeatureDefinitionPointPool CreateAndAddToDB(string name, string guid)
            => new DruidClassSkillPointPoolBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPointPool DruidClassSkillPointPool = CreateAndAddToDB(DruidClassSkillPointPoolName, DruidClassSkillPointPoolGuid);
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