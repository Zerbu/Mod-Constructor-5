using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.InteractionTemplates.Friendly
{
    [XmlSerializerExtraType]
    public class FriendlySocialLootItem : ReferenceListItem
    {
        public bool RunOnFailure { get; set; }
        public bool RunOnGreatSuccess { get; set; } = true;
        public bool RunOnHorribleFailure { get; set; }
        public bool RunOnSocialContextFailure { get; set; }
        public bool RunOnSuccess { get; set; } = true;
    }
}