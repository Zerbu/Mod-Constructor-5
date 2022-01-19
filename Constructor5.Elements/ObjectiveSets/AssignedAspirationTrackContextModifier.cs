using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.Elements.ObjectiveSets
{
    [XmlSerializerExtraType]
    public class AssignedAspirationTrackContextModifier : ContextModifier
    {
        public Reference AspirationTrack { get; set; } = new Reference();
    }
}
