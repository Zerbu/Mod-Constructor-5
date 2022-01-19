using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.PropertyTypes;
using Constructor5.Core;

namespace Constructor5.SituationGoalTemplates.Single
{
    [XmlSerializerExtraType]
    public class SituationGoalRelationshipSettings
    {
        public ReferenceList ProhibitedBitsAll { get; set; } = new ReferenceList();
        public ReferenceList ProhibitedBitsAny { get; set; } = new ReferenceList();
        public ReferenceList RequiredBitsAll { get; set; } = new ReferenceList();
        public ReferenceList RequiredBitsAny { get; set; } = new ReferenceList();

        [AutoTuneBasic("track")]
        public Reference Track { get; set; } = new Reference();

        [AutoTuneTupleRange("relationship_score_interval")]
        public IntBounds TrackBounds { get; set; } = new IntBounds();
    }
}
