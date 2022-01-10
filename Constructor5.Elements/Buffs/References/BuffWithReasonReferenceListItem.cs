using Constructor5.Base.ElementSystem;
using Constructor5.Base.PropertyTypes;
using Constructor5.Core;

namespace Constructor5.Elements.Buffs.References
{
    [XmlSerializerExtraType]
    public class BuffWithReasonReferenceListItem : ReferenceListItem
    {
        public STBLString Reason { get; set; } = new STBLString();
    }
}
