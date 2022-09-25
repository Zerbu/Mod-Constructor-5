using Constructor5.Base.CustomTuning;
using Constructor5.Base.ExportSystem;
using Constructor5.Core;
using ICSharpCode.AvalonEdit.Folding;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Dialogs.CustomTuningDialog
{
    /// <summary>
    /// Interaction logic for CustomTuningDialogControl.xaml
    /// </summary>
    public partial class CustomTuningDialogControl : UserControl
    {
        public static readonly DependencyProperty AutoUpdateProperty =
            DependencyProperty.Register("AutoUpdate", typeof(bool), typeof(CustomTuningDialogControl), new PropertyMetadata(false));

        public CustomTuningDialogControl()
        {
            InitializeComponent();
        }

        public bool AutoUpdate
        {
            get { return (bool)GetValue(AutoUpdateProperty); }
            set { SetValue(AutoUpdateProperty, value); }
        }

        public ISupportsCustomTuning Element
        {
            get => _element;
            set
            {
                _element = value;
                OnElementChanged();
            }
        }

        public FoldingManager FoldingManager { get; set; }
        public XmlFoldingStrategy FoldingStrategy { get; set; }
        public Window OwningWindow { get; set; }
        private ISupportsCustomTuning _element;

        private void AboutButton_Click(object sender, RoutedEventArgs e) => FancyMessageBox.Show("AboutCustomTuningMessageBox");

        private void OnElementChanged()
        {
            FoldingManager = FoldingManager.Install(TextBox.TextArea);
            FoldingStrategy = new XmlFoldingStrategy();
            FoldingStrategy.UpdateFoldings(FoldingManager, TextBox.Document);
            TextBox.Text = Element.CustomTuning.Text;
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
                Owner = OwningWindow
            }.ShowDialog();
        }

        private void TextBox_TextChanged(object sender, System.EventArgs e)
        {
            FoldingStrategy.UpdateFoldings(FoldingManager, TextBox.Document);
            if (AutoUpdate)
            {
                Element.CustomTuning.Text = TextBox.Text;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Element.CustomTuning.Text = TextBox.Text;
            OwningWindow.Close();
        }
    }
}