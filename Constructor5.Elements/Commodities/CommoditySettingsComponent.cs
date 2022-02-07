using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Core;

namespace Constructor5.Elements.Commodities
{
    [XmlSerializerExtraType]
    public class CommoditySettingsComponent : CommodityComponent
    {
        [AutoTuneIfFalse("_add_if_not_in_tracker")]
        public bool AddIfNotInTracker { get; set; } = true;

        public override int ComponentDisplayOrder => 1;
        public override string ComponentLabel => "CommoditySettings";

        public bool DecayOffLot { get; set; } = true;
        public double DecayRate { get; set; } = 1;

        [AutoTuneIfTrue("persisted_tuning", "False")]
        public bool IsNonPersisted { get; set; }

        [AutoTuneIfFalse("remove_on_convergence")]
        public bool RemoveAtLowestValue { get; set; } = true;

        protected internal override void OnExport(CommodityExportContext context)
        {
            var tunableList1 = context.Tuning.Get<TunableList>("arrow_data");
            tunableList1.Set<TunableBasic>(null, "-20");
            tunableList1.Set<TunableBasic>(null, "-1");
            tunableList1.Set<TunableBasic>(null, "-30");
            tunableList1.Set<TunableBasic>(null, "20");
            tunableList1.Set<TunableBasic>(null, "1");
            tunableList1.Set<TunableBasic>(null, "30");

            context.Tuning.Set<TunableBasic>("decay_rate", DecayRate);

            // decay off lot
            if (DecayOffLot)
            {
                context.Tuning.Set<TunableEnum>("_time_passage_fixup_type", "FIXUP_USING_TIME_ELAPSED");
            }

            // min value tuning
            context.Tuning.Set<TunableBasic>("_default_convergence_value", "0");
            context.Tuning.Set<TunableBasic>("min_value_tuning", "0");

            // max value tuning
            /*context.Tuning.Set<TunableBasic>("max_value_tuning", "998");
            context.Tuning.Set<TunableBasic>("maximum_auto_satisfy_time", "998");*/

            // misc
            var tunableTuple1 = context.Tuning.Get<TunableTuple>("initial_tuning");
            tunableTuple1.Set<TunableBasic>("_use_auto_satisfy_curve_as_initial_value", "False");
            tunableTuple1.Set<TunableBasic>("_value", "0");
            tunableTuple1.Set<TunableBasic>("_use_stat_value_on_init", "True");

            context.Tuning.Set<TunableBasic>("ui_sort_order", "0");
            context.Tuning.Set<TunableBasic>("ui_visible_distress_threshold", "0");
            context.Tuning.Set<TunableBasic>("weight", "1");

            AutoTunerInvoker.Invoke(this, context.Tuning);
        }
    }
}