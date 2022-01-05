using Constructor5.UI.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace Constructor5.UI.Converters
{
    public class EnumSelectorValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dataProvider = (ObjectDataProvider)parameter;
            if (dataProvider.Data == null)
            {
                return null;
            }
            foreach (var data in ((IEnumerable<EnumSelectorValue>)dataProvider.Data))
            {
                if (data.Value.Equals(value))
                {
                    return data;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => ((EnumSelectorValue)value).Value;
    }
}
