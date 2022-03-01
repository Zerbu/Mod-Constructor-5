using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.InteractionTemplates.Funny
{
    [XmlSerializerExtraType]
    public class FunnyIntroductionLootItem : ReferenceListItem
    {
        public bool RunOnFailure { get; set; }
        public bool RunOnGreatSuccess { get; set; } = true;
        public bool RunOnSuccess { get; set; } = true;
    }
}