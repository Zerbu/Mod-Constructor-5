using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.Elements.Interactions.Social.ContextModifiers
{
    [XmlSerializerExtraType]
    public class SIAssociatedTrait : ContextModifier
    {
        public Reference Trait { get; set; }
    }
}