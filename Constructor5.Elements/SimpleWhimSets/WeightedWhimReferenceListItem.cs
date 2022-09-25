using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.Elements.SimpleWhimSets
{
    [XmlSerializerExtraType]
    public class WeightedWhimReferenceListItem : ReferenceListItem
    {
        public int Weight { get; set; } = 1;
    }
}
