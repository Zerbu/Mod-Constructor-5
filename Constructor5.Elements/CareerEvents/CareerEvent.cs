using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Elements.TestConditions;
using System.Collections.Generic;

namespace Constructor5.Elements.CareerEvents
{
    //[ElementTypeData("CareerEvent", true, ElementTypes = new[] { typeof(CareerEvent) }, PresetFolders = new[] { "CareerEvent" })]
    public class CareerEvent : Element, IExportableElement, ISupportsCustomTuning
    {
        public Reference AdditionalRequiredVenue { get; set; } = new Reference();

        public STBLString BronzeText { get; set; } = new STBLString() { CustomText = "That was OK!" };
        public TestConditionList Conditions { get; set; } = new TestConditionList();
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();
        public STBLString EndOfDayReportText { get; set; } = new STBLString();
        public STBLString EndOfDayReportTitle { get; set; } = new STBLString();
        public STBLString GoldText { get; set; } = new STBLString() { CustomText = "That was great!" };

        [AutoTuneReferenceList("loots_on_cleanup")]
        public ReferenceList LootOnCleanup { get; set; } = new ReferenceList();

        [AutoTuneReferenceList("loots_on_end")]
        public ReferenceList LootOnEnd { get; set; } = new ReferenceList();

        [AutoTuneBasic("loot_on_request")]
        public Reference LootOnRequest { get; set; } = new Reference();

        [AutoTuneBasic("loot_on_start")]
        public Reference LootOnStart { get; set; } = new Reference();

        public STBLString NoMedalText { get; set; } = new STBLString() { CustomText = "That was bad!" };
        public bool ShowEndOfDayReport { get; set; }
        public STBLString SilverText { get; set; } = new STBLString() { CustomText = "That was good!" };

        public Reference Situation { get; set; } = new Reference();

        public ReferenceList Venues { get; set; } = new ReferenceList();

        public Reference ZoneDirector { get; set; } = new Reference();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "CareerEvent";
            tuning.InstanceType = "career_event";
            tuning.Module = "careers.career_event";

            var conditions = new List<TestCondition>();
            foreach (var condition in Conditions)
            {
                conditions.Add(condition.Condition);
            }
            TestConditionTuning.TuneTestList(tuning, conditions, "tests");

            TuneContent(tuning);

            AutoTunerInvoker.Invoke(this, tuning);

            CustomTuningExporter.Export(this, tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }

