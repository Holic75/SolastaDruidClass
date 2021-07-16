using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolastaModApi;
using SolastaModApi.Extensions; 
using HarmonyLib;

namespace SolastaDruidClass
{

    //*****************************************************************************************************************************************
    //***********************************		WandererSpiritBuilder		*******************************************************************
    //*****************************************************************************************************************************************

    internal class WandererSpiritBuilder : BaseDefinitionBuilder<MonsterDefinition>
    {
        const string WandererSpiritName = "WandererSpirit";
        const string WandererSpiritNameGuid = "41b31f06-a513-4113-9711-b6ee6f9a43fb";

        protected WandererSpiritBuilder(string name, string guid) : base(DatabaseHelper.MonsterDefinitions.WindSnake, name, guid)
        {

    //         Definition.SetMonsterPresentation(DatabaseHelper.MonsterDefinitions.WindSnake.MonsterPresentation);
    //         Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.MonsterDefinitions.WindSnake.GuiPresentation.SpriteReference);
   //
           Definition.GuiPresentation.Title = "Feat/&WandererSpiritTitle";
           Definition.GuiPresentation.Description = "Feat/&WandererSpiritDescription";
           Definition.MonsterPresentation.SetHasMonsterPortraitBackground(true);
           Definition.MonsterPresentation.SetCanGeneratePortrait(true);
   //
           Definition.SetArmorClass(18);
           Definition.SetNoExperienceGain(true);
           Definition.SetHitDice(1);
           Definition.SetHitDiceType(RuleDefinitions.DieType.D4);
   
          Definition.AbilityScores.Empty();
          Definition.AbilityScores.AddToArray(10);    // STR
          Definition.AbilityScores.AddToArray(14);    // DEX
          Definition.AbilityScores.AddToArray(14);    // CON
          Definition.AbilityScores.AddToArray(13);     // INT
          Definition.AbilityScores.AddToArray(15);    // WIS
          Definition.AbilityScores.AddToArray(11);     // CHA
   
   //    
   //        
   //
        Definition.SetFullyControlledWhenAllied(true);
      Definition.SetInDungeonEditor(true);
      Definition.SetStandardHitPoints(20);
      Definition.SetDefaultFaction("Party");
  
   //      
         Definition.Features.Clear();
         Definition.Features.Add(DatabaseHelper.FeatureDefinitionSenses.SenseDarkvision12);
         Definition.Features.Add(DatabaseHelper.FeatureDefinitionMoveModes.MoveModeFly8); 
         Definition.Features.Add(DatabaseHelper.FeatureDefinitionConditionAffinitys.ConditionAffinityCharmImmunity);
         Definition.Features.Add(DatabaseHelper.FeatureDefinitionConditionAffinitys.ConditionAffinityFrightenedImmunity);
         Definition.Features.Add(DatabaseHelper.FeatureDefinitionConditionAffinitys.ConditionAffinityGrappledImmunity);
           Definition.Features.Add(DatabaseHelper.FeatureDefinitionConditionAffinitys.ConditionAffinityProneImmunity);
           Definition.Features.Add(DatabaseHelper.FeatureDefinitionConditionAffinitys.ConditionAffinityRestrainedmmunity); 
           Definition.Features.Add(DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityForceImmunity);
         Definition.Features.Add(DatabaseHelper.FeatureDefinitionActionAffinitys.ActionAffinityFightingStyleProtection);

            //  Definition.Features.Add(DatabaseHelper.FeatureDefinitionPowers.PowerLaetharMistyFormEscape);
            //   Definition.Features.Add(DatabaseHelper.FeatureDefinitionPowers.PowerMountaineerCloseQuarters);
            //   Definition.Features.Add(SwapPositionsBuilder.SwapPositions);
            Definition.Features.Add(RiftJumpBuilder.RiftJump);
   //    
   //   
   //     
   //
             Definition.AttackIterations.Clear();
   
          
          MonsterAttackIteration monsterAttackIteration = new MonsterAttackIteration();
       
          Traverse.Create(monsterAttackIteration).Field("monsterAttackDefinition").SetValue(WandererSpiritAttackBuilder.WandererSpiritAttack);
  
          Traverse.Create(monsterAttackIteration).Field("number").SetValue(1);
  
          Definition.AttackIterations.AddRange(new List<MonsterAttackIteration> { monsterAttackIteration });
   //    

        }

