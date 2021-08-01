using System;
using System.Collections.Generic;
using SolastaModApi;
using SolastaModApi.Extensions;
using Common = SolastaModHelpers.Common;
using Helpers = SolastaModHelpers.Helpers;
using NewFeatureDefinitions = SolastaModHelpers.NewFeatureDefinitions;



namespace SolastaDruidClass
{
	// CR 0.125:  poisonous_snake, flying snake, eagle matriarch, 
	// CR 0.25 : wolf, 						//starving wolf
	// CR 0.50 : AlphaWolf, BadlandsSpider, black bear
	// CR 1.00 : Dire wolf, giant eagle, brown bear
	// CR 2.00 : tiger_drake, deepspider,  giant beetle
	public class SummoningWildshapeViaPolymorph
	{

		static public FeatureDefinitionPower WildShape_Power;
		static public FeatureDefinitionPower BeastSpellsWildshape_Power;
		static public List<MonsterDefinition> listofbeasts;


		static public Dictionary<string, FeatureDefinitionPower> Dictionaryof_Wildshape_Powers = new Dictionary<string, FeatureDefinitionPower>();
		static public Dictionary<string, FeatureDefinitionPower> Dictionaryof_BeastSpellsWildshape_Powers = new Dictionary<string, FeatureDefinitionPower>();


		internal static void Create()
		{
			Create_WildshapeViaPolymorph_Power();
			Create_BeastSpellsWildshapeViaPolymorph_Power();



		}


