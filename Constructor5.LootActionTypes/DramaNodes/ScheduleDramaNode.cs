using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.LootActionSets;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;

namespace Constructor5.LootActionTypes.DramaNodes
{
    [SelectableObjectType("LootActionTypes", "DramaNodesScheduleDramaNode")]
    [XmlSerializerExtraType]
    public class ScheduleDramaNode : LootAction
    {
        public ScheduleDramaNode() => GeneratedLabel = "Schedule Drama Node";

        [AutoTuneComplexChance]
        public ComplexChance Chance { get; set; } = new ComplexChance();

        [AutoTuneBasic("drama_node")]
        public Reference DramaNode { get; set; } = new Reference();

        [AutoTuneBasic("subject")]
        public string Participant { get; set; }

        protected override void OnExport(LASExportContext originalContext)
        {
            var mainTuple = LootTuning.GetActionTuple(originalContext.LootListTunable, "schedule_drama_node");
            AutoTunerInvoker.Invoke(this, mainTuple);
            TestConditionTuning.TuneTestList(mainTuple, originalContext.TestConditions, "tests");
        }
    }
}
