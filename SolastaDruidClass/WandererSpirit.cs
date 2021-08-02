using System;
using System.Collections.Generic; 
using SolastaModApi;
using SolastaModApi.Extensions; 
using HarmonyLib;
using NewFeatureDefinitions = SolastaModHelpers.NewFeatureDefinitions;

namespace SolastaDruidClass
{

  
    //*****************************************************************************************************************************************
    //***********************************		SummonWandererSpiritBuilder		*******************************************************************
    //*****************************************************************************************************************************************

//    internal class SummonWandererSpiritPowerBuilder : BaseDefinitionBuilder<NewFeatureDefinitions.PowerWithRestrictions>
//    {
//        const string SummonWandererSpiritName = "SummonWandererSpirit";
//        const string SummonWandererSpiritNameGuid = "59447ad2-d6f1-4b73-b1b3-cd927300d140";
//
//        protected SummonWandererSpiritPowerBuilder(string name, string guid) : base( name, guid)
//        {
//
//            Definition.GuiPresentation.Title = "Feat/&SummonWandererSpiritTitle";
//            Definition.GuiPresentation.Description = "Feat/&SummonWandererSpiritDescription";
//            Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.SpellDefinitions.ConjureElementalAir.GuiPresentation.SpriteReference);
//
//            Definition.SetActivationTime(RuleDefinitions.ActivationTime.BonusAction);
//            Definition.SetRechargeRate(RuleDefinitions.RechargeRate.ShortRest);
//            Definition.SetFixedUsesPerRecharge(2);
//            Definition.SetCostPerUse(1);
//            Definition.SetHasCastingFailure(false);
//            Definition.SetUniqueInstance(true);
//
//
//            SummonForm summonprotector = new SummonForm();
//            //summonprotector.SetMonsterDefinitionName(DatabaseHelper.MonsterDefinitions.Poisonous_Snake.Name);
//            summonprotector.SetMonsterDefinitionName(WandererSpiritBuilder.WandererSpirit.Name);
//            summonprotector.SetSummonType(SummonForm.Type.Creature);
//            summonprotector.SetNumber(1);
//            summonprotector.SetDecisionPackage(DatabaseHelper.DecisionPackageDefinitions.IdleGuard_Default);
//            summonprotector.SetEffectProxyDefinitionName("");
//
//            EffectForm summoneffect = new EffectForm();
//            summoneffect.FormType = EffectForm.EffectFormType.Summon;//"summons";
//            summoneffect.SetSummonForm(summonprotector);
//
//
//
//            //Add to our new effect
//            EffectDescription newEffectDescription = new EffectDescription();
//            newEffectDescription.Copy(Definition.EffectDescription);
//            newEffectDescription.EffectForms.Clear();
//            newEffectDescription.EffectForms.Add(summoneffect);
//            newEffectDescription.SetRangeParameter(1);
//            newEffectDescription.SetTargetType(RuleDefinitions.TargetType.Position);
//            newEffectDescription.DurationType = RuleDefinitions.DurationType.Hour;
//            newEffectDescription.DurationParameter = 1;
//
//
//
//            Definition.SetEffectDescription(newEffectDescription);
//
//
//        }
//
//        public static NewFeatureDefinitions.PowerWithRestrictions CreateAndAddToDB(string name, string guid)
//            => new SummonWandererSpiritPowerBuilder(name, guid).AddToDB();
//
//        public static NewFeatureDefinitions.PowerWithRestrictions SummonWandererSpirit = CreateAndAddToDB(SummonWandererSpiritName, SummonWandererSpiritNameGuid);
//
//    }
//
//    //*****************************************************************************************************************************************
//    //***********************************		SummonWandererSpiritPower_2Builder		*******************************************************************
//    //*****************************************************************************************************************************************
//
//    internal class SummonWandererSpiritPower_2Builder : BaseDefinitionBuilder<NewFeatureDefinitions.PowerWithRestrictions>
//    {
//        const string SummonWandererSpiritPower_2Name = "SummonWandererSpiritPower_2";
//        const string SummonWandererSpiritPower_2NameGuid = "f777b42f-8369-4cbf-9497-2fe662ae3445";
//
//        protected SummonWandererSpiritPower_2Builder(string name, string guid) : base(SummonWandererSpiritPowerBuilder.SummonWandererSpirit, name, guid)
//        {
//            Definition.GuiPresentation.Title = "Feat/&SummonWandererSpiritTitle_2";
//            Definition.GuiPresentation.Description = "Feat/&SummonWandererSpiritDescription_2";
//
//            Definition.SetOverriddenPower(SummonWandererSpiritPowerBuilder.SummonWandererSpirit);
//
//            Definition.EffectDescription.EffectForms[0].SummonForm.SetMonsterDefinitionName(WandererSpirit_2Builder.WandererSpirit_2.Name);
//
//        
//
//
//        }
//
//        public static NewFeatureDefinitions.PowerWithRestrictions CreateAndAddToDB(string name, string guid)
//            => new SummonWandererSpiritPower_2Builder(name, guid).AddToDB();
//
//        public static NewFeatureDefinitions.PowerWithRestrictions SummonWandererSpiritPower_2 = CreateAndAddToDB(SummonWandererSpiritPower_2Name, SummonWandererSpiritPower_2NameGuid);
//
//    }
//    //*****************************************************************************************************************************************
//    //***********************************		SummonWandererSpiritPower_3Builder		*******************************************************************
//    //*****************************************************************************************************************************************
//
//    internal class SummonWandererSpiritPower_3Builder : BaseDefinitionBuilder<NewFeatureDefinitions.PowerWithRestrictions>
//    {
//        const string SummonWandererSpiritPower_3Name = "SummonWandererSpiritPower_3";
//        const string SummonWandererSpiritPower_3NameGuid = "217208a4-01fb-4524-8ddc-576b32744003";
//
//        protected SummonWandererSpiritPower_3Builder(string name, string guid) : base(SummonWandererSpiritPowerBuilder.SummonWandererSpirit, name, guid)
//        {
//
//            Definition.GuiPresentation.Title = "Feat/&SummonWandererSpiritTitle_3";
//            Definition.GuiPresentation.Description = "Feat/&SummonWandererSpiritDescription_3";
//            Definition.SetOverriddenPower(SummonWandererSpiritPower_2Builder.SummonWandererSpiritPower_2);
//
//            Definition.EffectDescription.EffectForms[0].SummonForm.SetMonsterDefinitionName(WandererSpirit_3Builder.WandererSpirit_3.Name);
//
//            ConditionForm casterFlight = new ConditionForm();
//            casterFlight.SetApplyToSelf(true);
//            casterFlight.SetForceOnSelf(true);
//            casterFlight.Operation = ConditionForm.ConditionOperation.Add;
//            casterFlight.SetConditionDefinitionName(DatabaseHelper.ConditionDefinitions.ConditionFlyingBootsWinged.Name);
//            casterFlight.ConditionDefinition = DatabaseHelper.ConditionDefinitions.ConditionFlyingBootsWinged; 
//
//            EffectForm casterFlightEffect = new EffectForm();
//            casterFlightEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
//            casterFlightEffect.SetLevelMultiplier(1);
//            casterFlightEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
//            casterFlightEffect.SetCreatedByCharacter(true);
//            casterFlightEffect.FormType = EffectForm.EffectFormType.Condition;
//            casterFlightEffect.ConditionForm = casterFlight;
//
//            Definition.EffectDescription.EffectForms.Add(casterFlightEffect);
//
//
//        }
//
//        public static NewFeatureDefinitions.PowerWithRestrictions CreateAndAddToDB(string name, string guid)
//            => new SummonWandererSpiritPower_3Builder(name, guid).AddToDB();
//
//        public static NewFeatureDefinitions.PowerWithRestrictions SummonWandererSpiritPower_3 = CreateAndAddToDB(SummonWandererSpiritPower_3Name, SummonWandererSpiritPower_3NameGuid);
//
//    }
//
//    //*****************************************************************************************************************************************
//    //***********************************		SummonWandererSpiritPower_4Builder		*******************************************************************
//    //*****************************************************************************************************************************************
//
//    internal class SummonWandererSpiritPower_4Builder : BaseDefinitionBuilder<NewFeatureDefinitions.PowerWithRestrictions>
//    {
//        const string SummonWandererSpiritPower_4Name = "SummonWandererSpiritPower_4";
//        const string SummonWandererSpiritPower_4NameGuid = "119fface-8c98-4302-9088-afcc4cd79168";
//
//        protected SummonWandererSpiritPower_4Builder(string name, string guid) : base(SummonWandererSpiritPower_3Builder.SummonWandererSpiritPower_3, name, guid)
//        {
//
//            Definition.GuiPresentation.Title = "Feat/&SummonWandererSpiritTitle_4";
//            Definition.GuiPresentation.Description = "Feat/&SummonWandererSpiritDescription_4";
//            Definition.SetOverriddenPower(SummonWandererSpiritPower_3Builder.SummonWandererSpiritPower_3);
//
//            Definition.EffectDescription.EffectForms[0].SummonForm.SetMonsterDefinitionName(WandererSpirit_4Builder.WandererSpirit_4.Name);
//
//            ConditionForm casterSemiIncorporeal = new ConditionForm();
//            casterSemiIncorporeal.SetApplyToSelf(true);
//            casterSemiIncorporeal.SetForceOnSelf(true);
//            casterSemiIncorporeal.Operation = ConditionForm.ConditionOperation.Add;
//            casterSemiIncorporeal.SetConditionDefinitionName(DatabaseHelper.ConditionDefinitions.ConditionWardedByWardingBond.Name);
//            casterSemiIncorporeal.ConditionDefinition = DatabaseHelper.ConditionDefinitions.ConditionWardedByWardingBond;
//
//            EffectForm casterSemiIncorporealEffect = new EffectForm();
//            casterSemiIncorporealEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
//            casterSemiIncorporealEffect.SetLevelMultiplier(1);
//            casterSemiIncorporealEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
//            casterSemiIncorporealEffect.SetCreatedByCharacter(true);
//            casterSemiIncorporealEffect.FormType = EffectForm.EffectFormType.Condition;
//            casterSemiIncorporealEffect.ConditionForm = casterSemiIncorporeal;
//
//            Definition.EffectDescription.EffectForms.Add(casterSemiIncorporealEffect);
//
//
//        }
//
//        public static NewFeatureDefinitions.PowerWithRestrictions CreateAndAddToDB(string name, string guid)
//            => new SummonWandererSpiritPower_4Builder(name, guid).AddToDB();
//
//        public static NewFeatureDefinitions.PowerWithRestrictions SummonWandererSpiritPower_4 = CreateAndAddToDB(SummonWandererSpiritPower_4Name, SummonWandererSpiritPower_4NameGuid);
//
//    }
//    //*****************************************************************************************************************************************
//    //***********************************		SummonWandererSpiritPower_5Builder		*******************************************************************
//    //*****************************************************************************************************************************************
//
//    internal class SummonWandererSpiritPower_5Builder : BaseDefinitionBuilder<NewFeatureDefinitions.PowerWithRestrictions>
//    {
//        const string SummonWandererSpiritPower_5Name = "SummonWandererSpiritPower_5";
//        const string SummonWandererSpiritPower_5NameGuid = "6fe7e717-b2ae-48bc-86d3-3d2574248b7a";
//
//        protected SummonWandererSpiritPower_5Builder(string name, string guid) : base(SummonWandererSpiritPower_4Builder.SummonWandererSpiritPower_4, name, guid)
//        {
//
//            Definition.GuiPresentation.Title = "Feat/&SummonWandererSpiritTitle_5";
//            Definition.GuiPresentation.Description = "Feat/&SummonWandererSpiritDescription_5";
//            Definition.SetOverriddenPower(SummonWandererSpiritPower_4Builder.SummonWandererSpiritPower_4);
//
//            Definition.EffectDescription.EffectForms[0].SummonForm.SetMonsterDefinitionName(WandererSpirit_5Builder.WandererSpirit_5.Name);
//
//         
//
//
//        }
//
//        public static NewFeatureDefinitions.PowerWithRestrictions CreateAndAddToDB(string name, string guid)
//            => new SummonWandererSpiritPower_5Builder(name, guid).AddToDB();
//
//        public static NewFeatureDefinitions.PowerWithRestrictions SummonWandererSpiritPower_5 = CreateAndAddToDB(SummonWandererSpiritPower_5Name, SummonWandererSpiritPower_5NameGuid);
//
//    }
//  


}

