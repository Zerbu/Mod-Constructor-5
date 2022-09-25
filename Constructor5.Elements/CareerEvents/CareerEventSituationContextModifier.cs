using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.Elements.CareerEvents
{
    [XmlSerializerExtraType]
    public class CareerEventSituationContextModifier : ContextModifier
    {
        public Reference CareerEvent { get; set; } = new Reference();
    }
}