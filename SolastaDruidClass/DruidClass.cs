using SolastaModApi;
using SolastaModApi.Extensions;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using HarmonyLib;
using UnityEngine;
using System;

using Helpers = SolastaModHelpers.Helpers;
using NewFeatureDefinitions = SolastaModHelpers.NewFeatureDefinitions;
using ExtendedEnums = SolastaModHelpers.ExtendedEnums;
using SolastaModHelpers;
using System.Linq;

namespace SolastaDruidClass
{
    internal class DruidClassBuilder : CharacterClassDefinitionBuilder
    {
        const string DruidClassName = "DruidClass";
        const string DruidClassGuid = "a2112af0-636f-4b72-acdc-07c921bcea6d";
        const string DruidClassSubclassesGuid = "46ae0591-296d-4f6c-80b0-4e198c999076";

        static public CharacterClassDefinition druid_class;
        static public SpellListDefinition druid_spelllist;
        static public Dictionary<int, FeatureDefinitionFeatureSet> wildshapes = new Dictionary<int, FeatureDefinitionFeatureSet>();
        static public FeatureDefinitionCastSpell druid_spellcasting;
        //circle of the land
        static public FeatureDefinition circle_of_the_land_extra_cantrip;
        static public FeatureDefinitionPower circle_of_land_natural_recovery;
        static public FeatureDefinitionFeatureSet circle_of_land_lands_stride;
        static public FeatureDefinitionFeatureSet circle_of_land_natures_ward;
        static public FeatureDefinitionFeatureSet circle_of_land_circle_spells;
        static public FeatureDefinitionPower base_wildshape_power;
        //circle of the elements
        static public Dictionary<int, FeatureDefinitionFeatureSet> elemental_forms = new Dictionary<int, FeatureDefinitionFeatureSet>();
        static public FeatureDefinitionAutoPreparedSpells elemental_healing;
        static public FeatureDefinition elemental_form_mark;
        static public NewFeatureDefinitions.AddAttackTagIfHasFeature primal_attacks;
        static public NewFeatureDefinitions.MonsterAdditionalDamage elemental_strike;
        //circle of spirits
        static public ConditionDefinition inside_spirit_area_condition;
        static public EffectProxyDefinition spirit_proxy;
        static public FeatureDefinitionFeatureSet spirits;
        static public FeatureDefinitionFeatureSet spirit_summoner;
        static public NewFeatureDefinitions.AddExtraConditionToTargetOnConditionApplication guardian_spirits;

        //protection spirit
        //healing spirit
        //


