using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Xml;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.SituationGoals.Templates
{
    [XmlSerializerExtraType]
    [SelectableObjectType("SituationGoalTemplates", "Multiple Sims In Interaction Goal")]
    public class SituationGoalMultipleSimsInInteractionTemplate : SituationGoalTemplate
    {
        public bool InSituationOnly { get; set; } = true;
        public ObservableCollection<string> InteractionTags { get; } = new ObservableCollection<string>();
        public override string Label => "Multiple Sims In Interaction Goal";
        public int NumberOfSims { get; set; } = 2;
        [AutoTuneBasic("affordance")]
        public Reference SpecificInteraction { get; set; } = new Reference();

        protected override void OnExport(SituationGoalExportContext context)
        {
            var tuningHeader = (TuningHeader)context.Tuning;
            tuningHeader.Class = "SituationGoalMultipleSimsInInteraction";
            tuningHeader.Module = "situations.situation_goal_multi_sim";

            var goalTest = context.Tuning.Get<TunableTuple>("_goal_test");
            AutoTunerInvoker.Invoke(this, goalTest);

            foreach (var tag in InteractionTags)
            {
                var tunableList2 = goalTest.Get<TunableList>("tags");
                tunableList2.Set<TunableEnum>(null, tag);
            }

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