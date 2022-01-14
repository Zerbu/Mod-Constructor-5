using Constructor5.Base.ElementSystem;
using Constructor5.UI.Dialogs.PresetSelect;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Shared
{
    /// <summary>
    /// Interaction logic for TextBoxWithPresetsControl.xaml
    /// </summary>
    public partial class TextBoxWithPresetsControl : UserControl
    {
        public TextBoxWithPresetsControl() => InitializeComponent();

        public string PresetsFolder
        {
            get => (string)GetValue(PresetsFolderProperty);
            set => SetValue(PresetsFolderProperty, value);
        }

        public static readonly DependencyProperty PresetsFolderProperty =
            DependencyProperty.Register("PresetsFolder", typeof(string), typeof(TextBoxWithPresetsControl), new PropertyMetadata(null));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(TextBoxWithPresetsControl),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new PresetSelectWindow(null, new List<string> { PresetsFolder });
            window.PresetsSelectedCallback += (presets) =>
            {
                Text = ((Preset)presets[0]).Value;
            };
            window.ShowDialog();
        }
    }
}
