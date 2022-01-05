using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.Elements.SituationGoals
{
    [XmlSerializerExtraType]
    public class HolidayTraditionContextModifier : ContextModifier
    {
        public Reference HolidayTradition { get; set; } = new Reference();
    }
}
