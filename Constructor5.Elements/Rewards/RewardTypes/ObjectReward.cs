using Constructor5.Base.ExportSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using System.Globalization;

namespace Constructor5.Elements.Rewards.RewardTypes
{
    [SelectableObjectType("RewardTypes", "ObjectReward")]
    [SelectableObjectType("RandomRewardTypes", "ObjectReward")]
    [XmlSerializerExtraType]
    public class ObjectReward : Reward
    {
        public ObjectReward() => GeneratedLabel = "Object Reward";

        public string ObjectHex { get; set; }
        public bool UnlockInBuildMode { get; set; }

        protected internal override string GetVariantName() => UnlockInBuildMode ? "build_buy_object" : "object_definition";

        protected internal override void OnExport(RewardExportContext context)
        {
            var tunableTuple1 = context.Tunable.Get<TunableTuple>(GetVariantName());
            if (ulong.TryParse(ObjectHex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result))
            {
                tunableTuple1.Set<TunableBasic>("definition", result);
            }
            else
            {
                Exporter.Current.AddError(context.Element, "CouldNotParseObjectId");
            }
        }
    }
}
