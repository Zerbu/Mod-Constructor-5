using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Xml;

namespace Constructor5.Elements.SituationGoals.Templates
{
    [XmlSerializerExtraType]
    [SelectableObjectType("SituationGoalTemplates", "Multiple Sims In Emotion Goal")]
    public class SituationGoalMultipleSimsInEmotionTemplate : SituationGoalTemplate
    {
        public bool InSituationOnly { get; set; } = true;
        public override string Label => "Multiple Sims In Interaction Goal";
        public int NumberOfSims { get; set; } = 2;

        [AutoTuneBasic("mood")]
        public Reference Emotion { get; set; } = new Reference();

        protected override void OnExport(SituationGoalExportContext context)
        {
            var tuningHeader = (TuningHeader)context.Tuning;
            tuningHeader.Class = "SituationGoalMultipleSimsInMood";
            tuningHeader.Module = "situations.situation_goal_multi_sim";

            var goalTest = context.Tuning.Get<TunableTuple>("_goal_test");
            AutoTunerInvoker.Invoke(this, goalTest);

            var tunableVariant1 = goalTest.Set<TunableVariant>("sim_count", "fixed");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("fixed");
            tunableTuple1.Set<TunableBasic>("count", NumberOfSims);

            if (!InSituationOnly)
            {
                tuningHeader.Set<TunableBasic>("_select_all_instantiated_sims", "True");
            }
        }
    }
}