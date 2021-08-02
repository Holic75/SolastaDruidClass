using System;
using System.Collections.Generic;
using SolastaModApi;
using SolastaModApi.Extensions;
using Common = SolastaModHelpers.Common;
using Helpers = SolastaModHelpers.Helpers;
using NewFeatureDefinitions = SolastaModHelpers.NewFeatureDefinitions;  
using HarmonyLib;


namespace SolastaDruidClass
{
	public class SummoningPowersViaModHelpers
	{

		static public NewFeatureDefinitions.PowerWithRestrictions WandererSpirit_Power;
		static public NewFeatureDefinitions.PowerWithRestrictions ShifterForm_Power;
		static public List<MonsterDefinition> listofWandererSpirits;
		static public List<string> listofShifterForms;

		static public Dictionary<string, NewFeatureDefinitions.PowerWithRestrictions> Dictionaryof_WandererSpirit_Powers = new Dictionary<string, NewFeatureDefinitions.PowerWithRestrictions>();
		static public Dictionary<string, NewFeatureDefinitions.PowerWithRestrictions> Dictionaryof_ShifterForm_Powers = new Dictionary<string, NewFeatureDefinitions.PowerWithRestrictions>();

        internal static void Create()
        {
            Create_WandererSpirit_Power();
            Create_ShifterForm_Power();


        }
        


