using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Elements.Buffs.Modifiers;
using Constructor5.Elements.Traits;
using Constructor5.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.Buffs.Components
{
    [XmlSerializerExtraType]
    [SharedWithTraits]
    public class BuffCommoditiesComponent : BuffComponent
    {
        public ObservableCollection<BuffReferenceModifier> Commodities { get; } = new ObservableCollection<BuffReferenceModifier>();
        public override string ComponentLabel => "AutonomyCommodities";

        protected internal override bool HasContent() => Commodities.Count > 0;

        protected internal override void OnExport(BuffExportContext context)
        {
            var scoredCommodities = new HashSet<BuffReferenceModifier>();
            foreach (var commodity in Commodities)
            {
                foreach (var key in ElementTuning.GetInstanceKeys(commodity.Reference))
                {
                    context.CommodityKeysToAdd.Add(key);
                    if (commodity.Value != 1d)
                    {
                        scoredCommodities.Add(commodity);
                    }
                }
            }

            if (scoredCommodities.Count > 0)
            {
                var tunableTuple1 = context.Tuning.Get<TunableTuple>("game_effect_modifier");
                var tunableList1 = tunableTuple1.Get<TunableList>("_game_effect_modifiers");
                var tunableVariant1 = tunableList1.Set<TunableVariant>(null, "autonomy_modifier");
                var tunableTuple2 = tunableVariant1.Get<TunableTuple>("autonomy_modifier");
                var tunableList2 = tunableTuple2.Get<TunableList>("score_multipliers");

                foreach (var scoredCommodity in scoredCommodities)
                {
                    foreach (var key in ElementTuning.GetInstanceKeys(scoredCommodity.Reference))
                    {
                        var tunableTuple3 = tunableList2.Get<TunableTuple>(null);
                        tunableTuple3.Set<TunableBasic>("key", key);
                        tunableTuple3.Set<TunableBasic>("value", scoredCommodity.Value);
                    }
                }
            }
        }
    }
}