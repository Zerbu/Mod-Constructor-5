using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.TestConditions
{
    public class TestConditionList : ObservableCollection<TestConditionListItem>
    {
        public List<TestCondition> ToConditionList()
        {
            var result = new List<TestCondition>();
            foreach (var condition in this)
            {
                result.Add(condition.Condition);
            }
            return result;
        }
    }
}
