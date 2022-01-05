using Constructor5.Base.CustomTuning;
using Constructor5.Base.Export;
using Constructor5.Core;
using ICSharpCode.AvalonEdit.Folding;
using System.IO;
using System.Text;
using System.Windows;

namespace Constructor5.UI.Dialogs.CustomTuningDialog
{
    /// <summary>
    /// Interaction logic for CustomTuningWindow.xaml
    /// </summary>
    public partial class CustomTuningWindow : Window
    {
        public CustomTuningWindow() => InitializeComponent();

        public CustomTuningWindow(ISupportsCustomTuning element)
        {
            InitializeComponent();
            Element = element;

            FoldingManager = FoldingManager.Install(TextBox.TextArea);
            FoldingStrategy = new XmlFoldingStrategy();
            FoldingStrategy.UpdateFoldings(FoldingManager, TextBox.Document);

            TextBox.Text = element.CustomTuning.Text;
        }

        private ISupportsCustomTuning Element { get; set; }
        private FoldingManager FoldingManager { get; set; }
        private XmlFoldingStrategy FoldingStrategy { get; set; }

        private void TextBox_TextChanged(object sender, System.EventArgs e) => FoldingStrategy.UpdateFoldings(FoldingManager, TextBox.Document);

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Element.CustomTuning.Text = TextBox.Text;
            Close();
        }

        private void PreviewButton_Click(object sender, RoutedEventArgs e)
        {
            Exporter.Create();

            var previousText = Element.CustomTuning.Text;
            Element.CustomTuning.Text = TextBox.Text;
            Element.OnExport();
            Element.CustomTuning.Text = previousText;

            var memoryStream = new MemoryStream();
            XmlSaver.SaveStream(CustomTuningExporter.Header, memoryStream);

            new CustomTuningPreviewWindow
            {
                TextBox =
                {
                    Text = Encoding.UTF8.GetString(memoryStream.ToArray())
                },
                Owner = this
            }.ShowDialog();
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            FancyMessageBox.Show("Custom tuning allows you to define your own XML code that will be included in the exported file for an element.\n\nIf custom tuning is used to set a tunable that has already been set by Mod Constructor, it will be overridden instead of duplicated. If custom tuning is used to create a list (<L> tag) that already exists, the items will be added to the existing list rather than the list being completely replaced.\n\nIf the value of a simple tunable (<T> tag) is a hashtag (#) followed by the ID of an element in the mod, it will be replaced with the instance key of that element. For example, #MyCustomTrait will be replaced by the instance key of the element with the ID \"MyCustomTrait\".");
        }
    }
}