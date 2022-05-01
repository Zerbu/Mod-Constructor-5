using Constructor5.Base.CustomTuning;
using Constructor5.Base.ExportSystem;
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

        private void AboutButton_Click(object sender, RoutedEventArgs e) => FancyMessageBox.Show("AboutCustomTuningMessageBox");
    }
}