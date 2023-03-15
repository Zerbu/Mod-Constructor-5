using Constructor5.Base.ElementSystem;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;

namespace Constructor5.ZoneDirectorTemplates
{
    [XmlSerializerExtraType]
    public class ScheduledSituation : ReferenceListItem
    {
        public int Weight { get; set; } = 1;
        public TestConditionList Conditions { get; set; } = new TestConditionList();
    }
}