        public static MonsterDefinition CreateAndAddToDB(string name, string guid)
            => new WandererSpiritBuilder(name, guid).AddToDB();

        public static MonsterDefinition WandererSpirit = CreateAndAddToDB(WandererSpiritName, WandererSpiritNameGuid);


    }


  

    //*****************************************************************************************************************************************
    //***********************************		WandererSpirit_2Builder		*******************************************************************
    //*****************************************************************************************************************************************

    internal class WandererSpirit_2Builder : BaseDefinitionBuilder<MonsterDefinition>
    {
        const string WandererSpirit_2Name = "WandererSpirit_2";
        const string WandererSpirit_2NameGuid = "2effeff4-b451-4b20-b3f2-e74ff9508bf9";

        protected WandererSpirit_2Builder(string name, string guid) : base(WandererSpiritBuilder.WandererSpirit, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&WandererSpiritTitle_2"; 
            Definition.GuiPresentation.Description = "Feat/&WandererSpiritDescription_3";
            //assume level 6
         //   Definition.SetHitDice(7);
            Definition.SetStandardHitPoints(35);


        }

        public static MonsterDefinition CreateAndAddToDB(string name, string guid)
            => new WandererSpirit_2Builder(name, guid).AddToDB();

        public static MonsterDefinition WandererSpirit_2 = CreateAndAddToDB(WandererSpirit_2Name, WandererSpirit_2NameGuid);


    }

    //*****************************************************************************************************************************************
    //***********************************		WandererSpirit_3Builder		*******************************************************************
    //*****************************************************************************************************************************************

    internal class WandererSpirit_3Builder : BaseDefinitionBuilder<MonsterDefinition>
    {
        const string WandererSpirit_3Name = "WandererSpirit_3";
        const string WandererSpirit_3NameGuid = "5e75926e-7adc-4ca7-ae9a-b70fed975001";

        protected WandererSpirit_3Builder(string name, string guid) : base(WandererSpirit_2Builder.WandererSpirit_2, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&WandererSpiritTitle_3";
            Definition.GuiPresentation.Description = "Feat/&WandererSpiritDescription_3";
            //assume level 10
          //  Definition.SetHitDice(11);
            Definition.SetStandardHitPoints(55);

              Definition.SetMonsterPresentation(DatabaseHelper.MonsterDefinitions.Air_Elemental.MonsterPresentation);
              Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.MonsterDefinitions.Air_Elemental.GuiPresentation.SpriteReference);
            Definition.Features.Add(RiftJump_2Builder.RiftJump_2);
        //  Definition.Features.Add(RiftJumpBuilder.RiftJump);

              Definition.AttackIterations.Clear(); 
              MonsterAttackIteration monsterAttackIteration = new MonsterAttackIteration();
               Traverse.Create(monsterAttackIteration).Field("monsterAttackDefinition").SetValue(WandererSpiritAttack_2Builder.WandererSpiritAttack_2);
               Traverse.Create(monsterAttackIteration).Field("number").SetValue(1);
               Definition.AttackIterations.AddRange(new List<MonsterAttackIteration> { monsterAttackIteration });

        }

        public static MonsterDefinition CreateAndAddToDB(string name, string guid)
            => new WandererSpirit_3Builder(name, guid).AddToDB();

