using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.SimFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.SimFilterTypes
{
    [SelectableObjectType("SimFilterTypes", "Relationship Bit Filter")]
    [XmlSerializerExtraType]
    public class RelationshipBitFilter : SimFilterTerm
    {
        public RelationshipBitFilter() => GeneratedLabel = "Relationship Bit Filter";

        [AutoTuneReferenceList("black_list")]
        public ReferenceList Blacklist { get; set; } = new ReferenceList();

        [AutoTuneReferenceList("white_list")]
        public ReferenceList Whitelist { get; set; } = new ReferenceList();

        protected override void OnExport(TunableList filterTermsTunable)
        {
            var tunableVariant1 = filterTermsTunable.Set<TunableVariant>(null, "relationship_bit");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("relationship_bit");
            AutoTunerInvoker.Invoke(this, tunableTuple1);
        }
    }
}
