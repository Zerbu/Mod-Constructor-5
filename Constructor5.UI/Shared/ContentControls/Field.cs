using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Shared
{
    public class Field : ContentControl
    {
        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
            "Label",
            typeof(string),
            typeof(Field),
            new PropertyMetadata());

        public static readonly DependencyProperty LabelWidthProperty = DependencyProperty.Register(
            "LabelWidth",
            typeof(GridLength),
            typeof(Field),
            new PropertyMetadata(GridLength.Auto));

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public GridLength LabelWidth
        {
            get => (GridLength)GetValue(LabelWidthProperty);
            set => SetValue(LabelWidthProperty, value);
        }
    }
}