using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.LootActionSets;
using Constructor5.Elements.TestConditions;

namespace Constructor5.LootActionTypes.RelBits
{
    [SelectableObjectType("LootActionTypes", "RelationshipBitAddRemove")]
    [XmlSerializerExtraType]
    public class RelBitAction : LootAction
    {
        public RelBitAction() => GeneratedLabel = "Add/Remove Relationship Bits";

        public ReferenceList BitsToAdd { get; set; } = new ReferenceList();
        public ReferenceList BitsToRemove { get; set; } = new ReferenceList();

        [AutoTuneComplexChance]
        public ComplexChance Chance { get; set; } = new ComplexChance();

        public string Participant { get; set; } = "Actor";
        public string TargetParticipant { get; set; } = "TargetSim";

        protected override void OnExport(LASExportContext originalContext)
        {
            var mainTuple = LootTuning.GetActionTuple(originalContext.LootListTunable, "relationship_bits_loot");

            foreach (var bit in ElementTuning.GetInstanceKeys(BitsToAdd))
            {
                var tunableList1 = mainTuple.Get<TunableList>("bit_operations");
                var tunableTuple1 = tunableList1.Get<TunableTuple>(null);
                tunableTuple1.Set<TunableBasic>("bit", bit);
                tunableTuple1.Set<TunableEnum>("operation", "ADD");
                tunableTuple1.Set<TunableEnum>("recipients", Participant);
                tunableTuple1.Set<TunableEnum>("targets", TargetParticipant);
            }

            foreach (var bit in ElementTuning.GetInstanceKeys(BitsToRemove))
            {
                var tunableList1 = mainTuple.Get<TunableList>("bit_operations");
                var tunableTuple1 = tunableList1.Get<TunableTuple>(null);
                tunableTuple1.Set<TunableBasic>("bit", bit);
                tunableTuple1.Set<TunableEnum>("operation", "REMOVE");
                tunableTuple1.Set<TunableEnum>("recipients", Participant);
                tunableTuple1.Set<TunableEnum>("targets", TargetParticipant);
            }

            TestConditionTuning.TuneTestList(mainTuple, originalContext.TestConditions, "tests");

            AutoTunerInvoker.Invoke(this, mainTuple);
        }
    }
}