        public static MonsterDefinition WandererSpirit_3 = CreateAndAddToDB(WandererSpirit_3Name, WandererSpirit_3NameGuid);


    }

    //*****************************************************************************************************************************************
    //***********************************		WandererSpirit_4Builder		*******************************************************************
    //*****************************************************************************************************************************************

    internal class WandererSpirit_4Builder : BaseDefinitionBuilder<MonsterDefinition>
    {
        const string WandererSpirit_4Name = "WandererSpirit_4";
        const string WandererSpirit_4NameGuid = "05adef39-8a72-4fd2-8bf0-a30146af1676";

        protected WandererSpirit_4Builder(string name, string guid) : base(WandererSpirit_3Builder.WandererSpirit_3, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&WandererSpiritTitle_4"; 
            Definition.GuiPresentation.Description = "Feat/&WandererSpiritDescription_4";
            //assume level 14
         //   Definition.SetHitDice(15);
            Definition.SetStandardHitPoints(75);
            

        }

        public static MonsterDefinition CreateAndAddToDB(string name, string guid)
            => new WandererSpirit_4Builder(name, guid).AddToDB();

        public static MonsterDefinition WandererSpirit_4 = CreateAndAddToDB(WandererSpirit_4Name, WandererSpirit_4NameGuid);


    }

    //*****************************************************************************************************************************************
    //***********************************		WandererSpirit_5Builder		*******************************************************************
    //*****************************************************************************************************************************************

    internal class WandererSpirit_5Builder : BaseDefinitionBuilder<MonsterDefinition>
    {
        const string WandererSpirit_5Name = "WandererSpirit_5";
        const string WandererSpirit_5NameGuid = "f45715ea-ecc7-4d6c-a25a-483b05f356fd";

        protected WandererSpirit_5Builder(string name, string guid) : base(WandererSpirit_4Builder.WandererSpirit_4, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&WandererSpiritTitle_5";
            Definition.GuiPresentation.Description = "Feat/&WandererSpiritDescription_5";
            //assume level 18
          //  Definition.SetHitDice(19);
            Definition.SetStandardHitPoints(90);

          Definition.AttackIterations.Clear();
          MonsterAttackIteration monsterAttackIteration = new MonsterAttackIteration();
          Traverse.Create(monsterAttackIteration).Field("monsterAttackDefinition").SetValue(WandererSpiritAttack_3Builder.WandererSpiritAttack_3);
          Traverse.Create(monsterAttackIteration).Field("number").SetValue(1);
          Definition.AttackIterations.AddRange(new List<MonsterAttackIteration> { monsterAttackIteration });

        }

        public static MonsterDefinition CreateAndAddToDB(string name, string guid)
            => new WandererSpirit_5Builder(name, guid).AddToDB();

        public static MonsterDefinition WandererSpirit_5 = CreateAndAddToDB(WandererSpirit_5Name, WandererSpirit_5NameGuid);


    }
    //*****************************************************************************************************************************************
    //***********************************		WandererSpiritAttacksListBuilder		*******************************************************************
    //*****************************************************************************************************************************************

    internal class WandererSpiritAttackBuilder : BaseDefinitionBuilder<MonsterAttackDefinition>
    {
        const string WandererSpiritAttacksListName = "WandererSpiritAttacksList";
        const string WandererSpiritAttacksListGuid = "13376940-5af1-4e6b-ad20-ad8252347800";

        protected WandererSpiritAttackBuilder(string name, string guid) : base(DatabaseHelper.MonsterAttackDefinitions.Attack_Goblin_PebbleThrow, name, guid)
        {

            Definition.GuiPresentation.Title = "Feat/&WandererSpiritAttackTitle";
            Definition.GuiPresentation.Description = "Feat/&WandererSpiritAttackDescription";
            //
            

            EffectForm motionEffect = new EffectForm();
            motionEffect.FormType = EffectForm.EffectFormType.Motion;

            var motion = new MotionForm();
            int PushDistance = 2;
            motion.SetDistance(PushDistance);
            motion.SetType(MotionForm.MotionType.PushFromOrigin);

            motionEffect.SetMotionForm(motion);
            //healingEffect.SetLevelAdvancement("Multiply","ClassLevel", 1);
            motionEffect.SetApplyLevel(EffectForm.LevelApplianceType.Multiply);
            //healingEffect.SetLevelAdvancement(EffectForm.LevelApplianceType Multiply,RuleDefinitions.LevelSourceType ClassLevel, int 1);
            motionEffect.SetLevelType(RuleDefinitions.LevelSourceType.CharacterLevel);
            motionEffect.SetLevelMultiplier(1);
            motionEffect.SavingThrowAffinity = RuleDefinitions.EffectSavingThrowType.Negates;

            EffectForm damageEffect = new EffectForm();
            damageEffect.DamageForm = new DamageForm();
            damageEffect.DamageForm.DiceNumber = 1;
            damageEffect.DamageForm.DieType = RuleDefinitions.DieType.D6;
            int assumedWisModifier = 3;
            int assumedProficiencyBonus = 2;
            damageEffect.DamageForm.DamageType = "DamageForce";
            damageEffect.DamageForm.BonusDamage = assumedProficiencyBonus;
            //damageEffect.ApplyAbilityBonus = (true);

            //Add to our new effect
            EffectDescription newEffectDescription = new EffectDescription();
            newEffectDescription.Copy(Definition.EffectDescription);
            newEffectDescription.EffectForms.Clear();
            newEffectDescription.EffectForms.Add(motionEffect);
            newEffectDescription.EffectForms.Add(damageEffect);
            newEffectDescription.HasSavingThrow = true;
            newEffectDescription.SavingThrowAbility = DatabaseHelper.SmartAttributeDefinitions.Strength.Name;
            newEffectDescription.SetSavingThrowDifficultyAbility(DatabaseHelper.SmartAttributeDefinitions.Intelligence.Name);
            newEffectDescription.SetDifficultyClassComputation(RuleDefinitions.EffectDifficultyClassComputation.FixedValue);
            newEffectDescription.FixedSavingThrowDifficultyClass = 19;
            newEffectDescription.SetCreatedByCharacter(true);
            // newEffectDescription.

            newEffectDescription.DurationType = RuleDefinitions.DurationType.UntilLongRest;
            newEffectDescription.SetTargetSide(RuleDefinitions.Side.Enemy);
            newEffectDescription.SetTargetType(RuleDefinitions.TargetType.IndividualsUnique);
            newEffectDescription.SetTargetProximityDistance(12);
            newEffectDescription.SetCanBePlacedOnCharacter(true);
            newEffectDescription.SetRangeType(RuleDefinitions.RangeType.Distance);
            newEffectDescription.SetRangeParameter(6);

            newEffectDescription.SetEffectParticleParameters(DatabaseHelper.SpellDefinitions.GustOfWind.EffectDescription.EffectParticleParameters);

            Definition.SetEffectDescription(newEffectDescription);
            Definition.SetToHitBonus(assumedWisModifier + assumedProficiencyBonus);




        }

        public static MonsterAttackDefinition CreateAndAddToDB(string name, string guid)
            => new WandererSpiritAttackBuilder(name, guid).AddToDB();

        public static MonsterAttackDefinition WandererSpiritAttack = CreateAndAddToDB(WandererSpiritAttacksListName, WandererSpiritAttacksListGuid);


    }

    //*****************************************************************************************************************************************
    //***********************************		WandererSpiritAttack_2sListBuilder		*******************************************************************
    //*****************************************************************************************************************************************

    internal class WandererSpiritAttack_2Builder : BaseDefinitionBuilder<MonsterAttackDefinition>
    {
        const string WandererSpiritAttack_2sListName = "WandererSpiritAttack_2sList";
        const string WandererSpiritAttack_2sListGuid = "87d57604-9cd3-43df-a48a-9e1da0319348";

        protected WandererSpiritAttack_2Builder(string name, string guid) : base(WandererSpiritAttackBuilder.WandererSpiritAttack, name, guid)
        {

            int assumedWisModifier = 4;
            int assumedProficiencyBonus = 4;
            int PushDistance = 3;

            Definition.EffectDescription.SetFixedSavingThrowDifficultyClass(17);
            Definition.EffectDescription.EffectForms[1].MotionForm.SetDistance(PushDistance);

            Definition.EffectDescription.EffectForms[0].DamageForm.BonusDamage = assumedProficiencyBonus;
            Definition.SetToHitBonus(assumedWisModifier + assumedProficiencyBonus);

            


        }

        public static MonsterAttackDefinition CreateAndAddToDB(string name, string guid)
            => new WandererSpiritAttack_2Builder(name, guid).AddToDB();

        public static MonsterAttackDefinition WandererSpiritAttack_2 = CreateAndAddToDB(WandererSpiritAttack_2sListName, WandererSpiritAttack_2sListGuid);


    }

    //*****************************************************************************************************************************************
    //***********************************		WandererSpiritAttack_3sListBuilder		*******************************************************************
    //*****************************************************************************************************************************************

    internal class WandererSpiritAttack_3Builder : BaseDefinitionBuilder<MonsterAttackDefinition>
    {
        const string WandererSpiritAttack_3ListName = "WandererSpiritAttack_3sList";
        const string WandererSpiritAttack_3ListGuid = "9ae3f86e-b6f9-48d0-a91f-b1f2a2632e1c";

        protected WandererSpiritAttack_3Builder(string name, string guid) : base(WandererSpiritAttackBuilder.WandererSpiritAttack, name, guid)
        {

            int assumedWisModifier = 5;
            int assumedProficiencyBonus = 6;
            int PushDistance = 4;


            Definition.EffectDescription.EffectForms[1].MotionForm.SetDistance(PushDistance);

            Definition.EffectDescription.EffectForms[0].DamageForm.BonusDamage = assumedProficiencyBonus;
            Definition.SetToHitBonus(assumedWisModifier + assumedProficiencyBonus);




        }

        public static MonsterAttackDefinition CreateAndAddToDB(string name, string guid)
            => new WandererSpiritAttack_3Builder(name, guid).AddToDB();

        public static MonsterAttackDefinition WandererSpiritAttack_3 = CreateAndAddToDB(WandererSpiritAttack_3ListName, WandererSpiritAttack_3ListGuid);


    }
    //*****************************************************************************************************************************************
    //***********************************		SwapPositionsBuilder		*******************************************************************
    //*****************************************************************************************************************************************

