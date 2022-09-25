using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;

namespace Constructor5.TestConditionTypes.Buffs
{
    [SelectableObjectType("TestConditionTypes", "BuffCondition")]
    [SelectableObjectType("SituationGoalConditionTypes", "BuffCondition")]
    //[SelectableObjectType("ObjectiveConditionTypes", "BuffCondition")]
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

        protected override string GetVariantTunableName(string contextTag = null) => "buff";

        protected override void OnExportVariant(TunableBase variantTunable, string contextTag)
            => AutoTunerInvoker.Invoke(this, variantTunable.Get<TunableTuple>("buff"));
    }
}
