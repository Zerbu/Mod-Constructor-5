using Constructor5.Base.ElementSystem;
using Constructor5.Xml;

namespace Constructor5.Elements.Buffs.References
{
    [XmlSerializerExtraType]
    public class WeightedBuffReferenceListItem : ReferenceListItem
    {
        public int Weight { get; set; } = 1;
    }
}
