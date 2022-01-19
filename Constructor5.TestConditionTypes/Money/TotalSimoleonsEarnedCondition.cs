using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;

namespace Constructor5.TestConditionTypes.Money
{
    [SelectableObjectType("ObjectiveConditionTypes", "MoneyEarnedCondition", Description = "MoneyEarnedConditionNotice")]
    [XmlSerializerExtraType]
    public class TotalSimoleonsEarnedCondition : TestCondition
    {
        public TotalSimoleonsEarnedCondition() => GeneratedLabel = "Money Earned Condition";

        public string Tag { get; set; }

        [AutoTuneThresholdTuple("threshold")]
        public Threshold Threshold { get; set; } = new Threshold();

        //public string Source { get; set; } = "TotalMoneyEarned";
        public TotalSimoleonsEarnedType Type { get; set; } = TotalSimoleonsEarnedType.TotalMoneyEarned;

        protected override string GetVariantTunableName() => Type == TotalSimoleonsEarnedType.ByTag ? "total_simoleons_earned_by_tag" : "total_simoleons_earned";

        protected override void OnExportVariant(TunableBase variantTunable)
        {
            var tupleTunable = variantTunable.Get<TunableTuple>(GetVariantTunableName());

            if (Type == TotalSimoleonsEarnedType.TotalMoneyEarned)
            {
                tupleTunable.Set<TunableBasic>("earned_source", "TotalMoneyEarned");
            }

            if (Type == TotalSimoleonsEarnedType.ByTag)
            {
                tupleTunable.Set<TunableBasic>("tag_to_test", Tag);
            }

            AutoTunerInvoker.Invoke(this, tupleTunable);
        }
    }
}