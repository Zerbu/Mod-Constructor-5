using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;

namespace Constructor5.TestConditionTypes.Relationships
{
    [SelectableObjectType("TestConditionTypes", "Relationship Condition")]
    [SelectableObjectType("ObjectiveConditionTypes", "Relationship Condition")]
    [SelectableObjectType("HolidayTraditionConditionTypes", "Relationship Condition")]
    [XmlSerializerExtraType]
    public class RelationshipCondition : TestCondition
    {
        public RelationshipCondition() => GeneratedLabel = "Relationship Condition";

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

            if (RequiredBitsAll.HasItems() || RequiredBitsAny.HasItems())
            {
                var tunableTuple1 = tuning.Get<TunableTuple>("required_relationship_bits");

                if (RequiredBitsAny.HasItems())
                {
                    var tunableList1 = tunableTuple1.Get<TunableList>("match_any");
                    foreach (var key in ElementTuning.GetInstanceKeys(RequiredBitsAny))
                    {
                        tunableList1.Set<TunableBasic>(null, key);
                    }
                }

                if (RequiredBitsAll.HasItems())
                {
                    var tunableList1 = tunableTuple1.Get<TunableList>("match_all");
                    foreach (var key in ElementTuning.GetInstanceKeys(RequiredBitsAll))
                    {
                        tunableList1.Set<TunableBasic>(null, key);
                    }
                }
            }

            if (ProhibitedBitsAll.HasItems() || ProhibitedBitsAny.HasItems())
            {
                var tunableTuple1 = tuning.Get<TunableTuple>("prohibited_relationship_bits");

                if (ProhibitedBitsAny.HasItems())
                {
                    var tunableList1 = tunableTuple1.Get<TunableList>("match_any");
                    foreach (var key in ElementTuning.GetInstanceKeys(ProhibitedBitsAny))
                    {
                        tunableList1.Set<TunableBasic>(null, key);
                    }
                }

                if (ProhibitedBitsAll.HasItems())
                {
                    var tunableList1 = tunableTuple1.Get<TunableList>("match_all");
                    foreach (var key in ElementTuning.GetInstanceKeys(ProhibitedBitsAll))
                    {
                        tunableList1.Set<TunableBasic>(null, key);
                    }
                }
            }

            if (!string.IsNullOrEmpty(PrimaryParticipant))
            {
                var tunableList1 = tuning.Get<TunableList>("subject");
                tunableList1.Set<TunableEnum>(null, PrimaryParticipant);
            }

            if (TargetType == RelationshipConditionTarget.Participant)
            {
                var tunableList1 = tuning.Get<TunableList>("target_sim");
                tunableList1.Set<TunableEnum>(null, TargetParticipant);
            }
            else
            {
                var tunableList1 = tuning.Get<TunableList>("target_sim");
                tunableList1.Set<TunableEnum>(null, "AllRelationships");
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