using Constructor5.Base.ElementSystem;
using Constructor5.Xml;

namespace Constructor5.InteractionTemplates.Mischief
{
    [XmlSerializerExtraType]
    public class MischiefSocialLootItem : ReferenceListItem
    {
        public bool RunOnFailure { get; set; }
        public bool RunOnSocialContextFailure { get; set; }
        public bool RunOnSuccess { get; set; } = true;
    }
}