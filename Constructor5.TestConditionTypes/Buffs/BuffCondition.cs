using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.TestConditions;
using Constructor5.Xml;

namespace Constructor5.TestConditionTypes.Buffs
{
    [SelectableObjectType("TestConditionTypes", "Buff Condition")]
    [SelectableObjectType("SituationGoalConditionTypes", "Buff Condition")]
    [SelectableObjectType("ObjectiveConditionTypes", "Buff Condition")]
    [XmlSerializerExtraType]
    public class BuffCondition : TestCondition
    {
        public BuffCondition() => GeneratedLabel = "Buff Condition";

        [AutoTuneReferenceList("blacklist")]
        public ReferenceList Blacklist { get; set; } = new ReferenceList();

        [AutoTuneReferenceListVariant("whitelist")]
        public ReferenceList Whitelist { get; set; } = new ReferenceList();

        [AutoTuneEnum("subject")]
        public string Participant { get; set; }

        protected override string GetVariantTunableName() => "buff";

        protected override void OnExportVariant(TunableBase variantTunable)
            => AutoTunerInvoker.Invoke(this, variantTunable.Get<TunableTuple>("buff"));
    }
}
