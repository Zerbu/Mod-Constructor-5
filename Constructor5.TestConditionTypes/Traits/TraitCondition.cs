using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;

namespace Constructor5.TestConditionTypes
{
    [SelectableObjectType("TestConditionTypes", "TraitCondition")]
    [SelectableObjectType("ObjectiveConditionTypes", "TraitCondition")]
    [SelectableObjectType("HolidayTraditionConditionTypes", "TraitCondition")]
    [XmlSerializerExtraType]
    public class TraitCondition : TestCondition
    {
        public TraitCondition() => GeneratedLabel = "Trait Condition";

        [AutoTuneReferenceList("blacklist_traits")]
        public ReferenceList Blacklist { get; set; } = new ReferenceList();

        [AutoTuneBasic("num_blacklist_allowed", IgnoreIf = 0)]
        public int NumBlacklistAllowed { get; set; } = 0;

        [AutoTuneBasic("num_whitelist_required", IgnoreIf = 1)]
        public int NumWhitelistRequired { get; set; } = 1;

        [AutoTuneEnum("subject")]
        public string Participant { get; set; }

        [AutoTuneReferenceList("whitelist_traits")]
        public ReferenceList Whitelist { get; set; } = new ReferenceList();

        protected override string GetVariantTunableName(string contextTag = null) => "trait";

        protected override void OnExportVariant(TunableBase variantTunable, string contextTag)
            => AutoTunerInvoker.Invoke(this, variantTunable.Get<TunableTuple>("trait"));
    }
}