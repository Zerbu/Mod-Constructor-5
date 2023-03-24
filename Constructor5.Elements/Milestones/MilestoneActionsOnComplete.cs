using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Core;

namespace Constructor5.Elements.Milestones
{
    [XmlSerializerExtraType]
    public class MilestoneActionsOnComplete : MilestoneComponent
    {
        [AutoTuneReferenceList("loot")]
        public ReferenceList ActionSets { get; set; } = new ReferenceList();

        public override int ComponentDisplayOrder => 20;
        public override string ComponentLabel => "ActionsOnComplete";

        protected internal override void OnExport(MilestoneExportContext context)
        {
            AutoTunerInvoker.Invoke(this, context.Tuning);
        }
    }
}