using Constructor5.Base.ElementSystem;
using Constructor5.Base.PropertyTypes;

namespace Constructor5.Elements.Buffs.References
{
    public class BuffWithReason
    {
        public Reference Buff { get; set; } = new Reference();
        public STBLString Reason { get; set; } = new STBLString();
    }
}