		static void Create_WildshapeViaPolymorph_Power()
		{

			listofbeasts = new List<MonsterDefinition>
										{
										DatabaseHelper.MonsterDefinitions.Wolf ,
										DatabaseHelper.MonsterDefinitions.AlphaWolf,
										DatabaseHelper.MonsterDefinitions.BadlandsSpider,
										DatabaseHelper.MonsterDefinitions.Direwolf,
										DatabaseHelper.MonsterDefinitions.Giant_Eagle,
                                      //DatabaseHelper.MonsterDefinitions.BlackBear,
                                      //DatabaseHelper.MonsterDefinitions.BrownBear
                                        
                                        };


			foreach (MonsterDefinition beast in listofbeasts)
			{
				var WildshapeUnit = Common.createPolymoprhUnit                                           // createPolymoprhUnit
					(                                                                                        // (
					beast,                                                                                   // MonsterDefinition base_unit,
					beast.Name + "_Wildshape_Form",                                                          // string name,
					GuidHelper.Create(Main.ModGuidNamespace, beast.Name + "_Wildshape_Form").ToString(),     // string guid,
					"Feature/&DH_" + beast.Name + "_Wildshape_Form_Title",                                   // string title,
					"Feature/&DH_" + beast.Name + "_Wildshape_Form_Description"                              // string description
					);




				var feature = Helpers.FeatureBuilder<NewFeatureDefinitions.Polymorph>.createFeature
					(
					beast.Name + "_Wildshape_Feature",
					GuidHelper.Create(Main.ModGuidNamespace, beast.Name + "_Wildshape_Feature").ToString(),
					"Feature/&DH_" + beast.Name + "_Wildshape_Feature_Title",
					"Feature/&DH_" + beast.Name + "_Wildshape_Feature_Description",
					null,
					a =>
					{
						a.monster = WildshapeUnit;
						a.transferFeatures = true;
						a.statsToTransfer = new string[] { Helpers.Stats.Charisma, Helpers.Stats.Intelligence, Helpers.Stats.Wisdom };
						a.allowSpellcasting = false;
					}
					);

				var condition = Helpers.ConditionBuilder.createCondition
					(
					beast.Name + "_Wildshape_Condition",
					GuidHelper.Create(Main.ModGuidNamespace, beast.Name + "_Wildshape_Condition").ToString(),
					"Feature/&DH_" + beast.Name + "_Wildshape_Condition_Title",
					"Feature/&DH_" + beast.Name + "_Wildshape_Condition_Description",
					null,
					DatabaseHelper.ConditionDefinitions.ConditionBarkskin,
					feature
					);

				condition.ConditionTags.Clear();
				condition.SetTurnOccurence(RuleDefinitions.TurnOccurenceType.EndOfTurn);
				var effect = new EffectDescription();
				effect.Copy(DatabaseHelper.SpellDefinitions.Barkskin.EffectDescription);
				effect.EffectForms.Clear();
				effect.RangeType = RuleDefinitions.RangeType.Self;
				effect.TargetSide = RuleDefinitions.Side.Ally;
				effect.TargetType = RuleDefinitions.TargetType.Self;
				effect.DurationType = RuleDefinitions.DurationType.Hour;
				effect.DurationParameter = 1;

				var effect_form = new EffectForm();
				effect_form.ConditionForm = new ConditionForm();
				effect_form.FormType = EffectForm.EffectFormType.Condition;
				effect_form.ConditionForm.Operation = ConditionForm.ConditionOperation.Add;
				effect_form.ConditionForm.ConditionDefinition = condition;
				effect.EffectForms.Add(effect_form);

				if (beast.Name == "Giant_Eagle") 
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

					effect.EffectForms.Add(casterFlightEffect);
				}

				WildShape_Power = Helpers.GenericPowerBuilder<NewFeatureDefinitions.PowerWithRestrictions>
					.createPower(                                                                           //	  public static FeatureDefinitionPower createPower(    
					beast.Name + "_Wildshape_Power",                                                        //    string name,
					GuidHelper.Create(Main.ModGuidNamespace, beast.Name + "_Wildshape_Power").ToString(),   //    string guid,
					"Feature/&DH_" + beast.Name + "_Wildshape_Power_Title",                                 //	  string title,
					"Feature/&DH_" + beast.Name + "_Wildshape_Power_Description",                           //	  string description
					beast.GuiPresentation.SpriteReference,                                                  //    AssetReferenceSprite sprite,
					effect,                                                                                 //    EffectDescription effect_description,
					RuleDefinitions.ActivationTime.Action,                                                  //    RuleDefinitions.ActivationTime activation_time,
					2,                                                                                      //    int fixed_uses,
					RuleDefinitions.UsesDetermination.Fixed,                                                //    RuleDefinitions.UsesDetermination uses_determination
					RuleDefinitions.RechargeRate.ChannelDivinity,                                           //    RuleDefinitions.RechargeRate recharge_rate,
					"Wisdom",                                                                               //    string uses_ability = "Strength",
					"Wisdom",                                                                               //    string ability = "Strength",
					1,                                                                                      //    int cost_per_use = 1,
					true                                                                                    //    bool show_casting = true
					);                                                                                      //    )



				Dictionaryof_Wildshape_Powers.Add(beast.Name, WildShape_Power);

				if (beast.Name == "AlphaWolf")
				{
					WildshapeUnit.Features.Clear();     // remove die roll modifier
					WildshapeUnit.Features.AddRange(DatabaseHelper.MonsterDefinitions.Wolf.Features);

					WildShape_Power.SetOverriddenPower(Dictionaryof_Wildshape_Powers["Wolf"]);
				}
				if (beast.Name == "Direwolf")
				{

					WildShape_Power.SetOverriddenPower(Dictionaryof_Wildshape_Powers["AlphaWolf"]);

				}
				if (beast.Name == "BrownBear")
				{
					WildShape_Power.SetOverriddenPower(Dictionaryof_Wildshape_Powers["BlackBear"]);
				}

			};// foreach

		}// static void


