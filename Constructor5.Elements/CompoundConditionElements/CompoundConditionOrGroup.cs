using System.Collections.ObjectModel;

namespace Constructor5.Elements.CompoundConditionElements
{
    public class CompoundConditionOrGroup
    {
        public ObservableCollection<CompoundAndCondition> AndConditions { get; } = new ObservableCollection<CompoundAndCondition>();
    }
}
