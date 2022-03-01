using Constructor5.Base.ElementSystem;
using Constructor5.UI.Shared;
using System.Collections.Generic;
using System.Windows;

namespace Constructor5.UI.Dialogs.ElementFilter
{
    /// <summary>
    /// Interaction logic for ElementFilterWindow.xaml
    /// </summary>
    public partial class ElementFilterWindow : Window
    {
        public ElementFilterWindow() => InitializeComponent();

        private List<string> SelectedTags { get; } = new List<string>();

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            ElementFilterSettings.Current.SearchText = SearchTextBox.Text;
            ElementFilterSettings.Current.SortByType = SortByTypeCheckBox.IsChecked == true;
            ElementFilterSettings.Current.SortByTag = SortByTagCheckBox.IsChecked == true;
            ElementFilterSettings.Current.ShowContextSpecific = ShowContextSpecificCheckBox.IsChecked == true;

            ElementFilterSettings.Current.IncludeIDInSearch = IncludeIDInSearchCheckBox.IsChecked == true;
            ElementFilterSettings.Current.IncludeLabelInSearch = IncludeLabelInSearchCheckBox.IsChecked == true;
            ElementFilterSettings.Current.IncludeTagInSearch = IncludeTagInSearchCheckBox.IsChecked == true;
            ElementFilterSettings.Current.IncludeTypeNameInSearch = IncludeTypeNameInSearchCheckBox.IsChecked == true;

            ElementFilterSettings.Current.Save();
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = ElementFilterSettings.Current.SearchText;
            SortByTypeCheckBox.IsChecked = ElementFilterSettings.Current.SortByType;
            SortByTagCheckBox.IsChecked = ElementFilterSettings.Current.SortByTag;
            ShowContextSpecificCheckBox.IsChecked = ElementFilterSettings.Current.ShowContextSpecific;

            IncludeIDInSearchCheckBox.IsChecked = ElementFilterSettings.Current.IncludeIDInSearch;
            IncludeLabelInSearchCheckBox.IsChecked = ElementFilterSettings.Current.IncludeLabelInSearch;
            IncludeTagInSearchCheckBox.IsChecked = ElementFilterSettings.Current.IncludeTagInSearch;
            IncludeTypeNameInSearchCheckBox.IsChecked = ElementFilterSettings.Current.IncludeTypeNameInSearch;
        }
    }
}