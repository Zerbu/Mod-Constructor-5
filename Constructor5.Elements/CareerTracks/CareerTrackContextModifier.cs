using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.Elements.CareerTracks
{
    [XmlSerializerExtraType]
    public class CareerTrackContextModifier : ContextModifier
    {
        public Reference Career { get; set; } = new Reference();
        public Reference ParentTrack { get; set; } = new Reference();
    }
}