using System.Collections.Generic;

namespace Constructor5.DebugTools.PresetExtractor
{
    public static class InstructionBatches
    {
        public static PresetInstruction[] Animation { get; } = PresetInstruction.CreateBatch("Animation", "Animation", "All Animations", "", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] AspirationCategories { get; } = PresetInstruction.CreateBatch("Aspiration_Category", "AspirationCategory", "All Aspiration Categories", "display_text", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] AspirationTracks { get; } = PresetInstruction.CreateBatch("Aspiration_Track", "AspirationTrack", "All Aspiration Tracks", "display_text", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] Balloon { get; } = PresetInstruction.CreateBatch("Balloon", "Balloon", "All Balloon Sets", "", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] Broadcasters { get; } = PresetInstruction.CreateBatch("Broadcaster", "Broadcaster", "All Broadcasters", "", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] BucksPerks { get; } = PresetInstruction.CreateBatch("Bucks_Perk", "BucksPerk", "All Perks", "display_name", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] Buffs { get; } = PresetInstruction.CreateBatch("Buff", "Buff", "All Buffs", "buff_name", new Dictionary<string, string>
        {
            { "Autonomy Buffs", "AutonomyMod_" },
            { "Emotion Buffs", "MoodBuff_" },
            { "Festival Buffs", "Buff_Festival_" },
            { "Role Buffs", "Role_" },
        });

        public static PresetInstruction[] Commodities { get; } = PresetInstruction.CreateBatch("Statistic", "Commodity", "All Commodities", "stat_name", new Dictionary<string, string>
        {
            { "Autonomy", "_Autonomy_" },
        }, "Commodity");

        public static PresetInstruction[] CommodityBasedObjectStateValues { get; } = PresetInstruction.CreateBatch("Object_State", "CommodityBasedObjectStateValue", "All Commodity Based Object State Values", "", new Dictionary<string, string>
        {
        }, "CommodityBasedObjectStateValue");

        public static PresetInstruction[] Interactions { get; } = PresetInstruction.CreateBatch("Interaction", "Interaction", "All Interactions", "display_name", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] Loot { get; } = PresetInstruction.CreateBatch("Action", "Loot", "All Loot Actions", "", new Dictionary<string, string>
        {
            { "Career Daily Tasks", "CareerBenefit_" },
            { "Character Values", "LifeSkill_" },
            { "Reputation", "Reputation_" },
            { "Relationship Gain", "relationship_change" },
        });

        public static PresetInstruction[] MixerInteractions { get; } = PresetInstruction.CreateBatch("Interaction", "MixerInteraction", "All Mixer Interactions", "display_name", new Dictionary<string, string>
        {
        }, "MixerInteraction");

        public static PresetInstruction[] Objects { get; } = PresetInstruction.CreateBatch("Object", "Object", "All Objects", "display_text", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] Objectives { get; } = PresetInstruction.CreateBatch("Objective", "Objective", "All Objectives", "display_text", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] ObjectiveSets { get; } = PresetInstruction.CreateBatch("Aspiration", "ObjectiveSet", "All Objective Sets", "display_text", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] Outfits { get; } = PresetInstruction.CreateBatch("Snippet", "Outfit", "All Outfits", "display_text", new Dictionary<string, string> { }, "Outfit");

        public static PresetInstruction[] PieMenuCategories { get; } = PresetInstruction.CreateBatch("Pie_Menu_Category", "PieMenuCategory", "All Pie Menu Categories", "_display_name", new Dictionary<string, string>
        {
            { "Conversation Topics - Friendly", "SubCat_Friendly" },
            { "Conversation Topics - Funny", "SubCat_Funny" },
            { "Conversation Topics - Mean", "SubCat_Mean" },
            { "Conversation Topics - Mischief", "SubCat_Mischief" },
            { "Conversation Topics - Romantic", "SubCat_Romantic" },
        });