        private void TuneContent(TuningHeader tuning)
        {
            if (ShowEndOfDayReport)
            {
                // todo: change situation
                // todo: change icon
                var tunableVariant1 = tuning.Set<TunableVariant>("end_of_day_reports", "enabled");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("enabled");
                var tunableVariant2 = tunableTuple1.Set<TunableVariant>("header_string", "disabled");
                var tunableVariant3 = tunableTuple1.Set<TunableVariant>("leave_early_notification", "enabled");
                var tunableVariant4 = tunableVariant3.Set<TunableVariant>("enabled", "literal");
                var tunableTuple2 = tunableVariant4.Get<TunableTuple>("literal");
                var tunableList1 = tunableTuple2.Get<TunableList>("dialog_options");
                tunableList1.Set<TunableEnum>(null, "DISABLE_CLOSE_BUTTON");
                var tunableVariant5 = tunableTuple2.Set<TunableVariant>("icon", "enabled");
                var tunableVariant6 = tunableVariant5.Set<TunableVariant>("enabled", "resource_key");
                var tunableTuple3 = tunableVariant6.Get<TunableTuple>("resource_key");
                tunableTuple3.Set<TunableBasic>("key", "2f7d0004:00000000:f6d1b5068ae0cf9c");
                var tunableVariant7 = tunableTuple2.Set<TunableVariant>("text", "single");
                tunableVariant7.Set<TunableBasic>("single", "0x3EADD742");
                var tunableVariant8 = tunableTuple1.Set<TunableVariant>("notification", "literal");
                var tunableTuple4 = tunableVariant8.Get<TunableTuple>("literal");
                var tunableList2 = tunableTuple4.Get<TunableList>("dialog_options");
                tunableList2.Set<TunableEnum>(null, "DISABLE_CLOSE_BUTTON");
                var tunableVariant9 = tunableTuple4.Set<TunableVariant>("icon", "enabled");
                var tunableVariant10 = tunableVariant9.Set<TunableVariant>("enabled", "resource_key");
                var tunableTuple5 = tunableVariant10.Get<TunableTuple>("resource_key");
                tunableTuple5.Set<TunableBasic>("key", "2f7d0004:00000000:f6d1b5068ae0cf9c");
                var tunableVariant11 = tunableTuple4.Set<TunableVariant>("text", "single");
                tunableVariant11.Set<TunableBasic>("single", EndOfDayReportText);
                var tunableVariant12 = tunableTuple4.Set<TunableVariant>("title", "enabled");
                tunableVariant12.Set<TunableBasic>("enabled", EndOfDayReportTitle);
                var tunableList3 = tunableTuple1.Get<TunableList>("performance_strings");
                var tunableTuple6 = tunableList3.Get<TunableTuple>(null);
                tunableTuple6.Set<TunableBasic>("individual_string", GoldText);
                var tunableList4 = tunableTuple6.Get<TunableList>("tests");
                var tunableList5 = tunableList4.Get<TunableList>(null);
                var tunableVariant13 = tunableList5.Set<TunableVariant>(null, "situation_medal_test");
                var tunableTuple7 = tunableVariant13.Get<TunableTuple>("situation_medal_test");
                tunableTuple7.Set<TunableBasic>("situation", Situation);
                var tunableTuple8 = tunableTuple7.Get<TunableTuple>("threshold");
                tunableTuple8.Set<TunableEnum>("comparison", "EQUAL");
                tunableTuple8.Set<TunableEnum>("value", "GOLD");
                var tunableTuple9 = tunableList3.Get<TunableTuple>(null);
                tunableTuple9.Set<TunableBasic>("individual_string", SilverText);
                var tunableList6 = tunableTuple9.Get<TunableList>("tests");
                var tunableList7 = tunableList6.Get<TunableList>(null);
                var tunableVariant14 = tunableList7.Set<TunableVariant>(null, "situation_medal_test");
                var tunableTuple10 = tunableVariant14.Get<TunableTuple>("situation_medal_test");
                tunableTuple10.Set<TunableBasic>("situation", Situation);
                var tunableTuple11 = tunableTuple10.Get<TunableTuple>("threshold");
                tunableTuple11.Set<TunableEnum>("comparison", "EQUAL");
                tunableTuple11.Set<TunableEnum>("value", "SILVER");
                var tunableTuple12 = tunableList3.Get<TunableTuple>(null);
                tunableTuple12.Set<TunableBasic>("individual_string", BronzeText);
                var tunableList8 = tunableTuple12.Get<TunableList>("tests");
                var tunableList9 = tunableList8.Get<TunableList>(null);
                var tunableVariant15 = tunableList9.Set<TunableVariant>(null, "situation_medal_test");
                var tunableTuple13 = tunableVariant15.Get<TunableTuple>("situation_medal_test");
                tunableTuple13.Set<TunableBasic>("situation", Situation);
                var tunableTuple14 = tunableTuple13.Get<TunableTuple>("threshold");
                tunableTuple14.Set<TunableEnum>("comparison", "EQUAL");
                tunableTuple14.Set<TunableEnum>("value", "BRONZE");
                var tunableTuple15 = tunableList3.Get<TunableTuple>(null);
                tunableTuple15.Set<TunableBasic>("individual_string", NoMedalText);
                var tunableList10 = tunableTuple15.Get<TunableList>("tests");
                var tunableList11 = tunableList10.Get<TunableList>(null);
                var tunableVariant16 = tunableList11.Set<TunableVariant>(null, "situation_medal_test");
                var tunableTuple16 = tunableVariant16.Get<TunableTuple>("situation_medal_test");
                tunableTuple16.Set<TunableBasic>("situation", Situation);
                var tunableTuple17 = tunableTuple16.Get<TunableTuple>("threshold");
                tunableTuple17.Set<TunableEnum>("comparison", "EQUAL");
            }

            TuneVenues(tuning);

            var tunableVariant18 = tuning.Set<TunableVariant>("scorable_situation", "main_event");
            var tunableTuple19 = tunableVariant18.Get<TunableTuple>("main_event");
            var tunableTuple20 = tunableTuple19.Get<TunableTuple>("medal_payout_bronze");
            var tunableTuple21 = tunableTuple20.Get<TunableTuple>("money");
            tunableTuple21.Set<TunableBasic>("base_value", "0.8");
            tunableTuple20.Set<TunableBasic>("text", BronzeText);

            var tunableTuple22 = tunableTuple20.Get<TunableTuple>("work_performance");
            tunableTuple22.Set<TunableBasic>("base_value", "-0.1");
            var tunableTuple23 = tunableTuple19.Get<TunableTuple>("medal_payout_gold");
            var tunableTuple24 = tunableTuple23.Get<TunableTuple>("money");
            tunableTuple24.Set<TunableBasic>("base_value", "1.3");
            tunableTuple23.Set<TunableBasic>("text", GoldText);
            var tunableTuple25 = tunableTuple23.Get<TunableTuple>("work_performance");
            tunableTuple25.Set<TunableBasic>("base_value", "3");
            var tunableTuple26 = tunableTuple19.Get<TunableTuple>("medal_payout_silver");
            tunableTuple26.Set<TunableBasic>("text", SilverText);
            var tunableTuple27 = tunableTuple26.Get<TunableTuple>("work_performance");
            tunableTuple27.Set<TunableBasic>("base_value", "1.5");
            var tunableTuple28 = tunableTuple19.Get<TunableTuple>("medal_payout_tin");
            var tunableTuple29 = tunableTuple28.Get<TunableTuple>("money");
            tunableTuple29.Set<TunableBasic>("base_value", "0.15");
            tunableTuple28.Set<TunableBasic>("text", NoMedalText);
            var tunableTuple30 = tunableTuple28.Get<TunableTuple>("work_performance");
            tunableTuple30.Set<TunableBasic>("base_value", "-0.5");
            tunableTuple19.Set<TunableBasic>("situation", Situation);

            var tunableVariant20 = tuning.Set<TunableVariant>("zone_director", "enabled");
            tunableVariant20.Set<TunableBasic>("enabled", ZoneDirector);

        }

