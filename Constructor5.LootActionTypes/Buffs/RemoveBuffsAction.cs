using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.LootActionSets;
using Constructor5.Elements.TestConditions;
using Constructor5.Xml;

namespace Constructor5.LootActionTypes.Buffs
{
    [SelectableObjectType("LootActionTypes", "Buffs: Remove Buffs")]
    [XmlSerializerExtraType]
    public class RemoveBuffsAction : LootAction
    {
        public RemoveBuffsAction() => GeneratedLabel = "Remove Buffs";

        [AutoTuneReferenceList("buffs_to_remove")]
        public ReferenceList Buffs { get; set; } = new ReferenceList();

        [AutoTuneComplexChance]
        public ComplexChance Chance { get; set; } = new ComplexChance();

        [AutoTuneEnum("subject")]
        public string Participant { get; set; }

        protected override void OnExport(LASExportContext originalContext)
        {
            var mainTuple = LootTuning.GetActionTuple(originalContext.LootListTunable, "buff_removal");
            AutoTunerInvoker.Invoke(this, mainTuple);
            TestConditionTuning.TuneTestList(mainTuple, originalContext.TestConditions, "tests");
        }
    }
}
