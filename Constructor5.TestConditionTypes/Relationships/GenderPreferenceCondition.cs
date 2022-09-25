using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.TestConditionTypes.Relationships
{
    [SelectableObjectType("TestConditionTypes", "GenderPreferenceCondition")]
    [XmlSerializerExtraType]
    public class GenderPreferenceCondition : TestCondition
    {
        public GenderPreferenceCondition() => GeneratedLabel = "Gender Preference Condition";

        [AutoTuneIfFalse("consider_exploration")]
        public bool AlwaysPassIfExploringRomantically { get; set; } = true;
        [AutoTuneIfTrue("negate")]
        public bool Inverted { get; set; }
        public string PrimaryParticipant { get; set; }
        public string TargetParticipant { get; set; }
        [AutoTuneIfFalse("ignore_reciprocal", "True")]
        public bool RequireBothSims { get; set; }

        protected override string GetVariantTunableName(string contextTag = null) => "gender_preference";

        protected override void OnExportVariant(TunableBase variantTunable, string contextTag)
        {
            var tupleTunable = variantTunable.Get<TunableTuple>("gender_preference");

            if (!string.IsNullOrEmpty(PrimaryParticipant))
            {
                var tunableList1 = tupleTunable.Get<TunableList>("subject");
                tunableList1.Set<TunableEnum>(null, PrimaryParticipant);
            }
            if (!string.IsNullOrEmpty(PrimaryParticipant))
            {
                var tunableList1 = tupleTunable.Get<TunableList>("target_sim");
                tunableList1.Set<TunableEnum>(null, TargetParticipant);
            }

            AutoTunerInvoker.Invoke(this, tupleTunable);
        }
    }
}
