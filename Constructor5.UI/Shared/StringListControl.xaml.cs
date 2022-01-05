using Constructor5.Base.ElementSystem;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Shared
{
    /// <summary>
    /// Interaction logic for StringListControl.xaml
    /// </summary>
    public partial class StringListControl : UserControl
    {
        public static readonly DependencyProperty PresetsFolderProperty =
            DependencyProperty.Register("PresetsFolder", typeof(string), typeof(StringListControl), new PropertyMetadata(null));

        public static readonly DependencyProperty StringListProperty =
                    DependencyProperty.Register("StringList", typeof(ObservableCollection<string>), typeof(StringListControl), new PropertyMetadata(null));

        public StringListControl()
        {
            InitializeComponent();
            Loaded += (e, args) =>
            {
                ((SimpleBrowsePresetsCommand)Resources["AddReferenceCommand"]).OwnerWindow = Window.GetWindow(this);
                ((SimpleBrowsePresetsCommand)Resources["AddReferenceCommand"]).PresetsFolder = PresetsFolder;
            };
        }

        public string PresetsFolder
        {
            get => (string)GetValue(PresetsFolderProperty);
            set => SetValue(PresetsFolderProperty, value);
        }

        public ObservableCollection<string> StringList
        {
            get => (ObservableCollection<string>)GetValue(StringListProperty);
            set => SetValue(StringListProperty, value);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            foreach(var selectedItem in ListView.SelectedItems.OfType<string>().ToArray())
            {
                StringList.Remove(selectedItem);
            }
        }

        private void SimpleBrowseElementsCommand_PresetsSelectedCallback(Preset[] presets)
        {
            foreach (var preset in presets)
            {
                StringList.Add(preset.Value);
            }
        }
    }
}