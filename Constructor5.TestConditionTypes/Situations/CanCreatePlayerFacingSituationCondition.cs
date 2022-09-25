using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;

namespace Constructor5.TestConditionTypes.Situations
{
    [SelectableObjectType("TestConditionTypes", "SituationsCanCreatePlayerFacingSituationCondition", Description = "SituationsCanCreatePlayerFacingSituationConditionNotice")]
    [XmlSerializerExtraType]
    public class CanCreatePlayerFacingSituationCondition : TestCondition
    {
        public CanCreatePlayerFacingSituationCondition() => GeneratedLabel = "Can Create Player Facing Situation";

        [AutoTuneBasic("negate")]
        public bool IsInverted { get; set; }

        protected override string GetVariantTunableName(string contextTag = null) => "can_create_user_facing_situation";

        protected override void OnExportVariant(TunableBase variantTunable, string contextTag)
        {
            var tupleTunable = variantTunable.Get<TunableTuple>(GetVariantTunableName());
            AutoTunerInvoker.Invoke(this, tupleTunable);
        }
    }
}
