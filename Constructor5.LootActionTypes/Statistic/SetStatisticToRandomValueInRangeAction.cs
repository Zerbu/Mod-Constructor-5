using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.LootActionSets;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;

namespace Constructor5.LootActionTypes.Statistic
{
    [SelectableObjectType("LootActionTypes", "Statistics: Set Statistic to Random Value In Range")]
    [XmlSerializerExtraType]
    public class SetStatisticToRandomValueInRangeAction : StatisticActionBase
    {
        public SetStatisticToRandomValueInRangeAction() => GeneratedLabel = "Set Statistic to Random Value In Range";

        [AutoTuneIntRange("value_type")]
        public IntBounds Range { get; set; } = new IntBounds();

        protected override void OnExport(LASExportContext newContext)
        {
            var mainTuple = GetStatActionTunable(newContext.LootListTunable, "statistic_set_in_range");
            TestConditionTuning.TuneTestList(mainTuple, newContext.TestConditions, "tests");
        }
    }
}
