using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;

namespace Constructor5.TestConditionTypes.Perks
{
    [SelectableObjectType("TestConditionTypes", "PerksClubStatusCondition")]
    [SelectableObjectType("SituationGoalConditionTypes", "PerksClubStatusCondition")]
    [XmlSerializerExtraType]
    public class ClubCondition : TestCondition
    {
        public ClubCondition() => GeneratedLabel = "Club Condition";

        public ClubStatus ClubStatus { get; set; }
        public ClubInteractionRule InteractionRule { get; set; }
        public ClubConditionYesNoAny IsInviteOnly { get; set; }
        public ClubConditionYesNoAny IsRecentMember { get; set; }

        [AutoTuneThresholdVariant("required_sim_count")]
        public Threshold NumberOfSimsThreshold { get; set; } = new Threshold();

        public string OtherParticipant { get; set; } = "TargetSim";

        public string Participant { get; set; }

        [AutoTuneIfFalse("pass_if_any_clubs_pass", "True")]
        public bool RequireAllClubs { get; set; }

        public bool RequireOtherParticipantToBePartOfClub { get; set; }
        public bool RestrictNumberOfSimsInClub { get; set; }

        protected override string GetVariantTunableName() => "club";

        protected override void OnExportVariant(TunableBase variantTunable)
        {
            var tupleTunable = variantTunable.Get<TunableTuple>("club");

            if (InteractionRule != ClubInteractionRule.NoCondition)
            {
                var tunableVariant1 = tupleTunable.Set<TunableVariant>("affordance_rule", "enabled");
                var tunableVariant2 = tunableVariant1.Set<TunableVariant>("enabled", InteractionRule);
                tunableVariant2.Set<TunableBasic>(InteractionRule.ToString(), "");
            }

            if (ClubStatus != ClubStatus.NoCondition)
            {
                var tunableVariant1 = tupleTunable.Set<TunableVariant>("club_status", "enabled");
                var tunableVariant2 = tunableVariant1.Set<TunableVariant>("enabled", ClubStatus);

                var clubStatusString = ClubStatus.ToString();
                switch (ClubStatus)
                {
                    case ClubStatus.NotLeader:
                        clubStatusString = "Not Leader";
                        break;

                    case ClubStatus.NotMember:
                        clubStatusString = "Not Member";
                        break;
                }

                tunableVariant2.Set<TunableBasic>(clubStatusString, "");
            }

            if (RequireOtherParticipantToBePartOfClub)
            {
                var tunableVariant1 = tupleTunable.Set<TunableVariant>("require_common_club", "enabled");
                tunableVariant1.Set<TunableEnum>("enabled", OtherParticipant);
            }

            if (RestrictNumberOfSimsInClub)
            {
                var tunableVariant1 = variantTunable.Set<TunableVariant>("required_sim_count", "enabled");
                AutoTuneThresholdTuple.TuneThresholdTuple(tunableVariant1, NumberOfSimsThreshold, "enabled");
            }

            TuneYesNoAny(IsInviteOnly, tupleTunable, "invite_only");
            TuneYesNoAny(IsRecentMember, tupleTunable, "recent_member_status");

            AutoTunerInvoker.Invoke(this, tupleTunable);
        }

        private void TuneYesNoAny(ClubConditionYesNoAny variable, TuningBase tuning, string tunableName, string variantName = "enabled")
        {
            switch (variable)
            {
                case ClubConditionYesNoAny.Yes:
                    tuning.SetVariant<TunableBasic>(tunableName, variantName, "True");
                    break;
                case ClubConditionYesNoAny.No:
                    tuning.SetVariant<TunableBasic>(tunableName, variantName, "False");
                    break;
            }
        }
    }
}