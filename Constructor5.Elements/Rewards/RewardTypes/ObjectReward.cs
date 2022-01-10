using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.Elements.Rewards.RewardTypes
{
    [SelectableObjectType("RewardTypes", "Object Reward")]
    [SelectableObjectType("RandomRewardTypes", "Object Reward")]
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
            tunableTuple1.Set<TunableBasic>("definition", ulong.Parse(ObjectHex, System.Globalization.NumberStyles.HexNumber));
        }
    }
}
