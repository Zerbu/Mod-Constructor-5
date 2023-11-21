using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Core;
using System;

namespace Constructor5.Elements.DramaNodes.Components
{
    [XmlSerializerExtraType]
    public class DramaNodeInfo : DramaNodeComponent
    {
        public override int ComponentDisplayOrder => 2;

        public override string ComponentLabel => "DramaNodeInfo";

        public double MinHoursToStart { get; set; } = 1;
        public double MaxHoursToStart { get; set; } = 24;

        protected internal override void OnExport(DramaNodeExportContext context)
        {
            {
                var tunableTuple1 = context.Tuning.Get<TunableTuple>("min_and_max_times");
                tunableTuple1.Set<TunableBasic>("lower_bound", MinHoursToStart);
                tunableTuple1.Set<TunableBasic>("upper_bound", MaxHoursToStart);
            }

            {
                var tunableVariant1 = context.Tuning.Set<TunableVariant>("time_option", "schedule");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("schedule");
                var tunableList1 = tunableTuple1.Get<TunableList>("valid_times");
                var tunableTuple2 = tunableList1.Get<TunableTuple>(null);
                var tunableTuple3 = tunableTuple2.Get<TunableTuple>("days_available");
                tunableTuple3.Set<TunableBasic>("0 SUNDAY", "True");
                tunableTuple3.Set<TunableBasic>("1 MONDAY", "True");
                tunableTuple3.Set<TunableBasic>("2 TUESDAY", "True");
                tunableTuple3.Set<TunableBasic>("3 WEDNESDAY", "True");
                tunableTuple3.Set<TunableBasic>("4 THURSDAY", "True");
                tunableTuple3.Set<TunableBasic>("5 FRIDAY", "True");
                tunableTuple3.Set<TunableBasic>("6 SATURDAY", "True");
                tunableTuple2.Set<TunableBasic>("duration", "24");
                var tunableTuple4 = tunableTuple2.Get<TunableTuple>("start_time");
                tunableTuple4.Set<TunableBasic>("hour", "8");
            }
        }
    }
}