using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Elements.Careers.Components;
using Constructor5.Elements.Interactions.Shared;

namespace Constructor5.Elements.Interactions.Career
{
    [ElementTypeData("CareerInteraction", false, ElementTypes = new[] { typeof(CareerInteraction) })]
    public class CareerInteraction : InteractionElement, IExportableElement, ISupportsCustomTuning
    {
        public Reference BalloonSet { get; set; } = new Reference();
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "CareerSuperInteraction";
            tuning.InstanceType = "interaction";
            tuning.Module = "careers.career_interactions";

            Tune(tuning);

            CustomTuningExporter.Export(this, tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }

        protected internal override void TuneTags(InteractionExportContext context)
        {
        }

        private void Tune(TuningHeader tuning)
        {
            var actionFile = "Career Interaction";

            var modifier = GetContextModifier<CareerInteractionContextModifier>();
            if (modifier != null)
            {
                actionFile = ((Careers.Career)modifier.Career.Element).GetComponent<CareerTemplateComponent>().Template.GetInteractionTuningActionsFile();
            }

            TuningActionInvoker.InvokeFromFile(actionFile, new TuningActionContext
            {
                Tuning = tuning,
                DataContext = this
            });
        }
    }
}