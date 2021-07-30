using SolastaModApi;
using SolastaModApi.Extensions;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using HarmonyLib;
using UnityEngine;
using System;

namespace SolastaDruidClass
{
    internal class DruidClassBuilder : CharacterClassDefinitionBuilder
    {
        const string DruidClassName = "DHDruid";
        const string DruidClassGuid = "a2112af0-636f-4b72-acdc-07c921bcea6d";
        const string DruidClassSubclassesGuid = "46ae0591-296d-4f6c-80b0-4e198c999076";

        //protected DruidClassBuilder(string name, string guid) : base(DatabaseHelper.CharacterClassDefinitions.Cleric, name, guid)
        protected DruidClassBuilder(string name, string guid) : base( name, guid)
        {
            Definition.GuiPresentation.Title = "Class/&DruidClassTitle";
            Definition.GuiPresentation.Description = "Class/&DruidClassDescription";
            Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.LocationDefinitions.EncounterWaterfall_LocationDB.GuiPresentation.SpriteReference);

            // Druid
            // [‒]
            // Hit Dice: 1d8
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
            List<CharacterClassDefinition.HeroEquipmentOption> list = new List<CharacterClassDefinition.HeroEquipmentOption>();
            List<CharacterClassDefinition.HeroEquipmentOption> list2 = new List<CharacterClassDefinition.HeroEquipmentOption>();
            list.Add(EquipmentOptionsBuilder.Option(DatabaseHelper.ItemDefinitions.Shield, EquipmentDefinitions.ShieldCategory, 1));
            list2.Add(EquipmentOptionsBuilder.Option(DatabaseHelper.ItemDefinitions.Dagger, EquipmentDefinitions.OptionWeaponSimpleChoice, 1));
           List<CharacterClassDefinition.HeroEquipmentOption> list3 = new List<CharacterClassDefinition.HeroEquipmentOption>();
           List<CharacterClassDefinition.HeroEquipmentOption> list4 = new List<CharacterClassDefinition.HeroEquipmentOption>();
           list3.Add(EquipmentOptionsBuilder.Option(DatabaseHelper.ItemDefinitions.Quarterstaff, EquipmentDefinitions.MartialWeaponCategory, 1));
           list4.Add(EquipmentOptionsBuilder.Option(DatabaseHelper.ItemDefinitions.Dagger, EquipmentDefinitions.OptionWeaponSimpleMeleeChoice, 1));
            this.AddEquipmentRow(list, list2);
            this.AddEquipmentRow(list3, list4);
            this.AddEquipmentRow(new List<CharacterClassDefinition.HeroEquipmentOption>
            {
                EquipmentOptionsBuilder.Option(DatabaseHelper.ItemDefinitions.Leather, EquipmentDefinitions.OptionArmor, 1),
                EquipmentOptionsBuilder.Option(DatabaseHelper.ItemDefinitions.ExplorerPack, EquipmentDefinitions.OptionStarterPack, 1),
                EquipmentOptionsBuilder.Option(DatabaseHelper.ItemDefinitions.ComponentPouch_Belt, EquipmentDefinitions.OptionFocus, 1)
          
            });


           Definition.FeatureUnlocks.Clear();


