using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Elements.Traits;
using Constructor5.Core;

namespace Constructor5.Elements.Buffs.Components
{
    [XmlSerializerExtraType]
    [SharedWithTraits]
    public class BuffMixerInteractionsComponent : BuffComponent
    {
        public override string ComponentLabel => "MixerInteractions";

        public ReferenceList MixerInteractions { get; set; } = new ReferenceList();

        protected internal override bool HasContent() => MixerInteractions.HasItems();

        protected internal override void OnExport(BuffExportContext context)
        {
            if (MixerInteractions.HasItems())
            {
                var tunableVariant1 = context.Tuning.Set<TunableVariant>("interactions", "enabled");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("enabled");
                var tunableList1 = tunableTuple1.Get<TunableList>("interaction_items");
                foreach(var interaction in ElementTuning.GetInstanceKeys(MixerInteractions))
                {
                    tunableList1.Set<TunableBasic>(null, interaction);
                }
            }
        }
    }
}