using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.LootActionSets;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;

namespace Constructor5.LootActionTypes.Statistic
{
    [SelectableObjectType("LootActionTypes", "StatisticsSetStatistictoExactValue")]
    [XmlSerializerExtraType]
    public class SetStatisticToExactValueAction : StatisticActionBase
    {
        public SetStatisticToExactValueAction() => GeneratedLabel = "Set Statistic to Exact Value";

        [AutoTuneBasic("value")]
        public double Value { get; set; }

        protected override void OnExport(LASExportContext newContext)
        {
            var mainTuple = GetStatActionTunable(newContext.LootListTunable, "statistic_set");
            TestConditionTuning.TuneTestList(mainTuple, newContext.TestConditions, "tests");
        }
    }
}
