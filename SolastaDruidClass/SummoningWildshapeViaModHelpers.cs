using SolastaModApi;
using SolastaModApi.Extensions;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using HarmonyLib;
using Helpers = SolastaModHelpers.Helpers;


namespace SolastaDruidClass
{

    // CR 0.125:  poisonous_snake, flying snake, eagle matriarch, 
    // CR 0.25 : wolf, 						//starving wolf
    // CR 0.50 : AlphaWolf, BadlandsSpider, black bear
    // CR 1.00 : Dire wolf, giant eagle, brown bear
    // CR 2.00 : tiger_drake, deepspider,  giant beetle


    // No helpers?
    //    internal class   WildshapeChargesPoolBuilder                  : BaseDefinitionBuilder<    FeatureDefinitionAttributeModifier>
    //    internal class   WildshapedCasterActionAffinityBuilder        : BaseDefinitionBuilder<    FeatureDefinitionActionAffinity   >

    // replaced via helpers
    // Helpers.FeatureSetBuilder
    //    internal class   WildshapeFeatureSetBuilder                   : BaseDefinitionBuilder<    FeatureDefinitionFeatureSet       >
    //    internal class   Wildshape_level4FeatureSetBuilder            : BaseDefinitionBuilder<    FeatureDefinitionFeatureSet       >
    //    internal class   Wildshape_level8FeatureSetBuilder            : BaseDefinitionBuilder<    FeatureDefinitionFeatureSet       >
    //    internal class   BeastSpellsFeatureSetBuilder                 : BaseDefinitionBuilder<    FeatureDefinitionFeatureSet       >
    //
    // Helpers.PowerBuilder
    //    internal class   WildShapePowerBuilder                        : BaseDefinitionBuilder<    FeatureDefinitionPower            >
    //    internal class   WildShapePower_AlphaWolfBuilder              : BaseDefinitionBuilder<    FeatureDefinitionPower            >
    //	  internal class   WildShapePower_BadlandsspiderBuilder         : BaseDefinitionBuilder<    FeatureDefinitionPower            >
    //    internal class   WildShapePower_BlackBearBuilder              : BaseDefinitionBuilder<    FeatureDefinitionPower            >
    //    internal class   WildShapePower_DirewolfBuilder               : BaseDefinitionBuilder<    FeatureDefinitionPower            >
    //	  internal class   WildShapePower_Giant_EagleBuilder            : BaseDefinitionBuilder<    FeatureDefinitionPower            >
    //    internal class   WildShapePower_BrownBearBuilder              : BaseDefinitionBuilder<    FeatureDefinitionPower            >
    //
    //    internal class   EndWildShapePowerBuilder                     : BaseDefinitionBuilder<    FeatureDefinitionPower            >
    //    internal class   EndWildShapePowerDeadBeastBuilder            : BaseDefinitionBuilder<    FeatureDefinitionPower            >
    //
    //    internal class   WildShapePower_Direwolf_BeastSpellsBuilder   : BaseDefinitionBuilder<    FeatureDefinitionPower            >
    //    internal class   WildShapePower_Giant_Eagle_BeastSpellsBuilder: BaseDefinitionBuilder<    FeatureDefinitionPower            >
    //
    // Helpers.ConditionBuilder
    //    internal class   CasterWhileWildshapedConditionBuilder        : BaseDefinitionBuilder<    ConditionDefinition               >
    //    internal class   BeastSpellsConditionBuilder                  : BaseDefinitionBuilder<    ConditionDefinition               >


