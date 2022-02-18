using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.Elements.Interactions.Social.ContextModifiers
{
    [XmlSerializerExtraType]
    public class SIAssociatedBuff : ContextModifier
    {
        public Reference Buff { get; set; }
    }
}