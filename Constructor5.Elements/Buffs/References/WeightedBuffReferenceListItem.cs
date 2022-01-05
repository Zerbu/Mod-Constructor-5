using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.Elements.Buffs.References
{
    [XmlSerializerExtraType]
    public class WeightedBuffReferenceListItem : ReferenceListItem
    {
        public int Weight { get; set; } = 1;
    }
}
