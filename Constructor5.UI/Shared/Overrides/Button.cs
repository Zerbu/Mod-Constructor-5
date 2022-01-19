using System.Windows;

namespace Constructor5.UI.Shared
{
    public class Button : System.Windows.Controls.Button, ICanConvertContentToTextBlock
    {
        static Button() => CanConvertContentToTextBlockExtensions.StaticSetup<Button>(ContentProperty);

        public Button()
        {
            Style = (Style)Application.Current.Resources["ButtonStyle"];
            this.AddLoadedEvent();
        }

        public bool ShouldConvertStringToTextBlock
        {
            get => _shouldConvertStringToTextBlock;
            set
            {
                _shouldConvertStringToTextBlock = value;
                if (_shouldConvertStringToTextBlock)
                {
                    this.ConvertStringToTextBlock();
                }
            }
        }

        object ICanConvertContentToTextBlock.ContentToConvert
        {
            get => Content;
            set => Content = value;
        }

        private bool _shouldConvertStringToTextBlock = true;
    }
}