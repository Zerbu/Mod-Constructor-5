using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.Elements.CareerLevels
{
    [XmlSerializerExtraType]
    public class CareerLevelContextModifier : ContextModifier
    {
        public Reference Career { get; set; } = new Reference();
        public Reference Track { get; set; } = new Reference();
    }
}