    public class SummoningWildshapes
    {
        static public FeatureDefinitionFeatureSet WildshapeFeatureSet_level_2;
        static public FeatureDefinitionFeatureSet WildshapeFeatureSet_level_4;
        static public FeatureDefinitionFeatureSet WildshapeFeatureSet_level_8;
        static public FeatureDefinitionFeatureSet BeastSpellsFeatureSet;
        static public FeatureDefinitionPower Wildshape_Power;
        static public List<MonsterDefinition> listofbeasts;
        static public Dictionary<string, FeatureDefinitionPower> Dictionaryof_Wildshape_Power = new Dictionary<string, FeatureDefinitionPower>();
        static public FeatureDefinitionPower End_Wildshape_Power;
        static public FeatureDefinitionPower End_Wildshape_DeadBeast_Power;
        static public FeatureDefinitionPower BeastSpells_Wildshape_Power;
        static public List<MonsterDefinition> listof_BeastSpell_beasts; 
        static public Dictionary<string, FeatureDefinitionPower> Dictionaryof_BeastSpell_Wildshape_Power = new Dictionary<string, FeatureDefinitionPower>();
        static public ConditionDefinition Caster_Wildshaped_Condition;
        static public ConditionDefinition Caster_BeastSpells_Wildshaped_Condition;

        internal static void Create()
        {
            Create_Caster_Wildshaped_Condition();
            Create_Caster_BeastSpells_Wildshaped_Condition();
            Create_Wildshape_Power();
            Create_End_Wildshape_Power();
            Create_End_Wildshape_DeadBeast_Power();
            Create_BeastSpells_Wildshape_Power(); 
            Create_WildshapeFeatureSet_level_2();
            Create_WildshapeFeatureSet_level_4();
            Create_WildshapeFeatureSet_level_8();
            Create_BeastSpellsFeatureSet();
        }







        static void Create_WildshapeFeatureSet_level_2()
        {

            var text = "DH_WildshapeFeatureSet_level_2";
            var title_string = "Feature/&" + text + "_Title";
            var description_string = "Feature/&" + text + "_Description";


            WildshapeFeatureSet_level_2 = Helpers.FeatureSetBuilder.createFeatureSet(                                                   //   public static FeatureDefinitionFeatureSet createFeatureSet(
                                                                    text,                                                               //    string name,
                                                                    GuidHelper.Create(Main.ModGuidNamespace, text).ToString(),          //    string guid,
                                                                    title_string,                                                       //    string title_string,
                                                                    description_string,                                                 //    string description_string,
                                                                    false,                                                              //    bool enumerate_in_description,
                                                                    FeatureDefinitionFeatureSet.FeatureSetMode.Union,                   //    FeatureDefinitionFeatureSet.FeatureSetMode set_mode,
                                                                    false,                                                              //    bool unique_choices,
                                                                    //EndWildShapePowerBuilder.EndWildShapePower,                         //    params FeatureDefinition[] features
                                                                    //EndWildShapePowerDeadBeastBuilder.EndWildShapePowerDeadBeast,       //    )
                                                                    //WildShapePowerBuilder.WildShapePower
                                                                    
                                                                    WildshapeChargesPoolBuilder.WildshapeChargesPool,

                                                                    End_Wildshape_Power,
                                                                    End_Wildshape_DeadBeast_Power,
                                                                    Dictionaryof_Wildshape_Power[WildShaped_WolfBuilder.WildShaped_Wolf.Name]

                                                                    );

        }

        static void Create_WildshapeFeatureSet_level_4()
        {

            var text = "DH_WildshapeFeatureSet_level_4";
            var title_string = "Feature/&" + text + "_Title";
            var description_string = "Feature/&" + text + "_Description";


            WildshapeFeatureSet_level_4 = Helpers.FeatureSetBuilder.createFeatureSet(
                                                                    text,
                                                                    GuidHelper.Create(Main.ModGuidNamespace, text).ToString(),
                                                                    title_string,
                                                                    description_string,
                                                                    false,
                                                                    FeatureDefinitionFeatureSet.FeatureSetMode.Union,
                                                                    false,
                                                                     // WildShapePower_BlackBearBuilder.WildShapePower_BlackBear,
                                                                     // listof_Wildshape_Power[WildShapePower_BlackBearBuilder.WildShapePower_BlackBear.Name],

                                                                     // WildShapePower_BadlandsspiderBuilder.WildShapePower_Badlandsspider,
                                                                     //WildShapePower_AlphaWolfBuilder.WildShapePower_AlphaWolf
                                                                     Dictionaryof_Wildshape_Power[WildShaped_BadlandsSpiderBuilder.WildShaped_BadlandsSpider.Name],
                                                                     Dictionaryof_Wildshape_Power[WildShaped_AlphaWolfBuilder.WildShaped_AlphaWolf.Name]


                                                                    );

        }

