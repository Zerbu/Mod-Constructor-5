using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.SimData;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Elements.Buffs
{
    public static class SharedBuffTuner
    {
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
        }
    }
}
