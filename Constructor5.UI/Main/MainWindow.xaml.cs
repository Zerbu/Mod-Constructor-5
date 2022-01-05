using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem;
using Constructor5.Core;
using Constructor5.UI.Dialogs.ExportResults;
using Constructor5.UI.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Constructor5.UI.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged, IOnCallOpenElement, IOnExportComplete
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
                return !element.IsContextSpecific;
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICollectionView ElementsSource { get; private set; }
        public List<TaggedLayoutDocument> OpenDocuments { get; } = new List<TaggedLayoutDocument>();

        void IOnCallOpenElement.OnCallOpenElement(Element element) => OpenElement(element);

        void IOnExportComplete.OnExportComplete(ExportResultsData results) => new ExportResultsWindow(results) { Owner = this }.ShowDialog();

        private void ElementsControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var element = (Element)ElementsControl.SelectedItem;
            if (element == null)
            {
                return;
            }

            OpenElement(element);
        }

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
            var timer = new System.Threading.Timer((e) =>
            {
                ElementSaver.SaveScheduled();
            }, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) => ElementSaver.SaveScheduled();

        private void IssuesButton_Click(object sender, RoutedEventArgs e)
            => System.Diagnostics.Process.Start("https://github.com/Zerbu/Mod-Constructor-5/issues");
    }
}