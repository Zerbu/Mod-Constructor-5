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
            {
                var tunableTuple1 = context.Tuning.Get<TunableTuple>("arrow_data");
                tunableTuple1.Set<TunableBasic>("negative_double_arrow", "-20");
                tunableTuple1.Set<TunableBasic>("negative_single_arrow", "-1");
                tunableTuple1.Set<TunableBasic>("negative_triple_arrow", "-30");
                tunableTuple1.Set<TunableBasic>("positive_double_arrow", "20");
                tunableTuple1.Set<TunableBasic>("positive_single_arrow", "1");
                tunableTuple1.Set<TunableBasic>("positive_triple_arrow", "30");
            }

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
            {
                var tunableTuple1 = context.Tuning.Get<TunableTuple>("initial_tuning");
                tunableTuple1.Set<TunableBasic>("_use_auto_satisfy_curve_as_initial_value", "False");
                tunableTuple1.Set<TunableBasic>("_value", "0");
                tunableTuple1.Set<TunableBasic>("_use_stat_value_on_init", "True");
            }

            context.Tuning.Set<TunableBasic>("ui_sort_order", "0");
            {
                var distress = context.Tuning.Get<TunableTuple>("ui_visible_distress_threshold");
                distress.Set<TunableBasic>("threshold_value", "0");
            }
            context.Tuning.Set<TunableBasic>("weight", "1");

            AutoTunerInvoker.Invoke(this, context.Tuning);
        }
    }
}