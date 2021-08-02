 
using SolastaModApi;
using SolastaModApi.Extensions;  
using NewFeatureDefinitions = SolastaModHelpers.NewFeatureDefinitions;


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


 //   internal class SummonShifterForm_WolfFormPowerBuilder : BaseDefinitionBuilder<NewFeatureDefinitions.PowerWithRestrictions>
 //   {
 //       const string SummonShifterForm_WolfFormName = "SummonShifterForm_WolfForm_WolfForm";
 //       const string SummonShifterForm_WolfFormNameGuid = "e86ca115-ab3c-4bb8-a963-8356ea9c3a01";
 //
 //       protected SummonShifterForm_WolfFormPowerBuilder(string name, string guid) : base( name, guid)
 //       {
 //
 //           Definition.GuiPresentation.Title = "Feat/&SummonShifterForm_WolfFormTitle";
 //           Definition.GuiPresentation.Description = "Feat/&SummonShifterForm_WolfFormDescription";
 //           Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.SpellDefinitions.Heroism.GuiPresentation.SpriteReference);
 //       
 //           Definition.SetActivationTime(RuleDefinitions.ActivationTime.Action);
 //           Definition.SetRechargeRate(RuleDefinitions.RechargeRate.ShortRest);
 //           Definition.SetFixedUsesPerRecharge(2);
 //           Definition.SetCostPerUse(1);
 //           Definition.SetHasCastingFailure(false);
 //           Definition.SetUniqueInstance(true);
 //       
 //           ConditionForm WolfCondition = new ConditionForm();
 //           WolfCondition.SetApplyToSelf(true);
 //           WolfCondition.SetForceOnSelf(true);
 //           WolfCondition.Operation = ConditionForm.ConditionOperation.Add;
 //           WolfCondition.SetConditionDefinitionName(WolfFormConditionBuilder.WolfFormCondition.Name);
 //           WolfCondition.ConditionDefinition = WolfFormConditionBuilder.WolfFormCondition;
 //       
 //           EffectForm WolfFormEffect = new EffectForm();
 //           WolfFormEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
 //           WolfFormEffect.SetLevelMultiplier(1);
 //           WolfFormEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
 //           WolfFormEffect.SetCreatedByCharacter(true);
 //           WolfFormEffect.FormType = EffectForm.EffectFormType.Condition;
 //           WolfFormEffect.ConditionForm = WolfCondition;
 //       
 //           //Add to our new effect
 //           EffectDescription newEffectDescription = new EffectDescription();
 //           newEffectDescription.Copy(Definition.EffectDescription);
 //           newEffectDescription.EffectForms.Clear();
 //           newEffectDescription.EffectForms.Add(WolfFormEffect);
 //           newEffectDescription.SetRangeParameter(1);
 //           newEffectDescription.SetTargetType(RuleDefinitions.TargetType.Self);
 //           newEffectDescription.DurationType = RuleDefinitions.DurationType.Minute;
 //           newEffectDescription.DurationParameter = 10;
 //           newEffectDescription.SetEffectParticleParameters(DatabaseHelper.SpellDefinitions.Aid.EffectDescription.EffectParticleParameters);
 //
 //
 //
 //           Definition.SetEffectDescription(newEffectDescription);
 //
 //           Definition.linkedPower= SummoningWildshapeViaPolymorph.Dictionaryof_Wildshape_Powers["Wolf"];
 //       }
 //
 //       public static NewFeatureDefinitions.PowerWithRestrictions CreateAndAddToDB(string name, string guid)
 //           => new SummonShifterForm_WolfFormPowerBuilder(name, guid).AddToDB();
 //
 //       public static NewFeatureDefinitions.PowerWithRestrictions SummonShifterForm_WolfForm = CreateAndAddToDB(SummonShifterForm_WolfFormName, SummonShifterForm_WolfFormNameGuid);
 //
 //   }

  

