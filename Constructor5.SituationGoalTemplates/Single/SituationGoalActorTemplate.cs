using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.TestConditions;
using Constructor5.Xml;

namespace Constructor5.Elements.SituationGoals.Templates
{
    [XmlSerializerExtraType]
    [SelectableObjectType("SituationGoalTemplates", "Sim Condition Goal")]
    public class SituationGoalActorTemplate : SituationGoalTemplate
    {
        public bool IgnoreIfAlreadyMet { get; set; }
        public override string Label => "Sim Condition Goal";
        public TestCondition PrimaryCondition { get; set; } = new AlwaysRunCondition();

        protected override void OnExport(SituationGoalExportContext context)
        {
            var tuningHeader = (TuningHeader)context.Tuning;
            tuningHeader.Class = "SituationGoalActor";
            tuningHeader.Module = "situations.situation_goal_actor";

            if (!IgnoreIfAlreadyMet)
            {
                tuningHeader.Set<TunableBasic>("ignore_goal_precheck", "True");
            }

            TestConditionTuning.TuneSingleTestCondition(tuningHeader, PrimaryCondition, "_goal_test");
        }
    }
}