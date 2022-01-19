using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.SituationGoals;
using Constructor5.TestConditionTypes.Relationships;

namespace Constructor5.SituationGoalTemplates.Single
{
    [XmlSerializerExtraType]
    [SelectableObjectType("SituationGoalTemplates", "RelationshipChangedwithTargetGoal")]
    public class SituationGoalRelationshipChangedTemplate : SituationGoalTargetedBase
    {
        public override string Label => "Relationship Changed with Target Goal";

        public SituationGoalRelationshipSettings RelationshipConditions { get; set; } = new SituationGoalRelationshipSettings();
        public bool HasRelationshipPreConditions { get; set; }
        public SituationGoalRelationshipSettings RelationshipPreConditions { get; set; } = new SituationGoalRelationshipSettings();

        protected override void OnExport(SituationGoalExportContext context)
        {
            var tuningHeader = (TuningHeader)context.Tuning;
            tuningHeader.Class = "SituationGoalRelationshipChangeTargetedSim";
            tuningHeader.Module = "situations.situation_goal_targeted_sim";

            var tuple = context.Tuning.Get<TunableTuple>("_goal_test");
            AutoTunerInvoker.Invoke(RelationshipConditions, tuple);
            RelationshipConditionBitsTuner.TuneBits(tuple, RelationshipConditions.RequiredBitsAll, RelationshipConditions.RequiredBitsAny, RelationshipConditions.ProhibitedBitsAll, RelationshipConditions.ProhibitedBitsAny);

            if (HasRelationshipPreConditions)
            {
                var preTuple = context.Tuning.Get<TunableTuple>("_relationship_pretest");
                AutoTunerInvoker.Invoke(RelationshipPreConditions, preTuple);
                RelationshipConditionBitsTuner.TuneBits(preTuple, RelationshipPreConditions.RequiredBitsAll, RelationshipPreConditions.RequiredBitsAny, RelationshipPreConditions.ProhibitedBitsAll, RelationshipPreConditions.ProhibitedBitsAny);
            }

            TuneTarget(context);
        }
    }
}