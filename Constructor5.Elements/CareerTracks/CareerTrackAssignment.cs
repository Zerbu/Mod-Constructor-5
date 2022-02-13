using Constructor5.Base.ElementSystem;
using Constructor5.Base.PropertyTypes;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.CareerTracks
{
    [XmlSerializerExtraType]
    public class CareerTrackAssignment : ReferenceListItem
    {
        public TestConditionList Conditions { get; set; } = new TestConditionList();
        public bool IsFirstAssignment { get; set; }
        public IntBounds LevelRestriction { get; set; } = new IntBounds();
        public int Weight { get; set; } = 1;
    }
}