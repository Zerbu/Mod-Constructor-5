using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.TestConditionTypes.Statistics
{
    [SelectableObjectType("TestConditionTypes", "StatisticCondition")]
    [SelectableObjectType("SituationGoalConditionTypes", "StatisticCondition")]
    [SelectableObjectType("ObjectiveConditionTypes", "StatisticCondition")]
    [XmlSerializerExtraType]
    public class StatisticCondition : TestCondition
    {
        public StatisticCondition() => GeneratedLabel = "Statistic Condition";

        [AutoTuneBasic("must_have_stat")]
        public bool MustHaveStatistic { get; set; }

        [AutoTuneEnum("who")]
        public string Participant { get; set; }

        [AutoTuneBasic("stat")]
        public Reference Statistic { get; set; } = new Reference();

        public Threshold Threshold { get; set; } = new Threshold();

        protected override string GetVariantTunableName() => "statistic";

        protected override void OnExportVariant(TunableBase variantTunable)
        {
            var tupleTunable = variantTunable.Get<TunableTuple>("statistic");
            AutoTunerInvoker.Invoke(this, tupleTunable);

            var variant = tupleTunable.Set<TunableVariant>("threshold", "value_threshold");
            AutoTuneThresholdTuple.TuneThresholdTuple(variant, Threshold, "value_threshold");
        }
    }
}