		static void Create_BeastSpellsWildshapeViaPolymorph_Power()
		{

			listofbeasts = new List<MonsterDefinition>
										{
										DatabaseHelper.MonsterDefinitions.BadlandsSpider,
										DatabaseHelper.MonsterDefinitions.Direwolf,
										DatabaseHelper.MonsterDefinitions.Giant_Eagle, 
                                      //DatabaseHelper.MonsterDefinitions.BrownBear
                                        
                                        };


			foreach (MonsterDefinition beast in listofbeasts)
			{
				var BeastSpellsWildshapeUnit = Common.createPolymoprhUnit                                            // createPolymoprhUnit
					(																									// (
					beast,																								// MonsterDefinition base_unit,
					beast.Name + "_BeastSpellsWildshape_Form",                                                           // string name,
					GuidHelper.Create(Main.ModGuidNamespace, beast.Name + "_BeastSpellsWildshape_Form").ToString(),     // string guid,
					"Feature/&DH_" + beast.Name + "_BeastSpellsWildshape_Form_Title",                                    // string title,
					"Feature/&DH_" + beast.Name + "_BeastSpellsWildshape_Form_Description"                               // string description
					);




				var feature = Helpers.FeatureBuilder<NewFeatureDefinitions.Polymorph>.createFeature
					(
					beast.Name + "_BeastSpellsWildshape_Feature",
					GuidHelper.Create(Main.ModGuidNamespace, beast.Name + "_BeastSpellsWildshape_Feature").ToString(),
					"Feature/&DH_" + beast.Name + "_BeastSpellsWildshape_Feature_Title",
					"Feature/&DH_" + beast.Name + "_BeastSpellsWildshape_Feature_Description",
					null,
					a =>
					{
						a.monster = BeastSpellsWildshapeUnit;
						a.transferFeatures = true;
						a.statsToTransfer = new string[] { Helpers.Stats.Charisma, Helpers.Stats.Intelligence, Helpers.Stats.Wisdom };
						a.allowSpellcasting = true;
					}
					);

				var condition = Helpers.ConditionBuilder.createCondition
					(
					beast.Name + "_BeastSpellsWildshape_Condition",
					GuidHelper.Create(Main.ModGuidNamespace, beast.Name + "_BeastSpellsWildshape_Condition").ToString(),
					"Feature/&DH_" + beast.Name + "_BeastSpellsWildshape_Condition_Title",
					"Feature/&DH_" + beast.Name + "_BeastSpellsWildshape_Condition_Description",
					null,
					DatabaseHelper.ConditionDefinitions.ConditionBarkskin,
					feature
					);

				
				condition.ConditionTags.Clear();
				condition.SetTurnOccurence(RuleDefinitions.TurnOccurenceType.EndOfTurn);
				var effect = new EffectDescription();
				effect.Copy(DatabaseHelper.SpellDefinitions.Barkskin.EffectDescription);
				effect.EffectForms.Clear();
				effect.RangeType = RuleDefinitions.RangeType.Self;
				effect.TargetSide = RuleDefinitions.Side.Ally;
				effect.TargetType = RuleDefinitions.TargetType.Self;
				effect.DurationType = RuleDefinitions.DurationType.Hour;
				effect.DurationParameter = 1;

				var effect_form = new EffectForm();
				effect_form.ConditionForm = new ConditionForm();
				effect_form.FormType = EffectForm.EffectFormType.Condition;
				effect_form.ConditionForm.Operation = ConditionForm.ConditionOperation.Add;
				effect_form.ConditionForm.ConditionDefinition = condition;
				effect.EffectForms.Add(effect_form);

				if(beast.Name == "Giant_Eagle")
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

					effect.EffectForms.Add(casterFlightEffect);
				}

				BeastSpellsWildshape_Power = Helpers.GenericPowerBuilder<NewFeatureDefinitions.PowerWithRestrictions>
					.createPower(                                                                           //	  public static FeatureDefinitionPower createPower(    
					beast.Name + "_BeastSpellsWildshape_Power",                                                     //    string name,
					GuidHelper.Create(Main.ModGuidNamespace, beast.Name + "_BeastSpellsWildshape_Power").ToString(),   //    string guid,
					"Feature/&DH_" + beast.Name + "_BeastSpellsWildshape_Power_Title",                                 //	  string title,
					"Feature/&DH_" + beast.Name + "_BeastSpellsWildshape_Power_Description",                           //	  string description
					beast.GuiPresentation.SpriteReference,                                                  //    AssetReferenceSprite sprite,
					effect,                                                                                 //    EffectDescription effect_description,
					RuleDefinitions.ActivationTime.Action,                                                  //    RuleDefinitions.ActivationTime activation_time,
					2,                                                                                      //    int fixed_uses,
					RuleDefinitions.UsesDetermination.Fixed,                                                //    RuleDefinitions.UsesDetermination uses_determination
					RuleDefinitions.RechargeRate.ChannelDivinity,                                           //    RuleDefinitions.RechargeRate recharge_rate,
					"Wisdom",                                                                               //    string uses_ability = "Strength",
					"Wisdom",                                                                               //    string ability = "Strength",
					1,                                                                                      //    int cost_per_use = 1,
					true                                                                                    //    bool show_casting = true
					);                                                                                      //    )



				Dictionaryof_BeastSpellsWildshape_Powers.Add(beast.Name, BeastSpellsWildshape_Power);

				
				if (beast.Name == "BadlandsSpider")
				{
					BeastSpellsWildshape_Power.SetOverriddenPower(Dictionaryof_Wildshape_Powers["BadlandsSpider"]);
				}
				if (beast.Name == "Giant_Eagle")
				{
					BeastSpellsWildshape_Power.SetOverriddenPower(Dictionaryof_Wildshape_Powers["Giant_Eagle"]);
				}
				if (beast.Name == "Direwolf")
				{
					BeastSpellsWildshape_Power.SetOverriddenPower(Dictionaryof_Wildshape_Powers["Direwolf"]);
				}
				if (beast.Name == "BrownBear")
				{
					BeastSpellsWildshape_Power.SetOverriddenPower(Dictionaryof_Wildshape_Powers["BrownBear"]);
				}

			}; // foreach

		}// static void

	}//public class SummoningWildshapeViaPolymorph



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

			//    Definition.FeatureSet.Add(EndWildShapePowerBuilder.EndWildShapePower);
			//    Definition.FeatureSet.Add(EndWildShapePowerDeadBeastBuilder.EndWildShapePowerDeadBeast);
			//    Definition.FeatureSet.Add(WildShapePowerBuilder.WildShapePower);
			Definition.FeatureSet.Add(WildshapeChargesPoolBuilder.WildshapeChargesPool);
			Definition.FeatureSet.Add(SummoningWildshapeViaPolymorph.Dictionaryof_Wildshape_Powers["Wolf"]);
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
			//     Definition.FeatureSet.Add(WildShapePower_BadlandsspiderBuilder.WildShapePower_Badlandsspider);
			//    Definition.FeatureSet.Add(WildShapePower_AlphaWolfBuilder.WildShapePower_AlphaWolf);

			Definition.FeatureSet.Add(SummoningWildshapeViaPolymorph.Dictionaryof_Wildshape_Powers["AlphaWolf"]);
			Definition.FeatureSet.Add(SummoningWildshapeViaPolymorph.Dictionaryof_Wildshape_Powers["BadlandsSpider"]);
			//   Definition.FeatureSet.Add(SummoningWildshapeViaPolymorph.Dictionaryof_Wildshape_Powers["BlackBear"]);


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
			//Definition.FeatureSet.Add(WildShapePower_DirewolfBuilder.WildShapePower_Direwolf);
			//Definition.FeatureSet.Add(WildShapePower_Giant_EagleBuilder.WildShapePower_Giant_Eagle);
			//    Definition.FeatureSet.Add(WildShapePower_BrownBearBuilder.WildShapePower_BrownBear);

			Definition.FeatureSet.Add(SummoningWildshapeViaPolymorph.Dictionaryof_Wildshape_Powers["Direwolf"]);
			Definition.FeatureSet.Add(SummoningWildshapeViaPolymorph.Dictionaryof_Wildshape_Powers["Giant_Eagle"]);
			// Definition.FeatureSet.Add(SummoningWildshapeViaPolymorph.Dictionaryof_Wildshape_Powers["BrownBear"]);


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
			//    Definition.FeatureSet.Add(WildShapePower_Direwolf_BeastSpellsBuilder.WildShapePower_Direwolf_BeastSpells);
			//    Definition.FeatureSet.Add(WildShapePower_Giant_Eagle_BeastSpellsBuilder.WildShapePower_Giant_Eagle_BeastSpells);

			Definition.FeatureSet.Add(SummoningWildshapeViaPolymorph.Dictionaryof_BeastSpellsWildshape_Powers["BadlandsSpider"]);
			Definition.FeatureSet.Add(SummoningWildshapeViaPolymorph.Dictionaryof_BeastSpellsWildshape_Powers["Direwolf"]);
			Definition.FeatureSet.Add(SummoningWildshapeViaPolymorph.Dictionaryof_BeastSpellsWildshape_Powers["Giant_Eagle"]);
			// Definition.FeatureSet.Add(SummoningWildshapeViaPolymorph.Dictionaryof_BeastSpellsWildshape_Powers["BrownBear"]);




		}

		public static FeatureDefinitionFeatureSet CreateAndAddToDB(string name, string guid)
			=> new BeastSpellsFeatureSetBuilder(name, guid).AddToDB();

		public static FeatureDefinitionFeatureSet BeastSpellsFeatureSet = CreateAndAddToDB(BeastSpellsFeatureSetName, BeastSpellsFeatureSetGuid);
	}
}// namespace SolastaDruidClass
