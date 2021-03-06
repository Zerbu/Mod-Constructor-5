using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.LootActionSets;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;

namespace Constructor5.LootActionTypes.Statistic
{
    [SelectableObjectType("LootActionTypes", "StatisticsSetStatisticToMin")]
    [XmlSerializerExtraType]
    public class SetStatisticToMinAction : StatisticActionBase
    {
        public SetStatisticToMinAction() => GeneratedLabel = "Set Statistic To Min";

        protected override void OnExport(LASExportContext newContext)
        {
            var mainTuple = GetStatActionTunable(newContext.LootListTunable, "statistic_set_min");
            TestConditionTuning.TuneTestList(mainTuple, newContext.TestConditions, "tests");
        }
    }
}