        static void Create_WildshapeFeatureSet_level_8()
        {

            var text = "DH_WildshapeFeatureSet_level_8";
            var title_string = "Feature/&" + text + "_Title";
            var description_string = "Feature/&" + text + "_Description";


            WildshapeFeatureSet_level_8 = Helpers.FeatureSetBuilder.createFeatureSet(
                                                                    text,
                                                                    GuidHelper.Create(Main.ModGuidNamespace, text).ToString(),
                                                                    title_string,
                                                                    description_string,
                                                                    false,
                                                                    FeatureDefinitionFeatureSet.FeatureSetMode.Union,
                                                                    false,
                                                                    //WildShapePower_BrownBearBuilder.WildShapePower_BrownBear,
                                                                    //Dictionaryof_Wildshape_Power[WildShaped_BrownBearBuilder.WildShaped_BrownBear.Name],


                                                                    //WildShapePower_DirewolfBuilder.WildShapePower_Direwolf,
                                                                    //WildShapePower_Giant_EagleBuilder.WildShapePower_Giant_Eagle
                                                                    Dictionaryof_Wildshape_Power[WildShaped_DirewolfBuilder.WildShaped_Direwolf.Name],
                                                                    Dictionaryof_Wildshape_Power[WildShaped_Giant_EagleBuilder.WildShaped_Giant_Eagle.Name]

                                                                    );

        }


        static void Create_BeastSpellsFeatureSet()
        {

            var text = "DH_BeastSpellsFeatureSet";
            var title_string = "Feature/&" + text + "_Title";
            var description_string = "Feature/&" + text + "_Description";


            BeastSpellsFeatureSet = Helpers.FeatureSetBuilder.createFeatureSet(
                                                                    text,
                                                                    GuidHelper.Create(Main.ModGuidNamespace, text).ToString(),
                                                                    title_string,
                                                                    description_string,
                                                                    false,
                                                                    FeatureDefinitionFeatureSet.FeatureSetMode.Union,
                                                                    false,
                                                                    //WildShapePower_Direwolf_BeastSpellsBuilder.WildShapePower_Direwolf_BeastSpells,
                                                                    //WildShapePower_Giant_Eagle_BeastSpellsBuilder.WildShapePower_Giant_Eagle_BeastSpells

                                                                   //Dictionaryof_BeastSpell_Wildshape_Power[WildShaped_BrownBearBuilder.WildShaped_BrownBear.Name],
                                                                    Dictionaryof_BeastSpell_Wildshape_Power[WildShaped_DirewolfBuilder.WildShaped_Direwolf.Name],
                                                                    Dictionaryof_BeastSpell_Wildshape_Power[WildShaped_Giant_EagleBuilder.WildShaped_Giant_Eagle.Name]
                                                                    );

        }

        

