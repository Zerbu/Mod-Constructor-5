using Constructor5.Base.ElementSystem;
using Constructor5.Elements.Commodities;

namespace Constructor5.Elements.Statistics
{
    [ElementTypeData(PresetFolders = new[] { "Statistic", "Commodity", "Skill", "RelationshipTrack", "Need", "SimInfoStatistic" }, ElementTypes = new[] { typeof(Commodity) })]
    public class Statistic : Element
    {
    }
}
