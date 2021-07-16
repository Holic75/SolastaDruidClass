using SolastaModApi;
using SolastaModApi.Infrastructure;
using SolastaModApi.Extensions;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using HarmonyLib;
using UnityEngine;
using System;

namespace SolastaDruidClass
{
 

	 internal class ProduceFlameCantripBuilder : BaseDefinitionBuilder<SpellDefinition>
   {
       const string ProduceFlameCantripName = "ProduceFlameCantrip";
       const string ProduceFlameCantripGuid = "705b0353-a64c-4b27-809f-fff6d828f372";

       protected ProduceFlameCantripBuilder(string name, string guid) : base(DatabaseHelper.SpellDefinitions.FireBolt, name, guid)
       {
           Definition.GuiPresentation.Title = "Feat/&ProduceFlameCantripTitle";
           Definition.GuiPresentation.Description = "Feat/&ProduceFlameCantripDescription";
            
			 
           Definition.SetUniqueInstance(true);
           Definition.SetSpellsBundle(true);

           Traverse.Create(Definition).Field("subspellsList").SetValue(new List<SpellDefinition>
           {
               ProduceFlame_Light_CantripBuilder.ProduceFlame_Light_Cantrip , 
               ProduceFlame_Mote_CantripBuilder.ProduceFlame_Mote_Cantrip
           });

            



           Definition.EffectDescription.Clear();


       }

       public static SpellDefinition CreateAndAddToDB(string name, string guid)
           => new ProduceFlameCantripBuilder(name, guid).AddToDB();

       public static SpellDefinition ProduceFlameCantrip = CreateAndAddToDB(ProduceFlameCantripName, ProduceFlameCantripGuid);
   }
	
	 internal class ProduceFlame_Light_CantripBuilder : BaseDefinitionBuilder<SpellDefinition>
   {
       const string ProduceFlame_Light_CantripName = "ProduceFlame_Light_Cantrip";
       const string ProduceFlame_Light_CantripGuid = "808cfdbf-3d39-410c-bde6-7e27b347174e";

       protected ProduceFlame_Light_CantripBuilder(string name, string guid) : base(DatabaseHelper.SpellDefinitions.Light, name, guid)
       {
           Definition.GuiPresentation.Title = "Feat/&ProduceFlame_Light_CantripTitle";
           Definition.GuiPresentation.Description = "Feat/&ProduceFlame_Light_CantripDescription";
            
			 
           
           Definition.SetRequiresConcentration(false);
			Definition.EffectDescription.SetDurationParameter(10);
           Definition.EffectDescription.SetDurationType(RuleDefinitions.DurationType.Minute);

           
           Definition.EffectDescription.EffectForms[0].LightSourceForm.SetBrightRange(2);
           Definition.EffectDescription.EffectForms[0].LightSourceForm.SetDimAdditionalRange(2);




       }

       public static SpellDefinition CreateAndAddToDB(string name, string guid)
           => new ProduceFlame_Light_CantripBuilder(name, guid).AddToDB();

       public static SpellDefinition ProduceFlame_Light_Cantrip = CreateAndAddToDB(ProduceFlame_Light_CantripName, ProduceFlame_Light_CantripGuid);
   }
	
	
	 internal class ProduceFlame_Mote_CantripBuilder : BaseDefinitionBuilder<SpellDefinition>
   {
       const string ProduceFlame_Mote_CantripName = "ProduceFlame_Mote_Cantrip";
       const string ProduceFlame_Mote_CantripGuid = "44aca644-4b07-4e76-b37b-296a844b96ae";

       protected ProduceFlame_Mote_CantripBuilder(string name, string guid) : base(DatabaseHelper.SpellDefinitions.FireBolt, name, guid)
       {
           Definition.GuiPresentation.Title = "Feat/&ProduceFlame_Mote_CantripTitle";
           Definition.GuiPresentation.Description = "Feat/&ProduceFlame_Mote_CantripDescription";



           Definition.EffectDescription.SetRangeParameter(6);
           Definition.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D8);






       }

       public static SpellDefinition CreateAndAddToDB(string name, string guid)
           => new ProduceFlame_Mote_CantripBuilder(name, guid).AddToDB();