        public static void Create_WandererSpirit_Power()
		{

			listofWandererSpirits = new List<MonsterDefinition>
										{
										WandererSpiritBuilder.WandererSpirit,
										WandererSpirit_2Builder.WandererSpirit_2,
										WandererSpirit_3Builder.WandererSpirit_3,
										WandererSpirit_4Builder.WandererSpirit_4,
										WandererSpirit_5Builder.WandererSpirit_5, 
                                        };
    
    
			foreach (MonsterDefinition WandererSpirit in listofWandererSpirits)
			{
   
   
   
   
				SummonForm summonWandererSpirit = new SummonForm();
				//summonprotector.SetMonsterDefinitionName(DatabaseHelper.MonsterDefinitions.Poisonous_Snake.Name);
				summonWandererSpirit.SetMonsterDefinitionName(WandererSpirit.Name);
				summonWandererSpirit.SetSummonType(SummonForm.Type.Creature);
				summonWandererSpirit.SetNumber(1);
				summonWandererSpirit.SetDecisionPackage(DatabaseHelper.DecisionPackageDefinitions.IdleGuard_Default);
				summonWandererSpirit.SetEffectProxyDefinitionName("");
				
				EffectForm summoneffect = new EffectForm();
				summoneffect.FormType = EffectForm.EffectFormType.Summon;//"summons";
				summoneffect.SetSummonForm(summonWandererSpirit);

                ConditionForm BlockExtraSummonsCondition = new ConditionForm();
                BlockExtraSummonsCondition.SetApplyToSelf(true);
                BlockExtraSummonsCondition.SetForceOnSelf(true);
                BlockExtraSummonsCondition.Operation = ConditionForm.ConditionOperation.Add;
                BlockExtraSummonsCondition.SetConditionDefinitionName(WandererSpirit_Active_ConditionBuilder.WandererSpirit_Active_Condition.Name);
                BlockExtraSummonsCondition.ConditionDefinition = WandererSpirit_Active_ConditionBuilder.WandererSpirit_Active_Condition;

                EffectForm BlockExtraSummonsEffect = new EffectForm();
                BlockExtraSummonsEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
                BlockExtraSummonsEffect.SetLevelMultiplier(1);
                BlockExtraSummonsEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
                BlockExtraSummonsEffect.SetCreatedByCharacter(true);
                BlockExtraSummonsEffect.FormType = EffectForm.EffectFormType.Condition;
                BlockExtraSummonsEffect.ConditionForm = BlockExtraSummonsCondition;

                


                //Add to our new effect
                EffectDescription effect = new EffectDescription();
				effect.Copy(DatabaseHelper.SpellDefinitions.ConjureElementalAir.EffectDescription);
				effect.EffectForms.Clear();
				effect.EffectForms.Add(summoneffect);
                effect.EffectForms.Add(BlockExtraSummonsEffect);
                effect.SetRangeParameter(1);
				effect.SetTargetType(RuleDefinitions.TargetType.Position);
				effect.DurationType = RuleDefinitions.DurationType.Hour;
				effect.DurationParameter = 1;
    
    
    
				WandererSpirit_Power = Helpers.GenericPowerBuilder<NewFeatureDefinitions.PowerWithRestrictions>
					.createPower(                                                                           //	  public static FeatureDefinitionPower createPower(    
					WandererSpirit.Name + "_Power",                                                        //    string name,
					GuidHelper.Create(Main.ModGuidNamespace, WandererSpirit.Name + "_Power").ToString(),   //    string guid,
					"Feature/&DH_" + WandererSpirit.Name + "_Power_Title",                                 //	  string title,
					"Feature/&DH_" + WandererSpirit.Name + "_Power_Description",                           //	  string description
					WandererSpirit.GuiPresentation.SpriteReference,                                                  //    AssetReferenceSprite sprite,
					effect,                                                                                 //    EffectDescription effect_description,
					RuleDefinitions.ActivationTime.Action,                                                  //    RuleDefinitions.ActivationTime activation_time,
					2,                                                                                      //    int fixed_uses,
					RuleDefinitions.UsesDetermination.Fixed,                                                //    RuleDefinitions.UsesDetermination uses_determination
					RuleDefinitions.RechargeRate.ShortRest,													//    RuleDefinitions.RechargeRate recharge_rate,
					"Wisdom",                                                                               //    string uses_ability = "Strength",
					"Wisdom",                                                                               //    string ability = "Strength",
					1,                                                                                      //    int cost_per_use = 1,
					true                                                                                    //    bool show_casting = true
					);                                                                                      //    )
    
    
     
	 			Dictionaryof_WandererSpirit_Powers.Add(WandererSpirit.Name, WandererSpirit_Power);
     
				if (WandererSpirit.Name == "WandererSpirit_2")
				{
					WandererSpirit_Power.SetOverriddenPower(Dictionaryof_WandererSpirit_Powers["WandererSpirit"]);
				}
				if (WandererSpirit.Name == "WandererSpirit_3")
				{
    
					WandererSpirit_Power.SetOverriddenPower(Dictionaryof_WandererSpirit_Powers["WandererSpirit_2"]);
    
				}
				if (WandererSpirit.Name == "WandererSpirit_4")
				{
					WandererSpirit_Power.SetOverriddenPower(Dictionaryof_WandererSpirit_Powers["WandererSpirit_3"]);
				}
    
				if (WandererSpirit.Name == "WandererSpirit_5")
                {
					WandererSpirit_Power.linkedPower = Dictionaryof_WandererSpirit_Powers["WandererSpirit_4"];
    
				}
    
				if (WandererSpirit.Name == "WandererSpirit_3"|| WandererSpirit.Name == "WandererSpirit_4" || WandererSpirit.Name == "WandererSpirit_5") 
				{
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
    
					WandererSpirit_Power.EffectDescription.EffectForms.Add(casterFlightEffect);
				};
     
     
	 			if (WandererSpirit.Name == "WandererSpirit_4" || WandererSpirit.Name == "WandererSpirit_5")
	 			{
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
     
					WandererSpirit_Power.EffectDescription.EffectForms.Add(casterSemiIncorporealEffect);
	 			}
                

                //WildShape_Power.linkedPower = Dictionaryof_Wildshape_Powers["Wolf"];
                WandererSpirit_Power.linkedPower = SummoningWildshapeViaPolymorph.Dictionaryof_Wildshape_Powers["Wolf"];
               

            };// foreach
    
    

		}// static void


