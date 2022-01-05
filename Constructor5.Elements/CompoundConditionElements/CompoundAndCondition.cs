using Constructor5.Elements.TestConditions;

namespace Constructor5.Elements.CompoundConditionElements
{
    public class CompoundAndCondition
    {
        public TestCondition Condition { get; set; } = new AlwaysRunCondition();
    }
}
