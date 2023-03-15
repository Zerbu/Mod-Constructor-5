using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;
using System;

namespace Constructor5.TestConditionTypes.Locations
{
    [SelectableObjectType("TestConditionTypes", "LotInfoCondition", Description = "LotInfoConditionDescription")]
    //[SelectableObjectType("SituationGoalConditionTypes", "LocationCondition")]
    [XmlSerializerExtraType]
    public class LotInfoCondition : TestCondition
    {
        public LotInfoCondition() => GeneratedLabel = "Lot Info Condition";

        //public LotInfoSource Source { get; set; } = LotInfoSource.CurrentLot;

        public ReferenceList LotTypeBlacklist { get; set; } = new ReferenceList();
        public ReferenceList LotTypeWhitelist { get; set; } = new ReferenceList();

        public ReferenceList LotTraitBlacklist { get; set; } = new ReferenceList();
        public ReferenceList LotTraitWhitelist { get; set; } = new ReferenceList();

        public ReferenceList WorldBlacklist { get; set; } = new ReferenceList();
        public ReferenceList WorldWhitelist { get; set; } = new ReferenceList();

        public LotInfoYesNoAny IsApartment { get; set; } = LotInfoYesNoAny.Any;
        public LotInfoYesNoAny IsPenthouse { get; set; } = LotInfoYesNoAny.Any;

        public bool UseParentLot { get; set; }

        protected override string GetVariantTunableName(string contextTag = null) => "zone";

        protected override void OnExportVariant(TunableBase variantTunable, string contextTag)
        {
            //tupleTunable.Set<TunableBasic>("", "REPLACE WITH ZONE SOURCE");

            var tupleTunable = variantTunable.Get<TunableTuple>("zone");
            var zoneTestsTuple = tupleTunable.Get<TunableTuple>("zone_tests");

            TuneYesNoAny(zoneTestsTuple, IsApartment, "is_apartment", "Is_or_is_not_apartment_zone");
            TuneIsPenthouse(zoneTestsTuple);

            zoneTestsTuple.Set<TunableBasic>("use_source_venue", UseParentLot);

            TuneList(zoneTestsTuple, LotTypeBlacklist, LotTypeWhitelist, "venue_type");
            TuneList(zoneTestsTuple, WorldBlacklist, WorldWhitelist, "world_tests");
            TuneList(zoneTestsTuple, LotTraitBlacklist, LotTraitWhitelist, "zone_modifiers");

        }

        private void TuneList(TunableTuple tuning, ReferenceList blacklist, ReferenceList whitelist, string tunableName)
        {
            if (blacklist.HasItems() || whitelist.HasItems())
            {
                var tunableVariant1 = tuning.Set<TunableVariant>(tunableName, "enabled");
                var tunableTuple2 = tunableVariant1.Get<TunableTuple>("enabled");

                if (blacklist.HasItems())
                {
                    var tunableVariant2 = tunableTuple2.Set<TunableVariant>("blacklist", "specify");
                    var tunableTuple3 = tunableVariant2.Get<TunableTuple>("specify");
                    var tunableList1 = tunableTuple3.Get<TunableList>("blacklist");
                    foreach(var item in ElementTuning.GetInstanceKeys(blacklist))
                    {
                        tunableList1.Set<TunableBasic>(null, item);
                    }
                }

                if (whitelist.HasItems())
                {
                    var tunableVariant3 = tunableTuple2.Set<TunableVariant>("whitelist", "specify");
                    var tunableTuple4 = tunableVariant3.Get<TunableTuple>("specify");
                    var tunableList2 = tunableTuple4.Get<TunableList>("whitelist");
                    foreach (var item in ElementTuning.GetInstanceKeys(whitelist))
                    {
                        tunableList2.Set<TunableBasic>(null, item);
                    }
                }
            }
        }

        private void TuneIsPenthouse(TunableTuple zoneTestsTuple)
        {
            if (IsPenthouse == LotInfoYesNoAny.Any)
            {
                return;
            }

            var tunableVariant1 = zoneTestsTuple.Set<TunableVariant>("is_penthouse", "enabled");
            tunableVariant1.Set<TunableBasic>("enabled", IsPenthouse == LotInfoYesNoAny.Yes ? "True" : "False");
        }

        private void TuneYesNoAny(TuningBase tuning, LotInfoYesNoAny yesNoAny, string tunableName, string variantName)
        {
            if (yesNoAny == LotInfoYesNoAny.Any)
            {
                return;
            }

            var tunableVariant2 = tuning.Set<TunableVariant>(tunableName, variantName);
            if (yesNoAny == LotInfoYesNoAny.No)
            {
                tunableVariant2.Set<TunableBasic>(variantName, "False");
            }
        }
    }
}
