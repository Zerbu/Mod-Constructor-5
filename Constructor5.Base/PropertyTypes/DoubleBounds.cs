using System.ComponentModel;

namespace Constructor5.Base.PropertyTypes
{
    public class DoubleBounds : INotifyPropertyChanged
    {
        public DoubleBounds()
        { }

        public DoubleBounds(bool restrictLower = false, bool restrictUpper = false, double lower = 0, double upper = 0)
        {
            RestrictLowerBound = restrictLower;
            RestrictUpperBound = restrictUpper;
            LowerBound = lower;
            UpperBound = upper;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public double LowerBound { get; set; } = 0;
        public bool RestrictLowerBound { get; set; }
        public bool RestrictUpperBound { get; set; }
        public double UpperBound { get; set; } = 0;
    }
}