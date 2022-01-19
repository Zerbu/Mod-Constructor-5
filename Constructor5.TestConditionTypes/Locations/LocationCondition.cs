using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;

namespace Constructor5.TestConditionTypes.Locations
{
    [SelectableObjectType("TestConditionTypes", "LocationCondition")]
    //[SelectableObjectType("SituationGoalConditionTypes", "LocationCondition")]
    [XmlSerializerExtraType]
    public class LocationCondition : TestCondition
    {
        public LocationCondition() => GeneratedLabel = "Location Condition";

        public LocationOnLot IsOnLot { get; set; } = LocationOnLot.Any;
        public LocationIsOutside IsOutside { get; set; } = LocationIsOutside.Any;

        [AutoTuneEnum("subject")]
        public string Participant { get; set; }

        public Reference LotType { get; set; } = new Reference();
        public bool LotTypeRestrictionInverted { get; set; }

        protected override string GetVariantTunableName() => "location";

        protected override void OnExportVariant(TunableBase variantTunable)
        {
            var tupleTunable = variantTunable.Get<TunableTuple>(GetVariantTunableName());
            AutoTunerInvoker.Invoke(this, tupleTunable);

            var tunableTuple1 = tupleTunable.Get<TunableTuple>("location_tests");

            if (IsOnLot != LocationOnLot.Any)
            {
                var tunableVariant1 = tunableTuple1.Set<TunableVariant>("is_on_active_lot", "Is_or_is_not_on_active_lot");
                var tunableTuple2 = tunableVariant1.Get<TunableTuple>("Is_or_is_not_on_active_lot");
                tunableTuple2.Set<TunableBasic>("is_or_is_not_on_active_lot", IsOnLot == LocationOnLot.OnLotOnly ? "True" : "False");
                var tunableVariant2 = tunableTuple2.Set<TunableVariant>("tolerance", "use_default_tolerance");
                var tunableTuple3 = tunableVariant2.Get<TunableTuple>("use_default_tolerance");
            }

            if (IsOutside != LocationIsOutside.Any)
            {
                var tunableVariant3 = tunableTuple1.Set<TunableVariant>("is_outside", "enabled");
                tunableVariant3.Set<TunableBasic>("enabled", IsOutside == LocationIsOutside.OutsideOnly ? "True" : "False");
            }

            if (ElementTuning.GetSingleInstanceKey(LotType) != null)
            {
                var tunableVariant4 = tunableTuple1.Set<TunableVariant>("is_venue_type", "enabled");
                var tunableTuple4 = tunableVariant4.Get<TunableTuple>("enabled");
                tunableTuple4.Set<TunableBasic>("venue_type", LotType);
                if (LotTypeRestrictionInverted)
                {
                    tunableTuple4.Set<TunableBasic>("negate", "True");
                }
            }
        }
    }
}