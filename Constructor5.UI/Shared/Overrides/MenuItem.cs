namespace Constructor5.UI.Shared
{
    public class MenuItem : System.Windows.Controls.MenuItem, ICanConvertContentToTextBlock
    {
        static MenuItem() => CanConvertContentToTextBlockExtensions.StaticSetup<MenuItem>(HeaderProperty);

        public MenuItem()
        {
            //Style = (Style)Application.Current.Resources["ButtonStyle"];
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
