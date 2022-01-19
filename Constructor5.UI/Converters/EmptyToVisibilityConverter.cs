using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Constructor5.UI.Converters
{
    public class EmptyToVisibilityConverter : IValueConverter
    {
        public bool Inverted { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringValue = value.ToString();

            var condition = string.IsNullOrEmpty(stringValue);
            if (Inverted)
            {
                condition = !condition;
            }

            return condition ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new InvalidOperationException();
    }
}