        public static PresetInstruction[] Recipes { get; } = PresetInstruction.CreateBatch("Recipe", "Recipe", "All Recipes", "name", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] Rewards { get; } = PresetInstruction.CreateBatch("Reward", "Reward", "All Rewards", "name", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] RoleStates { get; } = PresetInstruction.CreateBatch("Role_State", "RoleState", "All Role States", "", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] SimFilters { get; } = PresetInstruction.CreateBatch("Sim_Filter", "SimFilter", "All Sim Filters", "", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] SituationGoals { get; } = PresetInstruction.CreateBatch("Situation_Goal", "SituationGoal", "All Situation Goals", "enabled", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] SituationGoalSets { get; } = PresetInstruction.CreateBatch("Situation_Goal_Set", "SituationGoalSet", "All Situation Goal Sets", "", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] SituationJobs { get; } = PresetInstruction.CreateBatch("Situation_Job", "SituationJob", "All Situation Jobs", "tooltip_name", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] Situations { get; } = PresetInstruction.CreateBatch("Situation", "Situation", "All Situations", "_display_name", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] Skills { get; } = PresetInstruction.CreateBatch("Statistic", "Skill", "All Skills", "stat_name", new Dictionary<string, string>
        {
            { "Mental Skills", "Skill_Mental" },
            { "Creative Skills", "Skill_Creative" },
            { "Physical Skills", "Skill_Physical" },
            { "Social Skills", "Skill_Social" },
        }, "Skill");

        public static PresetInstruction[] SocialInteractions { get; } = PresetInstruction.CreateBatch("Interaction", "SocialInteraction", "All Social Interactions", "display_name", new Dictionary<string, string>
        {
        }, "SocialMixerInteraction");

        public static PresetInstruction[] Traits { get; } = PresetInstruction.CreateBatch("Trait", "Trait", "All Traits", "display_name", new Dictionary<string, string>
        {
            { "Personality Traits", ">PERSONALITY" },
            { "Gameplay Traits", ">GAMEPLAY" },
            { "Fame Traits", "Fame" },
            { "Aspiration CAS Traits", ">ASPIRATION" },
            { "Ghost Traits", ">GHOST" },
            { "Hidden Traits", ">HIDDEN" },
            { "Phase Traits", ">PHASE" },
            { "University Degrees", ">UNIVERSITY" },
            { "Walk Styles", ">WALKSTYLE" },
            { "Likes", ">LIKE" },
            { "Dislikes", ">DISLIKE" },
        });

        public static PresetInstruction[] Venues { get; } = PresetInstruction.CreateBatch("Venue", "Venue", "All Venues", "display_name", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] Whims { get; } = PresetInstruction.CreateBatch("Whim", "Whim", "All Whims", "display_name", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] InteractionLists { get; } = PresetInstruction.CreateBatch("Snippet", "InteractionList", "All Interaction Lists", "display_name", new Dictionary<string, string>
        {
        }, "AffordanceList");

        public static PresetInstruction[] SimpleWhimSets { get; } = PresetInstruction.CreateBatch("Aspiration", "ObjectivelessWhimSet", "All Simple Want Sets", "reason", new Dictionary<string, string>
        {
        }, "ObjectivelessWhimSet");

        public static PresetInstruction[] CareerGigs { get; } = PresetInstruction.CreateBatch("Career_Gig", "CareerGig", "All Career Gigs", "enabled", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] TestBasedScores { get; } = PresetInstruction.CreateBatch("Test_Based_Score", "TestBasedScore", "All Test Based Scores", "reason", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] TemplateChoosers { get; } = PresetInstruction.CreateBatch("Template_Chooser", "TemplateChooser", "All Template Choosers", "reason", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] Regions { get; } = PresetInstruction.CreateBatch("Region", "Region", "All Worlds", "reason", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] ZoneModifiers { get; } = PresetInstruction.CreateBatch("Zone_Modifier", "ZoneModifier", "All Lot Traits", "reason", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] ZoneDirectors { get; } = PresetInstruction.CreateBatch("Zone_Director", "ZoneDirector", "All Zone Directors", "reason", new Dictionary<string, string>
        {
        });
    }
}