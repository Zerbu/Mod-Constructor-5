using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Constructor5.UI.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public bool Inverted { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolValue = (bool)value;
            if (boolValue)
            {
                return Inverted ? Visibility.Collapsed : Visibility.Visible;
            }

            return Inverted ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => ((Visibility)value) == Visibility.Visible;
    }
}