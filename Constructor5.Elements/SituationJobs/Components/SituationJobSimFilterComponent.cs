using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Elements.Situations.Components;
using Constructor5.UI.AutoGeneratedEditors;
using Constructor5.UI.Shared;
using Constructor5.Core;
using System;

namespace Constructor5.Elements.SituationJobs.Components
{
    [XmlSerializerExtraType]
    [HasAutoEditor("Only Sims that match this filter can be part of the situation.")]
    public class SituationJobSimFilterComponent : SituationJobComponent
    {
        public override string ComponentLabel => "Filter";

        [AutoTuneBasic("filter")]
        [AutoEditorReferenceWithEditorUnderneath("SimFilter", ResetTo = 30732, ResetToLabel = "Child to Elder")]
        public Reference Filter { get; set; } = new Reference() { GameReference = 30732, GameReferenceLabel = "Child to Elder" };

        protected internal override void OnExport(SituationJobExportContext context) => AutoTunerInvoker.Invoke(this, context.Tuning);
    }
}
