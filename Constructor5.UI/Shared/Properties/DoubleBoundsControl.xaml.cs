using Constructor5.Base.PropertyTypes;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Shared
{
    public partial class DoubleBoundsControl : UserControl
    {
        public DoubleBoundsControl() => InitializeComponent();

        public DoubleBounds Bounds
        {
            get => (DoubleBounds)GetValue(BoundsProperty);
            set => SetValue(BoundsProperty, value);
        }

        public static readonly DependencyProperty BoundsProperty =
            DependencyProperty.Register("Bounds", typeof(DoubleBounds), typeof(DoubleBoundsControl), new PropertyMetadata(null));
    }
}