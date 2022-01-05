using Constructor5.Base.ElementSystem;
using Constructor5.Xml;

namespace Constructor5.InteractionTemplates.Romance
{
    [XmlSerializerExtraType]
    public class RomanceSocialLootItem : ReferenceListItem
    {
        public bool RunOnFailure { get; set; }
        public bool RunOnGreatSuccess { get; set; } = true;
        public bool RunOnHorribleFailure { get; set; }
        public bool RunOnSocialContextFailure { get; set; }
        public bool RunOnSuccess { get; set; } = true;
    }
}