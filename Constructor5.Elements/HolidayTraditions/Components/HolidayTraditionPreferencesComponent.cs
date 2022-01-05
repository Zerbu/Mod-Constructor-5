using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Elements.TestConditions;
using Constructor5.Xml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.HolidayTraditions.Components
{
    [XmlSerializerExtraType]
    public class HolidayTraditionPreferencesComponent : HolidayTraditionComponent
    {
        public override string ComponentLabel => "Preferences";

        public bool IgnoredByToddlers { get; set; } = true;

        public ObservableCollection<HolidayTraditionPreference> Preferences { get; } = new ObservableCollection<HolidayTraditionPreference>();

        protected internal override void OnExport(HolidayTraditionExportContext context)
        {
            var listTunable = context.Tuning.Get<TunableBasic>("preference");

            {
                var tunableTuple1 = listTunable.Get<TunableTuple>(null);
                tunableTuple1.Set<TunableEnum>("preference", "DOES_NOT_CARE");
                var tunableList1 = tunableTuple1.Get<TunableList>("tests");
                var tunableVariant1 = tunableList1.Set<TunableVariant>(null, "sim_info");
                var tunableTuple2 = tunableVariant1.Get<TunableTuple>("sim_info");
                var tunableVariant2 = tunableTuple2.Set<TunableVariant>("ages", "specified");
                var tunableList2 = tunableVariant2.Get<TunableList>("specified");
                tunableList2.Set<TunableEnum>(null, "BABY");
                tunableTuple2.Set<TunableEnum>("who", "Actor");
            }

            foreach(var preference in Preferences)
            {
                var tunableTuple1 = listTunable.Get<TunableTuple>(null);
                tunableTuple1.Set<TunableEnum>("preference", preference.Type);

                var tunableVariant1 = tunableTuple1.Set<TunableVariant>("reason", "enabled");
                tunableVariant1.Set<TunableBasic>("enabled", preference.Reason);

                var conditions = new List<TestCondition>();
                foreach (var condition in preference.Conditions)
                {
                    conditions.Add(condition.Condition);
                }
                TestConditionTuning.TuneTestConditions(context.Tuning, conditions, "tests");
            }

            if (IgnoredByToddlers)
            {
                var tunableTuple1 = listTunable.Get<TunableTuple>(null);
                tunableTuple1.Set<TunableEnum>("preference", "DOES_NOT_CARE");
                var tunableVariant1 = tunableTuple1.Set<TunableVariant>("reason", "enabled");
                tunableVariant1.Set<TunableBasic>("enabled", "0x175B27F3");
                var tunableList1 = tunableTuple1.Get<TunableList>("tests");
                var tunableVariant2 = tunableList1.Set<TunableVariant>(null, "trait");
                var tunableTuple2 = tunableVariant2.Get<TunableTuple>("trait");
                var tunableList2 = tunableTuple2.Get<TunableList>("whitelist_traits");
                tunableList2.Set<TunableBasic>(null, "133125");
            }
        }
    }
}
