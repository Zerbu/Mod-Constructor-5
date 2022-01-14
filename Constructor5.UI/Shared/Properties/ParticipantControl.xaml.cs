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
            => FancyMessageBox.Show("The participant is which Sim or object an action or condition will be applied to. If left empty, the game will decide based on the type of action or condition (usually, but not always, Actor).\n\nSome common values include:\nActor - The Sim initiating an action. This is the most common, and usually the default.\nTargetSim - The Sim being targetted by a social interaction.\nActiveHousehold - All Sims in the active household.\nAllOtherInstancedSims - Every Sim that has currently been loaded into the world.");
    }
}
