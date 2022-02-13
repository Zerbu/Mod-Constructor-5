using System.Windows;
using System.Windows.Controls;

namespace Constructor5.Elements.Careers.Templates
{
    /// <summary>
    /// Interaction logic for CareerTemplateMessageOverrideControl.xaml
    /// </summary>
    public partial class CareerTemplateMessageOverrideControl : UserControl
    {
        public static readonly DependencyProperty MessageOverrideProperty =
            DependencyProperty.Register("MessageOverride", typeof(CareerTemplateMessageOverride), typeof(CareerTemplateMessageOverrideControl), new PropertyMetadata(null));

        public CareerTemplateMessageOverrideControl() => InitializeComponent();

        public CareerTemplateMessageOverride MessageOverride
        {
            get => (CareerTemplateMessageOverride)GetValue(MessageOverrideProperty);
            set => SetValue(MessageOverrideProperty, value);
        }
    }
}