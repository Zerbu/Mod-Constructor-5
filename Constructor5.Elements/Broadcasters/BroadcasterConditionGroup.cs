using Constructor5.Elements.TestConditions;
using Constructor5.UI.Shared;
using Constructor5.Xml;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.Broadcasters
{
    [XmlSerializerExtraType]
    public class BroadcasterConditionGroup : BroadcasterConditionGroupItem
    {
        public TestCondition Condition { get; set; } = new AlwaysRunCondition();
        public bool IsExpanded { get; set; }
        public ObservableCollection<BroadcasterConditionGroupItem> Items { get; } = new ObservableCollection<BroadcasterConditionGroupItem>();
    }
}