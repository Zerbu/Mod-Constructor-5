using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Core;

namespace Constructor5.Elements.Traits.Components
{
    [XmlSerializerExtraType]
    public class TraitProximityBuffs : TraitComponent
    {
        public override string ComponentLabel => "ProximityBuffs";

        [AutoTuneReferenceList("buffs_proximity")]
        public ReferenceList ProximityBuffs { get; set; } = new ReferenceList();

        protected internal override void OnExport(TraitExportContext context) => AutoTunerInvoker.Invoke(this, context.Tuning);
    }
}
