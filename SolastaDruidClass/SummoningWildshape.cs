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
    // CR 2.00 : tiger_drake, deepspider,  giant beetle

    internal class WildshapeChargesPoolBuilder : BaseDefinitionBuilder<FeatureDefinitionAttributeModifier>
    {
        const string WildshapeChargesPoolName = "WildshapeChargesPool";
        const string WildshapeChargesPoolGuid = "7f0ffd78-b8ef-476f-85cc-80812fe8fc4f";



        protected WildshapeChargesPoolBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionAttributeModifiers.AttributeModifierClericChannelDivinity, name, guid)
        {

            Definition.GuiPresentation.Title = "Feat/&WildshapeChargesPoolTitle";
            Definition.GuiPresentation.Description = "Feat/&WildshapeChargesPoolDescription";
            Definition.SetModifierValue(2);


        }

        public static FeatureDefinitionAttributeModifier CreateAndAddToDB(string name, string guid)
           => new WildshapeChargesPoolBuilder(name, guid).AddToDB();

        public static FeatureDefinitionAttributeModifier WildshapeChargesPool = CreateAndAddToDB(WildshapeChargesPoolName, WildshapeChargesPoolGuid);

    }

    internal class WildshapeFeatureSetBuilder : BaseDefinitionBuilder<FeatureDefinitionFeatureSet>
    {
        const string WildshapeFeatureSetName = "WildshapeFeatureSet";
        const string WildshapeFeatureSetGuid = "a88c0529-345b-4988-9891-bf22c2ad3ab6";

        protected WildshapeFeatureSetBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetGreenmageWardenOfTheForest, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&WildshapeFeatureSetTitle";
            Definition.GuiPresentation.Description = "Feat/&WildshapeFeatureSetDescription";

            Definition.FeatureSet.Clear();
            
            Definition.FeatureSet.Add(EndWildShapePowerBuilder.EndWildShapePower);
            Definition.FeatureSet.Add(EndWildShapePowerDeadBeastBuilder.EndWildShapePowerDeadBeast);
            Definition.FeatureSet.Add(WildShapePowerBuilder.WildShapePower);
            Definition.FeatureSet.Add(WildshapeChargesPoolBuilder.WildshapeChargesPool);
        //   Definition.FeatureSet.Add();
        //   Definition.FeatureSet.Add();
        //   Definition.FeatureSet.Add();
        
        }

        public static FeatureDefinitionFeatureSet CreateAndAddToDB(string name, string guid)
            => new WildshapeFeatureSetBuilder(name, guid).AddToDB();

        public static FeatureDefinitionFeatureSet WildshapeFeatureSet = CreateAndAddToDB(WildshapeFeatureSetName, WildshapeFeatureSetGuid);
    }

    internal class Wildshape_level4FeatureSetBuilder : BaseDefinitionBuilder<FeatureDefinitionFeatureSet>
    {
        const string Wildshape_level4FeatureSetName = "Wildshape_level4FeatureSet";
        const string Wildshape_level4FeatureSetGuid = "af6cc709-b359-4dfc-8907-8d58a746d4c0";

        protected Wildshape_level4FeatureSetBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetGreenmageWardenOfTheForest, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&Wildshape_level4FeatureSetTitle";
            Definition.GuiPresentation.Description = "Feat/&Wildshape_level4FeatureSetDescription";

            Definition.FeatureSet.Clear();
       //     Definition.FeatureSet.Add(WildShapePower_BlackBearBuilder.WildShapePower_BlackBear);
            Definition.FeatureSet.Add(WildShapePower_BadlandsspiderBuilder.WildShapePower_Badlandsspider);
            Definition.FeatureSet.Add(WildShapePower_AlphaWolfBuilder.WildShapePower_AlphaWolf);
       
            
        }

        public static FeatureDefinitionFeatureSet CreateAndAddToDB(string name, string guid)
            => new Wildshape_level4FeatureSetBuilder(name, guid).AddToDB();

        public static FeatureDefinitionFeatureSet Wildshape_level4FeatureSet = CreateAndAddToDB(Wildshape_level4FeatureSetName, Wildshape_level4FeatureSetGuid);
    }

    internal class Wildshape_level8FeatureSetBuilder : BaseDefinitionBuilder<FeatureDefinitionFeatureSet>
    {
        const string Wildshape_level8FeatureSetName = "Wildshape_level8FeatureSet";
        const string Wildshape_level8FeatureSetGuid = "57e74b03-139a-47df-bbb7-88da07cdf95b";

        protected Wildshape_level8FeatureSetBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetGreenmageWardenOfTheForest, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&Wildshape_level8FeatureSetTitle";
            Definition.GuiPresentation.Description = "Feat/&Wildshape_level8FeatureSetDescription";

            Definition.FeatureSet.Clear();
            Definition.FeatureSet.Add(WildShapePower_DirewolfBuilder.WildShapePower_Direwolf);
            Definition.FeatureSet.Add(WildShapePower_Giant_EagleBuilder.WildShapePower_Giant_Eagle);
        //    Definition.FeatureSet.Add(WildShapePower_BrownBearBuilder.WildShapePower_BrownBear);
        
        }

        public static FeatureDefinitionFeatureSet CreateAndAddToDB(string name, string guid)
            => new Wildshape_level8FeatureSetBuilder(name, guid).AddToDB();

        public static FeatureDefinitionFeatureSet Wildshape_level8FeatureSet = CreateAndAddToDB(Wildshape_level8FeatureSetName, Wildshape_level8FeatureSetGuid);
    }

    internal class BeastSpellsFeatureSetBuilder : BaseDefinitionBuilder<FeatureDefinitionFeatureSet>
    {
        const string BeastSpellsFeatureSetName = "BeastSpellsFeatureSet";
        const string BeastSpellsFeatureSetGuid = "935d9893-702d-444f-a168-1c80e1b412d2";

        protected BeastSpellsFeatureSetBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetGreenmageWardenOfTheForest, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&BeastSpellsFeatureSetTitle";
            Definition.GuiPresentation.Description = "Feat/&BeastSpellsFeatureSetDescription";

            Definition.FeatureSet.Clear();
            Definition.FeatureSet.Add(WildShapePower_Direwolf_BeastSpellsBuilder.WildShapePower_Direwolf_BeastSpells);
            Definition.FeatureSet.Add(WildShapePower_Giant_Eagle_BeastSpellsBuilder.WildShapePower_Giant_Eagle_BeastSpells);
            //    

        }

        public static FeatureDefinitionFeatureSet CreateAndAddToDB(string name, string guid)
            => new BeastSpellsFeatureSetBuilder(name, guid).AddToDB();

        public static FeatureDefinitionFeatureSet BeastSpellsFeatureSet = CreateAndAddToDB(BeastSpellsFeatureSetName, BeastSpellsFeatureSetGuid);
    }

    internal class WildShapePowerBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string Name = "WildShapePowerBuilder";
        const string Guid = "03851fd5-8481-4b60-91f6-0adb9c348d9d";

        protected WildShapePowerBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionPowers.PowerClericDivineInterventionCleric, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&WildShapePowerBuilderTitle";
            Definition.GuiPresentation.Description = "Feature/&WildShapePowerBuilderDescription";

            Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.MonsterDefinitions.Wolf.GuiPresentation.SpriteReference);

            Definition.SetHasCastingFailure(false);
            Definition.SetRechargeRate(RuleDefinitions.RechargeRate.ChannelDivinity);
            Definition.SetActivationTime(RuleDefinitions.ActivationTime.BonusAction);
            Definition.SetCostPerUse(1);
            Definition.SetFixedUsesPerRecharge(2);
            Definition.SetShortTitleOverride("Feature/&WildShapePowerBuilderTitle");
            Definition.SetUniqueInstance(true);

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
            casterwildshaped.SetConditionDefinitionName(CasterWhileWildshapedConditionBuilder.CasterWhileWildshapedCondition.Name);
            casterwildshaped.ConditionDefinition = CasterWhileWildshapedConditionBuilder.CasterWhileWildshapedCondition;
        //    casterwildshaped.SetConditionDefinitionName(DatabaseHelper.ConditionDefinitions.ConditionInvisibleGreater.Name);
        //    casterwildshaped.ConditionDefinition = DatabaseHelper.ConditionDefinitions.ConditionInvisibleGreater;

            EffectForm casterwildshapedEffect = new EffectForm();
            casterwildshapedEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
            casterwildshapedEffect.SetLevelMultiplier(1);
            casterwildshapedEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            casterwildshapedEffect.SetCreatedByCharacter(true);
            casterwildshapedEffect.FormType = EffectForm.EffectFormType.Condition;
            casterwildshapedEffect.ConditionForm = casterwildshaped;

        //    ConditionForm casterRestrictedActions = new ConditionForm();
        //    casterRestrictedActions.SetApplyToSelf(true);
        //    casterRestrictedActions.SetForceOnSelf(true);
        //    casterRestrictedActions.Operation = ConditionForm.ConditionOperation.Add;
        //    //casterRestrictedActions.SetConditionDefinitionName(CasterWhileWildshapedConditionBuilder.CasterWhileWildshapedCondition.Name);
        //    //casterRestrictedActions.ConditionDefinition = CasterWhileWildshapedConditionBuilder.CasterWhileWildshapedCondition;
        //    casterRestrictedActions.SetConditionDefinitionName(DatabaseHelper.ConditionDefinitions.ConditionSlowed.Name);
        //    casterRestrictedActions.ConditionDefinition = DatabaseHelper.ConditionDefinitions.ConditionSlowed;
        //
        //    EffectForm casterRestrictedActionsEffect = new EffectForm();
        //    casterRestrictedActionsEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
        //    casterRestrictedActionsEffect.SetLevelMultiplier(1);
        //    casterRestrictedActionsEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
        //    casterRestrictedActionsEffect.SetCreatedByCharacter(true);
        //    casterRestrictedActionsEffect.FormType = EffectForm.EffectFormType.Condition;
        //    casterRestrictedActionsEffect.ConditionForm = casterRestrictedActions;
        //
        //
        //    ConditionForm casterinvincible = new ConditionForm();
        //    casterinvincible.SetApplyToSelf(true);
        //    casterinvincible.SetForceOnSelf(true);
        //    casterinvincible.Operation = ConditionForm.ConditionOperation.Add;
        //    casterinvincible.SetConditionDefinitionName(CasterWhileWildshapedConditionBuilder.CasterWhileWildshapedCondition.Name);
        //    casterinvincible.ConditionDefinition = CasterWhileWildshapedConditionBuilder.CasterWhileWildshapedCondition;
        //    //casterinvincible.SetConditionDefinitionName(DatabaseHelper.ConditionDefinitions.ConditionDebugInvicible.Name);
        //   // casterinvincible.ConditionDefinition = DatabaseHelper.ConditionDefinitions.ConditionDebugInvicible;
        //
        //    EffectForm casterinvincibleEffect = new EffectForm();
        //    casterinvincibleEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
        //    casterinvincibleEffect.SetLevelMultiplier(1);
        //    casterinvincibleEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
        //    casterinvincibleEffect.SetCreatedByCharacter(true);
        //    casterinvincibleEffect.FormType = EffectForm.EffectFormType.Condition;
        //    casterinvincibleEffect.ConditionForm = casterinvincible;


            EffectDescription effectdescription = new EffectDescription();
            effectdescription.EffectForms.Add(WildShapeEffect);
            effectdescription.EffectForms.Add(casterwildshapedEffect);
        //    effectdescription.EffectForms.Add(casterinvincibleEffect);
       //     effectdescription.EffectForms.Add(casterRestrictedActionsEffect);
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

        protected CasterWhileWildshapedConditionBuilder(string name, string guid) : base(DatabaseHelper.ConditionDefinitions.ConditionBanished, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&CasterWhileWildshapedConditionTitle";
            Definition.GuiPresentation.Description = "Feature/&CasterWhileWildshapedConditionDescription";
             

            Definition.SetAllowMultipleInstances(false);
            Definition.SetDurationType(RuleDefinitions.DurationType.Dispelled);
            Definition.SetDurationParameter(1);

            Definition.SetConditionType(RuleDefinitions.ConditionType.Detrimental);
            Definition.Features.Clear();
            //Definition.Features.Add(DatabaseHelper.)


                Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleAcid);
                Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleBludgeoning);
                Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleCold);
                Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleFire);
                Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleForce);
                Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleLightning);
                Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleNecrotic);
                Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInviciblePiercing);
                Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInviciblePoison);
                Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInviciblePsychic);
                Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleRadiant);
                Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleSlashing);
                Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleThunder);

            Definition.Features.Add(WildshapedCasterActionAffinityBuilder.WildshapedCasterActionAffinity);
             

            //action affinity only bonus action and movement

        }

        public static ConditionDefinition CreateAndAddToDB(string name, string guid)
            => new CasterWhileWildshapedConditionBuilder(name, guid).AddToDB();

        public static ConditionDefinition CasterWhileWildshapedCondition = CreateAndAddToDB(CasterWhileWildshapedConditionName, CasterWhileWildshapedConditionGuid);
    }

    internal class EndWildShapePowerBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string Name = "EndWildShapePowerBuilder";
        const string Guid = "8ba254af-9711-46da-ae5f-1fc72ae9965f";

        protected EndWildShapePowerBuilder(string name, string guid) : base(WildShapePowerBuilder.WildShapePower, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&EndWildShapePowerBuilderTitle";
            Definition.GuiPresentation.Description = "Feature/&EndWildShapePowerBuilderDescription";

            Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.SpellDefinitions.AnimalFriendship.GuiPresentation.SpriteReference);

            Definition.SetRechargeRate(RuleDefinitions.RechargeRate.AtWill);
            Definition.SetActivationTime(RuleDefinitions.ActivationTime.Action);
            Definition.SetCostPerUse(1);
            Definition.SetFixedUsesPerRecharge(1);
            Definition.SetShortTitleOverride("Feature/&EndWildShapePowerBuilderTitle");

              
        
            ConditionForm endcasterwildshaped = new ConditionForm();
            endcasterwildshaped.SetApplyToSelf(true);
            endcasterwildshaped.SetForceOnSelf(true);
            endcasterwildshaped.Operation = ConditionForm.ConditionOperation.RemoveDetrimentalAll;
            endcasterwildshaped.SetConditionDefinitionName(DatabaseHelper.ConditionDefinitions.ConditionDebugInvicible.Name);
            endcasterwildshaped.ConditionDefinition = DatabaseHelper.ConditionDefinitions.ConditionDebugInvicible;
            endcasterwildshaped.DetrimentalConditions .AddRange( new List<ConditionDefinition>
            {
               
                CasterWhileWildshapedConditionBuilder.CasterWhileWildshapedCondition
        
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
            effectdescription.RestrictedCreatureFamilies.Add(WildshapeOptionFamilyBuilder.WildshapeOptionFamily.Name);



            Definition.SetEffectDescription(effectdescription);



        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new EndWildShapePowerBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPower EndWildShapePower = CreateAndAddToDB(Name, Guid);
    }

    internal class EndWildShapePowerDeadBeastBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string Name = "EndWildShapePowerDeadBeast";
        const string Guid = "f465e380-eb7d-49c4-b800-120f97c78d0a";

        protected EndWildShapePowerDeadBeastBuilder(string name, string guid) : base(WildShapePowerBuilder.WildShapePower, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&EndWildShapePowerDeadBeastBuilderTitle";
            Definition.GuiPresentation.Description = "Feature/&EndWildShapePowerDeadBeastBuilderDescription";
            Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.SpellDefinitions.DominateBeast.GuiPresentation.SpriteReference);
           

            Definition.SetRechargeRate(RuleDefinitions.RechargeRate.AtWill);
            Definition.SetActivationTime(RuleDefinitions.ActivationTime.Action);
            Definition.SetCostPerUse(1);
            Definition.SetFixedUsesPerRecharge(1);
            Definition.SetShortTitleOverride("Feature/&EndWildShapePowerDeadBeastBuilderTitle");

            


            ConditionForm endcasterwildshaped = new ConditionForm();
            endcasterwildshaped.SetApplyToSelf(true);
            endcasterwildshaped.SetForceOnSelf(true);
            endcasterwildshaped.Operation = ConditionForm.ConditionOperation.RemoveDetrimentalAll;
            endcasterwildshaped.SetConditionDefinitionName(DatabaseHelper.ConditionDefinitions.ConditionDebugInvicible.Name);
            endcasterwildshaped.ConditionDefinition = DatabaseHelper.ConditionDefinitions.ConditionDebugInvicible;
            endcasterwildshaped.DetrimentalConditions.AddRange(new List<ConditionDefinition>
            {

                CasterWhileWildshapedConditionBuilder.CasterWhileWildshapedCondition

            });

            EffectForm endcasterwildshapedEffect = new EffectForm();
            endcasterwildshapedEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
            endcasterwildshapedEffect.SetLevelMultiplier(1);
            endcasterwildshapedEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            endcasterwildshapedEffect.SetCreatedByCharacter(true);
            endcasterwildshapedEffect.FormType = EffectForm.EffectFormType.Condition;
            endcasterwildshapedEffect.ConditionForm = endcasterwildshaped;




            EffectDescription effectdescription = new EffectDescription();
            effectdescription.EffectForms.Add(endcasterwildshapedEffect);
            effectdescription.DurationType = RuleDefinitions.DurationType.Hour;
            effectdescription.DurationParameter = 1;
            effectdescription.SetRangeParameter(12);
            effectdescription.SetRangeType(RuleDefinitions.RangeType.Self);
            effectdescription.SetTargetType(RuleDefinitions.TargetType.Self);
            effectdescription.SetTargetSide(RuleDefinitions.Side.Ally);
            effectdescription.SetTargetParameter(1);




            Definition.SetEffectDescription(effectdescription);



        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new EndWildShapePowerDeadBeastBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPower EndWildShapePowerDeadBeast = CreateAndAddToDB(Name, Guid);
    }
    internal class WildshapedCasterActionAffinityBuilder : BaseDefinitionBuilder<FeatureDefinitionActionAffinity>
    {
        const string Name = "WildshapedCasterActionAffinity";
        const string Guid = "c25b5076-95f3-4fee-a90e-c2372d8e9d47";

        protected WildshapedCasterActionAffinityBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionActionAffinitys.ActionAffinityConditionSlowed, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&WildshapedCasterActionAffinityBuilderTitle";
            Definition.GuiPresentation.Description = "Feature/&WildshapedCasterActionAffinityBuilderDescription";



            //    Traverse.Create(Definition).Field("allowedActionTypes").SetValue(new List<int>
            //   {  
            //   });

            Definition.AuthorizedActions.Add(ActionDefinitions.Id.ExplorationMove);
            Definition.AuthorizedActions.Add(ActionDefinitions.Id.TacticalMove);
        //    Definition.AuthorizedActions.Add(ActionDefinitions.Id.PowerBonus);
            Definition.AuthorizedActions.Add(ActionDefinitions.Id.Cautious);
            Definition.AuthorizedActions.Add(ActionDefinitions.Id.Climb);
            Definition.AuthorizedActions.Add(ActionDefinitions.Id.DashMain);
            Definition.AuthorizedActions.Add(ActionDefinitions.Id.Jump);
        //    Definition.AuthorizedActions.Add(ActionDefinitions.Id.PowerNoCost);
        //    Definition.AuthorizedActions.Add(ActionDefinitions.Id.SpendPower);
           Definition.AuthorizedActions.Add(ActionDefinitions.Id.PowerMain);
        //      Definition.AuthorizedActions.Add(ActionDefinitions.Id.PowerNoCost);

            Definition.RestrictedActions.Add(ActionDefinitions.Id.ExplorationMove);
            Definition.RestrictedActions.Add(ActionDefinitions.Id.TacticalMove);
        //    Definition.RestrictedActions.Add(ActionDefinitions.Id.PowerBonus);
            Definition.RestrictedActions.Add(ActionDefinitions.Id.Cautious);
            Definition.RestrictedActions.Add(ActionDefinitions.Id.Climb);
            Definition.RestrictedActions.Add(ActionDefinitions.Id.DashMain);
            Definition.RestrictedActions.Add(ActionDefinitions.Id.Jump);
       //     Definition.RestrictedActions.Add(ActionDefinitions.Id.PowerNoCost);
       //     Definition.RestrictedActions.Add(ActionDefinitions.Id.SpendPower);
            Definition.RestrictedActions.Add(ActionDefinitions.Id.PowerMain);
        //    Definition.RestrictedActions.Add(ActionDefinitions.Id.PowerNoCost);

        }

        public static FeatureDefinitionActionAffinity CreateAndAddToDB(string name, string guid)
            => new WildshapedCasterActionAffinityBuilder(name, guid).AddToDB();

        public static FeatureDefinitionActionAffinity WildshapedCasterActionAffinity = CreateAndAddToDB(Name, Guid);
    }

    internal class WildShapePower_AlphaWolfBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string Name = "WildShapePower_AlphaWolf";
        const string Guid = "1b38eddb-c6e1-4eb0-b4cf-22cb292c5fdf";

        protected WildShapePower_AlphaWolfBuilder(string name, string guid) : base(WildShapePowerBuilder.WildShapePower, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&WildShapePower_AlphaWolfBuilderTitle";
            Definition.GuiPresentation.Description = "Feature/&WildShapePower_AlphaWolfBuilderDescription";
            
            Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.MonsterDefinitions.AlphaWolf.GuiPresentation.SpriteReference);
            Definition.SetOverriddenPower(WildShapePowerBuilder.WildShapePower);

            Definition.EffectDescription.EffectForms[0].SummonForm.SetMonsterDefinitionName(WildShaped_AlphaWolfBuilder.WildShaped_AlphaWolf.Name);
			Definition.EffectDescription.DurationParameter = (2);

        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new WildShapePower_AlphaWolfBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPower WildShapePower_AlphaWolf     = CreateAndAddToDB(Name, Guid);
    }
	
	internal class WildShapePower_BadlandsspiderBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string Name = "WildShapePower_Badlandsspider";
        const string Guid = "7229ec47-543b-4804-828e-8c6939e33c3e";

        protected WildShapePower_BadlandsspiderBuilder(string name, string guid) : base(WildShapePowerBuilder.WildShapePower, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&WildShapePower_BadlandsspiderBuilderTitle";
            Definition.GuiPresentation.Description = "Feature/&WildShapePower_BadlandsspiderBuilderDescription";
            Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.MonsterDefinitions.BadlandsSpider.GuiPresentation.SpriteReference);


            Definition.EffectDescription.EffectForms[0].SummonForm.SetMonsterDefinitionName(WildShaped_BadlandsSpiderBuilder.WildShaped_BadlandsSpider.Name);
            Definition.EffectDescription.DurationParameter = (2);

        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new WildShapePower_BadlandsspiderBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPower WildShapePower_Badlandsspider     = CreateAndAddToDB(Name, Guid);
    }

    internal class WildShapePower_BlackBearBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string Name = "WildShapePower_BlackBear";
        const string Guid = "b2e1ceae-58a0-4d3e-b8e1-eb8f6dd314ea";

        protected WildShapePower_BlackBearBuilder(string name, string guid) : base(WildShapePowerBuilder.WildShapePower, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&WildShapePower_BlackBearBuilderTitle";
            Definition.GuiPresentation.Description = "Feature/&WildShapePower_BlackBearBuilderDescription";
            Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.MonsterDefinitions.BlackBear.GuiPresentation.SpriteReference);


            Definition.EffectDescription.EffectForms[0].SummonForm.SetMonsterDefinitionName(WildShaped_BlackBearBuilder.WildShaped_BlackBear.Name);
            Definition.EffectDescription.DurationParameter = (2);

        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new WildShapePower_BlackBearBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPower WildShapePower_BlackBear = CreateAndAddToDB(Name, Guid);
    }
    internal class WildShapePower_DirewolfBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string Name = "WildShapePower_Direwolf";
        const string Guid = "fdbe19fd-4476-4882-a9fa-b20000b635cd";

        protected WildShapePower_DirewolfBuilder(string name, string guid) : base(WildShapePowerBuilder.WildShapePower, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&WildShapePower_DirewolfBuilderTitle";
            Definition.GuiPresentation.Description = "Feature/&WildShapePower_DirewolfBuilderDescription";
            Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.MonsterDefinitions.Direwolf.GuiPresentation.SpriteReference);

            Definition.SetOverriddenPower(WildShapePower_AlphaWolfBuilder.WildShapePower_AlphaWolf);

            Definition.EffectDescription.EffectForms[0].SummonForm.SetMonsterDefinitionName(WildShaped_DirewolfBuilder.WildShaped_Direwolf.Name);
            Definition.EffectDescription.DurationParameter = (4);

        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new WildShapePower_DirewolfBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPower WildShapePower_Direwolf     = CreateAndAddToDB(Name, Guid);
    }	
	
	
	internal class WildShapePower_Giant_EagleBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string Name = "WildShapePower_Giant_Eagle";
        const string Guid = "a5cfcbc8-73b0-46b2-9ba9-4220e7c19058";

        protected WildShapePower_Giant_EagleBuilder(string name, string guid) : base(WildShapePowerBuilder.WildShapePower, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&WildShapePower_Giant_EagleBuilderTitle";
            Definition.GuiPresentation.Description = "Feature/&WildShapePower_Giant_EagleBuilderDescription";
            Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.MonsterDefinitions.Giant_Eagle.GuiPresentation.SpriteReference);


            Definition.EffectDescription.EffectForms[0].SummonForm.SetMonsterDefinitionName(WildShaped_Giant_EagleBuilder.WildShaped_Giant_Eagle.Name);
            Definition.EffectDescription.DurationParameter = (4);

        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new WildShapePower_Giant_EagleBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPower WildShapePower_Giant_Eagle     = CreateAndAddToDB(Name, Guid);
    }

    internal class WildShapePower_BrownBearBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string Name = "WildShapePower_BrownBear";
        const string Guid = "1d3d2589-d860-4a14-a613-f574f4349ea7";

        protected WildShapePower_BrownBearBuilder(string name, string guid) : base(WildShapePowerBuilder.WildShapePower, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&WildShapePower_BrownBearBuilderTitle";
            Definition.GuiPresentation.Description = "Feature/&WildShapePower_BrownBearBuilderDescription";
            Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.MonsterDefinitions.BrownBear.GuiPresentation.SpriteReference);

            Definition.SetOverriddenPower(WildShapePower_BlackBearBuilder.WildShapePower_BlackBear);
            Definition.EffectDescription.EffectForms[0].SummonForm.SetMonsterDefinitionName(WildShaped_BrownBearBuilder.WildShaped_BrownBear.Name);
            Definition.EffectDescription.DurationParameter = (4);

        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new WildShapePower_BrownBearBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPower WildShapePower_BrownBear = CreateAndAddToDB(Name, Guid);
    }


    internal class BeastSpellsConditionBuilder : BaseDefinitionBuilder<ConditionDefinition>
    {
        const string BeastSpellsConditionName = "BeastSpellsCondition";
        const string BeastSpellsConditionGuid = "4213c569-6443-4ddf-ac2f-43985e687133";

        protected BeastSpellsConditionBuilder(string name, string guid) : base(DatabaseHelper.ConditionDefinitions.ConditionInvisibleGreater, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&BeastSpellsConditionTitle";
            Definition.GuiPresentation.Description = "Feature/&BeastSpellsConditionDescription";


            Definition.SetAllowMultipleInstances(false);
            Definition.SetDurationType(RuleDefinitions.DurationType.Dispelled);
            Definition.SetDurationParameter(1);

            Definition.SetConditionType(RuleDefinitions.ConditionType.Detrimental);
            Definition.Features.Clear();
            //Definition.Features.Add(DatabaseHelper.)


            Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleAcid);
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleBludgeoning);
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleCold);
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleFire);
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleForce);
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleLightning);
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleNecrotic);
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInviciblePiercing);
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInviciblePoison);
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInviciblePsychic);
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleRadiant);
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleSlashing);
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleThunder);



        }

        public static ConditionDefinition CreateAndAddToDB(string name, string guid)
            => new BeastSpellsConditionBuilder(name, guid).AddToDB();

        public static ConditionDefinition BeastSpellsCondition = CreateAndAddToDB(BeastSpellsConditionName, BeastSpellsConditionGuid);
    }

    internal class WildShapePower_Direwolf_BeastSpellsBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string Name = "WildShapePower_Direwolf_BeastSpells";
        const string Guid = "cba11290-0d75-4c2d-8bc4-f76e0181462f";

        protected WildShapePower_Direwolf_BeastSpellsBuilder(string name, string guid) : base(WildShapePowerBuilder.WildShapePower, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&WildShapePower_Direwolf_BeastSpellsBuilderTitle";
            Definition.GuiPresentation.Description = "Feature/&WildShapePower_Direwolf_BeastSpellsBuilderDescription";
            Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.MonsterDefinitions.Direwolf.GuiPresentation.SpriteReference);


            Definition.SetOverriddenPower(WildShapePower_DirewolfBuilder.WildShapePower_Direwolf);

            Definition.EffectDescription.EffectForms[0].SummonForm.SetMonsterDefinitionName(WildShaped_DirewolfBuilder.WildShaped_Direwolf.Name);
            Definition.EffectDescription.EffectForms[1].ConditionForm.SetConditionDefinition(BeastSpellsConditionBuilder.BeastSpellsCondition);
            Definition.EffectDescription.DurationParameter = (9);

        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new WildShapePower_Direwolf_BeastSpellsBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPower WildShapePower_Direwolf_BeastSpells = CreateAndAddToDB(Name, Guid);
    }

    internal class WildShapePower_Giant_Eagle_BeastSpellsBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string Name = "WildShapePower_Giant_Eagle_BeastSpells";
        const string Guid = "bfcb2e09-6177-4ffb-a2bb-23d21ce37993";

        protected WildShapePower_Giant_Eagle_BeastSpellsBuilder(string name, string guid) : base(WildShapePowerBuilder.WildShapePower, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&WildShapePower_Giant_Eagle_BeastSpellsBuilderTitle";
            Definition.GuiPresentation.Description = "Feature/&WildShapePower_Giant_Eagle_BeastSpellsBuilderDescription";
            Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.MonsterDefinitions.Giant_Eagle.GuiPresentation.SpriteReference);

            Definition.SetOverriddenPower(WildShapePower_Giant_EagleBuilder.WildShapePower_Giant_Eagle);

            Definition.EffectDescription.EffectForms[0].SummonForm.SetMonsterDefinitionName(WildShaped_Giant_EagleBuilder.WildShaped_Giant_Eagle.Name);
            Definition.EffectDescription.EffectForms[1].ConditionForm.SetConditionDefinition(BeastSpellsConditionBuilder.BeastSpellsCondition);
            Definition.EffectDescription.DurationParameter = (9);

        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new WildShapePower_Giant_Eagle_BeastSpellsBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPower WildShapePower_Giant_Eagle_BeastSpells = CreateAndAddToDB(Name, Guid);
    }




}