//    internal class SummonShifterForm_BearFormPowerBuilder : BaseDefinitionBuilder<NewFeatureDefinitions.PowerWithRestrictions>
//    {
//        const string SummonShifterForm_BearFormName = "SummonShifterForm_BearForm_BearForm";
//        const string SummonShifterForm_BearFormNameGuid = "d91bb65d-58c1-4af6-a201-3da98c6243e8";
//
//        protected SummonShifterForm_BearFormPowerBuilder(string name, string guid) : base( name, guid)
//        {
//
//            Definition.GuiPresentation.Title = "Feat/&SummonShifterForm_BearFormTitle";
//            Definition.GuiPresentation.Description = "Feat/&SummonShifterForm_BearFormDescription";
//            Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.SpellDefinitions.Barkskin.GuiPresentation.SpriteReference);
//
//            Definition.SetActivationTime(RuleDefinitions.ActivationTime.Action);
//            Definition.SetRechargeRate(RuleDefinitions.RechargeRate.ShortRest);
//            Definition.SetFixedUsesPerRecharge(2);
//            Definition.SetCostPerUse(1);
//            Definition.SetHasCastingFailure(false);
//            Definition.SetUniqueInstance(true);
//
//            ConditionForm BearCondition = new ConditionForm();
//            BearCondition.SetApplyToSelf(true);
//            BearCondition.SetForceOnSelf(true);
//            BearCondition.Operation = ConditionForm.ConditionOperation.Add;
//            BearCondition.SetConditionDefinitionName(BearFormConditionBuilder.BearFormCondition.Name);
//            BearCondition.ConditionDefinition = BearFormConditionBuilder.BearFormCondition;
//
//            EffectForm BearFormEffect = new EffectForm();
//            BearFormEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
//            BearFormEffect.SetLevelMultiplier(1);
//            BearFormEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
//            BearFormEffect.SetCreatedByCharacter(true);
//            BearFormEffect.FormType = EffectForm.EffectFormType.Condition;
//            BearFormEffect.ConditionForm = BearCondition;
//
//            //Add to our new effect
//            EffectDescription newEffectDescription = new EffectDescription();
//            newEffectDescription.Copy(Definition.EffectDescription);
//            newEffectDescription.EffectForms.Clear();
//            newEffectDescription.EffectForms.Add(BearFormEffect);
//            newEffectDescription.SetRangeParameter(1);
//            newEffectDescription.SetTargetType(RuleDefinitions.TargetType.Self);
//            newEffectDescription.DurationType = RuleDefinitions.DurationType.Minute;
//            newEffectDescription.DurationParameter = 10;
//            newEffectDescription.SetEffectParticleParameters(DatabaseHelper.SpellDefinitions.Aid.EffectDescription.EffectParticleParameters);
//
//
//
//            Definition.SetEffectDescription(newEffectDescription);
//
//            Definition.linkedPower = SummoningWildshapeViaPolymorph.Dictionaryof_Wildshape_Powers["Wolf"];
//        }
//
//        public static NewFeatureDefinitions.PowerWithRestrictions CreateAndAddToDB(string name, string guid)
//            => new SummonShifterForm_BearFormPowerBuilder(name, guid).AddToDB();
//
//        public static NewFeatureDefinitions.PowerWithRestrictions SummonShifterForm_BearForm = CreateAndAddToDB(SummonShifterForm_BearFormName, SummonShifterForm_BearFormNameGuid);
//
//    }

  


