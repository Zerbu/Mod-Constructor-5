using System.Windows;

namespace Constructor5.UI.Shared
{
    public class Expander : System.Windows.Controls.Expander, ICanConvertContentToTextBlock
    {
        static Expander() => CanConvertContentToTextBlockExtensions.StaticSetup<Button>(HeaderProperty);

        public Expander()
        {
            Style = (Style)Application.Current.Resources["ExpanderStyle"];
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
            get => Header;
            set => Header = value;
        }

        private bool _shouldConvertStringToTextBlock = true;
    }
}
