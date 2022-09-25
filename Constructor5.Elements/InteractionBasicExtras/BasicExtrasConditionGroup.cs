using Constructor5.Elements.TestConditions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Elements.InteractionBasicExtras
{
    public class BasicExtrasConditionGroup : BasicExtrasConditionGroupItem
    {
        public TestCondition Condition { get; set; } = new AlwaysRunCondition();
        public bool IsExpanded { get; set; }
        public ObservableCollection<BasicExtrasConditionGroupItem> Items { get; } = new ObservableCollection<BasicExtrasConditionGroupItem>();
    }
}
