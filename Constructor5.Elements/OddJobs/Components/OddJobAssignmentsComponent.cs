using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Core;
using System;

namespace Constructor5.Elements.OddJobs.Components
{
    [XmlSerializerExtraType]
    public class OddJobAssignmentsComponent : OddJobComponent
    {
        public override string ComponentLabel => "Assignments";

        public bool IsAssignmentJob { get; set; }

        public Reference ObjectiveSet { get; set; } = new Reference();

        protected internal override void OnExport(OddJobExportContext context)
        {
            if (!IsAssignmentJob)
            {
                return;
            }

            ((TuningHeader)context.Tuning).Class = "HomeAssignmentGig";
            ((TuningHeader)context.Tuning).Module = "careers.home_assignment_career_gig";

            var info = context.Element.GetComponent<OddJobInfoComponent>();
            var specialCasesComponent = context.Element.GetComponent<OddJobSpecialCasesComponent>();
            TuningActionInvoker.InvokeFromFile("Odd Job Assignment", new TuningActionContext
            {
                DataContext = info,
                Tuning = context.Tuning,
                Variables =
                {
                    { "Career", ElementTuning.GetSingleInstanceKey(specialCasesComponent.Career).ToString() },
                    { "DurationHoursMinusOne", (info.DurationHours-1).ToString() },
                    { "ObjectiveSet", ElementTuning.GetSingleInstanceKey(ObjectiveSet).ToString() }
                }
            });
        }
    }
}