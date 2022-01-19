using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Constructor5.UI.Shared
{
    /// <summary>
    /// Interaction logic for SliderWithTextBoxControl.xaml
    /// </summary>
    public partial class DoubleSlider : UserControl
    {
        public DoubleSlider() => InitializeComponent();

        public double Increment
        {
            get => (double)GetValue(IncrementProperty);
            set => SetValue(IncrementProperty, value);
        }

        public static readonly DependencyProperty IncrementProperty =
            DependencyProperty.Register("Increment", typeof(double), typeof(DoubleSlider),
                new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public double SliderMaximum
        {
            get => (double)GetValue(SliderMaximumProperty);
            set => SetValue(SliderMaximumProperty, value);
        }

        public static readonly DependencyProperty SliderMaximumProperty =
            DependencyProperty.Register("SliderMaximum", typeof(double), typeof(DoubleSlider), new PropertyMetadata(double.MaxValue));

        public double SliderMinimum
        {
            get => (double)GetValue(SliderMinimumProperty);
            set => SetValue(SliderMinimumProperty, value);
        }

        public static readonly DependencyProperty SliderMinimumProperty =
            DependencyProperty.Register("SliderMinimum", typeof(double), typeof(DoubleSlider), new PropertyMetadata(double.MinValue));

        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(DoubleSlider),
                new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    }
}
