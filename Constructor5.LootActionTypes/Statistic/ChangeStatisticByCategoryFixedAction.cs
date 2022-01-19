using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.LootActionSets;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;

namespace Constructor5.LootActionTypes.Statistic
{
    [SelectableObjectType("LootActionTypes", "StatisticsChangeBufforStatisticbyCategoryFixedAmount")]
    [XmlSerializerExtraType]
    public class ChangeStatisticByCategoryFixedAction : StatisticActionBase
    {
        public ChangeStatisticByCategoryFixedAction() => GeneratedLabel = "Change Buff or Statistic by Category (Fixed Amount)";

        public double Amount { get; set; }
        public string Category { get; set; }

        protected override void OnExport(LASExportContext newContext)
        {
            var mainTuple = GetStatActionTunable(newContext.LootListTunable, "statistic_change_by_category");

            mainTuple.Set<TunableEnum>("statistic_category", Category);
            var tunableVariant1 = mainTuple.Set<TunableVariant>("change", "stat_change");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("stat_change");
            tunableTuple1.Set<TunableBasic>("change_amount", Amount);

            TestConditionTuning.TuneTestList(mainTuple, newContext.TestConditions, "tests");
        }
    }
}
