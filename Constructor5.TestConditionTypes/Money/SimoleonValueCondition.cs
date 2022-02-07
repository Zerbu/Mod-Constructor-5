using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;

namespace Constructor5.TestConditionTypes.Money
{
    [SelectableObjectType("TestConditionTypes", "MoneyCondition", Description = "MoneyConditionNotice")]
    [SelectableObjectType("ObjectiveConditionTypes", "MoneyCondition", Description = "MoneyConditionNotice")]
    [XmlSerializerExtraType]
    public class SimoleonValueCondition : TestCondition
    {
        public SimoleonValueCondition() => GeneratedLabel = "Money Condition";

        public SimoleonValueContext Context { get; set; } = SimoleonValueContext.NetWorth;

        [AutoTuneThresholdTuple("value_threshold")]
        public Threshold Threshold { get; set; } = new Threshold();

        protected override string GetVariantTunableName() => "simoleon_value";

        protected override void OnExportVariant(TunableBase variantTunable)
        {
            var tupleTunable = variantTunable.Get<TunableTuple>("simoleon_value");

            switch (Context)
            {
                case SimoleonValueContext.NetWorth:
                    {
                        tupleTunable.Set<TunableVariant>("value_context", "net_worth");
                    }
                    break;

                case SimoleonValueContext.PropertyOnly:
                    {
                        tupleTunable.Set<TunableVariant>("value_context", "property_only");
                    }
                    break;

                case SimoleonValueContext.TotalCash:
                    {
                        tupleTunable.Set<TunableVariant>("value_context", "total_cash");
                    }
                    break;

                case SimoleonValueContext.BusinessFunds:
                    {
                        tupleTunable.Set<TunableVariant>("value_context", "retail_funds");
                    }
                    break;

                case SimoleonValueContext.CurrentValue:
                    {
                        tupleTunable.Set<TunableVariant>("value_context", "current_value");
                    }
                    break;
            }

            AutoTunerInvoker.Invoke(this, tupleTunable);
        }
    }
}