        static void Create_Wildshape_Power()
        {



             listofbeasts = new List<MonsterDefinition> 
                                        { 
                                        WildShaped_WolfBuilder.WildShaped_Wolf ,
                                        WildShaped_AlphaWolfBuilder.WildShaped_AlphaWolf,
                                        WildShaped_BadlandsSpiderBuilder.WildShaped_BadlandsSpider,
                                        WildShaped_DirewolfBuilder.WildShaped_Direwolf,
                                        WildShaped_Giant_EagleBuilder.WildShaped_Giant_Eagle,
                                        //WildShaped_BlackBearBuilder.WildShaped_BlackBear,
                                        //WildShaped_BrownBearBuilder.WildShaped_BrownBear
                                        
                                        };

             

            foreach (MonsterDefinition beast in listofbeasts)
            { 

                 SummonForm SummonWildShape = new SummonForm();
                 SummonWildShape.SetMonsterDefinitionName(beast.Name); 
                 SummonWildShape.SetSummonType(SummonForm.Type.Creature);
                 SummonWildShape.SetNumber(1);
                 SummonWildShape.SetDecisionPackage(DatabaseHelper.DecisionPackageDefinitions.IdleGuard_Default);
                 SummonWildShape.SetEffectProxyDefinitionName(""); 
     
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
               // casterwildshaped.SetConditionDefinitionName(CasterWhileWildshapedConditionBuilder.CasterWhileWildshapedCondition.Name);
               // casterwildshaped.ConditionDefinition = CasterWhileWildshapedConditionBuilder.CasterWhileWildshapedCondition;
             casterwildshaped.SetConditionDefinitionName(Caster_Wildshaped_Condition.Name);
             casterwildshaped.ConditionDefinition = Caster_Wildshaped_Condition;
    
               EffectForm casterwildshapedEffect = new EffectForm();
                casterwildshapedEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
                casterwildshapedEffect.SetLevelMultiplier(1);
                casterwildshapedEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
                casterwildshapedEffect.SetCreatedByCharacter(true);
                casterwildshapedEffect.FormType = EffectForm.EffectFormType.Condition;
                casterwildshapedEffect.ConditionForm = casterwildshaped;
    
    
                EffectDescription effectdescription = new EffectDescription();
                effectdescription.EffectForms.Add(WildShapeEffect);
                effectdescription.EffectForms.Add(casterwildshapedEffect); 
                effectdescription.DurationType = RuleDefinitions.DurationType.Hour;
                effectdescription.DurationParameter = 1;
                effectdescription.SetRangeParameter(1);
                effectdescription.SetRangeType(RuleDefinitions.RangeType.Self);
                effectdescription.SetTargetType(RuleDefinitions.TargetType.Position);
                effectdescription.SetTargetParameter(1);
    
    
    
    
    
                var text = beast.Name+"_Wildshape_Power";
                var title_string = "Feature/&DH_" + text + "_Title";
                var description_string = "Feature/&DH_" + text + "_Description";
    
    
                Wildshape_Power = Helpers.PowerBuilder.createPower
               (                                                                            // public static FeatureDefinitionPower createPower(    
               text,                                                                        //     string name,
               GuidHelper.Create(Main.ModGuidNamespace, text).ToString(),                   //     string guid,
               title_string,                                                                //    string title_string,
               description_string,                                                          //    string description_string,
               DatabaseHelper.MonsterDefinitions.Wolf.GuiPresentation.SpriteReference,      //    AssetReferenceSprite sprite,
               DatabaseHelper.FeatureDefinitionPowers.PowerClericDivineInterventionCleric,  //    FeatureDefinitionPower base_power,
               effectdescription,                                                           //    EffectDescription effect_description,
               RuleDefinitions.ActivationTime.BonusAction,                                  //    RuleDefinitions.ActivationTime activation_time,
               2,                                                                           //    int fixed_uses,
               RuleDefinitions.UsesDetermination.Fixed,                                     //    RuleDefinitions.UsesDetermination uses_determination,
               RuleDefinitions.RechargeRate.ChannelDivinity,                                //    RuleDefinitions.RechargeRate recharge_rate,
               "Wisdom",                                                                    //    string uses_ability = "Strength",
               "Wisdom",                                                                    //    string ability = "Strength",
               1,                                                                           //    int cost_per_use = 1,
               true                                                                         //    bool show_casting = true)
               );
    
    
               if (beast.Name == "WildShaped_AlphaWolf")
               {
                   Wildshape_Power.SetOverriddenPower(Dictionaryof_Wildshape_Power["WildShaped_Wolf"]);
                    Wildshape_Power.GuiPresentation.SetSpriteReference(DatabaseHelper.MonsterDefinitions.AlphaWolf.GuiPresentation.SpriteReference);
               }
               if (beast.Name == "WildShaped_Direwolf")
               {
                   Wildshape_Power.SetOverriddenPower(Dictionaryof_Wildshape_Power["WildShaped_AlphaWolf"]);
                    Wildshape_Power.GuiPresentation.SetSpriteReference(DatabaseHelper.MonsterDefinitions.Direwolf.GuiPresentation.SpriteReference);
                }
                if (beast.Name == "WildShaped_BadlandsSpider")
                {
                      Wildshape_Power.GuiPresentation.SetSpriteReference(DatabaseHelper.MonsterDefinitions.BadlandsSpider.GuiPresentation.SpriteReference);
                }
                if (beast.Name == "WildShaped_BlackBear")
                {
                    Wildshape_Power.GuiPresentation.SetSpriteReference(DatabaseHelper.MonsterDefinitions.BlackBear.GuiPresentation.SpriteReference);
                }
                if (beast.Name == "WildShaped_Giant_Eagle")
                {
                    Wildshape_Power.GuiPresentation.SetSpriteReference(DatabaseHelper.MonsterDefinitions.Giant_Eagle.GuiPresentation.SpriteReference);
                }
                if (beast.Name == "WildShaped_BrownBear")
                {
                    Wildshape_Power.GuiPresentation.SetSpriteReference(DatabaseHelper.MonsterDefinitions.BrownBear.GuiPresentation.SpriteReference);
                }


                Wildshape_Power.SetHasCastingFailure(false);
    
    
               Dictionaryof_Wildshape_Power.Add(beast.Name , Wildshape_Power);
    
            }



             


        }