        private void TuneVenues(TuningHeader tuning)
        {
            {
                var tunableVariant1 = tuning.Set<TunableVariant>("required_zone", "random_lot");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("random_lot");
                var tunableList1 = tunableTuple1.Get<TunableList>("random_weight_terms");
                var tunableTuple2 = tunableList1.Get<TunableTuple>(null);
                tunableTuple2.Set<TunableBasic>("negate", "True");
                var tunableVariant2 = tunableTuple2.Set<TunableVariant>("test", "venue_type");
                var tunableTuple3 = tunableVariant2.Get<TunableTuple>("venue_type");
                var tunableList2 = tunableTuple3.Get<TunableList>("venues");
                foreach (var key in ElementTuning.GetInstanceKeys(Venues))
                {
                    tunableList2.Set<TunableBasic>(null, key);
                }
                var tunableVariant3 = tunableTuple2.Set<TunableVariant>("weight", "forbid");
            }

            {
                var testTunable = tuning.Get<TunableList>("tests");
                var testList = testTunable.Tunables.Count > 0 ? testTunable.Tunables[0] : testTunable.Get<TunableList>(null);

                var tunableVariant1 = testList.Set<TunableVariant>(null, "venue_availability");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("venue_availability");
                var tunableList1 = tunableTuple1.Get<TunableList>("venues");
                foreach (var key in ElementTuning.GetInstanceKeys(Venues))
                {
                    tunableList1.Set<TunableBasic>(null, key);
                }

                tunableList1.Set<TunableBasic>(null, AdditionalRequiredVenue);
            }
        }
    }
}