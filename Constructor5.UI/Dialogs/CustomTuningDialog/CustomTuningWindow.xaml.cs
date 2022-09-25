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
            Control.Element = element;
            Control.OwningWindow = this;
        }
    }
}