        static void Create_End_Wildshape_Power()
        {


            ConditionForm endcasterwildshaped = new ConditionForm();
            endcasterwildshaped.SetApplyToSelf(true);
            endcasterwildshaped.SetForceOnSelf(true);
            endcasterwildshaped.Operation = ConditionForm.ConditionOperation.RemoveDetrimentalAll;
            endcasterwildshaped.SetConditionDefinitionName(DatabaseHelper.ConditionDefinitions.ConditionDebugInvicible.Name);
            endcasterwildshaped.ConditionDefinition = DatabaseHelper.ConditionDefinitions.ConditionDebugInvicible;
            endcasterwildshaped.DetrimentalConditions.AddRange(new List<ConditionDefinition>
            {

                Caster_Wildshaped_Condition,
                Caster_BeastSpells_Wildshaped_Condition

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



            var text = "DH_End_Wildshape_Power";
            var title_string = "Feature/&" + text + "_Title";
            var description_string = "Feature/&" + text + "_Description";


            End_Wildshape_Power = Helpers.PowerBuilder.createPower
            (                                                                            // public static FeatureDefinitionPower createPower(    
            text,                                                                        //     string name,
            GuidHelper.Create(Main.ModGuidNamespace, text).ToString(),                   //     string guid,
            title_string,                                                                //    string title_string,
            description_string,                                                          //    string description_string,
            DatabaseHelper.SpellDefinitions.AnimalFriendship.GuiPresentation.SpriteReference,      //    AssetReferenceSprite sprite,
            Wildshape_Power,                                                             //    FeatureDefinitionPower base_power,
            effectdescription,                                                           //    EffectDescription effect_description,
            RuleDefinitions.ActivationTime.Action,                                       //    RuleDefinitions.ActivationTime activation_time,
            2,                                                                           //    int fixed_uses,
            RuleDefinitions.UsesDetermination.Fixed,                                     //    RuleDefinitions.UsesDetermination uses_determination,
            RuleDefinitions.RechargeRate.AtWill,                                         //    RuleDefinitions.RechargeRate recharge_rate,
            "Wisdom",                                                                    //    string uses_ability = "Strength",
            "Wisdom",                                                                    //    string ability = "Strength",
            1,                                                                           //    int cost_per_use = 1,
            true                                                                         //    bool show_casting = true)
            );


        }

        //          Create_End_Wildshape_DeadBeast_Power
        static void Create_End_Wildshape_DeadBeast_Power()
        {
            ConditionForm endcasterwildshaped = new ConditionForm();
            endcasterwildshaped.SetApplyToSelf(true);
            endcasterwildshaped.SetForceOnSelf(true);
            endcasterwildshaped.Operation = ConditionForm.ConditionOperation.RemoveDetrimentalAll;
            endcasterwildshaped.SetConditionDefinitionName(DatabaseHelper.ConditionDefinitions.ConditionDebugInvicible.Name);
            endcasterwildshaped.ConditionDefinition = DatabaseHelper.ConditionDefinitions.ConditionDebugInvicible;
            endcasterwildshaped.DetrimentalConditions.AddRange(new List<ConditionDefinition>
            {

                Caster_Wildshaped_Condition,
                Caster_BeastSpells_Wildshaped_Condition

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



            var text = "DH_End_Wildshape_DeadBeast_Power";
            var title_string = "Feature/&" + text + "_Title";
            var description_string = "Feature/&" + text + "_Description";


            End_Wildshape_DeadBeast_Power = Helpers.PowerBuilder.createPower
            (                                                                            // public static FeatureDefinitionPower createPower(    
            text,                                                                        //     string name,
            GuidHelper.Create(Main.ModGuidNamespace, text).ToString(),                   //     string guid,
            title_string,                                                                //    string title_string,
            description_string,                                                          //    string description_string,
            DatabaseHelper.SpellDefinitions.DominateBeast.GuiPresentation.SpriteReference,      //    AssetReferenceSprite sprite,
            Wildshape_Power,                                                             //    FeatureDefinitionPower base_power,
            effectdescription,                                                           //    EffectDescription effect_description,
            RuleDefinitions.ActivationTime.Action,                                       //    RuleDefinitions.ActivationTime activation_time,
            2,                                                                           //    int fixed_uses,
            RuleDefinitions.UsesDetermination.Fixed,                                     //    RuleDefinitions.UsesDetermination uses_determination,
            RuleDefinitions.RechargeRate.AtWill,                                         //    RuleDefinitions.RechargeRate recharge_rate,
            "Wisdom",                                                                    //    string uses_ability = "Strength",
            "Wisdom",                                                                    //    string ability = "Strength",
            1,                                                                           //    int cost_per_use = 1,
            true                                                                         //    bool show_casting = true)
            ); 
        }




        static void Create_BeastSpells_Wildshape_Power()
        {

             listof_BeastSpell_beasts = new List<MonsterDefinition>
                                        {
                                        WildShaped_DirewolfBuilder.WildShaped_Direwolf,
                                        WildShaped_Giant_EagleBuilder.WildShaped_Giant_Eagle,
                                        //WildShaped_BrownBearBuilder.WildShaped_BrownBear
                                        
                                        };


            foreach (MonsterDefinition beast in listof_BeastSpell_beasts)
            {
                var text = beast.Name + "_BeastSpells_Wildshape_Power";
                var title_string = "Feature/&DH_" + text + "_Title";
                var description_string = "Feature/&DH_" + text + "_Description";


                BeastSpells_Wildshape_Power = Helpers.PowerBuilder.createPower
                (                                                                            // public static FeatureDefinitionPower createPower(    
                text,                                                                        //     string name,
                GuidHelper.Create(Main.ModGuidNamespace, text).ToString(),                   //     string guid,
                title_string,                                                                //    string title_string,
                description_string,                                                          //    string description_string,
                DatabaseHelper.MonsterDefinitions.Wolf.GuiPresentation.SpriteReference,      //    AssetReferenceSprite sprite,
                Wildshape_Power,  //    FeatureDefinitionPower base_power,
                Wildshape_Power.EffectDescription,                                                           //    EffectDescription effect_description,
                RuleDefinitions.ActivationTime.BonusAction,                                  //    RuleDefinitions.ActivationTime activation_time,
                2,                                                                           //    int fixed_uses,
                RuleDefinitions.UsesDetermination.Fixed,                                     //    RuleDefinitions.UsesDetermination uses_determination,
                RuleDefinitions.RechargeRate.ChannelDivinity,                                //    RuleDefinitions.RechargeRate recharge_rate,
                "Wisdom",                                                                    //    string uses_ability = "Strength",
                "Wisdom",                                                                    //    string ability = "Strength",
                1,                                                                           //    int cost_per_use = 1,
                true                                                                         //    bool show_casting = true)
                );

                BeastSpells_Wildshape_Power.EffectDescription.EffectForms[0].SummonForm.SetMonsterDefinitionName(beast.Name);
                BeastSpells_Wildshape_Power.EffectDescription.EffectForms[1].ConditionForm.SetConditionDefinition(Caster_BeastSpells_Wildshaped_Condition);

                if (beast.Name== "WildShaped_Direwolf")
                {
                    BeastSpells_Wildshape_Power.SetOverriddenPower(Dictionaryof_Wildshape_Power["WildShaped_Direwolf"]);
                    Wildshape_Power.GuiPresentation.SetSpriteReference(DatabaseHelper.MonsterDefinitions.Direwolf.GuiPresentation.SpriteReference);
                }
                if (beast.Name == "WildShaped_Giant_Eagle")
                {
                    BeastSpells_Wildshape_Power.SetOverriddenPower(Dictionaryof_Wildshape_Power["WildShaped_Giant_Eagle"]);
                    Wildshape_Power.GuiPresentation.SetSpriteReference(DatabaseHelper.MonsterDefinitions.Giant_Eagle.GuiPresentation.SpriteReference);
                }
                if (beast.Name == "WildShaped_BrownBear")
                {
                    BeastSpells_Wildshape_Power.SetOverriddenPower(Dictionaryof_Wildshape_Power["WildShaped_BrownBear"]);
                    Wildshape_Power.GuiPresentation.SetSpriteReference(DatabaseHelper.MonsterDefinitions.BrownBear.GuiPresentation.SpriteReference);
                }

 

                Dictionaryof_BeastSpell_Wildshape_Power.Add(beast.Name, BeastSpells_Wildshape_Power);
            }

        }


      
      
      
      
      
      
      
      
      
      


        static void Create_Caster_Wildshaped_Condition()
        {


            var text = "DH_Caster_Wildshaped_Condition";
            var title_string = "Feature/&" + text + "_Title";
            var description_string = "Feature/&" + text + "_Description";


            Caster_Wildshaped_Condition = Helpers.ConditionBuilder.createCondition       //  public static ConditionDefinition createCondition
            (                                                                            //  (
            text,                                                                        //  string name,
            GuidHelper.Create(Main.ModGuidNamespace, text).ToString(),                   //  string guid,
            title_string,                                                                //  string title_string,
            description_string,                                                          //  string description_string,
            DatabaseHelper.ConditionDefinitions.ConditionBanished.GuiPresentation.SpriteReference,      //  AssetReferenceSprite sprite,
            DatabaseHelper.ConditionDefinitions.ConditionBanished,                    //  ConditionDefinition base_condititon,

            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleAcid,  //  params FeatureDefinition[] features                                                                         //  )                            
            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleBludgeoning,
            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleCold,
            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleFire,
            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleForce,
            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleLightning,
            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleNecrotic,
            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInviciblePiercing,
            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInviciblePoison,
            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInviciblePsychic,
            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleRadiant,
            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleSlashing,
            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleThunder,
            WildshapedCasterActionAffinityBuilder.WildshapedCasterActionAffinity
            );

            
        }

        static void Create_Caster_BeastSpells_Wildshaped_Condition()
        {


            var text = "DH_Caster_BeastSpells_Wildshaped_Condition";
            var title_string = "Feature/&" + text + "_Title";
            var description_string = "Feature/&" + text + "_Description";


            Caster_BeastSpells_Wildshaped_Condition = Helpers.ConditionBuilder.createCondition       //  public static ConditionDefinition createCondition
            (                                                                            //  (
            text,                                                                        //  string name,
            GuidHelper.Create(Main.ModGuidNamespace, text).ToString(),                   //  string guid,
            title_string,                                                                //  string title_string,
            description_string,                                                          //  string description_string,
            DatabaseHelper.MonsterDefinitions.Wolf.GuiPresentation.SpriteReference,      //  AssetReferenceSprite sprite,
            DatabaseHelper.ConditionDefinitions.ConditionInvisibleGreater,                    //  ConditionDefinition base_condititon,

            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleAcid,  //  params FeatureDefinition[] features                                                                         //  )                            
            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleBludgeoning,
            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleCold,
            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleFire,
            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleForce,
            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleLightning,
            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleNecrotic,
            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInviciblePiercing,
            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInviciblePoison,
            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInviciblePsychic,
            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleRadiant,
            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleSlashing,
            DatabaseHelper.FeatureDefinitionDamageAffinitys.DamageAffinityDebugInvicibleThunder 
            );
        }
    }

}