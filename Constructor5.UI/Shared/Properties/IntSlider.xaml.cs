using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Shared
{
    /// <summary>
    /// Interaction logic for IntSlider.xaml
    /// </summary>
    public partial class IntSlider : UserControl
    {
        public IntSlider() => InitializeComponent();

        public int Increment
        {
            get => (int)GetValue(IncrementProperty);
            set => SetValue(IncrementProperty, value);
        }

        public static readonly DependencyProperty IncrementProperty =
            DependencyProperty.Register("Increment", typeof(int), typeof(IntSlider),
                new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public int SliderMaximum
        {
            get => (int)GetValue(SliderMaximumProperty);
            set => SetValue(SliderMaximumProperty, value);
        }

        public static readonly DependencyProperty SliderMaximumProperty =
            DependencyProperty.Register("SliderMaximum", typeof(int), typeof(IntSlider), new PropertyMetadata(int.MaxValue));

        public int SliderMinimum
        {
            get => (int)GetValue(SliderMinimumProperty);
            set => SetValue(SliderMinimumProperty, value);
        }

        public static readonly DependencyProperty SliderMinimumProperty =
            DependencyProperty.Register("SliderMinimum", typeof(int), typeof(IntSlider), new PropertyMetadata(int.MinValue));

        public int Value
        {
            get => (int)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(IntSlider),
                new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    }
}
