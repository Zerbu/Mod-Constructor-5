using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.Elements.Statistics
{
    [XmlSerializerExtraType]
    public class CareerPerformanceStatisticContextModifier : ContextModifier
    {
        public Reference Career { get; set; } = new Reference();
    }
}