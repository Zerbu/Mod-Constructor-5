using Constructor5.Core;
using Constructor5.Elements.TestConditions;

namespace Constructor5.Elements.ActionTriggers
{
    [XmlSerializerExtraType]
    public class ActionTriggerInfoComponent : ActionTriggerComponent
    {
        public override int ComponentDisplayOrder => -1;
        public override string ComponentLabel => "MainContent";

        public TestCondition TriggerCondition { get; set; } = new NoTestConditionSelected();

        protected internal override void OnExport(ActionTriggerExportContext context)
            => TestConditionTuning.TuneSingleTestCondition(context.Tuning, TriggerCondition, "objective_test");
    }
}