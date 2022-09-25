using Constructor5.Base.DebugCommandSystem;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem;
using Constructor5.Base.LocalizationSystem;
using Constructor5.Core;
using Constructor5.UI.Dialogs.ElementFilter;
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
    public partial class MainWindow : Window, INotifyPropertyChanged, IOnCallOpenElement, IOnExportComplete, IOnElementDeleted
    {
        public MainWindow()
        {
            InitializeComponent();
            Hooks.RegisterClass(this);
            StartAutosaveTimer();
            ((SimpleOpenWindowCommand)Resources["ElementAddCommand"]).OwnerWindow = this;

            var version = File.ReadAllText("Version.txt");
            Title = $"The Sims 4 Mod Constructor ({version})";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<TaggedLayoutDocument> OpenDocuments { get; } = new List<TaggedLayoutDocument>();

        void IOnCallOpenElement.OnCallOpenElement(Element element) => OpenElement(element);

        void IOnElementDeleted.OnElementDeleted(Element element)
        {
            var document = LayoutDocumentPane.Children.OfType<TaggedLayoutDocument>().FirstOrDefault(x => x.Tag == element);
            if (document != null)
            {
                LayoutDocumentPane.Children.Remove(document);
            }
        }

        void IOnExportComplete.OnExportComplete(ExportResultsData results)
        {
            new ExportResultsWindow(results) { Owner = this }.ShowDialog();
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