using Constructor5.Base.ElementSystem;
using Constructor5.Xml;

namespace Constructor5.Elements.Interactions.Social.ContextModifiers
{
    [XmlSerializerExtraType]
    public class SIAssociatedTrait : ContextModifier
    {
        public Reference Trait { get; set; }
    }
}