        protected DruidClassBuilder(string name, string guid) : base(name, guid)
        {
            druid_class = Definition;
            var druid_class_image = SolastaModHelpers.CustomIcons.Tools.storeCustomIcon("DruidClassImage",
                                                                               $@"{UnityModManagerNet.UnityModManager.modsPath}/SolastaDruidClass/Sprites/DruidClass.png",
                                                                               1024, 576);

            Definition.GuiPresentation.Title = "Class/&DruidClassTitle";
            Definition.GuiPresentation.Description = "Class/&DruidClassDescription";
            Definition.GuiPresentation.SetSpriteReference(druid_class_image);

            Definition.SetClassAnimationId(AnimationDefinitions.ClassAnimationId.Cleric);
            Definition.SetClassPictogramReference(DatabaseHelper.CharacterClassDefinitions.Cleric.ClassPictogramReference);
            Definition.SetDefaultBattleDecisions(DatabaseHelper.CharacterClassDefinitions.Cleric.DefaultBattleDecisions);
            Definition.SetHitDice(RuleDefinitions.DieType.D8);
            Definition.SetIngredientGatheringOdds(DatabaseHelper.CharacterClassDefinitions.Ranger.IngredientGatheringOdds);
            Definition.SetRequiresDeity(false);
            Definition.SetDefaultBattleDecisions(DatabaseHelper.DecisionPackageDefinitions.DefaultSupportCasterWithBackupAttacksDecisions);
              
            Definition.AbilityScoresPriority.Clear();
            Definition.AbilityScoresPriority.AddRange(new List<string> 
            {
                DatabaseHelper.SmartAttributeDefinitions.Wisdom.Name,
                DatabaseHelper.SmartAttributeDefinitions.Constitution.Name,
                DatabaseHelper.SmartAttributeDefinitions.Dexterity.Name,
                DatabaseHelper.SmartAttributeDefinitions.Intelligence.Name,
                DatabaseHelper.SmartAttributeDefinitions.Strength.Name,
                DatabaseHelper.SmartAttributeDefinitions.Charisma.Name
            });
            // Skills: Choose 2 from Arcana, Animal Handling, Insight, Medicine, Nature, Perception, Religion, and Survival.
            Definition.SkillAutolearnPreference.AddRange(new List<string>
            {
                DatabaseHelper.SkillDefinitions.Perception.Name,
                DatabaseHelper.SkillDefinitions.Arcana.Name,
                DatabaseHelper.SkillDefinitions.Religion.Name,
                DatabaseHelper.SkillDefinitions.Nature.Name,
                DatabaseHelper.SkillDefinitions.Insight.Name,
                DatabaseHelper.SkillDefinitions.Survival.Name,
                DatabaseHelper.SkillDefinitions.Medecine.Name,
                DatabaseHelper.SkillDefinitions.AnimalHandling.Name
            });

            Definition.FeatAutolearnPreference.AddRange(new List<string>
            {
                DatabaseHelper.FeatDefinitions.FlawlessConcentration.Name,
                DatabaseHelper.FeatDefinitions.Creed_Of_Arun.Name,
                DatabaseHelper.FeatDefinitions.FocusedSleeper.Name
            });

            Definition.PersonalityFlagOccurences.AddRange(DatabaseHelper.CharacterClassDefinitions.Cleric.PersonalityFlagOccurences);

            
            Definition.ToolAutolearnPreference.AddRange(new List<string>
            {
                DatabaseHelper.ToolTypeDefinitions.HerbalismKitType.Name,
             });

            // Starting Equipment
            // You start with the following items, plus anything provided by your background.
            // (a) a wooden shield or (b) any simple weapon
            // (a) a scimitar or (b) any simple melee weapon
            // Leather armor, an explorer's pack, and a druidic focus
            // Alternatively, you may start with 2d4 × 10 gp to buy your own equipment.

            Definition.EquipmentRows.AddRange(DatabaseHelper.CharacterClassDefinitions.Cleric.EquipmentRows);
            Definition.EquipmentRows.Clear();
            this.AddEquipmentRow(new List<CharacterClassDefinition.HeroEquipmentOption>
                                    {
                                        EquipmentOptionsBuilder.Option(DatabaseHelper.ItemDefinitions.Shield, EquipmentDefinitions.ShieldCategory, 1)
                                    },
                                new List<CharacterClassDefinition.HeroEquipmentOption>
                                    {
                                        EquipmentOptionsBuilder.Option(DatabaseHelper.ItemDefinitions.Dagger, EquipmentDefinitions.OptionWeaponSimpleChoice, 1)
                                    }
                                );
            this.AddEquipmentRow(new List<CharacterClassDefinition.HeroEquipmentOption>
                                    {
                                        EquipmentOptionsBuilder.Option(DatabaseHelper.ItemDefinitions.Scimitar, EquipmentDefinitions.MartialWeaponCategory, 1)
                                    },
                                new List<CharacterClassDefinition.HeroEquipmentOption>
                                    {
                                        EquipmentOptionsBuilder.Option(DatabaseHelper.ItemDefinitions.Dagger, EquipmentDefinitions.OptionWeaponSimpleChoice, 1)
                                    }
                                );

            this.AddEquipmentRow(new List<CharacterClassDefinition.HeroEquipmentOption>
            {
                EquipmentOptionsBuilder.Option(DatabaseHelper.ItemDefinitions.Leather, EquipmentDefinitions.OptionArmor, 1),
                EquipmentOptionsBuilder.Option(DatabaseHelper.ItemDefinitions.ExplorerPack, EquipmentDefinitions.OptionStarterPack, 1),
                EquipmentOptionsBuilder.Option(DatabaseHelper.ItemDefinitions.ComponentPouch_Belt, EquipmentDefinitions.OptionFocus, 1)
          
            });

            Definition.FeatureUnlocks.Clear();

            var saving_throws = Helpers.ProficiencyBuilder.CreateSavingthrowProficiency("DruidSavingthrowProficiency",
                                                                                        "",
                                                                                        Helpers.Stats.Intelligence, Helpers.Stats.Wisdom);


            var weapon_proficiency = Helpers.ProficiencyBuilder.CreateWeaponProficiency("DruidProficiencies",
                                                                                          "5b0c5413-79ae-4898-b993-85cf3619a938",
                                                                                          "Feature/&DruidProficienciesTitle",
                                                                                          "Feature/&DruidProficienciesDescription",
                                                                                          Helpers.WeaponProficiencies.Club,
                                                                                          Helpers.WeaponProficiencies.Dagger,
                                                                                          Helpers.WeaponProficiencies.Dart,
                                                                                          Helpers.WeaponProficiencies.Javelin,
                                                                                          Helpers.WeaponProficiencies.Mace,
                                                                                          Helpers.WeaponProficiencies.QuarterStaff,
                                                                                          Helpers.WeaponProficiencies.Scimitar,
                                                                                          Helpers.WeaponProficiencies.Spear
                                                                                          );

            var armor_proficiency = Helpers.ProficiencyBuilder.createCopy("DruidArmorProficiencies",
                                                                          "eb0d5b55-b878-4828-aaca-e4aa95a2a9db",
                                                                          "Feature/&DruidArmorProficienciesTitle",
                                                                          "Feature/&DruidArmorProficienciesDescription",
                                                                          DatabaseHelper.FeatureDefinitionProficiencys.ProficiencyClericArmor
                                                                          );
            armor_proficiency.proficiencies = new List<string> { Helpers.ArmorProficiencies.LigthArmor, Helpers.ArmorProficiencies.HideArmor };

            var skills = Helpers.PoolBuilder.createSkillProficiency("DruidClassSkillPointPool",
                                                                    "8f2cb82d-6bf9-4a72-a3e1-286a1e2b5662",
                                                                    "Feature/&DruidClassSkillPointPoolTitle",
                                                                    "Feature/&DruidClassSkillPointPoolDescription",
                                                                    2,
                                                                    Helpers.Skills.Arcana,
                                                                    Helpers.Skills.AnimalHandling,
                                                                    Helpers.Skills.Insight,
                                                                    Helpers.Skills.Medicine,
                                                                    Helpers.Skills.Nature,
                                                                    Helpers.Skills.Perception,
                                                                    Helpers.Skills.Religion,
                                                                    Helpers.Skills.Survival
                                                                    );


            var tools_proficiency = Helpers.ProficiencyBuilder.CreateToolsProficiency("DruidToolsProficiency",
                                                                                      "",
                                                                                      "Feature/&DruidToolsProficiencyTitle",
                                                                                      Helpers.Tools.HerbalismKit
                                                                                      );

            druid_spelllist = Helpers.SpelllistBuilder.create9LevelSpelllist("DruidSpelllist", "19ef0624-ede3-4612-b636-6479dd8f4e2e", "",
                                                                    new List<SpellDefinition>
                                                                    {
                                                                                    DatabaseHelper.SpellDefinitions.AnnoyingBee,
                                                                                    DatabaseHelper.SpellDefinitions.Guidance,
                                                                                    DatabaseHelper.SpellDefinitions.PoisonSpray,
                                                                                    DatabaseHelper.SpellDefinitions.Resistance,
                                                                                    DatabaseHelper.SpellDefinitions.Shine,
                                                                                    DatabaseHelper.SpellDefinitions.Sparkle
                                                                    },
                                                                    new List<SpellDefinition>
                                                                    {
                                                                                    DatabaseHelper.SpellDefinitions.AnimalFriendship,
                                                                                    DatabaseHelper.SpellDefinitions.CharmPerson,
                                                                                    DatabaseHelper.SpellDefinitions.CureWounds,
                                                                                    DatabaseHelper.SpellDefinitions.DetectMagic,
                                                                                    DatabaseHelper.SpellDefinitions.Entangle,
                                                                                    DatabaseHelper.SpellDefinitions.FaerieFire,
                                                                                    DatabaseHelper.SpellDefinitions.FogCloud,
                                                                                    DatabaseHelper.SpellDefinitions.Goodberry,
                                                                                    DatabaseHelper.SpellDefinitions.HealingWord,
                                                                                    DatabaseHelper.SpellDefinitions.Jump,
                                                                                    DatabaseHelper.SpellDefinitions.Longstrider,
                                                                                    DatabaseHelper.SpellDefinitions.ProtectionFromEvilGood,
                                                                                    DatabaseHelper.SpellDefinitions.Thunderwave
                                                                    },
                                                                    new List<SpellDefinition>
                                                                    {
                                                                                    DatabaseHelper.SpellDefinitions.Barkskin,
                                                                                    DatabaseHelper.SpellDefinitions.Darkvision,
                                                                                    DatabaseHelper.SpellDefinitions.EnhanceAbility,
                                                                                    DatabaseHelper.SpellDefinitions.FindTraps,
                                                                                    DatabaseHelper.SpellDefinitions.FlamingSphere,
                                                                                    DatabaseHelper.SpellDefinitions.HoldPerson,
                                                                                    DatabaseHelper.SpellDefinitions.GustOfWind,
                                                                                    DatabaseHelper.SpellDefinitions.LesserRestoration,
                                                                                    DatabaseHelper.SpellDefinitions.PassWithoutTrace,
                                                                                    DatabaseHelper.SpellDefinitions.ProtectionFromPoison,
                                                                    },
                                                                    new List<SpellDefinition>
                                                                    {
                                                                                    DatabaseHelper.SpellDefinitions.ConjureAnimals,
                                                                                    DatabaseHelper.SpellDefinitions.Daylight,
                                                                                    DatabaseHelper.SpellDefinitions.DispelMagic,
                                                                                    DatabaseHelper.SpellDefinitions.ProtectionFromEnergy,
                                                                                    DatabaseHelper.SpellDefinitions.Revivify,
                                                                                    DatabaseHelper.SpellDefinitions.SleetStorm,
                                                                                    DatabaseHelper.SpellDefinitions.WindWall
                                                                    },
                                                                    new List<SpellDefinition>
                                                                    {
                                                                                    DatabaseHelper.SpellDefinitions.Blight,
                                                                                    DatabaseHelper.SpellDefinitions.Confusion,
                                                                                    DatabaseHelper.SpellDefinitions.ConjureMinorElementals,
                                                                                    DatabaseHelper.SpellDefinitions.DominateBeast,
                                                                                    DatabaseHelper.SpellDefinitions.FireShield,
                                                                                    DatabaseHelper.SpellDefinitions.FreedomOfMovement,
                                                                                    DatabaseHelper.SpellDefinitions.GiantInsect,
                                                                                    DatabaseHelper.SpellDefinitions.IceStorm,
                                                                                    DatabaseHelper.SpellDefinitions.Stoneskin,
                                                                                    DatabaseHelper.SpellDefinitions.WallOfFire,
                                                                    },
                                                                    new List<SpellDefinition>
                                                                    {
                                                                                    DatabaseHelper.SpellDefinitions.ConeOfCold,
                                                                                    DatabaseHelper.SpellDefinitions.ConjureElemental,
                                                                                    DatabaseHelper.SpellDefinitions.Contagion,
                                                                                    DatabaseHelper.SpellDefinitions.GreaterRestoration,
                                                                                    DatabaseHelper.SpellDefinitions.InsectPlague,
                                                                                    DatabaseHelper.SpellDefinitions.MassCureWounds
                                                                    }
                                                                    );
            var new_spells = new SpellDefinition[]{ NewFeatureDefinitions.SpellData.getSpell("ShillelaghSpell"),
                                                    NewFeatureDefinitions.SpellData.getSpell("AirBlastSpell"),
                                                    NewFeatureDefinitions.SpellData.getSpell("ThunderStrikeSpell"),
                                                    NewFeatureDefinitions.SpellData.getSpell("IceStrikeSpell"),
                                                    NewFeatureDefinitions.SpellData.getSpell("HeatMetalSpell"),
                                                    NewFeatureDefinitions.SpellData.getSpell("CallLightningSpell")
                                                  };
            foreach (var s in new_spells)
            {
                if (s != null)
                {
                    Helpers.Misc.addSpellToSpelllist(druid_spelllist, s);
                }
            }


            druid_spellcasting = Helpers.SpellcastingBuilder.createDivinePreparedSpellcasting("DruidCastingAbility",
                                                                                                  "64e9ce25-cbbc-4ff2-9fd2-0e4ad1d32a67",
                                                                                                  "Feature/&DruidCastingAbilityTitle",
                                                                                                  "Feature/&DruidCastingAbilityDescription",
                                                                                                  druid_spelllist,
                                                                                                  Helpers.Stats.Wisdom,
                                                                                                  new List<int> { 2, 2, 2, 3, 3, 3, 3, 3, 3, 4,
                                                                                                                  4, 4, 4, 4, 4, 4, 4, 4, 4, 4},
                                                                                                  DatabaseHelper.FeatureDefinitionCastSpells.CastSpellCleric.SlotsPerLevels
                                                                                                  );
            var ritual_spellcasting = Helpers.RitualSpellcastingBuilder.createRitualSpellcasting("DruidRitualSpellcasting",
                                                                                                 "",
                                                                                                 DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetClericRitualCasting.GuiPresentation.Description,
                                                                                                 (RuleDefinitions.RitualCasting)ExtendedEnums.ExtraRitualCasting.Prepared);
            createWildshape();

            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(armor_proficiency, 1));
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(weapon_proficiency, 1));
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(saving_throws, 1)); 
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(tools_proficiency, 1));
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(skills, 1));
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(druid_spellcasting, 1));
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(ritual_spellcasting, 1));
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(wildshapes[2],2));
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetAbilityScoreChoice, 4));
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(wildshapes[4], 4));
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(wildshapes[6], 6));
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetAbilityScoreChoice, 8));
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(wildshapes[8], 8));
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(wildshapes[10], 10));
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetAbilityScoreChoice, 12));
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(wildshapes[12], 12));
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(wildshapes[14], 14));
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetAbilityScoreChoice, 16));
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(wildshapes[16], 16));
            //beast spells lvl 18
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(wildshapes[18], 18));
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetAbilityScoreChoice, 19));
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(wildshapes[20], 20));

            //Subclass circle at level 2
            var subclassChoicesGuiPresentation = new GuiPresentation();
            subclassChoicesGuiPresentation.Title = "Subclass/&DruidSubclassCircleTitle";
            subclassChoicesGuiPresentation.Description = "Subclass/&DruidSubclassCircleDescription";
            DruidFeatureDefinitionSubclassChoice = this.BuildSubclassChoice(2, "Circle", false, "SubclassChoiceDruidCircleArchetypes", subclassChoicesGuiPresentation, DruidClassSubclassesGuid);

            var item_list = new List<ItemDefinition>
                                {
                                DatabaseHelper.ItemDefinitions.WandOfLightningBolts,
                                //DatabaseHelper.ItemDefinitions.StaffOfMetis,              // devs removed class restrictions for HF 1.1.11 so not needed now
                                DatabaseHelper.ItemDefinitions.StaffOfHealing,
                                DatabaseHelper.ItemDefinitions.StaffOfFire,
                                DatabaseHelper.ItemDefinitions.GreenmageArmor,
                                //DatabaseHelper.ItemDefinitions.ArcaneShieldstaff,         // wizard only item?
                                //DatabaseHelper.ItemDefinitions.WizardClothes_Alternate
                                };

            foreach (ItemDefinition item in item_list)
            {
                item.RequiredAttunementClasses.Add(druid_class);
            };
        }


        public void createWildshape()
        {
            //lvl 2 - wolf cr 0.25
            //lvl 4 - badlands spider  cr 0.5
            //lvl 8 - dire wolf, giant eagle - cr 1
            base_wildshape_power = Helpers.GenericPowerBuilder<NewFeatureDefinitions.HiddenPower>
                                                            .createPower("DruidBaseWildshapePower",
                                                                            "",
                                                                            Common.common_no_title,
                                                                            Common.common_no_title,
                                                                            Common.common_no_icon,
                                                                            DatabaseHelper.FeatureDefinitionPowers.PowerDomainElementalFireBurst.effectDescription,
                                                                            RuleDefinitions.ActivationTime.Action,
                                                                            2,
                                                                            RuleDefinitions.UsesDetermination.Fixed,
                                                                            RuleDefinitions.RechargeRate.ShortRest,
                                                                            "Wisdom",
                                                                            "Wisdom",
                                                                            1,
                                                                            true
                                                                            );

            var wildshape_wolf_attack = Helpers.CopyFeatureBuilder<MonsterAttackDefinition>.createFeatureCopy("WildshapeWolfBiteAttack",
                                                                                                  "",
                                                                                                  "",
                                                                                                  "",
                                                                                                  null,
                                                                                                  DatabaseHelper.MonsterAttackDefinitions.Attack_Wolf_Bite,
                                                                                                  a =>
                                                                                                  {
                                                                                                      a.SetToHitBonus(4);
                                                                                                      var effect = new EffectDescription();
                                                                                                      effect.Copy(a.EffectDescription);
                                                                                                      effect.EffectForms.Clear();
                                                                                                      effect.HasSavingThrow = true;
                                                                                                      effect.SavingThrowAbility = Helpers.Stats.Strength;
                                                                                                      effect.FixedSavingThrowDifficultyClass = 11;
                                                                                                      effect.difficultyClassComputation = RuleDefinitions.EffectDifficultyClassComputation.FixedValue;

                                                                                                      var dmg = new EffectForm();
                                                                                                      dmg.FormType = EffectForm.EffectFormType.Damage;
                                                                                                      dmg.DamageForm = new DamageForm();
                                                                                                      dmg.DamageForm.BonusDamage = 2;
                                                                                                      dmg.DamageForm.DiceNumber = 2;
                                                                                                      dmg.DamageForm.DieType = RuleDefinitions.DieType.D4;
                                                                                                      dmg.DamageForm.DamageType = Helpers.DamageTypes.Piercing;
                                                                                                      effect.EffectForms.Add(dmg);

                                                                                                      var knock = new EffectForm();
                                                                                                      knock.FormType = EffectForm.EffectFormType.Motion;
                                                                                                      knock.SetMotionForm(new MotionForm());
                                                                                                      knock.MotionForm.SetType(MotionForm.MotionType.FallProne);
                                                                                                      knock.HasSavingThrow = true;
                                                                                                      knock.SavingThrowAffinity = RuleDefinitions.EffectSavingThrowType.Negates;
                                                                                                      effect.EffectForms.Add(knock);
                                                                                                      a.effectDescription = effect;
                                                                                                  }
                                                                                                  );

            var wildshape_spider_attack = Helpers.CopyFeatureBuilder<MonsterAttackDefinition>.createFeatureCopy("WildshapeMediumSpiderBiteAttack",
                                                                                      "",
                                                                                      "",
                                                                                      "",
                                                                                      null,
                                                                                      DatabaseHelper.MonsterAttackDefinitions.Attack_Badlands_Spider_Bite,
                                                                                      a =>
                                                                                      {
                                                                                          a.SetToHitBonus(5);
                                                                                          var effect = new EffectDescription();
                                                                                          effect.Copy(a.EffectDescription);
                                                                                          effect.EffectForms.Clear();
                                                                                          effect.HasSavingThrow = true;
                                                                                          effect.SavingThrowAbility = Helpers.Stats.Constitution;
                                                                                          effect.FixedSavingThrowDifficultyClass = 11;
                                                                                          effect.difficultyClassComputation = RuleDefinitions.EffectDifficultyClassComputation.FixedValue;

                                                                                          var dmg = new EffectForm();
                                                                                          dmg.FormType = EffectForm.EffectFormType.Damage;
                                                                                          dmg.DamageForm = new DamageForm();
                                                                                          dmg.DamageForm.BonusDamage = 1;
                                                                                          dmg.DamageForm.DiceNumber = 1;
                                                                                          dmg.DamageForm.DieType = RuleDefinitions.DieType.D4;
                                                                                          dmg.DamageForm.DamageType = Helpers.DamageTypes.Piercing;
                                                                                          effect.EffectForms.Add(dmg);

                                                                                          var dmg2 = new EffectForm();
                                                                                          dmg2.FormType = EffectForm.EffectFormType.Damage;
                                                                                          dmg2.DamageForm = new DamageForm();
                                                                                          dmg2.DamageForm.BonusDamage = 0;
                                                                                          dmg2.DamageForm.DiceNumber = 1;
                                                                                          dmg2.DamageForm.DieType = RuleDefinitions.DieType.D8;
                                                                                          dmg2.DamageForm.DamageType = Helpers.DamageTypes.Poison;
                                                                                          dmg2.savingThrowAffinity = RuleDefinitions.EffectSavingThrowType.Negates;
                                                                                          dmg2.hasSavingThrow = true;
                                                                                          effect.EffectForms.Add(dmg2);
                                                                                      }
                                                                                      );


            var wildshape_wolf = Common.createPolymoprhUnit(DatabaseHelper.MonsterDefinitions.Wolf,
                                                            "WildshapeWolfUnit",
                                                            "",
                                                            "",
                                                            "");
            
            wildshape_wolf.attackIterations = new List<MonsterAttackIteration>()
            {
                new MonsterAttackIteration(wildshape_wolf_attack, 1)
            };

            var wildshape_spider = Common.createPolymoprhUnit(DatabaseHelper.MonsterDefinitions.BadlandsSpider,
                                                                "WildshapeBadlandsSpiderUnit",
                                                                "",
                                                                "",
                                                                "");
            wildshape_spider.hitDice = 4;
            wildshape_spider.hitPointsBonus = 4;
            wildshape_spider.standardHitPoints = 18;
            wildshape_spider.armorClass = 14;

            wildshape_spider.attackIterations = new List<MonsterAttackIteration>()
            {
                new MonsterAttackIteration(wildshape_spider_attack, 1)
            };

            var wildshape_dire_wolf = Common.createPolymoprhUnit(DatabaseHelper.MonsterDefinitions.Direwolf,
                                                                "WildshapeDireWolfUnit",
                                                                "",
                                                                "",
                                                                "");

            var wildshape_giant_eagle = Common.createPolymoprhUnit(DatabaseHelper.MonsterDefinitions.Giant_Eagle,
                                                                    "WildshapeGiantEagleUnit",
                                                                    "",
                                                                    "",
                                                                    "");
            wildshape_giant_eagle.groupAttacks = true;

            var shapes = new Dictionary<MonsterDefinition, (int, int)>
            {
                {wildshape_wolf, (0, 8)},
                {wildshape_spider, (4, -1)},
                {wildshape_dire_wolf,  (8, -1)},
                {wildshape_giant_eagle,  (8, -1)}
            };

            wildshapes = createWildshapeFeatures("Wildshape", shapes, 2, 1);
            wildshapes[2].featureSet.Add(base_wildshape_power);
        }


        static Dictionary<int, FeatureDefinitionFeatureSet> createWildshapeFeatures(string prefix, Dictionary<MonsterDefinition, (int, int)> shapes, int min_level, int max_level = 20, int cost_per_use = 1)
        {
            var powers = new Dictionary<MonsterDefinition, List<NewFeatureDefinitions.PowerWithRestrictions>>();
            foreach (var s in shapes)
            {
                powers[s.Key] = new List<NewFeatureDefinitions.PowerWithRestrictions>();
                var feature = Helpers.FeatureBuilder<NewFeatureDefinitions.Polymorph>.createFeature
                                                                            (s.Key.name + "Feature",
                                                                            "",
                                                                            "Feature/&" + s.Key.name + "FeatureTitle",
                                                                            "Feature/&" + s.Key.name + "FeatureDescription",
                                                                            null,
                                                                            a =>
                                                                            {
                                                                                a.monster = s.Key;
                                                                                a.transferFeatures = true;
                                                                                a.statsToTransfer = new string[] { Helpers.Stats.Charisma, Helpers.Stats.Intelligence, Helpers.Stats.Wisdom };
                                                                                a.allowSpellcasting = false;
                                                                            }
                                                                            );

                var condition = Helpers.ConditionBuilder.createCondition(s.Key.Name + "Condition",
                                                                        "",
                                                                        "Rules/&CasterWhileWildshapedConditionTitle",
                                                                        "Rules/&CasterWhileWildshapedConditionDescription",
                                                                        null,
                                                                        DatabaseHelper.ConditionDefinitions.ConditionBarkskin,
                                                                        feature
                                                                        );

                condition.ConditionTags.Clear();
                condition.SetTurnOccurence(RuleDefinitions.TurnOccurenceType.EndOfTurn);


                for (int i = min_level; i <= 20; i += 2)
                {
                    int duration = i / 2;
                    var effect = new EffectDescription();
                    effect.Copy(DatabaseHelper.SpellDefinitions.Barkskin.EffectDescription);
                    effect.EffectForms.Clear();
                    effect.RangeType = RuleDefinitions.RangeType.Self;
                    effect.TargetSide = RuleDefinitions.Side.Ally;
                    effect.TargetType = RuleDefinitions.TargetType.Self;
                    effect.DurationType = RuleDefinitions.DurationType.Hour;
                    effect.DurationParameter = duration;

                    var effect_form = new EffectForm();
                    effect_form.ConditionForm = new ConditionForm();
                    effect_form.FormType = EffectForm.EffectFormType.Condition;
                    effect_form.ConditionForm.Operation = ConditionForm.ConditionOperation.Add;
                    effect_form.ConditionForm.ConditionDefinition = condition;
                    effect.EffectForms.Add(effect_form);

                    var power = Helpers.GenericPowerBuilder<NewFeatureDefinitions.PowerWithRestrictions>
                                                                                .createPower(s.Key.Name + $"{duration}Power",
                                                                                                "",
                                                                                                "Feature/&" + s.Key.name + "FeatureTitle",
                                                                                                "Feature/&" + s.Key.name + "FeatureDescription",
                                                                                                s.Key.GuiPresentation.SpriteReference,
                                                                                                effect,
                                                                                                RuleDefinitions.ActivationTime.Action,
                                                                                                2,
                                                                                                RuleDefinitions.UsesDetermination.Fixed,
                                                                                                RuleDefinitions.RechargeRate.ShortRest,
                                                                                                "Wisdom",
                                                                                                "Wisdom",
                                                                                                cost_per_use,
                                                                                                true
                                                                                                );
                    power.restrictions = new List<NewFeatureDefinitions.IRestriction> { new NewFeatureDefinitions.MinClassLevelRestriction(druid_class, s.Value.Item1) };
                    if (s.Value.Item2 > 0)
                    {
                        power.restrictions.Add(new NewFeatureDefinitions.InverseRestriction(new NewFeatureDefinitions.MinClassLevelRestriction(druid_class, s.Value.Item2)));
                    }
                    if (i > 2)
                    {
                        power.overriddenPower = powers[s.Key].Last();
                    }
                    power.linkedPower = base_wildshape_power;
                    powers[s.Key].Add(power);
                }
            };

            var forms = new Dictionary<int, FeatureDefinitionFeatureSet>();
            int k = 0;
            for (int i = min_level; i <= 20; i += 2)
            {
                forms[i] = Helpers.FeatureSetBuilder.createFeatureSet($"{prefix}{i}FeatureSet",
                                                            "",
                                                            $"Feature/&{prefix}FeatureSetTitle",
                                                            $"Feature/&{prefix}FeatureSetDescription",
                                                            false,
                                                            FeatureDefinitionFeatureSet.FeatureSetMode.Union,
                                                            false,
                                                            powers.Aggregate(new List<FeatureDefinitionPower>(), (old, next) => { old.Add(next.Value[k]); return old; }).ToArray()
                                                            );
                if (k != 0)
                {
                    forms[i].GuiPresentation.hidden = true;
                }
                k++;
            }

            return forms;
        }


        static void createCircleOfTheLandBonusCantrip()
        {
            circle_of_the_land_extra_cantrip = /*Helpers.CopyFeatureBuilder<FeatureDefinitionPointPool>.createFeatureCopy("DruidSubclassCircleOfLandExtraCantrip",
                                                                                                                        "71b34c54-00ad-4b55-9174-07fc4f979fcb",
                                                                                                                        "Feature/&DruidSubclassCircleOfLandExtraCantripTitle",
                                                                                                                        "Feature/&DruidSubclassCircleOfLandExtraCantripDescription",
                                                                                                                        null,
                                                                                                                        DatabaseHelper.FeatureDefinitionPointPools.PointPoolLoreMasterArcaneLore
                                                                                                                        );*/
            circle_of_the_land_extra_cantrip = Helpers.ExtraSpellSelectionBuilder.createExtraCantripSelection("DruidSubclassCircleOfLandExtraCantrip",
                                                                                                              "71b34c54-00ad-4b55-9174-07fc4f979fcb",
                                                                                                              "Feature/&DruidSubclassCircleOfLandExtraCantripTitle",
                                                                                                               "Feature/&DruidSubclassCircleOfLandExtraCantripDescription",
                                                                                                                druid_class,
                                                                                                                2,
                                                                                                                1,
                                                                                                                druid_spelllist
                                                                                                                );
        }


        static void createCircleOfTheLandNaturalRecovery()
        {
            circle_of_land_natural_recovery = Helpers.CopyFeatureBuilder<FeatureDefinitionPower>.createFeatureCopy("DruidSubclassCircleOfLandNaturalRecovery",
                                                                                                                    "72bf9d07-8eb2-4e08-95a0-a217e8504a85",
                                                                                                                    "Feature/&DruidSubclassCircleOfLandNaturalRecoveryTitle",
                                                                                                                    "Feature/&DruidSubclassCircleOfLandNaturalRecoveryDescription",
                                                                                                                    null,
                                                                                                                    DatabaseHelper.FeatureDefinitionPowers.PowerWizardArcaneRecovery
                                                                                                                    );
        }


        static void createCircleOfTheLandLandsStride()
        {
            var entangle_immunty = Helpers.CopyFeatureBuilder<FeatureDefinitionConditionAffinity>.createFeatureCopy("DruidSubclassCircleOfLandEntangleImmunity",
                                                                                                                    "20833a61-c3c7-4f9c-814a-8cce4ee23e4b",
                                                                                                                    Common.common_no_title,
                                                                                                                    Common.common_no_title,
                                                                                                                    null,
                                                                                                                    DatabaseHelper.FeatureDefinitionConditionAffinitys.ConditionAffinityRestrainedmmunity,
                                                                                                                    a =>
                                                                                                                    {
                                                                                                                        a.conditionType = DatabaseHelper.ConditionDefinitions.ConditionRestrainedByEntangle.Name;
                                                                                                                        a.conditionAffinityType = RuleDefinitions.ConditionAffinityType.Immunity;
                                                                                                                    }
                                                                                                                    );

            var difficult_terrain_immunty = Helpers.CopyFeatureBuilder<FeatureDefinitionMovementAffinity>.createFeatureCopy("DruidSubclassCircleOfLandMovementAffinity",
                                                                                                                            "9edd2200-4e0c-4f1e-a21e-edac6532e2b9",
                                                                                                                            Common.common_no_title,
                                                                                                                            Common.common_no_title,
                                                                                                                            null,
                                                                                                                            DatabaseHelper.FeatureDefinitionMovementAffinitys.MovementAffinityFreedomOfMovement,
                                                                                                                            a =>
                                                                                                                            {
                                                                                                                                a.SetImmuneDifficultTerrain(true);
                                                                                                                                a.SetMinimalBaseSpeed(0);
                                                                                                                                a.SetHeavyArmorImmunity(false);
                                                                                                                            }
                                                                                                                            );
            circle_of_land_lands_stride = Helpers.FeatureSetBuilder.createFeatureSet("DruidSubclassCircleOfLandLandsStrideFeatureSet",
                                                                                    "efad62ce-35f4-4906-8459-990e19f154a5",
                                                                                    "Feature/&DruidSubclassCircleOfLandLandsStrideFeatureSetTitle",
                                                                                    "Feature/&DruidSubclassCircleOfLandLandsStrideFeatureSetDescription",
                                                                                    false,
                                                                                    FeatureDefinitionFeatureSet.FeatureSetMode.Union,
                                                                                    false,
                                                                                    difficult_terrain_immunty,
                                                                                    entangle_immunty
                                                                                    );
        }


        static void createCircleOfTheLandNaturesWard()
        {
            var charm_immunity = Helpers.CopyFeatureBuilder<FeatureDefinitionConditionAffinity>.createFeatureCopy("DruidSubclassCircleOfLandCharmImmunity",
                                                                                                                  "55d4a966-db43-4c5e-9c04-434510ababa9",
                                                                                                                  Common.common_no_title,
                                                                                                                  Common.common_no_title,
                                                                                                                  null,
                                                                                                                  DatabaseHelper.FeatureDefinitionConditionAffinitys.ConditionAffinityProtectedFromEvilCharmImmunity,
                                                                                                                  a =>
                                                                                                                  {
                                                                                                                      a.otherCharacterFamilyRestrictions = new List<string>
                                                                                                                      {
                                                                                                                          DatabaseHelper.CharacterFamilyDefinitions.Fey.Name,
                                                                                                                          DatabaseHelper.CharacterFamilyDefinitions.Elemental.Name,
                                                                                                                      };
                                                                                                                  }
                                                                                                                  );

            var frightened_immunity = Helpers.CopyFeatureBuilder<FeatureDefinitionConditionAffinity>.createFeatureCopy("DruidSubclassCircleOfLandFrightenedImmunity",
                                                                                                      "0973473d-2a81-4635-aafa-86bff2f1d779",
                                                                                                      Common.common_no_title,
                                                                                                      Common.common_no_title,
                                                                                                      null,
                                                                                                      DatabaseHelper.FeatureDefinitionConditionAffinitys.ConditionAffinityProtectedFromEvilFrightenedImmunity,
                                                                                                      a =>
                                                                                                      {
                                                                                                          a.otherCharacterFamilyRestrictions = new List<string>
                                                                                                          {
                                                                                                                          DatabaseHelper.CharacterFamilyDefinitions.Fey.Name,
                                                                                                                          DatabaseHelper.CharacterFamilyDefinitions.Elemental.Name,
                                                                                                          };
                                                                                                      }
                                                                                                      );

            circle_of_land_natures_ward = Helpers.FeatureSetBuilder.createFeatureSet("DruidSubclassCircleOfLandNaturesWardFeatureSet",
                                                                                        "d28098d3-5c9c-4e56-80b6-7c5ba381a42e",
                                                                                        "Feature/&DruidSubclassCircleOfLandNaturesWardFeatureSetTitle",
                                                                                        "Feature/&DruidSubclassCircleOfLandNaturesWardFeatureSetDescription",
                                                                                        false,
                                                                                        FeatureDefinitionFeatureSet.FeatureSetMode.Union,
                                                                                        false,
                                                                                        charm_immunity,
                                                                                        frightened_immunity,
                                                                                        DatabaseHelper.FeatureDefinitionConditionAffinitys.ConditionAffinityPoisonImmunity,
                                                                                        DatabaseHelper.FeatureDefinitionConditionAffinitys.ConditionAffinityDiseaseImmunity
                                                                                        );
        }


        static void createCircleOfTheLandBonusSpells()
        {
            Dictionary<string, SpellDefinition[][]> extra_spells
                = new Dictionary<string, SpellDefinition[][]>()
                {
                    {"Arctic", new SpellDefinition[][]{new SpellDefinition[]{DatabaseHelper.SpellDefinitions.HoldPerson, DatabaseHelper.SpellDefinitions.RayOfEnfeeblement},
                                                       new SpellDefinition[]{DatabaseHelper.SpellDefinitions.SleetStorm, DatabaseHelper.SpellDefinitions.Slow},
                                                       new SpellDefinition[]{DatabaseHelper.SpellDefinitions.FreedomOfMovement, DatabaseHelper.SpellDefinitions.IceStorm},
                                                       new SpellDefinition[]{DatabaseHelper.SpellDefinitions.HoldMonster, DatabaseHelper.SpellDefinitions.ConeOfCold},
                                                      }
                    },
                    {"Desert", new SpellDefinition[][]{new SpellDefinition[]{DatabaseHelper.SpellDefinitions.Blur, DatabaseHelper.SpellDefinitions.Silence},
                                                       new SpellDefinition[]{DatabaseHelper.SpellDefinitions.CreateFood, DatabaseHelper.SpellDefinitions.ProtectionFromEnergy},
                                                       new SpellDefinition[]{DatabaseHelper.SpellDefinitions.Blight, DatabaseHelper.SpellDefinitions.GreaterInvisibility},
                                                       new SpellDefinition[]{DatabaseHelper.SpellDefinitions.InsectPlague, DatabaseHelper.SpellDefinitions.FlameStrike},
                                                       }
                    },
                    {"Forest", new SpellDefinition[][]{new SpellDefinition[]{DatabaseHelper.SpellDefinitions.Barkskin, DatabaseHelper.SpellDefinitions.SpiderClimb},
                                                       new SpellDefinition[]{ NewFeatureDefinitions.SpellData.getSpell("CallLightningSpell") ?? DatabaseHelper.SpellDefinitions.LightningBolt, DatabaseHelper.SpellDefinitions.SpiritGuardians},
                                                       new SpellDefinition[]{DatabaseHelper.SpellDefinitions.IdentifyCreatures, DatabaseHelper.SpellDefinitions.FreedomOfMovement},
                                                       new SpellDefinition[]{DatabaseHelper.SpellDefinitions.ConjureElemental, DatabaseHelper.SpellDefinitions.InsectPlague},
                                                       }
                    },
                    {"Grassland", new SpellDefinition[][]{new SpellDefinition[]{DatabaseHelper.SpellDefinitions.Invisibility, DatabaseHelper.SpellDefinitions.PassWithoutTrace},
                                                          new SpellDefinition[]{DatabaseHelper.SpellDefinitions.Daylight, DatabaseHelper.SpellDefinitions.Haste},
                                                          new SpellDefinition[]{DatabaseHelper.SpellDefinitions.IdentifyCreatures, DatabaseHelper.SpellDefinitions.FreedomOfMovement},
                                                          new SpellDefinition[]{DatabaseHelper.SpellDefinitions.ConjureElemental, DatabaseHelper.SpellDefinitions.InsectPlague},
                                                          }
                    },
                    {"Mountain", new SpellDefinition[][]{new SpellDefinition[]{DatabaseHelper.SpellDefinitions.SpiderClimb, DatabaseHelper.SpellDefinitions.Shatter},
                                                         new SpellDefinition[]{DatabaseHelper.SpellDefinitions.LightningBolt, DatabaseHelper.SpellDefinitions.WindWall},
                                                         new SpellDefinition[]{DatabaseHelper.SpellDefinitions.FreedomOfMovement, DatabaseHelper.SpellDefinitions.Stoneskin},
                                                         new SpellDefinition[]{DatabaseHelper.SpellDefinitions.ConjureElemental, DatabaseHelper.SpellDefinitions.GreaterRestoration},
                                                        }
                    },
                    {"Swamp", new SpellDefinition[][]{new SpellDefinition[]{DatabaseHelper.SpellDefinitions.Darkness, DatabaseHelper.SpellDefinitions.AcidArrow},
                                                         new SpellDefinition[]{DatabaseHelper.SpellDefinitions.BestowCurse, DatabaseHelper.SpellDefinitions.StinkingCloud},
                                                         new SpellDefinition[]{DatabaseHelper.SpellDefinitions.FreedomOfMovement, DatabaseHelper.SpellDefinitions.IdentifyCreatures},
                                                         new SpellDefinition[]{DatabaseHelper.SpellDefinitions.Contagion, DatabaseHelper.SpellDefinitions.InsectPlague},
                                                        }
                    },
                    {"Underdark", new SpellDefinition[][]{new SpellDefinition[]{DatabaseHelper.SpellDefinitions.SpiderClimb, DatabaseHelper.SpellDefinitions.Blindness},
                                                         new SpellDefinition[]{DatabaseHelper.SpellDefinitions.StinkingCloud, DatabaseHelper.SpellDefinitions.VampiricTouchIntelligence},
                                                         new SpellDefinition[]{DatabaseHelper.SpellDefinitions.GreaterInvisibility, DatabaseHelper.SpellDefinitions.Stoneskin},
                                                         new SpellDefinition[]{DatabaseHelper.SpellDefinitions.CloudKill, DatabaseHelper.SpellDefinitions.InsectPlague},
                                                        }
                    }
                };

            circle_of_land_circle_spells = Helpers.FeatureSetBuilder.createFeatureSet("DruidSubclassCircleOfLandSubclassCircleSpells",
                                                                                        "698b6ea8-6e0e-4f06-98e3-814a7dc21e53",
                                                                                        "Feature/&DruidSubclassCircleOfLandCircleSpellsTitle",
                                                                                        "Feature/&DruidSubclassCircleOfLandCircleSpellsDescription",
                                                                                        false,
                                                                                        FeatureDefinitionFeatureSet.FeatureSetMode.Exclusion,
                                                                                        true
                                                                                        );


            foreach (var kv in extra_spells)
            {
                var autoprepared_spells = Helpers.CopyFeatureBuilder<FeatureDefinitionAutoPreparedSpells>.createFeatureCopy("DruidSubclassCircleOfLand" + kv.Key + "AutopreparedSpells",
                                                                                                                            "",
                                                                                                                            "Feature/&DruidSubclassCircleOfLand" + kv.Key + "AutopreparedSpellsTitle",
                                                                                                                            "Feature/&DomainSpellsDescription",
                                                                                                                            null,
                                                                                                                            DatabaseHelper.FeatureDefinitionAutoPreparedSpellss.AutoPreparedSpellsDomainBattle,
                                                                                                                            a =>
                                                                                                                            {
                                                                                                                                a.SetSpellcastingClass(druid_class);
                                                                                                                                a.autoPreparedSpellsGroups = new List<FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup>();
                                                                                                                            }
                                                                                                                            );
                for (int i = 0; i < kv.Value.Length; i++)
                {
                    var spell_group = new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup()
                    {
                        classLevel = i * 2 + 1,
                        spellsList = kv.Value[i].ToList()
                    };
                    autoprepared_spells.autoPreparedSpellsGroups.Add(spell_group);
                }
                circle_of_land_circle_spells.featureSet.Add(autoprepared_spells);
            }
        }



        static CharacterSubclassDefinition createCircleOfTheLand()
        {
            createCircleOfTheLandBonusCantrip();
            createCircleOfTheLandNaturalRecovery();
            createCircleOfTheLandBonusSpells();
            createCircleOfTheLandLandsStride();
            createCircleOfTheLandNaturesWard();

            var gui_presentation = new GuiPresentationBuilder(
                    "Subclass/&DruidSubclassCircleOfLandDescription",
                    "Subclass/&DruidSubclassCircleOfLandTitle")
                    .SetSpriteReference(DatabaseHelper.CharacterSubclassDefinitions.TraditionGreenmage.GuiPresentation.SpriteReference)
                    .Build();

            CharacterSubclassDefinition definition = new CharacterSubclassDefinitionBuilder("DruidSubclassCircleOfLand", "9ff4743d-015b-4a89-b2e4-cacd5866b153")
                                                                                            .SetGuiPresentation(gui_presentation)
                                                                                            .AddFeatureAtLevel(circle_of_the_land_extra_cantrip, 2)
                                                                                            .AddFeatureAtLevel(circle_of_land_natural_recovery, 2)
                                                                                            .AddFeatureAtLevel(circle_of_land_circle_spells, 3)
                                                                                            .AddFeatureAtLevel(circle_of_land_lands_stride, 6)
                                                                                            .AddFeatureAtLevel(circle_of_land_natures_ward, 10)
                                                                                            .AddToDB();
            return definition;
        }


        static void createElementalForms()
        {
            elemental_form_mark = Helpers.OnlyDescriptionFeatureBuilder.createOnlyDescriptionFeature("DruidSubclassCircleOfElementsElementalFormMark",
                                                                                                     "",
                                                                                                     Common.common_no_title,
                                                                                                     Common.common_no_title);
            Dictionary<string, MonsterDefinition> monsters = new Dictionary<string, MonsterDefinition>
            {
                {"FireJester", DatabaseHelper.MonsterDefinitions.Fire_Jester},
                {"FireOsprey", DatabaseHelper.MonsterDefinitions.Fire_Osprey},
                {"WindSnake", DatabaseHelper.MonsterDefinitions.WindSnake},
                {"SkarnGhoul", DatabaseHelper.MonsterDefinitions.SkarnGhoul},
                {"Gargoyle", DatabaseHelper.MonsterDefinitions.Gargoyle},
                {"FireSpider", DatabaseHelper.MonsterDefinitions.Fire_Spider},
                {"AirElemental", DatabaseHelper.MonsterDefinitions.Air_Elemental},
                {"FireElemental", DatabaseHelper.MonsterDefinitions.Fire_Elemental},
                {"EarthElemental", DatabaseHelper.MonsterDefinitions.Earth_Elemental},
            };

            foreach (var key in monsters.Keys.ToArray())
            {
                monsters[key] = Common.createPolymoprhUnit(monsters[key],
                                                            $"DruidSubclassCircleOfElements{key}Unit",
                                                            "",
                                                            "",
                                                            "");
                monsters[key].alignment = "Unaligned";
                monsters[key].features.Add(elemental_form_mark);
            }

            var shapes = new Dictionary<MonsterDefinition, (int, int)>
            {
                {monsters["FireJester"], (0, -1)},
                {monsters["WindSnake"], (6, -1)},
                //{monsters["Gargoyle"], (6, -1)},
                {monsters["SkarnGhoul"], (6, -1)},
                {monsters["FireOsprey"], (8, -1)},
                {monsters["FireSpider"], (12, -1)},
                {monsters["AirElemental"], (14, -1)},
                {monsters["FireElemental"], (14, -1)},
                {monsters["EarthElemental"], (14, -1)},
            };

            elemental_forms = createWildshapeFeatures("DruidSubclassCircleOfElementsElementalForm", shapes, 2, 1);
        }


        static void createElementalHealing()
        {
            var sprite = SolastaModHelpers.CustomIcons.Tools.storeCustomIcon("ElementalHealingSpellImage",
                                        $@"{UnityModManagerNet.UnityModManager.modsPath}/SolastaDruidClass/Sprites/ElementalHealing.png",
                                        128, 128);

            var effect = new EffectDescription();
            effect.Copy(DatabaseHelper.SpellDefinitions.CureWounds.effectDescription);
            effect.targetType = RuleDefinitions.TargetType.Self;
            effect.rangeType = RuleDefinitions.RangeType.Self;
            effect.effectForms.Clear();
            var effect_form = new EffectForm();
            effect_form.healingForm = new HealingForm();
            effect_form.formType = EffectForm.EffectFormType.Healing;
            effect_form.healingForm.dieType = RuleDefinitions.DieType.D8;
            effect_form.healingForm.DiceNumber = 1;
            effect.effectForms.Add(effect_form);
            var elemental_healing_spell = Helpers.GenericSpellBuilder<NewFeatureDefinitions.SpellWithRestrictions>.createSpell("DruidSubclassCircleOfElementsElementalHealingSpell",
                                                                                                                               "",
                                                                                                                               "Feature/&DruidSubclassCircleOfElementsElementalHealingTitle",
                                                                                                                               "Feature/&DruidSubclassCircleOfElementsElementalHealingDescription",
                                                                                                                               sprite,
                                                                                                                               effect,
                                                                                                                               RuleDefinitions.ActivationTime.BonusAction,
                                                                                                                               1,
                                                                                                                               false,
                                                                                                                               false,
                                                                                                                               false,
                                                                                                                               Helpers.SpellSchools.Evocation
                                                                                                                               );
            elemental_healing_spell.restrictions.Add(new NewFeatureDefinitions.HasFeatureRestriction(elemental_form_mark));

            elemental_healing = Helpers.CopyFeatureBuilder<FeatureDefinitionAutoPreparedSpells>.createFeatureCopy("DruidSubclassCircleOfElementsElementalHealing",
                                                                                                            "",
                                                                                                            "Feature/&DruidSubclassCircleOfElementsElementalHealingTitle",
                                                                                                            "Feature/&DruidSubclassCircleOfElementsElementalHealingDescription",
                                                                                                            null,
                                                                                                            DatabaseHelper.FeatureDefinitionAutoPreparedSpellss.AutoPreparedSpellsDomainBattle,
                                                                                                            a =>
                                                                                                            {
                                                                                                                a.SetSpellcastingClass(druid_class);
                                                                                                                a.autoPreparedSpellsGroups = new List<FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup>()
                                                                                                                {
                                                                                                                    new FeatureDefinitionAutoPreparedSpells.AutoPreparedSpellsGroup()
                                                                                                                    {
                                                                                                                        classLevel = 2,
                                                                                                                        spellsList = new List<SpellDefinition>{elemental_healing_spell }
                                                                                                                    }
                                                                                                                };
                                                                                                            }
                                                                                                            );
            Common.polymorph_spellcasting_forbidden.exceptionSpells.Add(elemental_healing_spell);
        }



        static void createPrimalAttacks()
        {
            primal_attacks = Helpers.FeatureBuilder<NewFeatureDefinitions.AddAttackTagIfHasFeature>.createFeature("DruidSubclassCircleOfElementsPrimalAttacks",
                                                                                                                  "",
                                                                                                                  "Feature/&DruidSubclassCircleOfElementsPrimalAttacksTitle",
                                                                                                                  "Feature/&DruidSubclassCircleOfElementsPrimalAttacksDescription",
                                                                                                                  Common.common_no_icon,
                                                                                                                  a =>
                                                                                                                  {
                                                                                                                      a.requiredFeature = elemental_form_mark;
                                                                                                                      a.tag = "Magical";
                                                                                                                  }
                                                                                                                  );
        }


        static void createElementalStrike()
        {
            elemental_strike = Helpers.FeatureBuilder<NewFeatureDefinitions.MonsterAdditionalDamage>.createFeature("DruidSubclassCircleOfElementsElementalStrike",
                                                                                                                   "",
                                                                                                                   "Feature/&DruidSubclassCircleOfElementsElementalStrikeTitle",
                                                                                                                   "Feature/&DruidSubclassCircleOfElementsElementalStrikeDescription",
                                                                                                                   Common.common_no_icon,
                                                                                                                   b =>
                                                                                                                   {
                                                                                                                       var a = new NewFeatureDefinitions.MonsterAdditionalDamageProxy();
                                                                                                                       a.additionalDamageType = RuleDefinitions.AdditionalDamageType.SameAsBaseDamage;
                                                                                                                       a.damageAdvancement = RuleDefinitions.AdditionalDamageAdvancement.SlotLevel;
                                                                                                                       a.triggerCondition = RuleDefinitions.AdditionalDamageTriggerCondition.SpendSpellSlot;
                                                                                                                       a.spellcastingFeature = druid_spellcasting;
                                                                                                                       a.limitedUsage = RuleDefinitions.FeatureLimitedUsage.OnceInMyturn;
                                                                                                                       a.notificationTag = "DruidSubclassCircleOfElementsElementalStrike";
                                                                                                                       a.damageDieType = RuleDefinitions.DieType.D8;
                                                                                                                       a.damageValueDetermination = RuleDefinitions.AdditionalDamageValueDetermination.Die;
                                                                                                                       a.damageDiceNumber = 1;
                                                                                                                       var list = new (int, int)[10];
                                                                                                                       for (int i = 0; i < 10; i++)
                                                                                                                       {
                                                                                                                           list[i] = (i + 1, i + 2);
                                                                                                                       }

                                                                                                                       a.diceByRankTable = Helpers.Misc.createDiceRankTable(10, list);
                                                                                                                       a.impactParticle = DatabaseHelper.FeatureDefinitionAdditionalDamages.AdditionalDamageHuntersMark.ImpactParticle;
                                                                                                                       a.restricitons.Add(new NewFeatureDefinitions.HasFeatureRestriction(elemental_form_mark));
                                                                                                                       b.provider = a;
                                                                                                                   }
                                                                                                                   );
        }

        static CharacterSubclassDefinition createCircleOfTheElements()
        {
            createElementalForms();
            createElementalHealing();
            createPrimalAttacks();
            createElementalStrike();
            var gui_presentation = new GuiPresentationBuilder(
                    "Subclass/&DruidSubclassCircleOfElementsDescription",
                    "Subclass/&DruidSubclassCircleOfElementsTitle")
                    .SetSpriteReference(DatabaseHelper.CharacterSubclassDefinitions.TraditionShockArcanist.GuiPresentation.SpriteReference)
                    .Build();

            CharacterSubclassDefinition definition = new CharacterSubclassDefinitionBuilder("DruidSubclassCircleOfElements", "fce3fd2e-0bba-4fdc-98da-460c0249108e")
                                                                                            .SetGuiPresentation(gui_presentation)
                                                                                            .AddFeatureAtLevel(elemental_forms[2], 2)
                                                                                            .AddFeatureAtLevel(elemental_healing, 2)
                                                                                            .AddFeatureAtLevel(elemental_forms[4], 4)
                                                                                            .AddFeatureAtLevel(elemental_forms[6], 6)
                                                                                            .AddFeatureAtLevel(primal_attacks, 6)
                                                                                            .AddFeatureAtLevel(elemental_forms[8], 8)
                                                                                            .AddFeatureAtLevel(elemental_forms[10], 10)
                                                                                            .AddFeatureAtLevel(elemental_strike, 10)
                                                                                            .AddFeatureAtLevel(elemental_forms[12], 12)
                                                                                            .AddFeatureAtLevel(elemental_forms[14], 14)
                                                                                            .AddFeatureAtLevel(elemental_forms[16], 16)
                                                                                            .AddFeatureAtLevel(elemental_forms[18], 18)
                                                                                            .AddFeatureAtLevel(elemental_forms[20], 20)
                                                                                            .AddToDB();
            return definition;
        }


        static void createSpirits()
        {
            inside_spirit_area_condition = Helpers.ConditionBuilder.createCondition("DruidSubclassCircleOfSpiritsInsideSpiritAreaCondition",
                                                                                    "",
                                                                                    Common.common_no_title,
                                                                                    Common.common_no_title,
                                                                                    Common.common_no_icon,
                                                                                    DatabaseHelper.ConditionDefinitions.ConditionBlessed
                                                                                    );
            spirit_proxy = Helpers.CopyFeatureBuilder<EffectProxyDefinition>.createFeatureCopy("DruidSubclassCircleOfSpiritsSpiritProxy",
                                                                                               "",
                                                                                               "",
                                                                                               "",
                                                                                               null,
                                                                                               DatabaseHelper.EffectProxyDefinitions.ProxySilence
                                                                                               );
            //inside_spirit_area_condition.silentWhenAdded = true;
            //inside_spirit_area_condition.silentWhenRemoved = true;
            //inside_spirit_area_condition.guiPresentation.hidden = true;

            //protection spirit +1 AC, Saves and advantage on concentration checks
            var ac_bonus = DatabaseHelper.FeatureDefinitionAttributeModifiers.AttributeModifierHeraldOfBattle;
            var saves_bonus = DatabaseHelper.FeatureDefinitionSavingThrowAffinitys.SavingThrowAffinityHeraldOfBattle;
            var concentration_advantage = Helpers.CopyFeatureBuilder<FeatureDefinitionMagicAffinity>.createFeatureCopy("DruidSubclassCircleOfSpiritsProtectionConcentrationBonus",
                                                                                                                "",
                                                                                                                Common.common_no_title,
                                                                                                                Common.common_no_title,
                                                                                                                null,
                                                                                                                DatabaseHelper.FeatureDefinitionMagicAffinitys.MagicAffinityFeatFlawlessConcentration,
                                                                                                                a =>
                                                                                                                {
                                                                                                                    a.overConcentrationThreshold = 0;
                                                                                                                }
                                                                                                                );

            //hunt spirit
            //+1 attack / damage, advantage on perception checks
            var attack_damage_bonus = DatabaseHelper.FeatureDefinitionAttackModifiers.AttackModifierHeraldOfBattle;
            var perception_advantage = Helpers.AbilityCheckAffinityBuilder.createSkillCheckAffinity("DruidSubclassCircleOfSpiritsHuntPerceptionBonus",
                                                                                                    "",
                                                                                                    Common.common_no_title,
                                                                                                    Common.common_no_title,
                                                                                                    Common.common_no_icon,
                                                                                                    RuleDefinitions.CharacterAbilityCheckAffinity.Advantage,
                                                                                                    0,
                                                                                                    RuleDefinitions.DieType.D1,
                                                                                                    Helpers.Skills.Perception
                                                                                                    );

            //healing spirit
            //targets regain max hitpoints when healed, advantage on death saves
            var max_healing = DatabaseHelper.FeatureDefinitionHealingModifiers.HealingModifierBeaconOfHope;
            var death_saves_advantage = DatabaseHelper.FeatureDefinitionDeathSavingThrowAffinitys.DeathSavingThrowAffinityBeaconOfHope;

            var protection_spirit = createSpiritPower("DruidSubclassCircleOfSpiritsProtectionSpirit",
                                                      "Feature/&DruidSubclassCircleOfSpiritsProtectionSpiritTitle",
                                                      "Feature/&DruidSubclassCircleOfSpiritsProtectionSpiritDescription",
                                                      DatabaseHelper.FeatureDefinitionPowers.PowerPaladinAuraOfCourage.guiPresentation.SpriteReference,
                                                      ac_bonus,
                                                      saves_bonus,
                                                      concentration_advantage
                                                      );

            var hunt_spirit = createSpiritPower("DruidSubclassCircleOfSpiritsHuntSpirit",
                                                  "Feature/&DruidSubclassCircleOfSpiritsHuntSpiritTitle",
                                                  "Feature/&DruidSubclassCircleOfSpiritsHuntSpiritDescription",
                                                  DatabaseHelper.FeatureDefinitionPowers.PowerOathOfMotherlandVolcanicAura.guiPresentation.SpriteReference,
                                                  attack_damage_bonus,
                                                  perception_advantage
                                                  );

            var healing_spirit = createSpiritPower("DruidSubclassCircleOfSpiritsHealingSpirit",
                                                  "Feature/&DruidSubclassCircleOfSpiritsHealingSpiritTitle",
                                                  "Feature/&DruidSubclassCircleOfSpiritsHealingSpiritDescription",
                                                  DatabaseHelper.FeatureDefinitionPowers.PowerOathOfTirmarAuraTruth.guiPresentation.SpriteReference,
                                                  max_healing,
                                                  death_saves_advantage
                                                  );

            spirits = Helpers.FeatureSetBuilder.createFeatureSet("DruidSubclassCircleOfSpiritsSpiritsFeatureSet",
                                                                "",
                                                                "Feature/&DruidSubclassCircleOfSpiritsSpiritsFeatureSetTitle",
                                                                "Feature/&DruidSubclassCircleOfSpiritsSpiritsFeatureSetDescription",
                                                                true,
                                                                FeatureDefinitionFeatureSet.FeatureSetMode.Union,
                                                                false,
                                                                healing_spirit,
                                                                hunt_spirit,
                                                                protection_spirit
                                                                );
        }


        static FeatureDefinitionPower createSpiritPower(string name, string title, string description, AssetReferenceSprite power_sprite, params FeatureDefinition[] features)
        {
            var condition = Helpers.ConditionBuilder.createCondition(name + "AreaCondition",
                                                                    "",
                                                                    title,
                                                                    Common.common_no_title,
                                                                    null,
                                                                    DatabaseHelper.ConditionDefinitions.ConditionBlessed,
                                                                    features
                                                                    );
            condition.parentCondition = inside_spirit_area_condition;

            var effect = new EffectDescription();
            effect.Copy(DatabaseHelper.SpellDefinitions.Silence.effectDescription);
            effect.rangeParameter = 12;
            effect.durationParameter = 1;
            effect.effectForms.Clear();
            var condition_form = new EffectForm();
            condition_form.formType = EffectForm.EffectFormType.Condition;
            condition_form.conditionForm = new ConditionForm();
            condition_form.createdByCharacter = true;
            condition_form.conditionForm.conditionDefinition = condition;
            effect.effectForms.Add(condition_form);
            var summon_form = new EffectForm();
            summon_form.formType = EffectForm.EffectFormType.Summon;
            summon_form.summonForm = new SummonForm();
            summon_form.createdByCharacter = true;
            summon_form.summonForm.summonType = SummonForm.Type.EffectProxy;
            summon_form.summonForm.effectProxyDefinitionName = spirit_proxy.name;
            summon_form.summonForm.number = 1;
            effect.effectForms.Add(summon_form);
            effect.targetSide = RuleDefinitions.Side.Ally;

            var power = Helpers.GenericPowerBuilder<NewFeatureDefinitions.LinkedPower>.createPower(name + "Power",
                                                                                                   "",
                                                                                                   title,
                                                                                                   description,
                                                                                                   power_sprite,
                                                                                                   effect,
                                                                                                   RuleDefinitions.ActivationTime.BonusAction,
                                                                                                   2,
                                                                                                   RuleDefinitions.UsesDetermination.Fixed,
                                                                                                   RuleDefinitions.RechargeRate.ShortRest);
            power.linkedPower = base_wildshape_power;
            return power;
        }


        static void createSpiritSummoner()
        {
            var title = "Feature/&DruidSubclassCircleOfSpiritsSpiritSummonerTitle";
            var description = "Feature/&DruidSubclassCircleOfSpiritsSpiritSummonerDescription";


            var magic_tag = Helpers.FeatureBuilder<NewFeatureDefinitions.AddAttackTagIfHasFeature>.createFeature("DruidSubclassCircleOfSpiritsSpiritSummonerMagicAttacks",
                                                                                                                  "",
                                                                                                                  Common.common_no_title,
                                                                                                                  Common.common_no_title,
                                                                                                                  Common.common_no_icon,
                                                                                                                  a =>
                                                                                                                  {
                                                                                                                      a.requiredFeature = null;
                                                                                                                      a.tag = "Magical";
                                                                                                                  }
                                                                                                                  );

            var extra_hp = Helpers.FeatureBuilder<NewFeatureDefinitions.IncreaseMonsterHitPointsToTargetOnConditionApplication>
                                                                                .createFeature("DruidSubclassCircleOfSpiritsExtraHP",
                                                                                               "",
                                                                                               Common.common_no_title,
                                                                                               Common.common_no_title,
                                                                                               Common.common_no_icon,
                                                                                               a =>
                                                                                               {
                                                                                                   a.requiredCondition = DatabaseHelper.ConditionDefinitions.ConditionConjuredCreature;
                                                                                                   a.hdMultiplier = 2;
                                                                                               }
                                                                                               );
                                                                                               
            var condition = Helpers.ConditionBuilder.createCondition("DruidSubclassCircleOfSpiritsSpiritSummonerCondition",
                                                                    "",
                                                                    title,
                                                                    "Rules/&DruidSubclassCircleOfSpiritsSpiritSummonerConditionDescription",
                                                                    DatabaseHelper.ConditionDefinitions.ConditionBearsEndurance.guiPresentation.spriteReference,
                                                                    DatabaseHelper.ConditionDefinitions.ConditionBlessed,
                                                                    magic_tag
                                                                    );

            var apply_condition = Helpers.FeatureBuilder<NewFeatureDefinitions.AddExtraConditionToTargetOnConditionApplication>
                                                                                .createFeature("DruidSubclassCircleOfSpiritsApplySpiritSummonerCondition",
                                                                                               "",
                                                                                               Common.common_no_title,
                                                                                               Common.common_no_title,
                                                                                               Common.common_no_icon,
                                                                                               a =>
                                                                                               {
                                                                                                   a.requiredCondition = DatabaseHelper.ConditionDefinitions.ConditionConjuredCreature;
                                                                                                   a.extraCondition = condition;
                                                                                               }
                                                                                               );

            spirit_summoner = Helpers.FeatureSetBuilder.createFeatureSet("DruidSubclassCircleOfSpiritsSpiritSummonerFeatureSet",
                                                                            "",
                                                                            title,
                                                                            description,
                                                                            false,
                                                                            FeatureDefinitionFeatureSet.FeatureSetMode.Union,
                                                                            false,
                                                                            apply_condition,
                                                                            extra_hp
                                                                            );
        }


        static void createGuardianSpirits()
        {
            var title = "Feature/&DruidSubclassCircleOfSpiritsGuardianSpiritsTitle";
            var description = "Feature/&DruidSubclassCircleOfSpiritsGuardianSpiritsDescription";

            var feature = Helpers.FeatureBuilder<NewFeatureDefinitions.HealAtTurnEndIfHasConditionBasedOnCasterLevel>
                                                                    .createFeature("DruidSubclassCircleOfSpiritsGuardianSpiritsFeature",
                                                                                   "",
                                                                                   Common.common_no_title,
                                                                                   Common.common_no_title,
                                                                                   Common.common_no_icon,
                                                                                   a =>
                                                                                   {
                                                                                       a.casterCondition = inside_spirit_area_condition;
                                                                                       a.allowParentConditions = true;
                                                                                       a.characterClass = druid_class;
                                                                                       a.levelHealing = new List<(int, int)>
                                                                                       {
                                                                                           (9, 0),
                                                                                           (11, 5),
                                                                                           (13, 6),
                                                                                           (15, 7),
                                                                                           (17, 8),
                                                                                           (19, 9),
                                                                                           (20, 10)
                                                                                       };
                                                                                   }
                                                                                   );



            var condition = Helpers.ConditionBuilder.createCondition("DruidSubclassCircleOfSpiritsGuardianSpiritsCondition",
                                                                    "",
                                                                    title,
                                                                    "Rules/&DruidSubclassCircleOfSpiritsGuardianSpiritsConditionDescription",
                                                                    DatabaseHelper.ConditionDefinitions.ConditionBarkskin.guiPresentation.spriteReference,
                                                                    DatabaseHelper.ConditionDefinitions.ConditionBlessed,
                                                                    feature
                                                                    );

            guardian_spirits = Helpers.FeatureBuilder<NewFeatureDefinitions.AddExtraConditionToTargetOnConditionApplication>
                                                                                .createFeature("DruidSubclassCircleOfSpiritsGuardianSpiritsApplyCondition",
                                                                                               "",
                                                                                               title,
                                                                                               description,
                                                                                               Common.common_no_icon,
                                                                                               a =>
                                                                                               {
                                                                                                   a.requiredCondition = DatabaseHelper.ConditionDefinitions.ConditionConjuredCreature;
                                                                                                   a.extraCondition = condition;
                                                                                               }
                                                                                               );
        }



        static CharacterSubclassDefinition createCircleOfSpirits()
        {    
            var gui_presentation = new GuiPresentationBuilder(
                    "Subclass/&DruidSubclassCircleOfSpiritsDescription",
                    "Subclass/&DruidSubclassCircleOfSpiritsTitle")
                    .SetSpriteReference(DatabaseHelper.CharacterSubclassDefinitions.SorcerousChildRift.GuiPresentation.SpriteReference)
                    .Build();

            createSpirits();
            createSpiritSummoner();
            createGuardianSpirits();
            CharacterSubclassDefinition definition = new CharacterSubclassDefinitionBuilder("DruidSubclassCircleOfSpirits", "75856caa-9d96-4d59-9b6e-64b0f9256511")
                                                                                            .SetGuiPresentation(gui_presentation)
                                                                                            .AddFeatureAtLevel(spirits, 2)
                                                                                            .AddFeatureAtLevel(spirit_summoner, 6)
                                                                                            .AddFeatureAtLevel(guardian_spirits, 10)
                                                                                            .AddToDB();
            return definition;
        }


        public static void BuildAndAddClassToDB()
        {
            var DruidClass = new DruidClassBuilder(DruidClassName, DruidClassGuid).AddToDB();
            DruidClass.FeatureUnlocks.Sort(delegate (FeatureUnlockByLevel a, FeatureUnlockByLevel b)
                                            {
                                                return a.Level - b.Level;
                                            }
                                         );

            DruidFeatureDefinitionSubclassChoice.Subclasses.Add(createCircleOfTheElements().Name);
            DruidFeatureDefinitionSubclassChoice.Subclasses.Add(createCircleOfTheLand().Name);
            DruidFeatureDefinitionSubclassChoice.Subclasses.Add(createCircleOfSpirits().Name);
        }

        private static FeatureDefinitionSubclassChoice DruidFeatureDefinitionSubclassChoice;
    }
}
