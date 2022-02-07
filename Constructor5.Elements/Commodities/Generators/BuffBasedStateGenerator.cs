using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.Buffs.References;
using System.Collections.Generic;

namespace Constructor5.Elements.Commodities.Generators
{
    [SelectableObjectType("CommodityStateGenerators", "Buff Based State Generator")]
    [XmlSerializerExtraType]
    public class BuffBasedStateGenerator : CommodityStateGenerator
    {
        public BuffBasedStateGenerator() => Label = "Buff Based State Generator";

        public ReferenceList Buffs { get; set; } = new ReferenceList();
        public int DurationBeforeFirstLevel { get; set; } = 0;
        public int DurationOfLastLevel { get; set; } = 240;
        public int DurationPerLevelIncrease { get; set; } = 0;
        public int DurationPerLevelMinimum { get; set; } = 240;

        protected internal override void OnExport(CommodityExportContext context)
        {
            var currentValue = DurationBeforeFirstLevel;
            var currentLevel = 0;

            var listTunable = context.Tuning.Get<TunableList>("states");

            var buffKeys = new Dictionary<ulong, BuffWithReasonReferenceListItem>();

            foreach (var item in Buffs.GetOfType<BuffWithReasonReferenceListItem>())
            {
                foreach (var buff in ElementTuning.GetInstanceKeys(item.Reference))
                {
                    buffKeys.Add(buff, item);
                }
            }

            foreach(var buff in buffKeys)
            {
                var tunableTuple1 = listTunable.Get<TunableTuple>(null);
                tunableTuple1.Set<TunableBasic>("value", currentValue);
                var tunableTuple2 = tunableTuple1.Get<TunableTuple>("buff");
                tunableTuple2.Set<TunableBasic>("buff_type", buff.Key);

                if (!string.IsNullOrEmpty(buff.Value.Reason.CustomText))
                {
                    var reasonVariant = tunableTuple2.Set<TunableVariant>("buff_reason", "enabled");
                    reasonVariant.Set<TunableBasic>("enabled", buff.Value.Reason);
                }

                if (currentLevel != buffKeys.Count - 1)
                {
                    currentValue = currentValue + DurationPerLevelMinimum + (DurationPerLevelIncrease * currentLevel);
                    currentLevel++;
                }
            }

            context.Tuning.Set<TunableBasic>("max_value_tuning", currentValue+DurationOfLastLevel);
        }
    }
}