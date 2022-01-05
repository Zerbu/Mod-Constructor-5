using Constructor5.Elements.TestConditions;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.LootActionSets
{
    public class LASConditionGroup : LASConditionGroupItem
    {
        public TestCondition Condition { get; set; } = new AlwaysRunCondition();
        public bool IsExpanded { get; set; }
        public ObservableCollection<LASConditionGroupItem> Items { get; } = new ObservableCollection<LASConditionGroupItem>();
    }
}