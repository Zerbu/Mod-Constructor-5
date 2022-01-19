using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.LootActionSets;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;

namespace Constructor5.LootActionTypes.Statistic
{
    [SelectableObjectType("LootActionTypes", "StatisticsSetStatisticToMax")]
    [XmlSerializerExtraType]
    public class SetStatisticToMaxAction : StatisticActionBase
    {
        public SetStatisticToMaxAction() => GeneratedLabel = "Set Statistic To Max";

        protected override void OnExport(LASExportContext newContext)
        {
            var mainTuple = GetStatActionTunable(newContext.LootListTunable, "statistic_set_max");
            TestConditionTuning.TuneTestList(mainTuple, newContext.TestConditions, "tests");
        }
    }
}
