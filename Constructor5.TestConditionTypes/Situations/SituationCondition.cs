using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;

namespace Constructor5.TestConditionTypes.Situations
{
    [SelectableObjectType("TestConditionTypes", "SituationCondition")]
    [SelectableObjectType("ObjectiveConditionTypes", "SituationCondition")]
    [XmlSerializerExtraType]
    public class SituationCondition : TestCondition
    {
        public SituationCondition() => GeneratedLabel = "Situation Condition";

        [AutoTuneReferenceListVariant("situation_blacklist")]
        public ReferenceList Blacklist { get; set; } = new ReferenceList();

        public Threshold Level { get; set; } = new Threshold();

        [AutoTuneIfTrue("check_for_initiating_sim")]
        public bool MustBeInitiatedByParticipant { get; set; }

        [AutoTuneEnum("participant")]
        public string Participant { get; set; }

        public bool RestrictLevel { get; set; }

        [AutoTuneReferenceListVariant("situation_whitelist")]
        public ReferenceList Whitelist { get; set; } = new ReferenceList();

        protected override string GetVariantTunableName(string contextTag = null) => "situation_running_test";

        protected override void OnExportVariant(TunableBase variantTunable, string contextTag)
        {
            var tupleTunable = variantTunable.Get<TunableTuple>(GetVariantTunableName());
            AutoTunerInvoker.Invoke(this, tupleTunable);
            if (RestrictLevel)
            {
                var tunableVariant1 = tupleTunable.Set<TunableVariant>("level", "enabled");
                AutoTuneThresholdTuple.TuneThresholdTuple(tunableVariant1, Level, "enabled");
            }
            else
            {
                tupleTunable.Set<TunableEnum>("test_event", "SituationStarted");
            }
        }
    }
}