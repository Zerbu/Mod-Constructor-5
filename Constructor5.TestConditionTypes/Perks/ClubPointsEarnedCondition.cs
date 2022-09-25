using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;

namespace Constructor5.TestConditionTypes.Perks
{
    [SelectableObjectType("ObjectiveConditionTypes", "PerksClubPointsEarnedCondition", Description = "PerksClubPointsEarnedConditionNotice")]
    [XmlSerializerExtraType]
    public class ClubPointsEarnedCondition : TestCondition
    {
        public Threshold Threshold { get; set; } = new Threshold();

        protected override string GetVariantTunableName(string contextTag = null) => "club_bucks_earned";

        protected override void OnExportVariant(TunableBase variantTunable, string contextTag)
            => AutoTunerInvoker.Invoke(this, variantTunable.Get<TunableTuple>("club_bucks_earned"));
    }
}
