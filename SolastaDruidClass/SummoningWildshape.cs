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

	
	internal class WildShapePowerBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string Name = "WildShapePowerBuilder";
        const string Guid = "03851fd5-8481-4b60-91f6-0adb9c348d9d";

        protected WildShapePowerBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionPowers.PowerClericDivineInterventionCleric, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&WildShapePowerBuilderTitle";
            Definition.GuiPresentation.Description = "Feature/&WildShapePowerBuilderDescription";

            Definition.SetHasCastingFailure(false);
            Definition.SetRechargeRate(RuleDefinitions.RechargeRate.ShortRest);
            Definition.SetActivationTime(RuleDefinitions.ActivationTime.Action);
            Definition.SetCostPerUse(1);
            Definition.SetFixedUsesPerRecharge(2);
            Definition.SetShortTitleOverride("Feature/&WildShapePowerBuilderTitle");

            SummonForm SummonWildShape = new SummonForm();
            SummonWildShape.SetMonsterDefinitionName(WildShaped_WolfBuilder.WildShaped_Wolf.Name);
          //  SummonWildShape.SetItemDefinition(WandOfWildshapeBuilder.WandOfWildshape);
            SummonWildShape.SetSummonType(SummonForm.Type.Creature);
            SummonWildShape.SetNumber(1);
            SummonWildShape.SetDecisionPackage(DatabaseHelper.DecisionPackageDefinitions.IdleGuard_Default);
            SummonWildShape.SetEffectProxyDefinitionName("");
           // SummonWildShape.SetConditionDefinition(DatabaseHelper.ConditionDefinitions.ConditionMindDominatedByCaster);

            EffectForm WildShapeEffect = new EffectForm();
            WildShapeEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
            WildShapeEffect.SetLevelMultiplier(1);
            WildShapeEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            WildShapeEffect.SetCreatedByCharacter(true);
            WildShapeEffect.FormType = EffectForm.EffectFormType.Summon;
            WildShapeEffect.SetSummonForm(SummonWildShape);


            ConditionForm casterwildshaped = new ConditionForm();
            casterwildshaped.SetApplyToSelf(true);
            casterwildshaped.SetForceOnSelf(true);
            casterwildshaped.Operation = ConditionForm.ConditionOperation.Add;
          //  casterwildshaped.SetConditionDefinitionName(CasterWhileWildshapedConditionBuilder.CasterWhileWildshapedCondition.Name);
          //  casterwildshaped.ConditionDefinition = CasterWhileWildshapedConditionBuilder.CasterWhileWildshapedCondition;
            casterwildshaped.SetConditionDefinitionName(DatabaseHelper.ConditionDefinitions.ConditionInvisibleGreater.Name);
            casterwildshaped.ConditionDefinition = DatabaseHelper.ConditionDefinitions.ConditionInvisibleGreater;

            EffectForm casterwildshapedEffect = new EffectForm();
            casterwildshapedEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
            casterwildshapedEffect.SetLevelMultiplier(1);
            casterwildshapedEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            casterwildshapedEffect.SetCreatedByCharacter(true);
            casterwildshapedEffect.FormType = EffectForm.EffectFormType.Condition;
            casterwildshapedEffect.ConditionForm = casterwildshaped;

            ConditionForm casterRestrictedActions = new ConditionForm();
            casterRestrictedActions.SetApplyToSelf(true);
            casterRestrictedActions.SetForceOnSelf(true);
            casterRestrictedActions.Operation = ConditionForm.ConditionOperation.Add;
            //casterRestrictedActions.SetConditionDefinitionName(CasterWhileWildshapedConditionBuilder.CasterWhileWildshapedCondition.Name);
            //casterRestrictedActions.ConditionDefinition = CasterWhileWildshapedConditionBuilder.CasterWhileWildshapedCondition;
            casterRestrictedActions.SetConditionDefinitionName(DatabaseHelper.ConditionDefinitions.ConditionSlowed.Name);
            casterRestrictedActions.ConditionDefinition = DatabaseHelper.ConditionDefinitions.ConditionSlowed;

            EffectForm casterRestrictedActionsEffect = new EffectForm();
            casterRestrictedActionsEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
            casterRestrictedActionsEffect.SetLevelMultiplier(1);
            casterRestrictedActionsEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            casterRestrictedActionsEffect.SetCreatedByCharacter(true);
            casterRestrictedActionsEffect.FormType = EffectForm.EffectFormType.Condition;
            casterRestrictedActionsEffect.ConditionForm = casterRestrictedActions;


            ConditionForm casterinvincible = new ConditionForm();
            casterinvincible.SetApplyToSelf(true);
            casterinvincible.SetForceOnSelf(true);
            casterinvincible.Operation = ConditionForm.ConditionOperation.Add;
            //casterinvincible.SetConditionDefinitionName(CasterWhileWildshapedConditionBuilder.CasterWhileWildshapedCondition.Name);
            //casterinvincible.ConditionDefinition = CasterWhileWildshapedConditionBuilder.CasterWhileWildshapedCondition;
            casterinvincible.SetConditionDefinitionName(DatabaseHelper.ConditionDefinitions.ConditionDebugInvicible.Name);
            casterinvincible.ConditionDefinition = DatabaseHelper.ConditionDefinitions.ConditionDebugInvicible;
        
            EffectForm casterinvincibleEffect = new EffectForm();
            casterinvincibleEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
            casterinvincibleEffect.SetLevelMultiplier(1);
            casterinvincibleEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            casterinvincibleEffect.SetCreatedByCharacter(true);
            casterinvincibleEffect.FormType = EffectForm.EffectFormType.Condition;
            casterinvincibleEffect.ConditionForm = casterinvincible;


            EffectDescription effectdescription = new EffectDescription();
            effectdescription.EffectForms.Add(WildShapeEffect);
            effectdescription.EffectForms.Add(casterwildshapedEffect);
            effectdescription.EffectForms.Add(casterinvincibleEffect);
            effectdescription.EffectForms.Add(casterRestrictedActionsEffect);
            effectdescription.DurationType = RuleDefinitions.DurationType.Hour;
            effectdescription.DurationParameter = 1;
            effectdescription.SetRangeParameter(1);
            effectdescription.SetRangeType(RuleDefinitions.RangeType.Self);
            effectdescription.SetTargetType(RuleDefinitions.TargetType.Position);
            effectdescription.SetTargetParameter(1);
             



            Definition.SetEffectDescription(effectdescription);
        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new WildShapePowerBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPower WildShapePower     = CreateAndAddToDB(Name, Guid);
    }


    internal class CasterWhileWildshapedConditionBuilder : BaseDefinitionBuilder<ConditionDefinition>
    {
        const string CasterWhileWildshapedConditionName = "CasterWhileWildshapedCondition";
        const string CasterWhileWildshapedConditionGuid = "ba4b231c-53ea-4d02-96d4-c4917f1535d2";

        protected CasterWhileWildshapedConditionBuilder(string name, string guid) : base(DatabaseHelper.ConditionDefinitions.ConditionInvisibleGreater, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&CasterWhileWildshapedConditionTitle";
            Definition.GuiPresentation.Description = "Feature/&CasterWhileWildshapedConditionDescription";

            Definition.SetAllowMultipleInstances(false);
            Definition.SetDurationType(RuleDefinitions.DurationType.Dispelled);
            Definition.SetDurationParameter(1);

            Definition.Features.Clear();
            //Definition.Features.Add(DatabaseHelper.)
            
        }

        public static ConditionDefinition CreateAndAddToDB(string name, string guid)
            => new CasterWhileWildshapedConditionBuilder(name, guid).AddToDB();

        public static ConditionDefinition CasterWhileWildshapedCondition = CreateAndAddToDB(CasterWhileWildshapedConditionName, CasterWhileWildshapedConditionGuid);
    }

    internal class EndWildShapePowerBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string Name = "EndWildShapePowerBuilder";
        const string Guid = "8ba254af-9711-46da-ae5f-1fc72ae9965f";

        protected EndWildShapePowerBuilder(string name, string guid) : base(EndWildShapePowerBuilder.EndWildShapePower, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&EndWildShapePowerBuilderTitle";
            Definition.GuiPresentation.Description = "Feature/&EndWildShapePowerBuilderDescription";

            Definition.SetRechargeRate(RuleDefinitions.RechargeRate.AtWill);
            Definition.SetActivationTime(RuleDefinitions.ActivationTime.BonusAction);
            Definition.SetCostPerUse(1);
            Definition.SetFixedUsesPerRecharge(1);
            Definition.SetShortTitleOverride("Feature/&EndWildShapePowerBuilderTitle");

              

            ConditionForm endcasterwildshaped = new ConditionForm();
            endcasterwildshaped.SetApplyToSelf(true);
            endcasterwildshaped.SetForceOnSelf(true);
            endcasterwildshaped.Operation = ConditionForm.ConditionOperation.RemoveDetrimentalAll;
            //casterinvincible.SetConditionDefinitionName(CasterWhileWildshapedConditionBuilder.CasterWhileWildshapedCondition.Name);
            //casterinvincible.ConditionDefinition = CasterWhileWildshapedConditionBuilder.CasterWhileWildshapedCondition;
            endcasterwildshaped.SetConditionDefinitionName(DatabaseHelper.ConditionDefinitions.ConditionDebugInvicible.Name);
            endcasterwildshaped.ConditionDefinition = DatabaseHelper.ConditionDefinitions.ConditionDebugInvicible;
            endcasterwildshaped.DetrimentalConditions .AddRange( new List<ConditionDefinition>
            {
                DatabaseHelper.ConditionDefinitions.ConditionDebugInvicible,
                DatabaseHelper.ConditionDefinitions.ConditionInvisibleGreater,
                DatabaseHelper.ConditionDefinitions.ConditionSlowed

            });

            EffectForm endcasterwildshapedEffect = new EffectForm();
            endcasterwildshapedEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
            endcasterwildshapedEffect.SetLevelMultiplier(1);
            endcasterwildshapedEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            endcasterwildshapedEffect.SetCreatedByCharacter(true);
            endcasterwildshapedEffect.FormType = EffectForm.EffectFormType.Condition;
            endcasterwildshapedEffect.ConditionForm = endcasterwildshaped;


            CounterForm DismissWildshape = new CounterForm();
            DismissWildshape.SetType(CounterForm.CounterType.DismissCreature);

            EffectForm DismissWildshapeeffect = new EffectForm();
            DismissWildshapeeffect.FormType = EffectForm.EffectFormType.Counter;//"summons";
            DismissWildshapeeffect.SetCounterForm(DismissWildshape);
            DismissWildshapeeffect.HasSavingThrow = false;
            DismissWildshapeeffect.SetCreatedByCharacter(true);

            EffectDescription effectdescription = new EffectDescription();
            effectdescription.EffectForms.Add(endcasterwildshapedEffect);
            effectdescription.EffectForms.Add(DismissWildshapeeffect);
            effectdescription.DurationType = RuleDefinitions.DurationType.Hour;
            effectdescription.DurationParameter = 1;
            effectdescription.SetRangeParameter(12);
            effectdescription.SetRangeType(RuleDefinitions.RangeType.Distance);
            effectdescription.SetTargetType(RuleDefinitions.TargetType.Individuals);
            effectdescription.SetTargetSide(RuleDefinitions.Side.Ally);
            effectdescription.SetTargetParameter(1);




            Definition.SetEffectDescription(effectdescription);



        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new EndWildShapePowerBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPower EndWildShapePower = CreateAndAddToDB(Name, Guid);
    }

	

	internal class WildShapePower_AlphaWolfBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string Name = "WildShapePower_AlphaWolf";
        const string Guid = "1b38eddb-c6e1-4eb0-b4cf-22cb292c5fdf";

        protected WildShapePower_AlphaWolfBuilder(string name, string guid) : base(WildShapePower_AlphaWolfBuilder.WildShapePower_AlphaWolf, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&WildShapePower_AlphaWolfBuilderTitle";
            Definition.GuiPresentation.Description = "Feature/&WildShapePower_AlphaWolfBuilderDescription";

			 
            Definition.EffectDescription.EffectForms[0].SummonForm.SetMonsterDefinitionName(WildShaped_AlphaWolfBuilder.WildShaped_AlphaWolf.Name);
			Definition.SetDurationParameter(2);

        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new WildShapePower_AlphaWolfBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPower WildShapePower_AlphaWolf     = CreateAndAddToDB(Name, Guid);
    }
	
	internal class WildShapePower_BadlandsspiderBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string Name = "WildShapePower_Badlandsspider";
        const string Guid = "7229ec47-543b-4804-828e-8c6939e33c3e";

        protected WildShapePower_BadlandsspiderBuilder(string name, string guid) : base(WildShapePower_WolfBuilder.WildShapePower_Wolf, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&WildShapePower_BadlandsspiderBuilderTitle";
            Definition.GuiPresentation.Description = "Feature/&WildShapePower_BadlandsspiderBuilderDescription";

			 
            Definition.EffectDescription.EffectForms[0].SummonForm.SetMonsterDefinitionName(WildShaped_BadlandsspiderBuilder.WildShaped_Badlandsspider.Name);
			Definition.SetDurationParameter(2);

        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new WildShapePower_BadlandsspiderBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPower WildShapePower_Badlandsspider     = CreateAndAddToDB(Name, Guid);
    }	
	
	internal class WildShapePower_DirewolfBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string Name = "WildShapePower_Direwolf";
        const string Guid = "fdbe19fd-4476-4882-a9fa-b20000b635cd";

        protected WildShapePower_DirewolfBuilder(string name, string guid) : base(WildShapePower_WolfBuilder.WildShapePower_Wolf, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&WildShapePower_DirewolfBuilderTitle";
            Definition.GuiPresentation.Description = "Feature/&WildShapePower_DirewolfBuilderDescription";

			 
            Definition.EffectDescription.EffectForms[0].SummonForm.SetMonsterDefinitionName(WildShaped_DirewolfBuilder.WildShaped_Direwolf.Name);
			Definition.SetDurationParameter(2);

        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new WildShapePower_DirewolfBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPower WildShapePower_Direwolf     = CreateAndAddToDB(Name, Guid);
    }	
	
	
	internal class WildShapePower_Giant_EagleBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string Name = "WildShapePower_Giant_Eagle";
        const string Guid = "a5cfcbc8-73b0-46b2-9ba9-4220e7c19058";

        protected WildShapePower_Giant_EagleBuilder(string name, string guid) : base(WildShapePower_WolfBuilder.WildShapePower_Wolf, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&WildShapePower_Giant_EagleBuilderTitle";
            Definition.GuiPresentation.Description = "Feature/&WildShapePower_Giant_EagleBuilderDescription";

			 
            Definition.EffectDescription.EffectForms[0].SummonForm.SetMonsterDefinitionName(WildShaped_Giant_EagleBuilder.WildShaped_Giant_Eagle.Name);
			Definition.SetDurationParameter(2);

        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new WildShapePower_Giant_EagleBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPower WildShapePower_Giant_Eagle     = CreateAndAddToDB(Name, Guid);
    }
	

}