       public static SpellDefinition ProduceFlame_Mote_Cantrip = CreateAndAddToDB(ProduceFlame_Mote_CantripName, ProduceFlame_Mote_CantripGuid);
   }
//
 //  internal class shillelaghCantripBuilder : BaseDefinitionBuilder<SpellDefinition>
 //  {
 //      const string shillelaghCantripName = "shillelaghCantrip";
 //      const string shillelaghCantripGuid = "a48313fd-cb08-4a21-86ab-9053596c0d1c";
 //
 //      protected shillelaghCantripBuilder(string name, string guid) : base(DatabaseHelper.SpellDefinitions.MagicWeapon, name, guid)
 //      {
 //          Definition.GuiPresentation.Title = "Feat/&shillelaghCantripTitle";
 //          Definition.GuiPresentation.Description = "Feat/&shillelaghCantripDescription";
 //
 //
 //          Definition.SetSpellLevel(0);
 //          Definition.SetRequiresConcentration(false);
 //
 //          //Add to our new effect
 //          EffectDescription newEffectDescription = new EffectDescription();
 //          newEffectDescription.Copy(Definition.EffectDescription);
 //          newEffectDescription.EffectForms.Clear();
 //     
 //     //        FeatureUnlockByLevel attackmod = new FeatureUnlockByLevel();
 //     //        Traverse.Create(attackmod).Field("featureDefinition").SetValue(new List<FeatureDefinition> { shillelaghAttackModifierBuilder.shillelaghAttackModifier });
 //     //        Traverse.Create(attackmod).Field("level").SetValue(new List<int> { 0});
 //     //    
 //     //
 //     //        FeatureUnlockByLevel addDaamge = new FeatureUnlockByLevel();
 //     //        Traverse.Create(addDaamge).Field("featureDefinition").SetValue(new List<FeatureDefinition> { ShillelaghAdditionalDamageBuilder.ShillelaghAdditionalDamage });
 //     //        Traverse.Create(addDaamge).Field("level").SetValue(new List<int> { 0 });
 //     //    
 //     //        ItemPropertyForm shillelagh = new ItemPropertyForm();
 //     //        shillelagh.FeatureBySlotLevel.Add(attackmod);
 //     //        shillelagh.FeatureBySlotLevel.Add(addDaamge);
 //
 //           EffectForm itemeffect = new EffectForm();
 //          itemeffect.SetFormType(EffectForm.EffectFormType.ItemProperty);
 //          itemeffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
 //          itemeffect.SetLevelMultiplier(1);
 //          itemeffect.SetLevelType(RuleDefinitions.LevelSourceType.EffectLevel);
 //       //    itemeffect.SetItemPropertyForm(shillelagh);
 //
 //        
 //         //   itemeffect.SetItemPropertyForm(new List<FeatureUnlockByLevel>
 //         //   {
 //         //       new FeatureUnlockByLevel(shillelaghAttackModifierBuilder.shillelaghAttackModifier , 0)
 //         //    //,   new FeatureUnlockByLevel(ShillelaghAdditionalDamageBuilder.ShillelaghAdditionalDamage, 0)
 //         //   }, 
 //         //   0, 
 //         //   1);
 //
 //           //EffectForm.FormType = EffectForm.EffectFormType.ItemProperty; 
 //
 //     //    FeatureUnlockByLevel test = new FeatureUnlockByLevel();
 //     //    test.FeatureDefinition.
 //     //
 //        ItemPropertyForm itemForm = new ItemPropertyForm();
 //        itemForm.SetUsageLimitation(RuleDefinitions.ItemPropertyUsage.Unlimited);
 //        itemForm.SetUseAmount(1);
 //         itemForm.SetField("featureBySlotLevel", new List<FeatureUnlockByLevel>
 //                   {
 //                       new FeatureUnlockByLevel(shillelaghAttackModifierBuilder.shillelaghAttackModifier, 0)
 //                       ,   new FeatureUnlockByLevel(ShillelaghAdditionalDamageBuilder.ShillelaghAdditionalDamage, 0)
 //      //  });
 //                   });
 //         itemForm.FeatureBySlotLevel.Clear();
 //      //    itemForm.FeatureBySlotLevel.AddRange(new List<FeatureUnlockByLevel>
 //      //  {
 //      //      new FeatureUnlockByLevel(shillelaghAttackModifierBuilder.shillelaghAttackModifier , 0)
 //      //   ,   new FeatureUnlockByLevel(ShillelaghAdditionalDamageBuilder.ShillelaghAdditionalDamage, 0)
 //      //  });
 //     
 //       // effectForm.SetItemPropertyForm(itemForm);
 //         itemeffect.SetItemPropertyForm(itemForm);
 //
 //           newEffectDescription.SetItemSelectionType(ActionDefinitions.ItemSelectionType.WeaponNonMagical);
 //          newEffectDescription.EffectForms.Add(itemeffect);
 //          newEffectDescription.SetDurationType(RuleDefinitions.DurationType.Minute);
 //          newEffectDescription.SetDurationParameter(1);
 //
 //
 //
 //
 //      }
 //
 //      public static SpellDefinition CreateAndAddToDB(string name, string guid)
 //          => new shillelaghCantripBuilder(name, guid).AddToDB();
 //
 //      public static SpellDefinition shillelaghCantrip = CreateAndAddToDB(shillelaghCantripName, shillelaghCantripGuid);
 //  }
 // internal class shillelaghAttackModifierBuilder : BaseDefinitionBuilder<FeatureDefinitionAttackModifier>
 // {
 //     const string Name = "shillelaghAttackModifier";
 //     const string Guid = "77750733-551b-418e-b868-de796f566471";
 //
 //     protected shillelaghAttackModifierBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionAttackModifiers.AttackModifierOathOfDevotionSacredWeapon, name, guid)
 //     {
 //         Definition.GuiPresentation.Title = "Feature/&shillelaghAttackModifierTitle";
 //         Definition.GuiPresentation.Description = "Feature/&shillelaghAttackModifierDescription";
 //
 //         Definition.SetAttackRollAbilityScore(DatabaseHelper.SmartAttributeDefinitions.Wisdom.Name);
 //         Definition.SetDamageRollAbilityScore(DatabaseHelper.SmartAttributeDefinitions.Wisdom.Name);
 //         Definition.SetAttackRollModifierMethod(RuleDefinitions.AttackModifierMethod.AddAbilityScoreBonus);
 //         Definition.SetDamageRollModifierMethod(RuleDefinitions.AttackModifierMethod.AddAbilityScoreBonus);
 //
 //         Definition.SetAdditionalAttackTag("Magical");
 //
 //
 //     }
 //
 //     public static FeatureDefinitionAttackModifier CreateAndAddToDB(string name, string guid)
 //         => new shillelaghAttackModifierBuilder(name, guid).AddToDB();
 //
 //     public static FeatureDefinitionAttackModifier shillelaghAttackModifier     = CreateAndAddToDB(Name, Guid);
 // }
 // internal class ShillelaghAdditionalDamageBuilder : BaseDefinitionBuilder<FeatureDefinitionAdditionalDamage>
 // {
 //     const string Name = "ShillelaghAdditionalDamage";
 //     const string Guid = "9e50853b-ce42-4050-aaac-4e234de52e9a";
 //
 //     protected ShillelaghAdditionalDamageBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionAdditionalDamages.AdditionalDamagePoison_Basic, name, guid)
 //     {
 //         Definition.GuiPresentation.Title = "Feature/&ShillelaghAdditionalDamageTitle";
 //         Definition.GuiPresentation.Description = "Feature/&ShillelaghAdditionalDamageDescription";
 //         Definition.SetNotificationTag("Shillelagh");
 //         Definition.SetHasSavingThrow(false);
 //         Definition.SetAdditionalDamageType(RuleDefinitions.AdditionalDamageType.SameAsBaseDamage);
 //         Definition.SetTriggerCondition(RuleDefinitions.AdditionalDamageTriggerCondition.AlwaysActive);
 //         Definition.SetDamageDiceNumber(1);
 //         Definition.SetDamageValueDetermination(RuleDefinitions.AdditionalDamageValueDetermination.Die);
 //         Definition.SetDamageDieType(RuleDefinitions.DieType.D4);
 //
 //
 //     }
 //
 //     public static FeatureDefinitionAdditionalDamage CreateAndAddToDB(string name, string guid)
 //         => new ShillelaghAdditionalDamageBuilder(name, guid).AddToDB();
 //
 //     public static FeatureDefinitionAdditionalDamage ShillelaghAdditionalDamage = CreateAndAddToDB(Name, Guid);
 // }
 //
 //
 // internal class HeatMetalSpellBuilder : BaseDefinitionBuilder<SpellDefinition>
 // {
 //     const string HeatMetalSpellName = "HeatMetalSpell";
 //     const string HeatMetalSpellGuid = "69ded88e-a57d-4480-9a64-b227cdec686f";
 //
 //     protected HeatMetalSpellBuilder(string name, string guid) : base(DatabaseHelper.SpellDefinitions.FireBolt , name, guid)
 //     {
 //         Definition.GuiPresentation.Title = "Feat/&HeatMetalSpellTitle";
 //         Definition.GuiPresentation.Description = "Feat/&HeatMetalSpellDescription";
 //         Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.SpellDefinitions.Banishment.GuiPresentation.SpriteReference);
 //
 //           Definition.SetSpellLevel(2);
 //           Definition.SetRequiresConcentration(true);
 //
 //           EffectForm HeatMetalEffect = new EffectForm();
 //           HeatMetalEffect.ConditionForm = new ConditionForm();
 //           HeatMetalEffect.FormType = EffectForm.EffectFormType.Condition;
 //           HeatMetalEffect.ConditionForm.Operation = ConditionForm.ConditionOperation.Add;
 //           HeatMetalEffect.ConditionForm.ConditionDefinition = HeatMetalConditionBuilder.HeatMetalCondition ;//
 //
 //
 //
 //
 //           //Add to our new effect
 //           EffectDescription newEffectDescription = new EffectDescription();
 //           newEffectDescription.Copy(Definition.EffectDescription);
 //           newEffectDescription.EffectForms.Clear();
 //           newEffectDescription.EffectForms.Add(HeatMetalEffect);
 //
 //           newEffectDescription.HasSavingThrow = false;
 //           newEffectDescription.DurationType = RuleDefinitions.DurationType.Minute;
 //           newEffectDescription.SetTargetSide(RuleDefinitions.Side.Enemy);
 //           newEffectDescription.SetTargetType(RuleDefinitions.TargetType.Individuals);
 //           newEffectDescription.SetTargetProximityDistance(12);
 //           newEffectDescription.SetCanBePlacedOnCharacter(true);
 //           newEffectDescription.SetRangeType(RuleDefinitions.RangeType.Distance);
 //           newEffectDescription.SetRangeParameter(12);
 //           newEffectDescription.SetTargetParameter(1);
 //           Definition.SetEffectDescription(newEffectDescription);
 //
 //      }
 //
 //      public static SpellDefinition CreateAndAddToDB(string name, string guid)
 //          => new HeatMetalSpellBuilder(name, guid).AddToDB();
 //
 //      public static SpellDefinition HeatMetalSpell = CreateAndAddToDB(HeatMetalSpellName, HeatMetalSpellGuid);
 //  }
 //
 //  internal class HeatMetalConditionBuilder : BaseDefinitionBuilder<ConditionDefinition>
 //  {
 //      const string HeatMetalConditionName = "HeatMetalCondition";
 //      const string HeatMetalConditionGuid = "09a33627-f7d7-489a-87bd-380c96039854";
 //
 //      protected HeatMetalConditionBuilder(string name, string guid) : base(DatabaseHelper.ConditionDefinitions.ConditionBaned, name, guid)
 //      {
 //          Definition.GuiPresentation.Title = "Feature/&HeatMetalConditionTitle";
 //          Definition.GuiPresentation.Description = "Feature/&HeatMetalConditionDescription";
 //
 //          Definition.SetAllowMultipleInstances(false);
 //          Definition.Features.Clear();
 //         Definition.Features.Add(HeatMetalAdditionalDamageBuilder.HeatMetalAdditionalDamage); // additional damage
 //         Definition.Features.Add(HeatMetalDisadvantageBuilder.HeatMetalDisadvantage); // combat affinity
 //
 //          Definition.SetDurationType(RuleDefinitions.DurationType.Minute);
 //          Definition.SetDurationParameter(1);
 //      }
 //
 //      public static ConditionDefinition CreateAndAddToDB(string name, string guid)
 //          => new HeatMetalConditionBuilder(name, guid).AddToDB();
 //
 //      public static ConditionDefinition HeatMetalCondition
 //          = CreateAndAddToDB(HeatMetalConditionName, HeatMetalConditionGuid);
 //  }
 //
 //
 //
 //
 //  internal class HeatMetalAdditionalDamageBuilder : BaseDefinitionBuilder<FeatureDefinitionAdditionalDamage>
 //  {
 //      const string Name = "HeatMetalAdditionalDamage";
 //      const string Guid = "8b58f2d4-86f0-4004-ba8f-bbb76fbf2edd";
 //
 //      protected HeatMetalAdditionalDamageBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionAdditionalDamages.AdditionalDamagePoison_Basic, name, guid)
 //      {
 //          Definition.GuiPresentation.Title = "Feature/&HeatMetalAdditionalDamageTitle";
 //          Definition.GuiPresentation.Description = "Feature/&HeatMetalAdditionalDamageDescription";
 //          Definition.SetNotificationTag("HeatMetal");
 //
 //
 //          Definition.SetRequiredTargetCreatureTag("MetalArmor");
 //          Definition.SetHasSavingThrow(false);
 //          Definition.SetAdditionalDamageType(RuleDefinitions.AdditionalDamageType.Specific);
 //          Definition.SetSpecificDamageType(DatabaseHelper.DamageDefinitions.DamageFire.Name);
 //          Definition.SetTriggerCondition(RuleDefinitions.AdditionalDamageTriggerCondition.TargetHasCreatureTag);
 //          Definition.SetDamageDiceNumber(2);
 //          Definition.SetDamageValueDetermination(RuleDefinitions.AdditionalDamageValueDetermination.Die);
 //          Definition.SetDamageDieType(RuleDefinitions.DieType.D6);
 //          
 //
 //      }
 //
 //      public static FeatureDefinitionAdditionalDamage CreateAndAddToDB(string name, string guid)
 //          => new HeatMetalAdditionalDamageBuilder(name, guid).AddToDB();
 //
 //      public static FeatureDefinitionAdditionalDamage HeatMetalAdditionalDamage = CreateAndAddToDB(Name, Guid);
 //  }
 //
 //  internal class HeatMetalDisadvantageBuilder : BaseDefinitionBuilder<FeatureDefinitionCombatAffinity>
 //  {
 //      const string HeatMetalDisadvantageName = "MetalDisadvantage";
 //      const string HeatMetalDisadvantageGuid = "0228f75a-fa8f-4f47-9675-3bce4bcec6b4";
 //
 //      protected HeatMetalDisadvantageBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionCombatAffinitys.CombatAffinityPoisoned, name, guid)
 //      {
 //          Definition.GuiPresentation.Title = "Feature/&MetalDisadvantageTitle";
 //          Definition.GuiPresentation.Description = "Feature/&MetalDisadvantageDescription";
 //          Definition.SetMyAttackAdvantage(RuleDefinitions.AdvantageType.Disadvantage);
 //          Definition.SetSituationalContext(RuleDefinitions.SituationalContext.WearingArmor);
 //      }
 //
 //      public static FeatureDefinitionCombatAffinity CreateAndAddToDB(string name, string guid)
 //          => new HeatMetalDisadvantageBuilder(name, guid).AddToDB();
 //
 //      public static FeatureDefinitionCombatAffinity HeatMetalDisadvantage = CreateAndAddToDB(HeatMetalDisadvantageName, HeatMetalDisadvantageGuid);
 //  }

}