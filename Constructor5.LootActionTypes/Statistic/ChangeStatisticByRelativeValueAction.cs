using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.LootActionSets;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;

namespace Constructor5.LootActionTypes.Statistic
{
    [SelectableObjectType("LootActionTypes", "StatisticsSetStatistictoExactValue")]
    [XmlSerializerExtraType]
    public class ChangeStatisticByRelativeValueAction : StatisticActionBase
    {
        public ChangeStatisticByRelativeValueAction() => GeneratedLabel = "Set Statistic to Exact Value";

        [AutoTuneBasic("amount")]
        public double Value { get; set; }

        protected override void OnExport(LASExportContext newContext)
        {
            var mainTuple = GetStatActionTunable(newContext.LootListTunable, "statistic_change");
            TestConditionTuning.TuneTestList(mainTuple, newContext.TestConditions, "tests");
        }
    }
}
