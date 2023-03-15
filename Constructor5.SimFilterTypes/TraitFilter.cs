using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.SimFilters;

namespace Constructor5.SimFilterTypes
{
    [SelectableObjectType("SimFilterTypes", "TraitFilter")]
    [XmlSerializerExtraType]
    public class TraitFilter : SimFilterTerm
    {
        public TraitFilter() => GeneratedLabel = "Trait Filter";

        [AutoTuneIfTrue("ignore_if_wrong_pack")]
        public bool IgnoreIfWrongPack { get; set; }

        public bool IsOptional { get; set; }


        [AutoTuneBasic("trait")]
        public Reference Trait { get; set; } = new Reference();

        protected override void OnExport(TunableList filterTermsTunable)
        {
            var tunableVariant1 = filterTermsTunable.Set<TunableVariant>(null, "trait");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("trait");
            AutoTunerInvoker.Invoke(this, tunableTuple1);

            if (IsOptional)
            {
                tunableTuple1.Set<TunableBasic>("minimum_filter_score", "0.1");
            }
        }
    }
}
