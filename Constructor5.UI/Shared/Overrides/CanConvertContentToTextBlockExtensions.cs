using System.Windows;

namespace Constructor5.UI.Shared
{
    internal static class CanConvertContentToTextBlockExtensions
    {
        internal static void AddLoadedEvent(this ICanConvertContentToTextBlock obj)
        {
            var frameworkElement = (FrameworkElement)obj;
            frameworkElement.Loaded += OnLoaded;
        }

        internal static void ConvertStringToTextBlock(this ICanConvertContentToTextBlock obj)
        {
            if (!obj.ShouldConvertStringToTextBlock)
            {
                return;
            }

            if (obj.ContentToConvert == null || !(obj.ContentToConvert is string))
            {
                return;
            }

            obj.ContentToConvert = new TextBlock
            {
                Text = (string)obj.ContentToConvert
            };
        }

        internal static void StaticSetup<T>(DependencyProperty contentProperty) where T : FrameworkElement, ICanConvertContentToTextBlock
        {
            contentProperty.OverrideMetadata(typeof(T), new FrameworkPropertyMetadata(null, new PropertyChangedCallback((dp, e) =>
            {
                var control = ((T)dp);

                if (!control.IsLoaded || !control.ShouldConvertStringToTextBlock)
                {
                    return;
                }

                control.ConvertStringToTextBlock();
            })));
        }

        private static void OnLoaded(object sender, RoutedEventArgs e)
        {
            var obj = (ICanConvertContentToTextBlock)sender;
            if (obj.ShouldConvertStringToTextBlock)
            {
                obj.ConvertStringToTextBlock();
            }

            var frameworkElement = (FrameworkElement)obj;
            frameworkElement.Loaded -= OnLoaded;
        }
    }
}