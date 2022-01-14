using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;

namespace Constructor5.TestConditionTypes.Perks
{
    [SelectableObjectType("ObjectiveConditionTypes", "Perks: Club Points Earned Condition", Description = "This checks the total amount of club points the Sim has ever earned across all clubs, regardless of how much they currently have.")]
    [XmlSerializerExtraType]
    public class ClubPointsEarnedCondition : TestCondition
    {
        public Threshold Threshold { get; set; } = new Threshold();

        protected override string GetVariantTunableName() => "club_bucks_earned";

        protected override void OnExportVariant(TunableBase variantTunable)
            => AutoTunerInvoker.Invoke(this, variantTunable.Get<TunableTuple>("club_bucks_earned"));
    }
}
