using Constructor5.Base.LocalizationSystem;
using System.ComponentModel;
using System.Windows;

namespace Constructor5.UI.Shared
{
    public class TextBlock : System.Windows.Controls.TextBlock
    {
        static TextBlock()
        {
            TextProperty.OverrideMetadata(typeof(TextBlock), new FrameworkPropertyMetadata(null, new PropertyChangedCallback((dp, e) =>
            {
                var control = ((TextBlock)dp);

                if (!control.IsLoaded)
                {
                    return;
                }

                if (control.IsSettingExactText || !control.IsLocalizable)
                {
                    return;
                }

                control.UpdateLocalization();
            })));
        }

        public TextBlock()
        {
            TextWrapping = TextWrapping.Wrap;
            Loaded += OnLoaded;
        }

        public bool IsLocalizable
        {
            get => _isLocalizable;
            set
            {
                _isLocalizable = value;
                if (_isLocalizable)
                {
                    UpdateLocalization();
                }
            }
        }

        public void SetExactText(string text)
        {
            IsSettingExactText = true;
            Text = text;
            IsSettingExactText = false;
        }

        private bool _isLocalizable = true;

        private bool IsSettingExactText { get; set; }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (IsLocalizable)
            {
                UpdateLocalization();
            }
            Loaded -= OnLoaded;
        }

        private void UpdateLocalization()
        {
            SetExactText(TextStringManager.Get(Text));
        }
    }
}