            // Proficiencies
            // Armor: light armor, medium armor, shields (druids will not wear armor or use shields made of metal)
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DruidArmorProficienciesBuilder.DruidArmorProficiencies, 1));
       //     // weapon profs
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DruidProficienciesBuilder.DruidProficiencies, 1));
       //     // Saving Throws: Intelligence, Wisdom
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.FeatureDefinitionProficiencys.ProficiencyWizardSavingThrow, 1)); 
       //     // Tools: Herbalism kit
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.FeatureDefinitionProficiencys.ProficiencyPhilosopherTools, 1));
            //     // skill choice
               Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DruidClassSkillPointPoolBuilder.DruidClassSkillPointPool, 1));
           // Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.FeatureDefinitionPointPools.PointPoolRangerSkillPoints, 1));






            // druid casting
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DruidCastingAbilityBuilder.DruidCastingAbility, 1));
            // wild shape 
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(WildshapeFeatureSetBuilder.WildshapeFeatureSet,2));

            //Subclass circle at level 2
            var subclassChoicesGuiPresentation = new GuiPresentation();
            subclassChoicesGuiPresentation.Title = "Subclass/&DruidSubclassCircleTitle";
            subclassChoicesGuiPresentation.Description = "Subclass/&DruidSubclassCircleDescription";
            DruidFeatureDefinitionSubclassChoice = this.BuildSubclassChoice(2, "Circle", false, "SubclassChoiceDruidCircleArchetypes", subclassChoicesGuiPresentation, DruidClassSubclassesGuid);


            // wildshape improvement at level 4 and ability improvement
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetAbilityScoreChoice, 4));
           Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(Wildshape_level4FeatureSetBuilder.Wildshape_level4FeatureSet, 4));
          
            //circle at level 6

            // wildshape improvement at level 8 and ability improvement
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetAbilityScoreChoice, 8));
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(Wildshape_level8FeatureSetBuilder.Wildshape_level8FeatureSet, 8));

            //circle at level 10

            // ability improvement at 12
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetAbilityScoreChoice, 12));

            //circle at level 14

            // ability improvement at 16
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetAbilityScoreChoice, 16));
            // 18th	 	Beast Spells
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(BeastSpellsFeatureSetBuilder.BeastSpellsFeatureSet, 18));
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.FeatureDefinitionMagicAffinitys.MagicAffinityBattleMagic, 18));
            // 19th	Ability Score Improvement  -
            Definition.FeatureUnlocks.Add(new FeatureUnlockByLevel(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetAbilityScoreChoice, 19));
             // 20th	Archdruid                  -
            // ?? turn off materials in the rule settings??
        }

        public static void BuildAndAddClassToDB()
        {
            var DruidClass = new DruidClassBuilder(DruidClassName, DruidClassGuid).AddToDB();

             DruidSubClassCircleOfLand.BuildandAddSubclass();
            DruidSubClassCircleOfWanderers.BuildandAddSubclass();
            DruidSubClassCircleOfShifters.BuildandAddSubclass();

            //
            CharacterSubclassDefinition CircleOfLand = DatabaseRepository.GetDatabase<CharacterSubclassDefinition>().TryGetElement("DruidSubclassCircleOfLand", "9ff4743d-015b-4a89-b2e4-cacd5866b153");
            DruidFeatureDefinitionSubclassChoice.Subclasses.Add(CircleOfLand.Name);

            
            // circle of wayfarers/summons/companion druid fey battle buddy using wildfire companion and primal companions as templates
            CharacterSubclassDefinition CircleOfWanderers = DatabaseRepository.GetDatabase<CharacterSubclassDefinition>().TryGetElement("DruidSubclassCircleOfWanderers", "3d08c24e-f16f-4c57-ae30-ce02084c5077");
            DruidFeatureDefinitionSubclassChoice.Subclasses.Add(CircleOfWanderers.Name);


            //circle of shifters/aspects/lycanthropy (use conditions to alter PC's body in different ways for gish druid)
            CharacterSubclassDefinition CircleOfShifters = DatabaseRepository.GetDatabase<CharacterSubclassDefinition>().TryGetElement("DruidSubclassCircleOfShifters", "fed33975-da89-482d-bd4c-3b95ab914d8a");
            DruidFeatureDefinitionSubclassChoice.Subclasses.Add(CircleOfShifters.Name);
        }

        private static FeatureDefinitionSubclassChoice DruidFeatureDefinitionSubclassChoice;
    }


    internal class DruidProficienciesBuilder : BaseDefinitionBuilder<FeatureDefinitionProficiency>
    {
        const string DruidProficienciesName = "DruidProficiencies";
        const string DruidProficienciesGuid = "5b0c5413-79ae-4898-b993-85cf3619a938";

        protected DruidProficienciesBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionProficiencys.ProficiencyWizardWeapon, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&DruidProficienciesTitle"; //Feature/&NoContentTitle
            Definition.GuiPresentation.Description = "Feat/&DruidProficienciesDescription";//Feature/&NoContentTitle

            Definition.SetProficiencyType(RuleDefinitions.ProficiencyType.Weapon);
            Definition.Proficiencies.Clear();

            // Weapons: clubs, daggers, darts, javelins, maces, quarterstaffs, scimitars, sickles, slings, spears

            Definition.Proficiencies.Add(DatabaseHelper.WeaponTypeDefinitions.ClubType.Name);
            Definition.Proficiencies.Add(DatabaseHelper.WeaponTypeDefinitions.DaggerType.Name);
            Definition.Proficiencies.Add(DatabaseHelper.WeaponTypeDefinitions.DartType.Name);
            Definition.Proficiencies.Add(DatabaseHelper.WeaponTypeDefinitions.JavelinType.Name);
            Definition.Proficiencies.Add(DatabaseHelper.WeaponTypeDefinitions.MaceType.Name);
            Definition.Proficiencies.Add(DatabaseHelper.WeaponTypeDefinitions.QuarterstaffType.Name);
            Definition.Proficiencies.Add(DatabaseHelper.WeaponTypeDefinitions.ScimitarType.Name);
            Definition.Proficiencies.Add(DatabaseHelper.WeaponTypeDefinitions.SpearType.Name);

        }

        public static FeatureDefinitionProficiency CreateAndAddToDB(string name, string guid)
            => new DruidProficienciesBuilder(name, guid).AddToDB();

        public static FeatureDefinitionProficiency DruidProficiencies = CreateAndAddToDB(DruidProficienciesName, DruidProficienciesGuid);
    }
    internal class DruidArmorProficienciesBuilder : BaseDefinitionBuilder<FeatureDefinitionProficiency>
    {
        const string DruidArmorProficienciesName = "DruidArmorProficiencies";
        const string DruidArmorProficienciesGuid = "eb0d5b55-b878-4828-aaca-e4aa95a2a9db";

        protected DruidArmorProficienciesBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionProficiencys.ProficiencyClericArmor, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&DruidArmorProficienciesTitle"; //Feature/&NoContentTitle
            Definition.GuiPresentation.Description = "Feat/&DruidArmorProficienciesDescription";//Feature/&NoContentTitle


        }

        public static FeatureDefinitionProficiency CreateAndAddToDB(string name, string guid)
            => new DruidArmorProficienciesBuilder(name, guid).AddToDB();

        public static FeatureDefinitionProficiency DruidArmorProficiencies = CreateAndAddToDB(DruidArmorProficienciesName, DruidArmorProficienciesGuid);
    }
    internal class DruidClassSkillPointPoolBuilder : BaseDefinitionBuilder<FeatureDefinitionPointPool>
    {
        const string DruidClassSkillPointPoolName = "DruidClassSkillPointPool";
        const string DruidClassSkillPointPoolGuid = "8f2cb82d-6bf9-4a72-a3e1-286a1e2b5662";

        protected DruidClassSkillPointPoolBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionPointPools.PointPoolClericSkillPoints, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&DruidClassSkillPointPoolTitle";
            Definition.GuiPresentation.Description = "Feature/&DruidClassSkillPointPoolDescription";

           // Definition.SetPoolAmount(2);
           // Definition.SetPoolType("Skill");
        //   Definition.RestrictedChoices.Clear();
        //   Definition.RestrictedChoices.Add("Arcana");
        //   Definition.RestrictedChoices.Add("AnimalHandling");
        //   Definition.RestrictedChoices.Add("Insight");
        //   Definition.RestrictedChoices.Add("Medicine");
        //   Definition.RestrictedChoices.Add("Nature");
        //   Definition.RestrictedChoices.Add("Perception");
        //   Definition.RestrictedChoices.Add("Religion");
        //   Definition.RestrictedChoices.Add("Survival" );

            Definition.SetPoolAmount(2);
            Definition.SetPoolType(HeroDefinitions.PointsPoolType.Skill);
            Definition.RestrictedChoices.Clear();
            Definition.RestrictedChoices.AddRange(new string[] { "AnimalHandling", "Arcana", "Insight","Medecine", "Nature", "Perception", "Religion","Survival", });
        }                               //// Skills: Choose 2 from Arcana, Animal Handling, Insight, Medicine, Nature, Perception, Religion, and Survival.

        public static FeatureDefinitionPointPool CreateAndAddToDB(string name, string guid)
            => new DruidClassSkillPointPoolBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPointPool DruidClassSkillPointPool = CreateAndAddToDB(DruidClassSkillPointPoolName, DruidClassSkillPointPoolGuid);
    }

    internal class DruidCastingAbilityBuilder : BaseDefinitionBuilder<FeatureDefinitionCastSpell>
    {
        const string DruidCastingAbilityName = "DruidCastingAbility";
        const string DruidCastingAbilityGuid = "64e9ce25-cbbc-4ff2-9fd2-0e4ad1d32a67";

        protected DruidCastingAbilityBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionCastSpells.CastSpellCleric, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&DruidCastingAbilityTitle";
            Definition.GuiPresentation.Description = "Feature/&DruidCastingAbilityDescription";

           
            Definition.SetSpellListDefinition(DruidSpellListBuilder.DruidSpellList);
            Definition.SetSpellCastingOrigin(FeatureDefinitionCastSpell.CastingOrigin.Class);
            
            Definition.KnownCantrips.Clear();
           Definition.KnownCantrips.AddRange( new List<int> { 2, 2, 2, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 });



        }

        public static FeatureDefinitionCastSpell CreateAndAddToDB(string name, string guid)
            => new DruidCastingAbilityBuilder(name, guid).AddToDB();

        public static FeatureDefinitionCastSpell DruidCastingAbility = CreateAndAddToDB(DruidCastingAbilityName, DruidCastingAbilityGuid);
    }




    internal class DruidSpellListBuilder : BaseDefinitionBuilder<SpellListDefinition>
    {
        const string DruidSpellListName = "DruidSpellList";
        const string DruidSpellListGuid = "19ef0624-ede3-4612-b636-6479dd8f4e2e";

        protected DruidSpellListBuilder(string name, string guid) : base(DatabaseHelper.SpellListDefinitions.SpellListCleric, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&DruidSpellListTitle";
            Definition.GuiPresentation.Description = "Feature/&DruidSpellListDescription";

            SpellListDefinition.SpellsByLevelDuplet DruidSpell_Cantrips = new SpellListDefinition.SpellsByLevelDuplet();
            DruidSpell_Cantrips.Spells = new List<SpellDefinition>();
            //DruidSpell_Cantrips.Level = 1;
            DruidSpell_Cantrips.Spells.Add(DatabaseHelper.SpellDefinitions.Guidance);
            DruidSpell_Cantrips.Spells.Add(DatabaseHelper.SpellDefinitions.PoisonSpray);
            DruidSpell_Cantrips.Spells.Add(DatabaseHelper.SpellDefinitions.Resistance);
            DruidSpell_Cantrips.Spells.Add(ProduceFlameCantripBuilder.ProduceFlameCantrip);
         //   DruidSpell_Cantrips.Spells.Add(shillelaghCantripBuilder.shillelaghCantrip);
            // DruidSpell_Cantrips.Spells.Add(DatabaseHelper.SpellDefinitions.Druidcraft);
            DruidSpell_Cantrips.Spells.Add(DatabaseHelper.SpellDefinitions.Sparkle);
            DruidSpell_Cantrips.Spells.Add(DatabaseHelper.SpellDefinitions.Dazzle);
            DruidSpell_Cantrips.Spells.Add(DatabaseHelper.SpellDefinitions.Shine);
            DruidSpell_Cantrips.Spells.Add(DatabaseHelper.SpellDefinitions.AnnoyingBee);    // added solasta's cantrips to give more than 3 srd options
            DruidSpell_Cantrips.Spells.Add(DatabaseHelper.SpellDefinitions.ShadowArmor);
            DruidSpell_Cantrips.Spells.Add(DatabaseHelper.SpellDefinitions.ShadowDagger);
           // DruidSpell_Cantrips.Spells.Add(DatabaseHelper.SpellDefinitions.Gust);
           // DruidSpell_Cantrips.Spells.Add(DatabaseHelper.SpellDefinitions.shapewater);
           // DruidSpell_Cantrips.Spells.Add(DatabaseHelper.SpellDefinitions.controlflames);
           // DruidSpell_Cantrips.Spells.Add(DatabaseHelper.SpellDefinitions.moldearth);     // non srd cantrips
           // DruidSpell_Cantrips.Spells.Add(DatabaseHelper.SpellDefinitions.thornwhip);
           // DruidSpell_Cantrips.Spells.Add(DatabaseHelper.SpellDefinitions.thunderclap);
           // DruidSpell_Cantrips.Spells.Add(DatabaseHelper.SpellDefinitions.primalsavgery);


            SpellListDefinition.SpellsByLevelDuplet DruidSpell_level_1 = new SpellListDefinition.SpellsByLevelDuplet();
            DruidSpell_level_1.Spells = new List<SpellDefinition>();
            DruidSpell_level_1.Level = 1;
            DruidSpell_level_1.Spells.Add(DatabaseHelper.SpellDefinitions.AnimalFriendship);
            DruidSpell_level_1.Spells.Add(DatabaseHelper.SpellDefinitions.CharmPerson);
        //    DruidSpell_level_1.Spells.Add(DatabaseHelper.SpellDefinitions.CreateDestroyWater);
            DruidSpell_level_1.Spells.Add(DatabaseHelper.SpellDefinitions.CureWounds);
            DruidSpell_level_1.Spells.Add(DatabaseHelper.SpellDefinitions.DetectMagic);
            DruidSpell_level_1.Spells.Add(DatabaseHelper.SpellDefinitions.DetectPoisonAndDisease);
            DruidSpell_level_1.Spells.Add(DatabaseHelper.SpellDefinitions.Entangle);
            DruidSpell_level_1.Spells.Add(DatabaseHelper.SpellDefinitions.FaerieFire);
            DruidSpell_level_1.Spells.Add(DatabaseHelper.SpellDefinitions.FogCloud);
            DruidSpell_level_1.Spells.Add(DatabaseHelper.SpellDefinitions.Goodberry);
            DruidSpell_level_1.Spells.Add(DatabaseHelper.SpellDefinitions.HealingWord);
            DruidSpell_level_1.Spells.Add(DatabaseHelper.SpellDefinitions.Jump);
            DruidSpell_level_1.Spells.Add(DatabaseHelper.SpellDefinitions.Longstrider);
            DruidSpell_level_1.Spells.Add(DatabaseHelper.SpellDefinitions.ProtectionFromEvilGood);
       //     DruidSpell_level_1.Spells.Add(DatabaseHelper.SpellDefinitions.PurifyFood);
            DruidSpell_level_1.Spells.Add(DatabaseHelper.SpellDefinitions.Thunderwave);
            //DruidSpell_level_1.Spells.Add(DatabaseHelper.SpellDefinitions.);

            SpellListDefinition.SpellsByLevelDuplet DruidSpell_level_2 = new SpellListDefinition.SpellsByLevelDuplet();
            DruidSpell_level_2.Spells = new List<SpellDefinition>();
            DruidSpell_level_2.Level = 2;
            DruidSpell_level_2.Spells.Add(DatabaseHelper.SpellDefinitions.Barkskin);
            DruidSpell_level_2.Spells.Add(DatabaseHelper.SpellDefinitions.Darkvision);
            DruidSpell_level_2.Spells.Add(DatabaseHelper.SpellDefinitions.EnhanceAbility);
            DruidSpell_level_2.Spells.Add(DatabaseHelper.SpellDefinitions.FindTraps);
        //    DruidSpell_level_2.Spells.Add(DatabaseHelper.SpellDefinitions.FlameBlade);
            DruidSpell_level_2.Spells.Add(DatabaseHelper.SpellDefinitions.FlamingSphere);
            DruidSpell_level_2.Spells.Add(DatabaseHelper.SpellDefinitions.GustOfWind);
       //     DruidSpell_level_2.Spells.Add(HeatMetalSpellBuilder.HeatMetalSpell);
            DruidSpell_level_2.Spells.Add(DatabaseHelper.SpellDefinitions.HoldPerson);
            DruidSpell_level_2.Spells.Add(DatabaseHelper.SpellDefinitions.LesserRestoration);
            DruidSpell_level_2.Spells.Add(DatabaseHelper.SpellDefinitions.PassWithoutTrace);
            DruidSpell_level_2.Spells.Add(DatabaseHelper.SpellDefinitions.ProtectionFromPoison);
        //    DruidSpell_level_2.Spells.Add(DatabaseHelper.SpellDefinitions.spikegrowth);
        //    DruidSpell_level_2.Spells.Add(DatabaseHelper.SpellDefinitions.);
        //    DruidSpell_level_2.Spells.Add(DatabaseHelper.SpellDefinitions.);
        //    DruidSpell_level_2.Spells.Add(DatabaseHelper.SpellDefinitions.);
        //    DruidSpell_level_2.Spells.Add(DatabaseHelper.SpellDefinitions.);

            SpellListDefinition.SpellsByLevelDuplet DruidSpell_level_3 = new SpellListDefinition.SpellsByLevelDuplet();
            DruidSpell_level_3.Spells = new List<SpellDefinition>();
            DruidSpell_level_3.Level = 3;
       //     DruidSpell_level_3.Spells.Add(DatabaseHelper.SpellDefinitions.CallLightning);
            DruidSpell_level_3.Spells.Add(DatabaseHelper.SpellDefinitions.ConjureAnimals);
            DruidSpell_level_3.Spells.Add(DatabaseHelper.SpellDefinitions.Daylight);
            DruidSpell_level_3.Spells.Add(DatabaseHelper.SpellDefinitions.DispelMagic);
            DruidSpell_level_3.Spells.Add(DatabaseHelper.SpellDefinitions.ProtectionFromEnergy);
            DruidSpell_level_3.Spells.Add(DatabaseHelper.SpellDefinitions.Revivify);
            DruidSpell_level_3.Spells.Add(DatabaseHelper.SpellDefinitions.SleetStorm);
        //    DruidSpell_level_3.Spells.Add(DatabaseHelper.SpellDefinitions.WaterBreathing);
        //    DruidSpell_level_3.Spells.Add(DatabaseHelper.SpellDefinitions.WaterWalk);
            DruidSpell_level_3.Spells.Add(DatabaseHelper.SpellDefinitions.WindWall);
        //    DruidSpell_level_3.Spells.Add(DatabaseHelper.SpellDefinitions.);
        //    DruidSpell_level_3.Spells.Add(DatabaseHelper.SpellDefinitions.);
        //    DruidSpell_level_3.Spells.Add(DatabaseHelper.SpellDefinitions.);
        //    DruidSpell_level_3.Spells.Add(DatabaseHelper.SpellDefinitions.);
        //    DruidSpell_level_3.Spells.Add(DatabaseHelper.SpellDefinitions.);
        //    DruidSpell_level_3.Spells.Add(DatabaseHelper.SpellDefinitions.);
        //    DruidSpell_level_3.Spells.Add(DatabaseHelper.SpellDefinitions.);

            SpellListDefinition.SpellsByLevelDuplet DruidSpell_level_4 = new SpellListDefinition.SpellsByLevelDuplet();
            DruidSpell_level_4.Spells = new List<SpellDefinition>();
            DruidSpell_level_4.Level = 4;
            DruidSpell_level_4.Spells.Add(DatabaseHelper.SpellDefinitions.Blight);
            DruidSpell_level_4.Spells.Add(DatabaseHelper.SpellDefinitions.Confusion);
            DruidSpell_level_4.Spells.Add(DatabaseHelper.SpellDefinitions.ConjureMinorElementals);
            DruidSpell_level_4.Spells.Add(DatabaseHelper.SpellDefinitions.FireShield);
            DruidSpell_level_4.Spells.Add(DatabaseHelper.SpellDefinitions.FreedomOfMovement);
            DruidSpell_level_4.Spells.Add(DatabaseHelper.SpellDefinitions.GiantInsect);
            DruidSpell_level_4.Spells.Add(DatabaseHelper.SpellDefinitions.IceStorm);
            DruidSpell_level_4.Spells.Add(DatabaseHelper.SpellDefinitions.Stoneskin);
            DruidSpell_level_4.Spells.Add(DatabaseHelper.SpellDefinitions.WallOfFire);
        //    DruidSpell_level_4.Spells.Add(DatabaseHelper.SpellDefinitions.);
        //    DruidSpell_level_4.Spells.Add(DatabaseHelper.SpellDefinitions.);
        //    DruidSpell_level_4.Spells.Add(DatabaseHelper.SpellDefinitions.);
        //    DruidSpell_level_4.Spells.Add(DatabaseHelper.SpellDefinitions.);
        //    DruidSpell_level_4.Spells.Add(DatabaseHelper.SpellDefinitions.);
        //    DruidSpell_level_4.Spells.Add(DatabaseHelper.SpellDefinitions.);
        //    DruidSpell_level_4.Spells.Add(DatabaseHelper.SpellDefinitions.);
        //    DruidSpell_level_4.Spells.Add(DatabaseHelper.SpellDefinitions.);

            SpellListDefinition.SpellsByLevelDuplet DruidSpell_level_5 = new SpellListDefinition.SpellsByLevelDuplet();
            DruidSpell_level_5.Spells = new List<SpellDefinition>();
            DruidSpell_level_5.Level = 5;
            DruidSpell_level_5.Spells.Add(DatabaseHelper.SpellDefinitions.ConeOfCold);
            DruidSpell_level_5.Spells.Add(DatabaseHelper.SpellDefinitions.ConjureElemental);
            DruidSpell_level_5.Spells.Add(DatabaseHelper.SpellDefinitions.Contagion);
            DruidSpell_level_5.Spells.Add(DatabaseHelper.SpellDefinitions.GreaterRestoration);
            DruidSpell_level_5.Spells.Add(DatabaseHelper.SpellDefinitions.InsectPlague);
            DruidSpell_level_5.Spells.Add(DatabaseHelper.SpellDefinitions.MassCureWounds);
            //  DruidSpell_level_5.Spells.Add(DatabaseHelper.SpellDefinitions.);
            //  DruidSpell_level_5.Spells.Add(DatabaseHelper.SpellDefinitions.);
            //  DruidSpell_level_5.Spells.Add(DatabaseHelper.SpellDefinitions.);
            //  DruidSpell_level_5.Spells.Add(DatabaseHelper.SpellDefinitions.);
            //  DruidSpell_level_5.Spells.Add(DatabaseHelper.SpellDefinitions.);
            //  DruidSpell_level_5.Spells.Add(DatabaseHelper.SpellDefinitions.);
            //  DruidSpell_level_5.Spells.Add(DatabaseHelper.SpellDefinitions.);
            //  DruidSpell_level_5.Spells.Add(DatabaseHelper.SpellDefinitions.);
            //  DruidSpell_level_5.Spells.Add(DatabaseHelper.SpellDefinitions.);
            //  DruidSpell_level_5.Spells.Add(DatabaseHelper.SpellDefinitions.);
            //  DruidSpell_level_5.Spells.Add(DatabaseHelper.SpellDefinitions.);



            // adding spells from other mods
            SpellDefinition shillelagh = DatabaseRepository.GetDatabase<SpellDefinition>().TryGetElement("ShillelaghSpell", "8ccfb62d-5119-4a1c-afc4-042e18fb02ca");

            if (shillelagh != null)
            {
                DruidSpell_Cantrips.Spells.Add(shillelagh);
            }

            Definition.SpellsByLevel.Clear();
            Definition.SpellsByLevel.AddRange(new List<SpellListDefinition.SpellsByLevelDuplet> 
            { 
                DruidSpell_Cantrips, 
                DruidSpell_level_1 ,
                DruidSpell_level_2,
                DruidSpell_level_3,
                DruidSpell_level_4,
                DruidSpell_level_5
            });


        }

        public static SpellListDefinition CreateAndAddToDB(string name, string guid)
            => new DruidSpellListBuilder(name, guid).AddToDB();

        public static SpellListDefinition DruidSpellList = CreateAndAddToDB(DruidSpellListName, DruidSpellListGuid);
    }

   
    //    internal class WandOfWildshapeBuilder : BaseDefinitionBuilder<ItemDefinition>
    //    {
    //        const string WandOfWildshapeName = "WandOfWildshape";
    //        const string WandOfWildshapeGuid = "12ec71f9-5e79-46aa-8683-f948f2540a2d";
    //
    //        protected WandOfWildshapeBuilder(string name, string guid) : base(DatabaseHelper.ItemDefinitions.WandMagicMissile, name, guid)
    //        {
    //            Definition.GuiPresentation.Title = "Item/&WandOfWildshapeTitle";
    //            Definition.GuiPresentation.Description = "Item/&WandOfWildshapeDescription";
    //
    //            Definition.SetInDungeonEditor(true);
    //
    //            DeviceFunctionDescription wildshapefunction = new DeviceFunctionDescription();
    //            wildshapefunction.SetCanOverchargeSpell(false);
    //            wildshapefunction.SetDurationType(RuleDefinitions.DurationType.UntilLongRest);
    //            wildshapefunction.SetFeatureDefinitionPower(WildShapePowerBuilder.WildShapePower);
    //            wildshapefunction.SetParentUsage(EquipmentDefinitions.ItemUsage.ByFunction);
    //            wildshapefunction.SetRechargeRate(RuleDefinitions.RechargeRate.LongRest);
    //            wildshapefunction.SetType(DeviceFunctionDescription.FunctionType.Power);
    //            wildshapefunction.SetUseAffinity(DeviceFunctionDescription.FunctionUseAffinity.IterationPerRecharge);
    //            wildshapefunction.SetUseAmount(6);
    //
    //            UsableDeviceDescription usableDeviceDescription = new UsableDeviceDescription();
    //            usableDeviceDescription.SetUsage(EquipmentDefinitions.ItemUsage.ByFunction);
    //            usableDeviceDescription.SetChargesCapitalNumber(5);
    //            usableDeviceDescription.SetRechargeRate(RuleDefinitions.RechargeRate.LongRest);
    //            usableDeviceDescription.SetRechargeNumber(0);
    //            usableDeviceDescription.SetRechargeDie(RuleDefinitions.DieType.D1);
    //            usableDeviceDescription.SetRechargeBonus(5);
    //            usableDeviceDescription.SetOutOfChargesConsequence(EquipmentDefinitions.ItemOutOfCharges.Persist);
    //            usableDeviceDescription.SetMagicAttackBonus(5);
    //            usableDeviceDescription.SetSaveDC(13);
    //
    //            Traverse.Create(usableDeviceDescription).Field("deviceFunctions").SetValue(new List<DeviceFunctionDescription> { wildshapefunction });
    //
    //            Traverse.Create(usableDeviceDescription).Field("itemTags").SetValue(new List<string> { "Consumable" });
    //
    //            Definition.UsableDeviceDescription.DeviceFunctions.Clear();
    //            Definition.UsableDeviceDescription.DeviceFunctions.Add(wildshapefunction);
    //
    //             
    //        }
    //
    //        public static ItemDefinition CreateAndAddToDB(string name, string guid)
    //            => new WandOfWildshapeBuilder(name, guid).AddToDB();
    //
    //        public static ItemDefinition WandOfWildshape = CreateAndAddToDB(WandOfWildshapeName, WandOfWildshapeGuid);
    //    }

    //  internal class DummySavingThrowAffinityBuilder : BaseDefinitionBuilder<FeatureDefinitionSavingThrowAffinity>
    //  {
    //      const string DummySavingThrowAffinityName = "DummySavingThrowAffinityBuilder";
    //      const string DummySavingThrowAffinityGuid = "";
    //
    //      protected DummySavingThrowAffinityBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionSavingThrowAffinitys., name, guid)
    //      {
    //          Definition.GuiPresentation.Title = "Feature/&DummySavingThrowAffinityBuilder";
    //          Definition.GuiPresentation.Description = "Feature/&DummySavingThrowAffinityBuilder";
    //
    //           Definition.AffinityGroups.Clear();
    //          
    //		
    //		
    //          Definition.AffinityGroups.Add();
    //      }
    //
    //      public static FeatureDefinitionSavingThrowAffinity CreateAndAddToDB(string name, string guid)
    //          => new DummySavingThrowAffinityBuilder(name, guid).AddToDB();
    //
    //      public static FeatureDefinitionSavingThrowAffinity DummySavingThrowAffinityBuilder = CreateAndAddToDB(DummySavingThrowAffinityName, DummySavingThrowAffinityGuid);
    //  }
    //
    //  internal class DummyFightingStyleBuilder : BaseDefinitionBuilder<FeatureDefinitionFightingStyleChoice>
    //  {
    //      const string DummyFightingStyleName = "DummyFightingStyle";
    //      const string DummyFightingStyleGuid = "";
    // 
    //      protected DummyFightingStyleBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionFightingStyleChoices.FightingStyleCleric, name, guid)
    //      {
    //          Definition.GuiPresentation.Title = "Feature/&DummyFightingStyleTitle";
    //          Definition.GuiPresentation.Description = ;
    // 
    //          Definition.FightingStyles.Clear();
    //          Definition.FightingStyles.Add();
    //      }
    // 
    //      public static FeatureDefinitionFightingStyleChoice CreateAndAddToDB(string name, string guid)
    //          => new DummyFightingStyleBuilder(name, guid).AddToDB();
    // 
    //      public static FeatureDefinitionFightingStyleChoice DummyFightingStyle = CreateAndAddToDB(DummyFightingStyleName, DummyFightingStyleGuid);
    //  }
    //
    //
    //
    //  internal class DummyMovementAffinityBuilder : BaseDefinitionBuilder<FeatureDefinitionMovementAffinity>
    //  {
    //      const string Name = "DummyMovementAffinityBuilder";
    //      const string Guid = "";
    //
    //      protected DruidClassBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionMovementAffinitys., name, guid)
    //      {
    //          Definition.GuiPresentation.Title = "Feature/&DummyMovementAffinityBuilder";
    //          Definition.GuiPresentation.Description = "Feature/&DummyMovementAffinityBuilder";
    //      }
    //
    //      public static FeatureDefinitionMovementAffinity CreateAndAddToDB(string name, string guid)
    //          => new DummyMovementAffinityBuilder(name, guid).AddToDB();
    //
    //      public static FeatureDefinitionMovementAffinity 
    //          = CreateAndAddToDB(Name, Guid);
    //  }
    //
    //   
    //  internal class DummyPowerBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    //  {
    //      const string Name = "DummyPowerBuilder";
    //      const string Guid = "";
    //
    //      protected DummyPowerBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionPowers., name, guid)
    //      {
    //          Definition.GuiPresentation.Title = "Feature/&DummyPowerBuilderTitle";
    //          Definition.GuiPresentation.Description = "Feature/&DummyPowerBuilderDescription";
    //
    //          Definition.SetRechargeRate(RuleDefinitions.RechargeRate.None);
    //          Definition.SetActivationTime(RuleDefinitions.ActivationTime.Permanent);
    //          Definition.SetCostPerUse(1);
    //          Definition.SetFixedUsesPerRecharge(0);
    //          Definition.SetShortTitleOverride("Feature/&DummyPowerBuilderTitle");
    //          Definition.SetEffectDescription(new EffectDescription());
    //      }
    //
    //      public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
    //          => new DummyPowerBuilder(name, guid).AddToDB();
    //
    //      public static FeatureDefinitionPower DummyPowerBuilder
    //          = CreateAndAddToDB(Name, Guid);
    //  }
    //
    //
    //  internal class DummyConditionBuilder : BaseDefinitionBuilder<ConditionDefinition>
    //  {
    //      const string DummyConditionName = "DummyCondition";
    //      const string DummyConditionGuid = "";
    //
    //      protected DummyConditionBuilder(string name, string guid) : base(DatabaseHelper.ConditionDefinitions., name, guid)
    //      {
    //          Definition.GuiPresentation.Title = "Feature/&DummyConditionTitle";
    //          Definition.GuiPresentation.Description = "Feature/&DummyConditionDescription";
    //
    //          Definition.SetAllowMultipleInstances(false);
    //          Definition.Features.Clear();
    //          
    //		Definition.SetDurationType(RuleDefinitions.DurationType.Minute);
    //          Definition.SetDurationParameter(1);
    //      }
    //
    //      public static ConditionDefinition CreateAndAddToDB(string name, string guid)
    //          => new DummyConditionBuilder(name, guid).AddToDB();
    //
    //      public static ConditionDefinition DummyCondition
    //          = CreateAndAddToDB(DummyConditionName, DummyConditionGuid);
    //  }
    //
    //  /// </summary>
    //   internal class DummyAttackModifierBuilder : BaseDefinitionBuilder<FeatureDefinitionAttackModifier>
    //  {
    //      const string DummyAttackModifierName = "DummyAttackModifier";
    //      const string DummyAttackModifierGuid = "";
    //
    //      protected DummyAttackModifierBuilder(string name, string guid) : base(DatabaseHelper.FeatureDefinitionAttackModifiers., name, guid)
    //      {
    //          Definition.GuiPresentation.Title = "Feature/&DummyAttackModifierTitle";
    //          Definition.GuiPresentation.Description = "Feature/&DummyAttackModifierDescription";
    //
    //          Definition.SetAttackRollModifier(0);
    //          Definition.SetDamageRollModifier(0);
    //
    //	}
    //
    //      public static FeatureDefinitionAttackModifier CreateAndAddToDB(string name, string guid)
    //          => new DummyAttackModifierBuilder(name, guid).AddToDB();
    //
    //      public static FeatureDefinitionAttackModifier DummyAttackModifier
    //          = CreateAndAddToDB(DummyAttackModifierName, DummyAttackModifierGuid);
    //  }
    //
    //
    //  internal class DummyItemBuilder : BaseDefinitionBuilder<ItemDefinition>
    //  {
    //       const string DummyItemName = "DummyItem";
    //       const string DummyItemGuid = "";
    //
    //       protected DummyItemBuilder(string name, string guid) : base(DatabaseHelper.ItemDefinitions., name, guid)
    //       {
    //           Definition.GuiPresentation.Title = "Item/&DummyItemTitle";
    //           Definition.GuiPresentation.Description = "Item/&DummyItemDescription";
    //
    //       }
    //
    //       public static ItemDefinition CreateAndAddToDB(string name, string guid)
    //           => new DummyItemBuilder(name, guid).AddToDB();
    //
    //       public static ItemDefinition HideClothes
    //           = CreateAndAddToDB(DummyItemName, DummyItemGuid);
    //   }
}
