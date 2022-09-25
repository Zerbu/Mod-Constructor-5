using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.SimData;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Elements.CASPreferences;
using Constructor5.Elements.Traits;

namespace Constructor5.Elements.Buffs
{
    public static class SharedBuffTuner
    {
        public static bool AlwaysHasContent(Element element) => element.GetContextModifier<CASPreferenceContextModifier>() != null;

        public static TuningHeader CreateTuning(Element element, BuffComponent[] components, string subTuningName = null)
        {
            var tuning = ElementTuning.Create(element, subTuningName);
            tuning.Class = "Buff";
            tuning.InstanceType = "buff";
            tuning.Module = "buffs.buff";

            tuning.SimDataHandler = new SimDataHandler("SimData/Buff.data");

            var context = new BuffExportContext
            {
                Element = element,
                Tuning = tuning
            };

            foreach (var component in components)
            {
                if (!component.HasContent())
                {
                    continue;
                }
                component.OnExport(context);
            }

            var preferenceModifier = element.GetContextModifier<CASPreferenceContextModifier>();
            if (preferenceModifier != null)
            {
                if (preferenceModifier.IsBuff)
                {
                    TunePreferenceBuff(tuning, preferenceModifier);
                }
                else
                {
                    new PreferenceTraitTuner(context, preferenceModifier).TunePreferenceTrait();
                }
            }

            AddCommodities(context);

            if (element is Buff buff)
            {
                CustomTuningExporter.Export(buff, tuning, buff.CustomTuning);
            }

            TuningExport.AddToQueue(tuning);

            return tuning;
        }

        private static void AddCommodities(BuffExportContext context)
        {
            if (context.CommodityKeysToAdd.Count == 0)
            {
                return;
            }

            var tunableTuple1 = context.Tuning.Get<TunableTuple>("game_effect_modifier");
            var tunableList1 = tunableTuple1.Get<TunableList>("_game_effect_modifiers");
            var tunableVariant1 = tunableList1.Set<TunableVariant>(null, "autonomy_modifier");
            var tunableTuple2 = tunableVariant1.Get<TunableTuple>("autonomy_modifier");
            var tunableList2 = tunableTuple2.Get<TunableList>("commodities_to_add");
            foreach (var key in context.CommodityKeysToAdd)
            {
                tunableList2.Set<TunableBasic>(null, key);
            }

            foreach (var commodityTuning in context.IntervalCommodities.Values)
            {
                TuningExport.AddToQueue(commodityTuning);
            }
        }

        private static void TunePreferenceBuff(TuningBase tuning, CASPreferenceContextModifier preferenceModifier)
        {
            var preference = (CASPreference)preferenceModifier.CASPreference.Element;

            if (preferenceModifier.IsDislike)
            {
                var tunableTuple1 = tuning.Get<TunableTuple>("game_effect_modifier");
                var tunableList1 = tunableTuple1.Get<TunableList>("_game_effect_modifiers");
                var tunableVariant1 = tunableList1.Set<TunableVariant>(null, "continuous_statistic_modifier");
                var tunableTuple2 = tunableVariant1.Get<TunableTuple>("continuous_statistic_modifier");
                tunableTuple2.Set<TunableBasic>("modifier_value", "0.5");
                tunableTuple2.Set<TunableBasic>("statistic", "259983");
                var tunableVariant2 = tunableList1.Set<TunableVariant>(null, "continuous_statistic_modifier");
                var tunableTuple3 = tunableVariant2.Get<TunableTuple>("continuous_statistic_modifier");
                tunableTuple3.Set<TunableBasic>("modifier_value", "-1");
                tunableTuple3.Set<TunableBasic>("statistic", "16655");
            }
            else
            {
                var tunableTuple1 = tuning.Get<TunableTuple>("game_effect_modifier");
                var tunableList1 = tunableTuple1.Get<TunableList>("_game_effect_modifiers");
                var tunableVariant1 = tunableList1.Set<TunableVariant>(null, "continuous_statistic_modifier");
                var tunableTuple2 = tunableVariant1.Get<TunableTuple>("continuous_statistic_modifier");
                tunableTuple2.Set<TunableBasic>("modifier_value", "-1");
                tunableTuple2.Set<TunableBasic>("statistic", "259983");
                var tunableVariant2 = tunableList1.Set<TunableVariant>(null, "continuous_statistic_modifier");
                var tunableTuple3 = tunableVariant2.Get<TunableTuple>("continuous_statistic_modifier");
                tunableTuple3.Set<TunableBasic>("modifier_value", "1");
                tunableTuple3.Set<TunableBasic>("statistic", "16655");
            }
        }
    }
}