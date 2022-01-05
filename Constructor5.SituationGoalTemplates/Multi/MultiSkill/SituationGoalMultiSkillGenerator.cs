using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.SituationGoals;
using Constructor5.Elements.SituationGoals.Templates;
using Constructor5.Xml;
using System.Collections.Generic;

namespace Constructor5.SituationGoalTemplates.Multi.MultiSkill
{
    [XmlSerializerExtraType]
    //[SelectableObjectType("SituationGoalTemplates", "Experimental: Generate Multiple Skill Goals", Description = "Generates a goal for each level in a skill, with the score increasing for each level.")]
    public class SituationGoalMultiSkillGenerator : SituationGoalMultiGenerator
    {
        public override string Label => "Generate Multiple Skill Goals";

        public int MaxLevel { get; set; } = 10;
        public Reference Skill { get; set; } = new Reference();

        protected override ulong[] GetInstanceKeys(SituationGoalExportContext context)
        {
            var result = new List<ulong>();
            for (int level = 2; level <= MaxLevel; level++)
            {
                result.Add(ElementTuning.GetInstanceKeyFromName(context.Element, $"Level{level}"));
            }
            return result.ToArray();
        }

        protected override void OnExport(SituationGoalExportContext context)
        {
            for (int level = 2; level <= MaxLevel; level++)
            {
                var tuning = SituationGoalTuner.CreateTuning(context.Element, new SituationGoalExportContext { MultiGeneratorSubTuningName = $"Level{level}" });
                TuningExport.AddToQueue(tuning);
            }
        }
    }
}