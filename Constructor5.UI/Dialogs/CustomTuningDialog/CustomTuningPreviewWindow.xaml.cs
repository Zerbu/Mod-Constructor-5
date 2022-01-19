using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Constructor5.UI.Dialogs.CustomTuningDialog
{
    /// <summary>
    /// Interaction logic for CustomTuningPreviewWindow.xaml
    /// </summary>
    public partial class CustomTuningPreviewWindow : Window
    {
        public CustomTuningPreviewWindow() => InitializeComponent();

        private void CloseButton_Click(object sender, RoutedEventArgs e) => Close();
    }
}
