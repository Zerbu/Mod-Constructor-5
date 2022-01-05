using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Constructor5.UI.Converters
{
    public class PathToReadOnlySourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            Debug.Assert(value is string, "PathToReadOnlySourceConverter: object must be a string");

            if (!File.Exists((string)value))
            {
                return null;
            }

            try
            {
                using (var fileStream = File.OpenRead((string)value))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        fileStream.CopyTo(memoryStream);
                        var result = new BitmapImage();
                        result.BeginInit();
                        result.StreamSource = memoryStream;
                        result.CacheOption = BitmapCacheOption.OnLoad;
                        result.EndInit();
                        result.Freeze();
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                try
                {
                }
                catch { }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