//    internal class SummonShifterForm_StagFormPowerBuilder : BaseDefinitionBuilder<NewFeatureDefinitions.PowerWithRestrictions>
//    {
//        const string SummonShifterForm_StagFormName = "SummonShifterForm_StagForm_StagForm";
//        const string SummonShifterForm_StagFormNameGuid = "8370d085-b46b-4655-a2f4-5eb9f47fdef3";
//
//        protected SummonShifterForm_StagFormPowerBuilder(string name, string guid) : base( name, guid)
//        {
//
//            Definition.GuiPresentation.Title = "Feat/&SummonShifterForm_StagFormTitle";
//            Definition.GuiPresentation.Description = "Feat/&SummonShifterForm_StagFormDescription";
//            Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.SpellDefinitions.MassHealingWord.GuiPresentation.SpriteReference);
//
//            Definition.SetActivationTime(RuleDefinitions.ActivationTime.Action);
//            Definition.SetRechargeRate(RuleDefinitions.RechargeRate.ShortRest);
//            Definition.SetFixedUsesPerRecharge(2);
//            Definition.SetCostPerUse(1);
//            Definition.SetHasCastingFailure(false);
//            Definition.SetUniqueInstance(true);
//
//            ConditionForm StagCondition = new ConditionForm();
//           // StagCondition.SetApplyToSelf(true);
//           // StagCondition.SetForceOnSelf(true);
//            StagCondition.Operation = ConditionForm.ConditionOperation.Add;
//            StagCondition.SetConditionDefinitionName(StagFormConditionBuilder.StagFormCondition.Name);
//            StagCondition.ConditionDefinition = StagFormConditionBuilder.StagFormCondition;
//
//            EffectForm StagFormEffect = new EffectForm();
//            StagFormEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
//            StagFormEffect.SetLevelMultiplier(1);
//            StagFormEffect.SetLevelType(RuleDefinitions.LevelSourceType.CharacterLevel);
//            StagFormEffect.SetCreatedByCharacter(true);
//            StagFormEffect.FormType = EffectForm.EffectFormType.Condition;
//            StagFormEffect.ConditionForm = StagCondition;
//
//            //Add to our new effect
//            EffectDescription newEffectDescription = new EffectDescription();
//            newEffectDescription.Copy(Definition.EffectDescription);
//            newEffectDescription.EffectForms.Clear();
//            newEffectDescription.EffectForms.Add(StagFormEffect);
//            newEffectDescription.SetRangeParameter(2);
//            newEffectDescription.SetRangeType(RuleDefinitions.RangeType.Self);
//            newEffectDescription.SetTargetType(RuleDefinitions.TargetType.Sphere);
//            newEffectDescription.SetTargetSide(RuleDefinitions.Side.Ally);
//            newEffectDescription.DurationType = RuleDefinitions.DurationType.Minute;
//            newEffectDescription.SetTargetParameter(2);
//            newEffectDescription.DurationParameter = 1;
//            newEffectDescription.SetEffectParticleParameters(DatabaseHelper.SpellDefinitions.SpiderClimb.EffectDescription.EffectParticleParameters);
//
//
//            Definition.SetEffectDescription(newEffectDescription);
//
//            Definition.linkedPower = SummoningWildshapeViaPolymorph.Dictionaryof_Wildshape_Powers["Wolf"];
//        }
//
//        public static NewFeatureDefinitions.PowerWithRestrictions CreateAndAddToDB(string name, string guid)
//            => new SummonShifterForm_StagFormPowerBuilder(name, guid).AddToDB();
//
//        public static NewFeatureDefinitions.PowerWithRestrictions SummonShifterForm_StagForm = CreateAndAddToDB(SummonShifterForm_StagFormName, SummonShifterForm_StagFormNameGuid);
//
//    }

 

