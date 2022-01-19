namespace Constructor5.Base.PropertyTypes
{
    public class Threshold
    {
        public Threshold()
        { }

        public Threshold(double amount, ThresholdComparison comparison = ThresholdComparison.GREATER_OR_EQUAL)
        {
            Amount = amount;
            Comparison = comparison;
        }

        public double Amount { get; set; }
        public ThresholdComparison Comparison { get; set; } = ThresholdComparison.GREATER_OR_EQUAL;
    }
}