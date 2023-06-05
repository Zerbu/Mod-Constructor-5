using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.Elements.SituationGoals.Templates
{
    [XmlSerializerExtraType]
    [SelectableObjectType("SituationGoalTemplates", "SimTraitGoal")]
    public class SituationGoalActorTraitTemplate : SituationGoalTemplate
    {
        public bool IgnoreIfAlreadyMet { get; set; }
        public override string Label => "Sim Trait Goal";

        [AutoTuneBasic("num_whitelist_required", IgnoreIf = 1)]
        public int NumWhitelistRequired { get; set; } = 1;

        [AutoTuneEnum("subject")]
        public string Participant { get; set; }

        [AutoTuneReferenceList("whitelist_traits")]
        public ReferenceList Whitelist { get; set; } = new ReferenceList();

        protected override void OnExport(SituationGoalExportContext context)
        {
            var tuningHeader = (TuningHeader)context.Tuning;
            tuningHeader.Class = "SituationGoalActorTrait";
            tuningHeader.Module = "situations.situation_goal_actor";

            AutoTunerInvoker.Invoke(this, tuningHeader.Get<TunableTuple>("_goal_test"));
        }
    }
}
