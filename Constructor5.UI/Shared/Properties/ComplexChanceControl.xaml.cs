using Constructor5.Base.PropertyTypes;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Shared
{
    /// <summary>
    /// Interaction logic for ComplexChanceControl.xaml
    /// </summary>
    public partial class ComplexChanceControl : UserControl
    {
        public static readonly DependencyProperty ChanceProperty =
            DependencyProperty.Register("Chance", typeof(ComplexChance), typeof(ComplexChanceControl),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public ComplexChanceControl() => InitializeComponent();

        public ComplexChance Chance
        {
            get => (ComplexChance)GetValue(ChanceProperty);
            set => SetValue(ChanceProperty, value);
        }
    }
}