		public static void Create_ShifterForm_Power()
		{

			listofShifterForms = new List<string>
										{
										  "Wolf",
										  "Bear",
										  "Stag",
										  "WolfAndBear",
										  "WolfAndStag",
										  "BearAndStag",
										};


			foreach (string ShifterForm in listofShifterForms)
			{


				EffectDescription effect = new EffectDescription();
				effect.Copy(DatabaseHelper.FeatureDefinitionPowers.PowerClericDivineInterventionCleric.EffectDescription);
				effect.EffectForms.Clear();
				effect.SetRangeParameter(1);
				effect.SetTargetType(RuleDefinitions.TargetType.Self);
				effect.DurationType = RuleDefinitions.DurationType.Minute;
				effect.DurationParameter = 10;
				effect.SetEffectParticleParameters(DatabaseHelper.SpellDefinitions.Aid.EffectDescription.EffectParticleParameters);
				 

				ShifterForm_Power = Helpers.GenericPowerBuilder<NewFeatureDefinitions.PowerWithRestrictions>
					.createPower(                                                                           //	  public static FeatureDefinitionPower createPower(    
					"ShifterForm_"+ShifterForm + "_Power",                                                     //    string name,
					GuidHelper.Create(Main.ModGuidNamespace, "ShifterForm_" + ShifterForm + "_Power").ToString(),   //    string guid,
					"Feature/&DH_" + "ShifterForm_" + ShifterForm + "_Power_Title",                                 //	  string title,
					"Feature/&DH_" + "ShifterForm_" + ShifterForm + "_Power_Description",                           //	  string description
					DatabaseHelper.SpellDefinitions.Heroism.GuiPresentation.SpriteReference,                                                  //    AssetReferenceSprite sprite,
					effect,                                                                                 //    EffectDescription effect_description,
					RuleDefinitions.ActivationTime.Action,                                                  //    RuleDefinitions.ActivationTime activation_time,
					2,                                                                                      //    int fixed_uses,
					RuleDefinitions.UsesDetermination.Fixed,                                                //    RuleDefinitions.UsesDetermination uses_determination
					RuleDefinitions.RechargeRate.ShortRest,                                           //    RuleDefinitions.RechargeRate recharge_rate,
					"Wisdom",                                                                               //    string uses_ability = "Strength",
					"Wisdom",                                                                               //    string ability = "Strength",
					1,                                                                                      //    int cost_per_use = 1,
					true                                                                                    //    bool show_casting = true
					);                                                                                      //    )



				Dictionaryof_ShifterForm_Powers.Add(ShifterForm, ShifterForm_Power);

				
				if (ShifterForm == "Wolf"|| ShifterForm == "WolfAndBear"|| ShifterForm == "WolfAndStag")
				{

					ConditionForm WolfCondition = new ConditionForm();
					WolfCondition.SetApplyToSelf(true);
					WolfCondition.SetForceOnSelf(true);
					WolfCondition.Operation = ConditionForm.ConditionOperation.Add;
					WolfCondition.SetConditionDefinitionName(WolfFormConditionBuilder.WolfFormCondition.Name);
					WolfCondition.ConditionDefinition = WolfFormConditionBuilder.WolfFormCondition;

					EffectForm WolfFormEffect = new EffectForm();
					WolfFormEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
					WolfFormEffect.SetLevelMultiplier(1);
					WolfFormEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
					WolfFormEffect.SetCreatedByCharacter(true);
					WolfFormEffect.FormType = EffectForm.EffectFormType.Condition;
					WolfFormEffect.ConditionForm = WolfCondition;

					effect.EffectForms.Add(WolfFormEffect);

                    ShifterForm_Power.GuiPresentation.SetSpriteReference(DatabaseHelper.SpellDefinitions.Heroism.GuiPresentation.SpriteReference);


                }
				if (ShifterForm == "Bear" || ShifterForm == "WolfAndBear" || ShifterForm == "BearAndStag")
				{
					ConditionForm BearCondition = new ConditionForm();
					BearCondition.SetApplyToSelf(true);
					BearCondition.SetForceOnSelf(true);
					BearCondition.Operation = ConditionForm.ConditionOperation.Add;
					BearCondition.SetConditionDefinitionName(BearFormConditionBuilder.BearFormCondition.Name);
					BearCondition.ConditionDefinition = BearFormConditionBuilder.BearFormCondition;

					EffectForm BearFormEffect = new EffectForm();
					BearFormEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
					BearFormEffect.SetLevelMultiplier(1);
					BearFormEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
					BearFormEffect.SetCreatedByCharacter(true);
					BearFormEffect.FormType = EffectForm.EffectFormType.Condition;
					BearFormEffect.ConditionForm = BearCondition;

					effect.EffectForms.Add(BearFormEffect);

                    ShifterForm_Power.GuiPresentation.SetSpriteReference(DatabaseHelper.SpellDefinitions.Barkskin.GuiPresentation.SpriteReference);
                }
				if (ShifterForm == "Stag" || ShifterForm == "WolfAndStag" || ShifterForm == "BearAndStag")
				{
					ConditionForm StagCondition = new ConditionForm();
					// StagCondition.SetApplyToSelf(true);
					// StagCondition.SetForceOnSelf(true);
					StagCondition.Operation = ConditionForm.ConditionOperation.Add;
					StagCondition.SetConditionDefinitionName(StagFormConditionBuilder.StagFormCondition.Name);
					StagCondition.ConditionDefinition = StagFormConditionBuilder.StagFormCondition;

					EffectForm StagFormEffect = new EffectForm();
					StagFormEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
					StagFormEffect.SetLevelMultiplier(1);
					StagFormEffect.SetLevelType(RuleDefinitions.LevelSourceType.CharacterLevel);
					StagFormEffect.SetCreatedByCharacter(true);
					StagFormEffect.FormType = EffectForm.EffectFormType.Condition;
					StagFormEffect.ConditionForm = StagCondition;

					effect.SetEffectParticleParameters(DatabaseHelper.SpellDefinitions.SpiderClimb.EffectDescription.EffectParticleParameters);
					effect.EffectForms.Add(StagFormEffect);
                     
                    effect.SetRangeParameter(2);
                    effect.SetRangeType(RuleDefinitions.RangeType.Self);
                    effect.SetTargetType(RuleDefinitions.TargetType.Sphere);
                    effect.SetTargetSide(RuleDefinitions.Side.Ally);
                    effect.DurationType = RuleDefinitions.DurationType.Minute;
                    effect.SetTargetParameter(2);
                    effect.DurationParameter = 1;

                    ShifterForm_Power.GuiPresentation.SetSpriteReference(DatabaseHelper.SpellDefinitions.MassHealingWord.GuiPresentation.SpriteReference);
                }

                if ( ShifterForm == "WolfAndBear" )
                {
                    ShifterForm_Power.GuiPresentation.SetSpriteReference(DatabaseHelper.SpellDefinitions.Stoneskin.GuiPresentation.SpriteReference);

                }
                if (ShifterForm == "BearAndStag")
                {
                    ShifterForm_Power.GuiPresentation.SetSpriteReference(DatabaseHelper.SpellDefinitions.GreaterInvisibility.GuiPresentation.SpriteReference);
                }
                if ( ShifterForm == "WolfAndStag")
                {
                   ShifterForm_Power.GuiPresentation.SetSpriteReference(DatabaseHelper.SpellDefinitions.Invisibility.GuiPresentation.SpriteReference);
                }

                ShifterForm_Power.linkedPower = SummoningWildshapeViaPolymorph.Dictionaryof_Wildshape_Powers["Wolf"];

			}; // foreach

		}// static void


















	}//public class 


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

