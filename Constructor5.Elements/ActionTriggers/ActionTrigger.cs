using Constructor5.Base.ComponentSystem;
using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.ProjectSystem;
using Constructor5.Base.Python;
using Constructor5.Elements.TestConditions;

namespace Constructor5.Elements.ActionTriggers
{
    [ElementTypeData("ActionTrigger", true, ElementTypes = new[] { typeof(ActionTrigger) }, IsRootType = true)]
    public class ActionTrigger : SimpleComponentElement<ActionTriggerComponent>, ISupportsCustomTuning
    {
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        void IExportableElement.OnExport()
        {
            PythonBuilder.AddStep(ImportActionTriggerPythonStep.Current);

            var tuning = ElementTuning.Create(this);
            tuning.Class = "ActionTrigger";
            tuning.InstanceType = "objective";
            tuning.Module = Project.Id;

            var context = new ActionTriggerExportContext
            {
                Element = this,
                Tuning = tuning
            };

            foreach (var component in Components)
            {
                component.OnExport(context);
            }

            //TestConditionTuning.TuneSingleTestCondition(tuning, TriggerCondition, "objective_test");

            //AutoTunerInvoker.Invoke(this, tuning);

            CustomTuningExporter.Export(this, tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }
    }
}