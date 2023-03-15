using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.Elements.CareerEvents
{
    [XmlSerializerExtraType]
    public class CareerEventContextModifier : ContextModifier
    {
        public Reference Career { get; set; } = new Reference();
    }
}
