using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Elements.Shared;
using Constructor5.Core;

namespace Constructor5.Elements.AspirationTracks
{
    [XmlSerializerExtraType]
    public class AspirationTrackWhimsComponent : AspirationTrackComponent
    {
        public override string ComponentLabel => "Whims";

        public ReferenceList Whims { get; set; } = new ReferenceList();
        public STBLString Reason { get; set; } = new STBLString();

        protected internal override void OnExport(AspirationTrackExportContext context)
        {
            if (!Whims.HasItems())
            {
                return;
            }

            var set = WhimSetBuilder.BuildWhimSet(ElementTuning.GetFullName(Element, "WhimSet"), Reason, Whims, 5);
            var tunableVariant1 = context.Tuning.Set<TunableVariant>("whim_set", "enabled");
            tunableVariant1.Set<TunableBasic>("enabled", set.InstanceKey);
        }
    }
}