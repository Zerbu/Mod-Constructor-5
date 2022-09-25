using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.Elements.EnumExtensions
{
    [XmlSerializerExtraType]
    public class EnumExtensionTag : EnumExtensionItem
    {
        public ReferenceList InjectToInteractions { get; set; } = new ReferenceList();
    }
}