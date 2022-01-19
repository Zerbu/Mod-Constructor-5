using Constructor5.Base.PropertyTypes;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Shared
{
    /// <summary>
    /// Interaction logic for ThresholdControl.xaml
    /// </summary>
    public partial class ThresholdControl : UserControl
    {
        public static readonly DependencyProperty ThresholdProperty =
            DependencyProperty.Register("Threshold", typeof(Threshold), typeof(ThresholdControl), new PropertyMetadata(null));

        public ThresholdControl() => InitializeComponent();

        public Threshold Threshold
        {
            get => (Threshold)GetValue(ThresholdProperty);
            set => SetValue(ThresholdProperty, value);
        }
    }
}