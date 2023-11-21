using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Elements.TestConditions;

namespace Constructor5.TestConditionTypes.Traits
{
    public class SelfDiscoveryEnabledCondition : TestCondition
    {
        public SelfDiscoveryEnabledCondition() => GeneratedLabel = "Self Discovery Enabled Condition";

        protected override string GetVariantTunableName(string contextTag = null) => "game_option";

        protected override void OnExportVariant(TunableBase variantTunable, string contextTag)
        {
            variantTunable.Get<TunableTuple>("game_option").Set<TunableEnum>("gameplay_option", "SELF_DISCOVERY_ENABLED");
        }
    }
}
