using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.Elements.Traits
{
    [XmlSerializerExtraType]
    public class CASPreferenceContextModifier : ContextModifier
    {
        public Reference CASPreference { get; set; } = new Reference();
        public bool IsDislike { get; set; }
        public bool IsBuff { get; set; }
    }
}