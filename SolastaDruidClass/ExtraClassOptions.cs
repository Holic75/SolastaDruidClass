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

    internal class DH_StaffOfWoodlandsBuilder : BaseDefinitionBuilder<ItemDefinition>
    {
        const string DH_StaffOfWoodlandsName = "DH_StaffOfWoodlands";
        const string DH_StaffOfWoodlandsGuid = "56ae6296-47b9-4cf2-a95b-181a56655261";

        protected DH_StaffOfWoodlandsBuilder(string name, string guid) : base(DatabaseHelper.ItemDefinitions.StaffOfHealing, name, guid)
        {

            Definition.GuiPresentation.Title = "Equipment/&DH_StaffOfWoodlandsTitle";
            Definition.GuiPresentation.Description = "Equipment/&DH_StaffOfWoodlandsDescription";
            //  Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.ItemDefinitions.WandOfLightningBolts.GuiPresentation.SpriteReference);

            Definition.SetRequiresIdentification(false);
            Definition.SetRequiresAttunement(true);

            Definition.SetInDungeonEditor(true);

            CharacterClassDefinition Druid = DatabaseRepository.GetDatabase<CharacterClassDefinition>().TryGetElement("DHDruid", "a2112af0-636f-4b72-acdc-07c921bcea6d");
            //
            Definition.RequiredAttunementClasses.Clear();
            Definition.RequiredAttunementClasses.Add(Druid);


             Definition.StaticProperties.Clear();
            //
            ItemPropertyDescription attackAndDamageProperty = new ItemPropertyDescription();
            attackAndDamageProperty.SetFeatureDefinition(DatabaseHelper.FeatureDefinitionAttackModifiers.AttackModifierWeaponPlus2);
            attackAndDamageProperty.SetType(ItemPropertyDescription.PropertyType.Feature);
            attackAndDamageProperty.SetAppliesOnItemOnly(true);
            attackAndDamageProperty.SetKnowledgeAffinity(EquipmentDefinitions.KnowledgeAffinity.InactiveAndHidden);
            // itemProperty.SetConditionDefinition();

            ItemPropertyDescription SpellcastingProperty = new ItemPropertyDescription();
            SpellcastingProperty.SetFeatureDefinition(DatabaseHelper.FeatureDefinitionAttributeModifiers.AttributeModifierCreed_Of_Maraike);
            SpellcastingProperty.SetType(ItemPropertyDescription.PropertyType.Feature);
            //itemProperty.SetAppliesOnItemOnly(false);
            SpellcastingProperty.SetKnowledgeAffinity(EquipmentDefinitions.KnowledgeAffinity.InactiveAndHidden);



            Definition.StaticProperties.Add(attackAndDamageProperty);
            Definition.StaticProperties.Add(SpellcastingProperty);
            Definition.StaticProperties.Add(SpellcastingProperty);

            //       Definition.UsableDeviceDescription.SetSaveDC(13);
            Definition.UsableDeviceDescription.SetChargesCapital(EquipmentDefinitions.ItemChargesCapital.Fixed);
            Definition.UsableDeviceDescription.SetChargesCapitalBonus(4);
            Definition.UsableDeviceDescription.SetChargesCapitalDie(RuleDefinitions.DieType.D6);
            Definition.UsableDeviceDescription.SetChargesCapitalNumber(10);
            Definition.UsableDeviceDescription.SetMagicAttackBonus(2);
            Definition.UsableDeviceDescription.SetOutOfChargesConsequence(EquipmentDefinitions.ItemOutOfCharges.DestroyOnRoll1);
            Definition.UsableDeviceDescription.SetRechargeBonus(4);
            Definition.UsableDeviceDescription.SetRechargeDie(RuleDefinitions.DieType.D6);
            Definition.UsableDeviceDescription.SetRechargeNumber(1);
            Definition.UsableDeviceDescription.SetRechargeRate(RuleDefinitions.RechargeRate.LongRest);
            Definition.UsableDeviceDescription.SetSaveDC(15);
            //
            //
            

            //
            Definition.UsableDeviceDescription.DeviceFunctions.Clear();


            DeviceFunctionDescription passwithoutatrace = new DeviceFunctionDescription();
            passwithoutatrace.SetCanOverchargeSpell(false);
            passwithoutatrace.SetDurationType(RuleDefinitions.DurationType.UntilLongRest);
            passwithoutatrace.SetSpellDefinition(DatabaseHelper.SpellDefinitions.PassWithoutTrace);
            passwithoutatrace.SetParentUsage(EquipmentDefinitions.ItemUsage.Charges);
            passwithoutatrace.SetRechargeRate(RuleDefinitions.RechargeRate.LongRest);
            passwithoutatrace.SetType(DeviceFunctionDescription.FunctionType.Spell);
            passwithoutatrace.SetUseAffinity(DeviceFunctionDescription.FunctionUseAffinity.ChargeCost);
            passwithoutatrace.SetUseAmount(0);


            DeviceFunctionDescription AnimalFriendship = new DeviceFunctionDescription();
            AnimalFriendship.SetCanOverchargeSpell(false);
            AnimalFriendship.SetDurationType(RuleDefinitions.DurationType.UntilLongRest);
            AnimalFriendship.SetSpellDefinition(DatabaseHelper.SpellDefinitions.AnimalFriendship);
            AnimalFriendship.SetParentUsage(EquipmentDefinitions.ItemUsage.Charges);
            AnimalFriendship.SetRechargeRate(RuleDefinitions.RechargeRate.LongRest);
            AnimalFriendship.SetType(DeviceFunctionDescription.FunctionType.Spell);
            AnimalFriendship.SetUseAffinity(DeviceFunctionDescription.FunctionUseAffinity.ChargeCost);
            AnimalFriendship.SetUseAmount(1);

            DeviceFunctionDescription Barkskin = new DeviceFunctionDescription();
            Barkskin.SetCanOverchargeSpell(false);
            Barkskin.SetDurationType(RuleDefinitions.DurationType.UntilLongRest);
            Barkskin.SetSpellDefinition(DatabaseHelper.SpellDefinitions.Barkskin);
            Barkskin.SetParentUsage(EquipmentDefinitions.ItemUsage.Charges);
            Barkskin.SetRechargeRate(RuleDefinitions.RechargeRate.LongRest);
            Barkskin.SetType(DeviceFunctionDescription.FunctionType.Spell);
            Barkskin.SetUseAffinity(DeviceFunctionDescription.FunctionUseAffinity.ChargeCost);
            Barkskin.SetUseAmount(2);

            DeviceFunctionDescription Sunbeam = new DeviceFunctionDescription();
            Sunbeam.SetCanOverchargeSpell(false);
            Sunbeam.SetDurationType(RuleDefinitions.DurationType.UntilLongRest);
            Sunbeam.SetSpellDefinition(DatabaseHelper.SpellDefinitions.Sunbeam);
            Sunbeam.SetParentUsage(EquipmentDefinitions.ItemUsage.Charges);
            Sunbeam.SetRechargeRate(RuleDefinitions.RechargeRate.LongRest);
            Sunbeam.SetType(DeviceFunctionDescription.FunctionType.Spell);
            Sunbeam.SetUseAffinity(DeviceFunctionDescription.FunctionUseAffinity.ChargeCost);
            Sunbeam.SetUseAmount(6);

            DeviceFunctionDescription Entangle = new DeviceFunctionDescription();
            Entangle.SetCanOverchargeSpell(false);
            Entangle.SetDurationType(RuleDefinitions.DurationType.UntilLongRest);
            Entangle.SetSpellDefinition(DatabaseHelper.SpellDefinitions.Entangle);
            Entangle.SetParentUsage(EquipmentDefinitions.ItemUsage.Charges);
            Entangle.SetRechargeRate(RuleDefinitions.RechargeRate.LongRest);
            Entangle.SetType(DeviceFunctionDescription.FunctionType.Spell);
            Entangle.SetUseAffinity(DeviceFunctionDescription.FunctionUseAffinity.ChargeCost);
            Entangle.SetUseAmount(1);

            DeviceFunctionDescription ConjureAnimals = new DeviceFunctionDescription();
            ConjureAnimals.SetCanOverchargeSpell(false);
            ConjureAnimals.SetDurationType(RuleDefinitions.DurationType.UntilLongRest);
            ConjureAnimals.SetSpellDefinition(DatabaseHelper.SpellDefinitions.ConjureAnimals);
            ConjureAnimals.SetParentUsage(EquipmentDefinitions.ItemUsage.Charges);
            ConjureAnimals.SetRechargeRate(RuleDefinitions.RechargeRate.LongRest);
            ConjureAnimals.SetType(DeviceFunctionDescription.FunctionType.Spell);
            ConjureAnimals.SetUseAffinity(DeviceFunctionDescription.FunctionUseAffinity.ChargeCost);
            ConjureAnimals.SetUseAmount(3);

            var devicefunctionlist = new List<DeviceFunctionDescription> {
            passwithoutatrace,
            AnimalFriendship,
            Entangle,
            Barkskin,
            ConjureAnimals,
            Sunbeam
            };

            Definition.UsableDeviceDescription.DeviceFunctions.AddRange(devicefunctionlist);
            
        }

        public static ItemDefinition CreateAndAddToDB(string name, string guid)
            => new DH_StaffOfWoodlandsBuilder(name, guid).AddToDB();

        public static ItemDefinition DH_StaffOfWoodlands = CreateAndAddToDB(DH_StaffOfWoodlandsName, DH_StaffOfWoodlandsGuid);


    }
   

}