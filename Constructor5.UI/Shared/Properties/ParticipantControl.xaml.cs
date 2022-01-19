using Constructor5.UI.Dialogs;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Shared
{
    /// <summary>
    /// Interaction logic for ParticipantControl.xaml
    /// </summary>
    public partial class ParticipantControl : UserControl
    {
        public ParticipantControl() => InitializeComponent();

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ParticipantControl),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        private void HelpButton_Click(object sender, RoutedEventArgs e)
            => FancyMessageBox.Show("ParticipantsHelp");
    }
}