//   internal class SummonShifterForm_WolfAndBearFormPowerBuilder : BaseDefinitionBuilder<NewFeatureDefinitions.PowerWithRestrictions>
//   {
//       const string SummonShifterForm_WolfAndBearFormName = "SummonShifterForm_WolfAndBearForm_WolfAndBearForm";
//       const string SummonShifterForm_WolfAndBearFormNameGuid = "ab0ec75c-2961-4625-92d6-c0d5196add1c";
//
//       protected SummonShifterForm_WolfAndBearFormPowerBuilder(string name, string guid) : base( name, guid)
//       {
//
//           Definition.GuiPresentation.Title = "Feat/&SummonShifterForm_WolfAndBearFormTitle";
//           Definition.GuiPresentation.Description = "Feat/&SummonShifterForm_WolfAndBearFormDescription";
//           Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.SpellDefinitions.Stoneskin.GuiPresentation.SpriteReference);
//
//           Definition.SetActivationTime(RuleDefinitions.ActivationTime.Action);
//           Definition.SetRechargeRate(RuleDefinitions.RechargeRate.ShortRest);
//           Definition.SetFixedUsesPerRecharge(2);
//           Definition.SetCostPerUse(1);
//           Definition.SetHasCastingFailure(false);
//           Definition.SetUniqueInstance(true);
//
//           ConditionForm BearCondition = new ConditionForm();
//           BearCondition.SetApplyToSelf(true);
//           BearCondition.SetForceOnSelf(true);
//           BearCondition.Operation = ConditionForm.ConditionOperation.Add;
//           BearCondition.SetConditionDefinitionName(BearFormConditionBuilder.BearFormCondition.Name);
//           BearCondition.ConditionDefinition = BearFormConditionBuilder.BearFormCondition;
//
//           EffectForm BearFormEffect = new EffectForm();
//           BearFormEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
//           BearFormEffect.SetLevelMultiplier(1);
//           BearFormEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
//           BearFormEffect.SetCreatedByCharacter(true);
//           BearFormEffect.FormType = EffectForm.EffectFormType.Condition;
//           BearFormEffect.ConditionForm = BearCondition;
//
//
//           ConditionForm WolfCondition = new ConditionForm();
//           WolfCondition.SetApplyToSelf(true);
//           WolfCondition.SetForceOnSelf(true);
//           WolfCondition.Operation = ConditionForm.ConditionOperation.Add;
//           WolfCondition.SetConditionDefinitionName(WolfFormConditionBuilder.WolfFormCondition.Name);
//           WolfCondition.ConditionDefinition = WolfFormConditionBuilder.WolfFormCondition;
//
//           EffectForm WolfFormEffect = new EffectForm();
//           WolfFormEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
//           WolfFormEffect.SetLevelMultiplier(1);
//           WolfFormEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
//           WolfFormEffect.SetCreatedByCharacter(true);
//           WolfFormEffect.FormType = EffectForm.EffectFormType.Condition;
//           WolfFormEffect.ConditionForm = WolfCondition;
//
//           //Add to our new effect
//           EffectDescription newEffectDescription = new EffectDescription();
//           newEffectDescription.Copy(Definition.EffectDescription);
//           newEffectDescription.EffectForms.Clear();
//           newEffectDescription.EffectForms.Add(BearFormEffect);
//           newEffectDescription.EffectForms.Add(WolfFormEffect);
//           newEffectDescription.SetRangeParameter(1);
//           newEffectDescription.SetTargetType(RuleDefinitions.TargetType.Self);
//           newEffectDescription.DurationType = RuleDefinitions.DurationType.Minute;
//           newEffectDescription.DurationParameter = 10;
//           newEffectDescription.SetEffectParticleParameters(DatabaseHelper.SpellDefinitions.Aid.EffectDescription.EffectParticleParameters);
//
//
//
//           Definition.SetEffectDescription(newEffectDescription);
//
//           Definition.linkedPower = SummoningWildshapeViaPolymorph.Dictionaryof_Wildshape_Powers["Wolf"];
//       }
//
//       public static NewFeatureDefinitions.PowerWithRestrictions CreateAndAddToDB(string name, string guid)
//           => new SummonShifterForm_WolfAndBearFormPowerBuilder(name, guid).AddToDB();
//
//       public static NewFeatureDefinitions.PowerWithRestrictions SummonShifterForm_WolfAndBearForm = CreateAndAddToDB(SummonShifterForm_WolfAndBearFormName, SummonShifterForm_WolfAndBearFormNameGuid);
//
//   }
//
//
//   internal class SummonShifterForm_WolfAndStagFormPowerBuilder : BaseDefinitionBuilder<NewFeatureDefinitions.PowerWithRestrictions>
//   {
//       const string SummonShifterForm_WolfAndStagFormName = "SummonShifterForm_WolfAndStagForm_WolfAndStagForm";
//       const string SummonShifterForm_WolfAndStagFormNameGuid = "7049aca0-29aa-4269-ab5f-fbd5bdf55372";
//
//       protected SummonShifterForm_WolfAndStagFormPowerBuilder(string name, string guid) : base( name, guid)
//       {
//
//           Definition.GuiPresentation.Title = "Feat/&SummonShifterForm_WolfAndStagFormTitle";
//           Definition.GuiPresentation.Description = "Feat/&SummonShifterForm_WolfAndStagFormDescription";
//           Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.SpellDefinitions.Invisibility.GuiPresentation.SpriteReference);
//
//           Definition.SetActivationTime(RuleDefinitions.ActivationTime.Action);
//           Definition.SetRechargeRate(RuleDefinitions.RechargeRate.ShortRest);
//           Definition.SetFixedUsesPerRecharge(2);
//           Definition.SetCostPerUse(1);
//           Definition.SetHasCastingFailure(false);
//           Definition.SetUniqueInstance(true);
//
//           ConditionForm WolfCondition = new ConditionForm();
//           WolfCondition.SetApplyToSelf(true);
//           WolfCondition.SetForceOnSelf(true);
//           WolfCondition.Operation = ConditionForm.ConditionOperation.Add;
//           WolfCondition.SetConditionDefinitionName(WolfFormConditionBuilder.WolfFormCondition.Name);
//           WolfCondition.ConditionDefinition = WolfFormConditionBuilder.WolfFormCondition;
//
//           EffectForm WolfFormEffect = new EffectForm();
//           WolfFormEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
//           WolfFormEffect.SetLevelMultiplier(1);
//           WolfFormEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
//           WolfFormEffect.SetCreatedByCharacter(true);
//           WolfFormEffect.FormType = EffectForm.EffectFormType.Condition;
//           WolfFormEffect.ConditionForm = WolfCondition;
//
//
//           ConditionForm StagCondition = new ConditionForm();
//           // StagCondition.SetApplyToSelf(true);
//           // StagCondition.SetForceOnSelf(true);
//           StagCondition.Operation = ConditionForm.ConditionOperation.Add;
//           StagCondition.SetConditionDefinitionName(StagFormConditionBuilder.StagFormCondition.Name);
//           StagCondition.ConditionDefinition = StagFormConditionBuilder.StagFormCondition;
//
//           EffectForm StagFormEffect = new EffectForm();
//           StagFormEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
//           StagFormEffect.SetLevelMultiplier(1);
//           StagFormEffect.SetLevelType(RuleDefinitions.LevelSourceType.CharacterLevel);
//           StagFormEffect.SetCreatedByCharacter(true);
//           StagFormEffect.FormType = EffectForm.EffectFormType.Condition;
//           StagFormEffect.ConditionForm = StagCondition;
//
//           //Add to our new effect
//           EffectDescription newEffectDescription = new EffectDescription();
//           newEffectDescription.Copy(Definition.EffectDescription);
//           newEffectDescription.EffectForms.Clear();
//           newEffectDescription.EffectForms.Add(StagFormEffect);
//           newEffectDescription.EffectForms.Add(WolfFormEffect);
//           newEffectDescription.SetRangeParameter(6);
//           newEffectDescription.SetRangeType(RuleDefinitions.RangeType.Self);
//           newEffectDescription.SetTargetType(RuleDefinitions.TargetType.Sphere);
//           newEffectDescription.SetTargetSide(RuleDefinitions.Side.Ally);
//           newEffectDescription.DurationType = RuleDefinitions.DurationType.Minute;
//           newEffectDescription.SetEffectParticleParameters(DatabaseHelper.SpellDefinitions.Aid.EffectDescription.EffectParticleParameters);
//
//
//           //Add to our new effect
//           //    EffectDescription newEffectDescription = new EffectDescription();
//           //    newEffectDescription.Copy(Definition.EffectDescription);
//           //    newEffectDescription.EffectForms.Clear();
//           //    newEffectDescription.EffectForms.Add();
//           //    newEffectDescription.EffectForms.Add();
//           //    newEffectDescription.SetRangeParameter(1);
//           //    newEffectDescription.SetTargetType(RuleDefinitions.TargetType.Sphere);
//           //    newEffectDescription.DurationType = RuleDefinitions.DurationType.Minute;
//           //    newEffectDescription.DurationParameter = 10;
//
//
//
//           Definition.SetEffectDescription(newEffectDescription);
//
//           Definition.linkedPower = SummoningWildshapeViaPolymorph.Dictionaryof_Wildshape_Powers["Wolf"];
//       }
//
//       public static NewFeatureDefinitions.PowerWithRestrictions CreateAndAddToDB(string name, string guid)
//           => new SummonShifterForm_WolfAndStagFormPowerBuilder(name, guid).AddToDB();
//
//       public static NewFeatureDefinitions.PowerWithRestrictions SummonShifterForm_WolfAndStagForm = CreateAndAddToDB(SummonShifterForm_WolfAndStagFormName, SummonShifterForm_WolfAndStagFormNameGuid);
//
//   }
//
//
//
//
//    internal class SummonShifterForm_BearAndStagFormPowerBuilder : BaseDefinitionBuilder<NewFeatureDefinitions.PowerWithRestrictions>
//    {
//        const string SummonShifterForm_BearAndStagFormName = "SummonShifterForm_BearAndStagForm_BearAndStagForm";
//        const string SummonShifterForm_BearAndStagFormNameGuid = "64c561dd-4dff-43ac-9f56-cb3b58b62bab";
//
//        protected SummonShifterForm_BearAndStagFormPowerBuilder(string name, string guid) : base( name, guid)
//        {
//
//            Definition.GuiPresentation.Title = "Feat/&SummonShifterForm_BearAndStagFormTitle";
//            Definition.GuiPresentation.Description = "Feat/&SummonShifterForm_BearAndStagFormDescription";
//            Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.SpellDefinitions.GreaterInvisibility.GuiPresentation.SpriteReference);
//
//            Definition.SetActivationTime(RuleDefinitions.ActivationTime.Action);
//            Definition.SetRechargeRate(RuleDefinitions.RechargeRate.ShortRest);
//            Definition.SetFixedUsesPerRecharge(2);
//            Definition.SetCostPerUse(1);
//            Definition.SetHasCastingFailure(false);
//            Definition.SetUniqueInstance(true);
//
//            ConditionForm BearCondition = new ConditionForm();
//            BearCondition.SetApplyToSelf(true);
//            BearCondition.SetForceOnSelf(true);
//            BearCondition.Operation = ConditionForm.ConditionOperation.Add;
//            BearCondition.SetConditionDefinitionName(BearFormConditionBuilder.BearFormCondition.Name);
//            BearCondition.ConditionDefinition = BearFormConditionBuilder.BearFormCondition;
//
//            EffectForm BearFormEffect = new EffectForm();
//            BearFormEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
//            BearFormEffect.SetLevelMultiplier(1);
//            BearFormEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
//            BearFormEffect.SetCreatedByCharacter(true);
//            BearFormEffect.FormType = EffectForm.EffectFormType.Condition;
//            BearFormEffect.ConditionForm = BearCondition;
//
//            ConditionForm StagCondition = new ConditionForm();
//            // StagCondition.SetApplyToSelf(true);
//            // StagCondition.SetForceOnSelf(true);
//            StagCondition.Operation = ConditionForm.ConditionOperation.Add;
//            StagCondition.SetConditionDefinitionName(StagFormConditionBuilder.StagFormCondition.Name);
//            StagCondition.ConditionDefinition = StagFormConditionBuilder.StagFormCondition;
//
//            EffectForm StagFormEffect = new EffectForm();
//            StagFormEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
//            StagFormEffect.SetLevelMultiplier(1);
//            StagFormEffect.SetLevelType(RuleDefinitions.LevelSourceType.CharacterLevel);
//            StagFormEffect.SetCreatedByCharacter(true);
//            StagFormEffect.FormType = EffectForm.EffectFormType.Condition;
//            StagFormEffect.ConditionForm = StagCondition;
//
//            //Add to our new effect
//            EffectDescription newEffectDescription = new EffectDescription();
//            newEffectDescription.Copy(Definition.EffectDescription);
//            newEffectDescription.EffectForms.Clear();
//            newEffectDescription.EffectForms.Add(StagFormEffect);
//            newEffectDescription.EffectForms.Add(BearFormEffect);
//            newEffectDescription.SetRangeParameter(6);
//            newEffectDescription.SetRangeType(RuleDefinitions.RangeType.Self);
//            newEffectDescription.SetTargetType(RuleDefinitions.TargetType.Sphere);
//            newEffectDescription.SetTargetSide(RuleDefinitions.Side.Ally);
//            newEffectDescription.DurationType = RuleDefinitions.DurationType.Minute;
//            newEffectDescription.SetEffectParticleParameters(DatabaseHelper.SpellDefinitions.Aid.EffectDescription.EffectParticleParameters);
//
//
//
//            Definition.SetEffectDescription(newEffectDescription);
//
//            Definition.linkedPower = SummoningWildshapeViaPolymorph.Dictionaryof_Wildshape_Powers["Wolf"];
//        }
//
//        public static NewFeatureDefinitions.PowerWithRestrictions CreateAndAddToDB(string name, string guid)
//            => new SummonShifterForm_BearAndStagFormPowerBuilder(name, guid).AddToDB();
//
//        public static NewFeatureDefinitions.PowerWithRestrictions SummonShifterForm_BearAndStagForm = CreateAndAddToDB(SummonShifterForm_BearAndStagFormName, SummonShifterForm_BearAndStagFormNameGuid);
//
//    }
//
//


   

}

