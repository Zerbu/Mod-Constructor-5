using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Core;
using System;

namespace Constructor5.Elements.AspirationTracks
{
    [XmlSerializerExtraType]
    public class AspirationTrackReward : AspirationTrackComponent
    {
        public override string ComponentLabel => "Reward";

        [AutoTuneBasic("reward")]
        public Reference Reward { get; set; } = new Reference();

        protected internal override void OnExport(AspirationTrackExportContext context)
        {
            AutoTunerInvoker.Invoke(this, context.Tuning);

            var header = (TuningHeader)context.Tuning;
            header.SimDataHandler.Write(208, ElementTuning.GetSingleInstanceKey(Reward) ?? 0);
        }
    }
}