            //  Definition.Features.Add(DatabaseHelper.NewFeatureDefinitions.PowerWithRestrictionss.PowerLaetharMistyFormEscape);
            //   Definition.Features.Add(DatabaseHelper.NewFeatureDefinitions.PowerWithRestrictionss.PowerMountaineerCloseQuarters);
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

//   internal class SwapPositionsBuilder : BaseDefinitionBuilder<NewFeatureDefinitions.PowerWithRestrictions>
//   {
//       const string SwapPositionsName = "WandererSpiritSwapPositions";
//       const string SwapPositionsNameGuid = "78b6d051-e9e8-405e-ba3d-356edeedbd26";
//
//       protected SwapPositionsBuilder(string name, string guid) : base(DatabaseHelper.NewFeatureDefinitions.PowerWithRestrictionss.PowerLaetharMistyFormEscape, name, guid)
//       {
//   
//          Definition.GuiPresentation.Title = "Feat/&WandererSpiritSwapPositionsTitle";
//          Definition.GuiPresentation.Description = "Feat/&WandererSpiritSwapPositionsDescription";
//          Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.NewFeatureDefinitions.PowerWithRestrictionss.PowerMountaineerCloseQuarters.GuiPresentation.SpriteReference);
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
//       public static NewFeatureDefinitions.PowerWithRestrictions CreateAndAddToDB(string name, string guid)
//           => new SwapPositionsBuilder(name, guid).AddToDB();
//
//       public static NewFeatureDefinitions.PowerWithRestrictions SwapPositions = CreateAndAddToDB(SwapPositionsName, SwapPositionsNameGuid);
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

    internal class WolfFormConditionBuilder : BaseDefinitionBuilder<ConditionDefinition>
    {
        const string WolfFormConditionName = "WolfFormCondition";
        const string WolfFormConditionGuid = "d6b3dcd8-8a8f-4b84-99f8-a9798f0f6d2e";

