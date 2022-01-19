using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.SimFilters;

namespace Constructor5.SimFilterTypes
{
    [SelectableObjectType("SimFilterTypes", "Relationship Track Filter")]
    [XmlSerializerExtraType]
    public class RelationshipTrackFilter : SimFilterTerm
    {
        public RelationshipTrackFilter() => GeneratedLabel = "Relationship Track Filter";

        public int IdealValue { get; set; } = 0;
        public int MaxValue { get; set; } = 100;
        public int MinValue { get; set; } = -100;
        public Reference RelationshipTrack { get; set; } = new Reference();

        protected override void OnExport(TunableList filterTermsTunable)
        {
            var tunableVariant1 = filterTermsTunable.Set<TunableVariant>(null, "relationship_track");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("relationship_track");
            tunableTuple1.Set<TunableBasic>("ideal_value", IdealValue);
            tunableTuple1.Set<TunableBasic>("max_value", MaxValue);
            tunableTuple1.Set<TunableBasic>("min_value", MinValue);
            tunableTuple1.Set<TunableBasic>("relationship_track", RelationshipTrack);

            AutoTunerInvoker.Invoke(this, tunableTuple1);
        }
    }
}