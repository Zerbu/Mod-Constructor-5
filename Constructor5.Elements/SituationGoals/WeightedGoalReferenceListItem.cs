using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.Elements.SituationGoals
{
    [XmlSerializerExtraType]
    public class WeightedGoalReferenceListItem : ReferenceListItem
    {
        public int Weight { get; set; } = 1;
    }
}