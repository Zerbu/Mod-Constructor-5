using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.LootActionSets;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;

namespace Constructor5.LootActionTypes.Statistic
{
    [SelectableObjectType("LootActionTypes", "Statistics: Change Buff or Statistic by Category (Percentage)")]
    [XmlSerializerExtraType]
    public class ChangeStatisticByCategoryPercentageAction : StatisticActionBase
    {
        public ChangeStatisticByCategoryPercentageAction() => GeneratedLabel = "Change Buff or Statistic by Category (Percentage)";

        public string Category { get; set; }
        public double Percentage { get; set; }

        protected override void OnExport(LASExportContext newContext)
        {
            var mainTuple = GetStatActionTunable(newContext.LootListTunable, "statistic_change_by_category");

            mainTuple.Set<TunableEnum>("statistic_category", Category);
            var tunableVariant1 = mainTuple.Set<TunableVariant>("change", "percent_change");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("percent_change");
            tunableTuple1.Set<TunableBasic>("percent_change_amount", Percentage);

            TestConditionTuning.TuneTestList(mainTuple, newContext.TestConditions, "tests");
        }
    }
}
