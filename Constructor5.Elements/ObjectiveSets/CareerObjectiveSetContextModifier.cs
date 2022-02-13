using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.Elements.ObjectiveSets
{
    [XmlSerializerExtraType]
    public class CareerObjectiveSetContextModifier : ContextModifier
    {
        public Reference CareerLevel { get; set; } = new Reference();
    }
}
