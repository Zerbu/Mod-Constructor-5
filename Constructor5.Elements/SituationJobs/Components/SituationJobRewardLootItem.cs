using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.Elements.SituationJobs.Components
{
    [XmlSerializerExtraType]
    public class SituationJobRewardLootItem : ReferenceListItem
    {
        public bool RunOnBronze { get; set; }
        public bool RunOnGold { get; set; }
        public bool RunOnNoMedal { get; set; }
        public bool RunOnSilver { get; set; }
        // public Reference TargetSimJob { get; set; } = new Reference(); not currently implemented
    }
}