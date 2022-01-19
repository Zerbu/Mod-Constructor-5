using System.ComponentModel;

namespace Constructor5.Base.PropertyTypes
{
    public class IntBounds : INotifyPropertyChanged
    {
        public IntBounds() { }

        public IntBounds(bool restrictLower = false, bool restrictUpper = false, int lower = 0, int upper = 0)
        {
            RestrictLowerBound = restrictLower;
            RestrictUpperBound = restrictUpper;
            LowerBound = lower;
            UpperBound = upper;
        }

        public bool RestrictLowerBound { get; set; }
        public bool RestrictUpperBound { get; set; }
        public int LowerBound { get; set; } = 0;
        public int UpperBound { get; set; } = 0;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
