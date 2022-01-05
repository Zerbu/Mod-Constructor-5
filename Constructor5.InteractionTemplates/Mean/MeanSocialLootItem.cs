using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.InteractionTemplates.Mean
{
    [XmlSerializerExtraType]
    public class MeanSocialLootItem : ReferenceListItem
    {
        public bool RunOnLevel1Success { get; set; } = true;
        public bool RunOnLevel2Success { get; set; } = true;
        public bool RunOnLevel3Success { get; set; } = true;
    }
}