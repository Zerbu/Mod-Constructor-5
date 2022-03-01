using Constructor5.Base.ElementSystem;
using Constructor5.Base.LocalizationSystem;
using Constructor5.Core;
using Constructor5.UI.Dialogs;
using Constructor5.UI.Dialogs.ElementFilter;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Constructor5.UI.Main
{
    /// <summary>
    /// Interaction logic for ElementSidebar.xaml
    /// </summary>
    public partial class ElementSidebar : UserControl, INotifyPropertyChanged, IOnUnlocalizableStringDetected, IOnElementContextSpecificChanged, IOnShowContextSpecificElementsChanged, IOnElementFilterSettingChanged
    {
        private static bool _showContextSpecificElements;

        public ElementSidebar()
        {
            InitializeComponent();
            Hooks.RegisterClass(this);

            ElementsSource = CollectionViewSource.GetDefaultView(ElementManager.AllElements);
            ElementsSource.Filter += (obj) =>
            {
                var element = (Element)obj;

                var searchText = ElementFilterSettings.Current.SearchText?.ToLower();
                if (!string.IsNullOrEmpty(searchText) && !PassesSearchFilter(searchText, element))
                {
                    return false;
                }

                if (!ElementFilterSettings.Current.ShowContextSpecific && element.IsContextSpecific)
                {
                    return false;
                }

                return true;
            };
            RefreshFilter();
        }

        private bool PassesSearchFilter(string searchText, Element element)
        {
            var passConditions = new List<bool>
            {
                ElementFilterSettings.Current.IncludeLabelInSearch && element.Label.ToLower().Contains(searchText),
                ElementFilterSettings.Current.IncludeIDInSearch && element.UserFacingId.ToLower().Contains(searchText),
                ElementFilterSettings.Current.IncludeTypeNameInSearch && element.TypeName.ToLower().Contains(searchText),
                ElementFilterSettings.Current.IncludeTagInSearch && element.TagText.ToLower().Contains(searchText)
            };

            foreach (var condition in passConditions)
            {
                if (condition)
                {
                    return true;
                }
            }

            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static bool ShowContextSpecificElements
        {
            get => _showContextSpecificElements;
            set
            {
                _showContextSpecificElements = value;
                Hooks.Location<IOnShowContextSpecificElementsChanged>(x => x.OnShowContextSpecificElementsChanged());
            }
        }

        public ICollectionView ElementsSource { get; private set; }

        void IOnElementContextSpecificChanged.OnElementContextSpecificChanged(Element element)
            => ElementsSource.Refresh();

        void IOnShowContextSpecificElementsChanged.OnShowContextSpecificElementsChanged()
            => ElementsSource.Refresh();

        void IOnUnlocalizableStringDetected.OnUnlocalizableStringDetected(string text)
        {
#if DEBUG
            UnlocalizableStringFinderButton.Visibility = System.Windows.Visibility.Visible;
            UnlocalizableStringsText.Foreground = new SolidColorBrush(Colors.Red);
#endif
        }

        private void ElementsControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var element = (Element)ElementsControl.SelectedItem;
            if (element == null)
            {
                return;
            }

            ElementManager.FocusedElement = element;

            Hooks.Location<IOnCallOpenElement>(x => x.OnCallOpenElement(element));
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e) => new ElementFilterWindow() { Owner = DialogUtility.GetOwner() }.ShowDialog();

        private void IssuesButton_Click(object sender, RoutedEventArgs e)
            => System.Diagnostics.Process.Start("https://github.com/Zerbu/Mod-Constructor-5/issues");

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) => ElementFilterSettings.Current.SearchText = SearchTextBox.Text;

        void IOnElementFilterSettingChanged.OnElementFilterSettingChanged()
        {
            RefreshFilter();
        }

        private void RefreshFilter()
        {
            ElementsSource.SortDescriptions.Clear();
            if (ElementFilterSettings.Current.SortByTag)
            {
                ElementsSource.SortDescriptions.Add(new SortDescription("HasTag", ListSortDirection.Descending));
                ElementsSource.SortDescriptions.Add(new SortDescription("TagText", ListSortDirection.Ascending));
            }
            if (ElementFilterSettings.Current.SortByType)
            {
                ElementsSource.SortDescriptions.Add(new SortDescription("TypeName", ListSortDirection.Ascending));
            }
            ElementsSource.SortDescriptions.Add(new SortDescription("Label", ListSortDirection.Ascending));
            ElementsSource.Refresh();
        }
    }
}