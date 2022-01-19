using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Elements.Shared;
using Constructor5.Core;

namespace Constructor5.Elements.Traits.Components
{
    [XmlSerializerExtraType]
    public class TraitWhimsComponent : TraitComponent
    {
        public override string ComponentLabel => "Whims";

        public STBLString Reason { get; set; } = new STBLString() { CustomText = "(From Custom Trait)" };
        public ReferenceList Whims { get; set; } = new ReferenceList();

        protected internal override void OnExport(TraitExportContext context)
        {
            if (!Whims.HasItems())
            {
                return;
            }

            var set = WhimSetBuilder.BuildWhimSet(ElementTuning.GetFullName(Element, "WhimSet"), Reason, Whims, 1);
            var tunableVariant1 = context.Tuning.Set<TunableVariant>("whim_set", "enabled");
            tunableVariant1.Set<TunableBasic>("enabled", set.InstanceKey);
        }
    }
}
