using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;

namespace Constructor5.TestConditionTypes.Relationships
{
    [SelectableObjectType("TestConditionTypes", "RelationshipCondition")]
    [SelectableObjectType("ObjectiveConditionTypes", "RelationshipCondition")]
    [SelectableObjectType("HolidayTraditionConditionTypes", "RelationshipCondition")]
    [XmlSerializerExtraType]
    public class RelationshipCondition : TestCondition
    {
        public RelationshipCondition() => GeneratedLabel = "Relationship Condition";

        public bool InvertNumRelationshipsAll { get; set; }
        public bool InvertNumRelationshipsParticipant { get; set; }

        public int NumRelationshipsAll { get; set; } = 0;
        public int NumRelationshipsParticipant { get; set; } = 1;

        public string PrimaryParticipant { get; set; }

        public ReferenceList ProhibitedBitsAll { get; set; } = new ReferenceList();
        public ReferenceList ProhibitedBitsAny { get; set; } = new ReferenceList();
        public ReferenceList RequiredBitsAll { get; set; } = new ReferenceList();
        public ReferenceList RequiredBitsAny { get; set; } = new ReferenceList();

        public string TargetParticipant { get; set; } = "TargetSim";
        public RelationshipConditionTarget TargetType { get; set; } = RelationshipConditionTarget.AllRelationships;

        [AutoTuneBasic("track")]
        public Reference Track { get; set; } = new Reference();

        [AutoTuneTupleRange("relationship_score_interval")]
        public IntBounds TrackBounds { get; set; } = new IntBounds();

        protected override string GetVariantTunableName() => "relationship";

        protected override void OnExportVariant(TunableBase variantTunable)
        {
            var tuning = variantTunable.Get<TunableTuple>(GetVariantTunableName());
            AutoTunerInvoker.Invoke(this, tuning);

            RelationshipConditionBitsTuner.TuneBits(variantTunable, RequiredBitsAll, RequiredBitsAny, ProhibitedBitsAll, ProhibitedBitsAny);

            if (!string.IsNullOrEmpty(PrimaryParticipant))
            {
                var tunableList1 = tuning.Get<TunableList>("subject");
                tunableList1.Set<TunableEnum>(null, PrimaryParticipant);
            }

            if (TargetType == RelationshipConditionTarget.Participant)
            {
                var tunableList1 = tuning.Get<TunableList>("target_sim");
                tunableList1.Set<TunableEnum>(null, TargetParticipant);

                if (InvertNumRelationshipsParticipant)
                {
                    tuning.Set<TunableList>("invert_num_relations", "True");
                }
            }
            else
            {
                var tunableList1 = tuning.Get<TunableList>("target_sim");
                tunableList1.Set<TunableEnum>(null, "AllRelationships");

                if (InvertNumRelationshipsAll)
                {
                    tuning.Set<TunableList>("invert_num_relations", "True");
                }
            }

            if (TargetType == RelationshipConditionTarget.AllRelationships && NumRelationshipsAll != 0)
            {
                tuning.Set<TunableBasic>("num_relations", NumRelationshipsAll);
            }

            if (TargetType == RelationshipConditionTarget.Participant && NumRelationshipsParticipant != 0)
            {
                tuning.Set<TunableBasic>("num_relations", NumRelationshipsParticipant);
            }
        }
    }
}