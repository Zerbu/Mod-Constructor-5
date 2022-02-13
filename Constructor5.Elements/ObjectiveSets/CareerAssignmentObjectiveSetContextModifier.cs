using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.Elements.ObjectiveSets
{
    [XmlSerializerExtraType]
    public class CareerAssignmentObjectiveSetContextModifier : ContextModifier
    {
        public Reference CareerTrack { get; set; } = new Reference();
    }
}