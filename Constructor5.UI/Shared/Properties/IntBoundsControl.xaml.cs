using Constructor5.Base.PropertyTypes;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Shared
{
    public partial class IntBoundsControl : UserControl
    {
        public static readonly DependencyProperty BoundsProperty =
            DependencyProperty.Register("Bounds", typeof(IntBounds), typeof(IntBoundsControl), new PropertyMetadata(null));

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(int), typeof(IntBoundsControl), new PropertyMetadata(int.MaxValue));

        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(int), typeof(IntBoundsControl), new PropertyMetadata(int.MinValue));

        public IntBoundsControl() => InitializeComponent();

        public IntBounds Bounds
        {
            get => (IntBounds)GetValue(BoundsProperty);
            set => SetValue(BoundsProperty, value);
        }

        public int Maximum
        {
            get => (int)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        public int Minimum
        {
            get => (int)GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, value);
        }
    }
}