        protected WolfFormConditionBuilder(string name, string guid) : base(DatabaseHelper.ConditionDefinitions.ConditionBearsEndurance, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&WolfFormConditionTitle";
            Definition.GuiPresentation.Description = "Feature/&WolfFormConditionDescription";

            Definition.SetAllowMultipleInstances(false);
            Definition.Features.Clear();
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionAdditionalDamages.AdditionalDamageHunterColossusSlayer);
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionActionAffinitys.ActionAffinityNimbleEscape);
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionCombatAffinitys.CombatAffinityPackTactics);
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionActionAffinitys.ActionAffinityAggressive);
            Definition.Features.Add(ShifterFormCasterActionAffinityBuilder.ShifterFormCasterActionAffinity);

            Definition.SetDurationType(RuleDefinitions.DurationType.Minute);
            Definition.SetDurationParameter(1);

            Definition.SetCharacterShaderReference(DatabaseHelper.MonsterDefinitions.Fire_Jester.MonsterPresentation.CustomShaderReference);
            Definition.SetTimeToWaitBeforeRemovingShader(1);
        }

        public static ConditionDefinition CreateAndAddToDB(string name, string guid)
            => new WolfFormConditionBuilder(name, guid).AddToDB();

        public static ConditionDefinition WolfFormCondition
            = CreateAndAddToDB(WolfFormConditionName, WolfFormConditionGuid);
    }

    internal class BearFormConditionBuilder : BaseDefinitionBuilder<ConditionDefinition>
    {
        const string BearFormConditionName = "BearFormCondition";
        const string BearFormConditionGuid = "95d8d08e-d761-40c7-944c-5963b5659aa3";

        protected BearFormConditionBuilder(string name, string guid) : base(DatabaseHelper.ConditionDefinitions.ConditionBearsEndurance, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&BearFormConditionTitle";
            Definition.GuiPresentation.Description = "Feature/&BearFormConditionDescription";

            Definition.SetAllowMultipleInstances(false);
            Definition.Features.Clear();
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionAttributeModifiers.AttributeModifierArmorPlus2);
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionAdditionalActions.AdditionalActionHasted);
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionAttackModifiers.AttackModifierWeaponPlus2);
            Definition.Features.Add(ShifterFormCasterActionAffinityBuilder.ShifterFormCasterActionAffinity);

            Definition.SetDurationType(RuleDefinitions.DurationType.Minute);
            Definition.SetDurationParameter(1);

            Definition.SetCharacterShaderReference(DatabaseHelper.MonsterDefinitions.SpectralDragon_Magister.MonsterPresentation.CustomShaderReference);
            Definition.SetTimeToWaitBeforeRemovingShader(1);
        }

        public static ConditionDefinition CreateAndAddToDB(string name, string guid)
            => new BearFormConditionBuilder(name, guid).AddToDB();

        public static ConditionDefinition BearFormCondition
            = CreateAndAddToDB(BearFormConditionName, BearFormConditionGuid);
    }

    internal class StagFormConditionBuilder : BaseDefinitionBuilder<ConditionDefinition>
    {
        const string StagFormConditionName = "StagFormCondition";
        const string StagFormConditionGuid = "f6740258-8dd6-420b-a946-33d45589b537";

        protected StagFormConditionBuilder(string name, string guid) : base(DatabaseHelper.ConditionDefinitions.ConditionBearsEndurance, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&StagFormConditionTitle";
            Definition.GuiPresentation.Description = "Feature/&StagFormConditionDescription";

            Definition.SetAllowMultipleInstances(false);
            Definition.Features.Clear();
            Definition.Features.Add(DatabaseHelper.FeatureDefinitionAttributeModifiers.AttributeModifierArmorPlus1);
            //     Definition.Features.Add(DatabaseHelper.);
            //     Definition.Features.Add(DatabaseHelper.);
            Definition.Features.Add(ShifterFormCasterActionAffinityBuilder.ShifterFormCasterActionAffinity);

            Definition.SetDurationType(RuleDefinitions.DurationType.Minute);
            Definition.SetDurationParameter(1);



            EffectForm healingEffect = new EffectForm();
            healingEffect.FormType = EffectForm.EffectFormType.TemporaryHitPoints;

            var tempHPForm = new TemporaryHitPointsForm();
            tempHPForm.DiceNumber = 1;
            tempHPForm.DieType = RuleDefinitions.DieType.D8;
            tempHPForm.BonusHitPoints = 0;

            healingEffect.SetTemporaryHitPointsForm(tempHPForm);
            //healingEffect.SetLevelAdvancement("Multiply","ClassLevel", 1);
            healingEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
            //healingEffect.SetLevelAdvancement(EffectForm.LevelApplianceType Multiply,RuleDefinitions.LevelSourceType ClassLevel, int 1);
            healingEffect.SetLevelType(RuleDefinitions.LevelSourceType.CharacterLevel);
            healingEffect.SetLevelMultiplier(1);



            Definition.RecurrentEffectForms.Add(healingEffect);
            //  Definition.SetCharacterShaderReference(DatabaseHelper.MonsterDefinitions.WizardTower_Servant_NPC_Variant.MonsterPresentation.CustomShaderReference);
            // Definition.SetConditionParticleReference(DatabaseHelper.ConditionDefinitions.ConditionAided.ConditionParticle[0]);
            Definition.SetTimeToWaitBeforeRemovingShader(1);
        }

        public static ConditionDefinition CreateAndAddToDB(string name, string guid)
            => new StagFormConditionBuilder(name, guid).AddToDB();

        public static ConditionDefinition StagFormCondition
            = CreateAndAddToDB(StagFormConditionName, StagFormConditionGuid);
    }

    internal class ShifterFormCasterActionAffinityBuilder : BaseDefinitionBuilder<FeatureDefinitionActionAffinity>
    {
        const string Name = "ShifterFormCasterActionAffinity";
        const string Guid = "fbb93589-8cd8-4507-a1b4-d89aff81794e";

        protected ShifterFormCasterActionAffinityBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionActionAffinitys.ActionAffinityConditionSlowed, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&ShifterFormCasterActionAffinityBuilderTitle";
            Definition.GuiPresentation.Description = "Feature/&ShifterFormCasterActionAffinityBuilderDescription";





            Definition.ForbiddenActions.Add(ActionDefinitions.Id.PowerNoCost);
            Definition.ForbiddenActions.Add(ActionDefinitions.Id.SpendPower);
            Definition.ForbiddenActions.Add(ActionDefinitions.Id.PowerMain);
            Definition.ForbiddenActions.Add(ActionDefinitions.Id.PowerNoCost);
            Definition.ForbiddenActions.Add(ActionDefinitions.Id.PowerBonus);


        }

        public static FeatureDefinitionActionAffinity CreateAndAddToDB(string name, string guid)
            => new ShifterFormCasterActionAffinityBuilder(name, guid).AddToDB();

        public static FeatureDefinitionActionAffinity ShifterFormCasterActionAffinity = CreateAndAddToDB(Name, Guid);
    }



    internal class WandererSpirit_Active_ConditionBuilder : BaseDefinitionBuilder<ConditionDefinition>
    {
        const string WandererSpirit_Active_ConditionName = "WandererSpirit_Active_Condition";
        const string WandererSpirit_Active_ConditionGuid = "a49ab5cc-ff6b-47b1-bbbc-4b9e62093af7";

        protected WandererSpirit_Active_ConditionBuilder(string name, string guid) : base(DatabaseHelper.ConditionDefinitions.ConditionBearsEndurance, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&WandererSpirit_Active_ConditionTitle";
            Definition.GuiPresentation.Description = "Feature/&WandererSpirit_Active_ConditionDescription";

            Definition.SetAllowMultipleInstances(false);
            Definition.Features.Clear();

            Definition.Features.Add(ShifterFormCasterActionAffinityBuilder.ShifterFormCasterActionAffinity);

            Definition.SetDurationType(RuleDefinitions.DurationType.Minute);
            Definition.SetDurationParameter(1);

        }

        public static ConditionDefinition CreateAndAddToDB(string name, string guid)
            => new WandererSpirit_Active_ConditionBuilder(name, guid).AddToDB();

        public static ConditionDefinition WandererSpirit_Active_Condition
            = CreateAndAddToDB(WandererSpirit_Active_ConditionName, WandererSpirit_Active_ConditionGuid);
    }


}// namespace SolastaDruidClass
