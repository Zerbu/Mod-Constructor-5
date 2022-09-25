using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.SituationGoals;
using Constructor5.Elements.SituationGoals.Templates;

namespace Constructor5.SituationGoalTemplates.Single
{
    [XmlSerializerExtraType]
    [SelectableObjectType("SituationGoalTemplates", "TravelGoal")]
    public class SituationGoalTravelTemplate : SituationGoalTemplate
    {
        public override string Label => "Travel Goal";

        public Reference Venue { get; set; } = new Reference();
        public bool SelectOnlyOnOwnedLot { get; set; } = true;

        protected override void OnExport(SituationGoalExportContext context)
        {
            var tuningHeader = (TuningHeader)context.Tuning;
            tuningHeader.Class = "SituationGoalZoneLoaded";
            tuningHeader.Module = "situations.situation_goal_zone_loaded";

            var preTests = context.Tuning.Get<TunableList>("_pre_tests");

            if (SelectOnlyOnOwnedLot)
            {
                preTests.Set<TunableVariant>(null, "lot_owner");
            }

            if (ElementTuning.GetSingleInstanceKey(Venue) == null)
            {
                return;
            }

            var tunableVariant1 = context.Tuning.Get<TunableList>("_post_tests").Set<TunableVariant>(null, "location");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("location");
            var tunableTuple2 = tunableTuple1.Get<TunableTuple>("location_tests");
            var tunableVariant2 = tunableTuple2.Set<TunableVariant>("is_venue_type", "enabled");
            var tunableTuple3 = tunableVariant2.Get<TunableTuple>("enabled");
            tunableTuple3.Set<TunableBasic>("venue_type", Venue);
        }
    }
}
