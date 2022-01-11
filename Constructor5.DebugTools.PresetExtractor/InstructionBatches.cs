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

        public static PresetInstruction[] Buffs { get; } = PresetInstruction.CreateBatch("Buff", "Buff", "All Buff", "buff_name", new Dictionary<string, string>
        {
            { "Autonomy Buffs", "AutonomyMod_" },
            { "Emotion Buffs", "MoodBuff_" },
            { "Festival Buffs", "Buff_Festival_" },
            { "Role Buffs", "Role_" },
        });

        public static PresetInstruction[] Commodities { get; } = PresetInstruction.CreateBatch("Commodity", "Commodity", "All Commodities", "stat_name", new Dictionary<string, string>
        {
            { "Autonomy", "_Autonomy_" },
        });

        public static PresetInstruction[] Loot { get; } = PresetInstruction.CreateBatch("Action", "Loot", "All Loot Actions", "", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] Objectives { get; } = PresetInstruction.CreateBatch("Objective", "Objective", "All Objectives", "display_text", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] ObjectiveSets { get; } = PresetInstruction.CreateBatch("Aspiration", "ObjectiveSet", "All Objective Sets", "display_text", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] PieMenuCategories { get; } = PresetInstruction.CreateBatch("Pie_Menu_Category", "PieMenuCategory", "All Pie Menu Categories", "_display_name", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] Rewards { get; } = PresetInstruction.CreateBatch("Reward", "Reward", "All Rewards", "name", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] SituationGoals { get; } = PresetInstruction.CreateBatch("Situation_Goal", "SituationGoal", "All Situation Goals", "enabled", new Dictionary<string, string>
        {
        });

        public static PresetInstruction[] SituationGoalSets { get; } = PresetInstruction.CreateBatch("Situation_Goal_Set", "SituationGoalSet", "All Situation Goal Sets", "", new Dictionary<string, string>
        {
        });

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
    }
}