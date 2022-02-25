using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem;
using Constructor5.Base.LocalizationSystem;
using Constructor5.Core;
using Constructor5.UI.Dialogs.ExportResults;
using Constructor5.UI.Shared;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Constructor5.UI.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged, IOnCallOpenElement, IOnExportComplete, IOnElementDeleted, IOnUnlocalizableStringDetected, IOnElementContextSpecificChanged, IOnShowContextSpecificElementsChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            Hooks.RegisterClass(this);
            StartAutosaveTimer();
            ((SimpleOpenWindowCommand)Resources["ElementAddCommand"]).OwnerWindow = this;

            ElementsSource = CollectionViewSource.GetDefaultView(ElementManager.AllElements);
            ElementsSource.SortDescriptions.Add(new SortDescription("Label", ListSortDirection.Ascending));
            ElementsSource.Filter += (obj) =>
            {
                var element = (Element)obj;

                if (!string.IsNullOrEmpty(SearchBoxText))
                {
                    if (!element.Label.ToLower().Contains(SearchBoxText.ToLower())
                        && !element.UserFacingId.ToLower().Contains(SearchBoxText.ToLower())
                        && !element.GetType().Name.ToLower().Contains(SearchBoxText.ToLower())
                        )
                    {
                        return false;
                    }
                }

                if (!ShowContextSpecificElements && element.IsContextSpecific)
                {
                    return false;
                }

                return true;
            };

            var version = File.ReadAllText("Version.txt");
            Title = $"The Sims 4 Mod Constructor ({version})";
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
        public List<TaggedLayoutDocument> OpenDocuments { get; } = new List<TaggedLayoutDocument>();
        public string SearchBoxText { get; set; }

        void IOnCallOpenElement.OnCallOpenElement(Element element) => OpenElement(element);

        void IOnElementContextSpecificChanged.OnElementContextSpecificChanged(Element element)
            => ElementsSource.Refresh();

        void IOnElementDeleted.OnElementDeleted(Element element)
        {
            var document = LayoutDocumentPane.Children.OfType<TaggedLayoutDocument>().FirstOrDefault(x => x.Tag == element);
            if (document != null)
            {
                LayoutDocumentPane.Children.Remove(document);
            }
        }

        void IOnExportComplete.OnExportComplete(ExportResultsData results) => new ExportResultsWindow(results) { Owner = this }.ShowDialog();

        void IOnShowContextSpecificElementsChanged.OnShowContextSpecificElementsChanged()
            => ElementsSource.Refresh();

        void IOnUnlocalizableStringDetected.OnUnlocalizableStringDetected(string text)
        {
#if DEBUG
            UnlocalizableStringFinderButton.Visibility = Visibility.Visible;
            UnlocalizableStringsText.Foreground = new SolidColorBrush(Colors.Red);
#endif
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
            if (e.PropertyName == nameof(SearchBoxText))
            {
                ElementsSource.Refresh();
            }
        }

        private static bool _showContextSpecificElements;

        private void ElementsControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var element = (Element)ElementsControl.SelectedItem;
            if (element == null)
            {
                return;
            }

            ElementManager.FocusedElement = element;

            OpenElement(element);
        }

        private void IssuesButton_Click(object sender, RoutedEventArgs e)
            => System.Diagnostics.Process.Start("https://github.com/Zerbu/Mod-Constructor-5/issues");

        private void OpenElement(Element element)
        {
            var existingDocument = OpenDocuments.FirstOrDefault(x => x.Tag == element);
            if (existingDocument != null)
            {
                existingDocument.IsSelected = true;
                return;
            }

            TaggedLayoutDocument layoutDocument = new TaggedLayoutDocument { Title = element.Label, Tag = element };

            layoutDocument.Content = new ElementEditorPresenter() { Element = element };
            LayoutDocumentPane.Children.Add(layoutDocument);
            layoutDocument.IsSelected = true;

            OpenDocuments.Add(layoutDocument);
            layoutDocument.Closed += (s, ev) =>
            {
                OpenDocuments.Remove(layoutDocument);
            };
        }

        private void StartAutosaveTimer()
        {
            var timer = new Timer(60000); // 1 minute
            timer.Elapsed += (s, e) =>
            {
                ElementSaver.SaveScheduled();
            };

            timer.Start();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ElementSaver.SaveScheduled();
        }
    }
}