using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;
using System;

namespace Constructor5.TestConditionTypes.Time
{
    [SelectableObjectType("TestConditionTypes", "Day and Time Condition")]
    [XmlSerializerExtraType]
    public class DayAndTimeCondition : TestCondition
    {
        public DayAndTimeCondition() => GeneratedLabel = "Day and Time Condition";

        public DayNightRestriction DayOrNight { get; set; } = DayNightRestriction.Any;
        public bool Include0Sunday { get; set; } = true;
        public bool Include1Monday { get; set; } = true;
        public bool Include2Tuesday { get; set; } = true;
        public bool Include3Wednesday { get; set; } = true;
        public bool Include4Thursday { get; set; } = true;
        public bool Include5Friday { get; set; } = true;
        public bool Include6Saturday { get; set; } = true;
        public bool RestrictTimeRange { get; set; }
        public int TimeBeginHour { get; set; }
        public int TimeBeginMinute { get; set; }
        public int TimeDurationHour { get; set; }
        public int TimeDurationMinute { get; set; }

        public bool RestrictDay() => !Include0Sunday || !Include1Monday || !Include2Tuesday || !Include3Wednesday || !Include4Thursday || !Include5Friday || !Include6Saturday;

        protected override string GetVariantTunableName() => "day_and_time";

        protected override void OnExportVariant(TunableBase variantTunable)
        {
            var tunableTuple1 = variantTunable.Get<TunableTuple>("day_and_time");

            if (RestrictDay())
            {
                TuneDayRestriction(tunableTuple1);
            }

            switch (DayOrNight)
            {
                case DayNightRestriction.Day:
                    tunableTuple1.SetVariant<TunableBasic>("is_day", "enabled", "True");
                    break;
                case DayNightRestriction.Night:
                    tunableTuple1.SetVariant<TunableBasic>("is_day", "enabled", "False");
                    break;
            }

            if (RestrictTimeRange)
            {
                var tunableVariant1 = tunableTuple1.Set<TunableVariant>("time_range", "enabled");
                var tunableTuple2 = tunableVariant1.Get<TunableTuple>("enabled");
                var tunableTuple3 = tunableTuple2.Get<TunableTuple>("begin_time");
                tunableTuple3.Set<TunableBasic>("hour", TimeBeginHour);
                if (TimeBeginMinute != 0)
                {
                    tunableTuple3.Set<TunableBasic>("minute", TimeBeginMinute);
                }
                var tunableTuple4 = tunableTuple2.Get<TunableTuple>("duration");
                tunableTuple4.Set<TunableBasic>("hour", TimeDurationHour);
                if (TimeDurationMinute != 0)
                {
                    tunableTuple4.Set<TunableBasic>("minute", TimeDurationMinute);
                }
            }
        }

        private void TuneDayRestriction(TunableTuple tuning)
        {
            var tunableVariant1 = tuning.Set<TunableVariant>("days_available", "enabled");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("enabled");
            if (Include0Sunday)
            {
                tunableTuple1.Set<TunableBasic>("0 SUNDAY", "True");
            }
            if (Include1Monday)
            {
                tunableTuple1.Set<TunableBasic>("1 MONDAY", "True");
            }
            if (Include2Tuesday)
            {
                tunableTuple1.Set<TunableBasic>("2 TUESDAY", "True");
            }
            if (Include3Wednesday)
            {
                tunableTuple1.Set<TunableBasic>("3 WEDNESDAY", "True");
            }
            if (Include4Thursday)
            {
                tunableTuple1.Set<TunableBasic>("4 THURSDAY", "True");
            }
            if (Include5Friday)
            {
                tunableTuple1.Set<TunableBasic>("5 FRIDAY", "True");
            }
            if (Include6Saturday)
            {
                tunableTuple1.Set<TunableBasic>("6 SATURDAY", "True");
            }
        }
    }
}