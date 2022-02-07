using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.LootActionSets;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;

namespace Constructor5.LootActionTypes.Statistic
{
    [SelectableObjectType("LootActionTypes", "StatisticsAddStatistic")]
    [XmlSerializerExtraType]
    public class AddStatisticAction : StatisticActionBase
    {
        public AddStatisticAction() => GeneratedLabel = "Add Statistic";

        protected override void OnExport(LASExportContext newContext)
        {
            var mainTuple = GetStatActionTunable(newContext.LootListTunable, "statistic_add");
            TestConditionTuning.TuneTestList(mainTuple, newContext.TestConditions, "tests");
        }
    }
}