//   internal class SwapPositionsBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
//   {
//       const string SwapPositionsName = "WandererSpiritSwapPositions";
//       const string SwapPositionsNameGuid = "78b6d051-e9e8-405e-ba3d-356edeedbd26";
//
//       protected SwapPositionsBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionPowers.PowerLaetharMistyFormEscape, name, guid)
//       {
//   
//          Definition.GuiPresentation.Title = "Feat/&WandererSpiritSwapPositionsTitle";
//          Definition.GuiPresentation.Description = "Feat/&WandererSpiritSwapPositionsDescription";
//          Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.FeatureDefinitionPowers.PowerMountaineerCloseQuarters.GuiPresentation.SpriteReference);
//   
//          Definition.SetActivationTime(RuleDefinitions.ActivationTime.Action);
//         
//   
//         EffectForm motionEffect = new EffectForm();
//         motionEffect.ApplyAbilityBonus = (false);
//         motionEffect.SetMotionForm(new MotionForm()); 
//         motionEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
//         motionEffect.SetCreatedByCharacter(true); 
//         motionEffect.SetLevelMultiplier(1); 
//         motionEffect.MotionForm.SetType(MotionForm.MotionType.SwapPositions);
//           motionEffect.HasSavingThrow = false;
//   
//          EffectDescription newEffectDescription = new EffectDescription();
//          newEffectDescription.Copy(Definition.EffectDescription);
//          newEffectDescription.EffectForms.Clear();
//          newEffectDescription.EffectForms.Add(motionEffect);
//          newEffectDescription.SetRangeParameter(6);
//          newEffectDescription.SetRangeType(RuleDefinitions.RangeType.Distance);
//          newEffectDescription.SetTargetSide(RuleDefinitions.Side.Ally);
//          newEffectDescription.SetTargetType(RuleDefinitions.TargetType.Individuals);
//          newEffectDescription.SetTargetParameter(1);
//          newEffectDescription.SetTargetProximityDistance(30);
//          newEffectDescription.DurationType = RuleDefinitions.DurationType.Instantaneous;
//          newEffectDescription.DurationParameter = 1;
//   
//          Definition.SetRechargeRate(RuleDefinitions.RechargeRate.AtWill);
//          Definition.SetEffectDescription(newEffectDescription);
//   
//
//       }
//
//       public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
//           => new SwapPositionsBuilder(name, guid).AddToDB();
//
//       public static FeatureDefinitionPower SwapPositions = CreateAndAddToDB(SwapPositionsName, SwapPositionsNameGuid);
//
//
//   }

    //*****************************************************************************************************************************************
    //***********************************		RiftJumpBuilder		*******************************************************************
    //*****************************************************************************************************************************************

    internal class RiftJumpBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string RiftJumpName = "RiftJump";
        const string RiftJumpNameGuid = "2290e63c-f647-4ace-8d0c-aa9407071c22";

        protected RiftJumpBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionPowers.PowerShadowcasterShadowDodge, name, guid)
        {

            Definition.GuiPresentation.Title = "Feat/&RiftJumpTitle";
            Definition.GuiPresentation.Description = "Feat/&RiftJumpDescription";
            Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.SpellDefinitions.DimensionDoor.GuiPresentation.SpriteReference);
            Definition.SetShortTitleOverride("Feat/&RiftJumpTitle");

            Definition.SetRechargeRate(RuleDefinitions.RechargeRate.AtWill);
            Definition.EffectDescription.SetInviteOptionalAlly(true);
             
        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new RiftJumpBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPower RiftJump = CreateAndAddToDB(RiftJumpName, RiftJumpNameGuid);


    }

    internal class RiftJump_2Builder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string RiftJump_2Name = "RiftJump_2";
        const string RiftJump_2NameGuid = "6041b7be-2ce9-446e-bcbf-77ea8ccc1138";

        protected RiftJump_2Builder(string name, string guid) : base(RiftJumpBuilder.RiftJump, name, guid)
        {

            Definition.SetOverriddenPower(RiftJumpBuilder.RiftJump);
            Definition.EffectDescription.SetRangeParameter(12);


        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new RiftJump_2Builder(name, guid).AddToDB();

        public static FeatureDefinitionPower RiftJump_2 = CreateAndAddToDB(RiftJump_2Name, RiftJump_2NameGuid);


    }
    //*****************************************************************************************************************************************
    //***********************************		SummonWandererSpiritBuilder		*******************************************************************
    //*****************************************************************************************************************************************

    internal class SummonWandererSpiritPowerBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string SummonWandererSpiritName = "SummonWandererSpirit";
        const string SummonWandererSpiritNameGuid = "59447ad2-d6f1-4b73-b1b3-cd927300d140";

        protected SummonWandererSpiritPowerBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionPowers.PowerClericDivineInterventionCleric, name, guid)
        {

            Definition.GuiPresentation.Title = "Feat/&SummonWandererSpiritTitle";
            Definition.GuiPresentation.Description = "Feat/&SummonWandererSpiritDescription";
            Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.SpellDefinitions.ConjureElementalAir.GuiPresentation.SpriteReference);

            Definition.SetActivationTime(RuleDefinitions.ActivationTime.BonusAction);
            Definition.SetRechargeRate(RuleDefinitions.RechargeRate.ChannelDivinity);
            Definition.SetFixedUsesPerRecharge(1);
            Definition.SetCostPerUse(1);
            Definition.SetHasCastingFailure(false);
            Definition.SetUniqueInstance(true);


            SummonForm summonprotector = new SummonForm();
          //  summonprotector.SetMonsterDefinitionName(DatabaseHelper.MonsterDefinitions.WindSnake.Name);
            summonprotector.SetMonsterDefinitionName(WandererSpiritBuilder.WandererSpirit.Name);
            summonprotector.SetSummonType(SummonForm.Type.Creature);
            summonprotector.SetNumber(1);
            summonprotector.SetDecisionPackage(DatabaseHelper.DecisionPackageDefinitions.IdleGuard_Default);
            summonprotector.SetEffectProxyDefinitionName("");

            EffectForm summoneffect = new EffectForm();
            summoneffect.FormType = EffectForm.EffectFormType.Summon;//"summons";
            summoneffect.SetSummonForm(summonprotector);



            //Add to our new effect
            EffectDescription newEffectDescription = new EffectDescription();
            newEffectDescription.Copy(Definition.EffectDescription);
            newEffectDescription.EffectForms.Clear();
            newEffectDescription.EffectForms.Add(summoneffect);
            newEffectDescription.SetRangeParameter(1);
            newEffectDescription.SetTargetType(RuleDefinitions.TargetType.Position);
            newEffectDescription.DurationType = RuleDefinitions.DurationType.Hour;
            newEffectDescription.DurationParameter = 1;



            Definition.SetEffectDescription(newEffectDescription);


        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new SummonWandererSpiritPowerBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPower SummonWandererSpirit = CreateAndAddToDB(SummonWandererSpiritName, SummonWandererSpiritNameGuid);

    }

    //*****************************************************************************************************************************************
    //***********************************		SummonWandererSpiritPower_2Builder		*******************************************************************
    //*****************************************************************************************************************************************

    internal class SummonWandererSpiritPower_2Builder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string SummonWandererSpiritPower_2Name = "SummonWandererSpiritPower_2";
        const string SummonWandererSpiritPower_2NameGuid = "f777b42f-8369-4cbf-9497-2fe662ae3445";

        protected SummonWandererSpiritPower_2Builder(string name, string guid) : base(SummonWandererSpiritPowerBuilder.SummonWandererSpirit, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&SummonWandererSpiritTitle_2";
            Definition.GuiPresentation.Description = "Feat/&SummonWandererSpiritDescription_2";

            Definition.SetOverriddenPower(SummonWandererSpiritPowerBuilder.SummonWandererSpirit);

            Definition.EffectDescription.EffectForms[0].SummonForm.SetMonsterDefinitionName(WandererSpirit_2Builder.WandererSpirit_2.Name);

        


        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new SummonWandererSpiritPower_2Builder(name, guid).AddToDB();

        public static FeatureDefinitionPower SummonWandererSpiritPower_2 = CreateAndAddToDB(SummonWandererSpiritPower_2Name, SummonWandererSpiritPower_2NameGuid);

    }
    //*****************************************************************************************************************************************
    //***********************************		SummonWandererSpiritPower_3Builder		*******************************************************************
    //*****************************************************************************************************************************************

    internal class SummonWandererSpiritPower_3Builder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string SummonWandererSpiritPower_3Name = "SummonWandererSpiritPower_3";
        const string SummonWandererSpiritPower_3NameGuid = "217208a4-01fb-4524-8ddc-576b32744003";

        protected SummonWandererSpiritPower_3Builder(string name, string guid) : base(SummonWandererSpiritPowerBuilder.SummonWandererSpirit, name, guid)
        {

            Definition.GuiPresentation.Title = "Feat/&SummonWandererSpiritTitle_3";
            Definition.GuiPresentation.Description = "Feat/&SummonWandererSpiritDescription_3";
            Definition.SetOverriddenPower(SummonWandererSpiritPower_2Builder.SummonWandererSpiritPower_2);

            Definition.EffectDescription.EffectForms[0].SummonForm.SetMonsterDefinitionName(WandererSpirit_3Builder.WandererSpirit_3.Name);

            ConditionForm casterFlight = new ConditionForm();
            casterFlight.SetApplyToSelf(true);
            casterFlight.SetForceOnSelf(true);
            casterFlight.Operation = ConditionForm.ConditionOperation.Add;
            casterFlight.SetConditionDefinitionName(DatabaseHelper.ConditionDefinitions.ConditionFlyingBootsWinged.Name);
            casterFlight.ConditionDefinition = DatabaseHelper.ConditionDefinitions.ConditionFlyingBootsWinged; 

            EffectForm casterFlightEffect = new EffectForm();
            casterFlightEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
            casterFlightEffect.SetLevelMultiplier(1);
            casterFlightEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            casterFlightEffect.SetCreatedByCharacter(true);
            casterFlightEffect.FormType = EffectForm.EffectFormType.Condition;
            casterFlightEffect.ConditionForm = casterFlight;

            Definition.EffectDescription.EffectForms.Add(casterFlightEffect);


        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new SummonWandererSpiritPower_3Builder(name, guid).AddToDB();

        public static FeatureDefinitionPower SummonWandererSpiritPower_3 = CreateAndAddToDB(SummonWandererSpiritPower_3Name, SummonWandererSpiritPower_3NameGuid);

    }

    //*****************************************************************************************************************************************
    //***********************************		SummonWandererSpiritPower_4Builder		*******************************************************************
    //*****************************************************************************************************************************************

    internal class SummonWandererSpiritPower_4Builder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string SummonWandererSpiritPower_4Name = "SummonWandererSpiritPower_4";
        const string SummonWandererSpiritPower_4NameGuid = "119fface-8c98-4302-9088-afcc4cd79168";

        protected SummonWandererSpiritPower_4Builder(string name, string guid) : base(SummonWandererSpiritPower_3Builder.SummonWandererSpiritPower_3, name, guid)
        {

            Definition.GuiPresentation.Title = "Feat/&SummonWandererSpiritTitle_4";
            Definition.GuiPresentation.Description = "Feat/&SummonWandererSpiritDescription_4";
            Definition.SetOverriddenPower(SummonWandererSpiritPower_3Builder.SummonWandererSpiritPower_3);

            Definition.EffectDescription.EffectForms[0].SummonForm.SetMonsterDefinitionName(WandererSpirit_4Builder.WandererSpirit_4.Name);

            ConditionForm casterSemiIncorporeal = new ConditionForm();
            casterSemiIncorporeal.SetApplyToSelf(true);
            casterSemiIncorporeal.SetForceOnSelf(true);
            casterSemiIncorporeal.Operation = ConditionForm.ConditionOperation.Add;
            casterSemiIncorporeal.SetConditionDefinitionName(DatabaseHelper.ConditionDefinitions.ConditionWardedByWardingBond.Name);
            casterSemiIncorporeal.ConditionDefinition = DatabaseHelper.ConditionDefinitions.ConditionWardedByWardingBond;

            EffectForm casterSemiIncorporealEffect = new EffectForm();
            casterSemiIncorporealEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
            casterSemiIncorporealEffect.SetLevelMultiplier(1);
            casterSemiIncorporealEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            casterSemiIncorporealEffect.SetCreatedByCharacter(true);
            casterSemiIncorporealEffect.FormType = EffectForm.EffectFormType.Condition;
            casterSemiIncorporealEffect.ConditionForm = casterSemiIncorporeal;

            Definition.EffectDescription.EffectForms.Add(casterSemiIncorporealEffect);


        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new SummonWandererSpiritPower_4Builder(name, guid).AddToDB();

        public static FeatureDefinitionPower SummonWandererSpiritPower_4 = CreateAndAddToDB(SummonWandererSpiritPower_4Name, SummonWandererSpiritPower_4NameGuid);

    }
    //*****************************************************************************************************************************************
    //***********************************		SummonWandererSpiritPower_5Builder		*******************************************************************
    //*****************************************************************************************************************************************

    internal class SummonWandererSpiritPower_5Builder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string SummonWandererSpiritPower_5Name = "SummonWandererSpiritPower_5";
        const string SummonWandererSpiritPower_5NameGuid = "6fe7e717-b2ae-48bc-86d3-3d2574248b7a";

        protected SummonWandererSpiritPower_5Builder(string name, string guid) : base(SummonWandererSpiritPower_4Builder.SummonWandererSpiritPower_4, name, guid)
        {

            Definition.GuiPresentation.Title = "Feat/&SummonWandererSpiritTitle_5";
            Definition.GuiPresentation.Description = "Feat/&SummonWandererSpiritDescription_5";
            Definition.SetOverriddenPower(SummonWandererSpiritPower_4Builder.SummonWandererSpiritPower_4);

            Definition.EffectDescription.EffectForms[0].SummonForm.SetMonsterDefinitionName(WandererSpirit_5Builder.WandererSpirit_5.Name);

         


        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new SummonWandererSpiritPower_5Builder(name, guid).AddToDB();

        public static FeatureDefinitionPower SummonWandererSpiritPower_5 = CreateAndAddToDB(SummonWandererSpiritPower_5Name, SummonWandererSpiritPower_5NameGuid);

    }
  


}

