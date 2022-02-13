using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.Elements.Interactions.Career
{
    [XmlSerializerExtraType]
    public class CareerInteractionContextModifier : ContextModifier
    {
        public Reference Career { get; set; } = new Reference();
    }
}
