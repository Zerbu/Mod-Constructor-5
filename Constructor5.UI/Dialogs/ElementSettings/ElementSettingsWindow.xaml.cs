using Constructor5.Base.ElementSystem;
using System.Linq;
using System.Windows;

namespace Constructor5.UI.Dialogs.ElementSettings
{
    /// <summary>
    /// Interaction logic for ElementSettingsWindow.xaml
    /// </summary>
    public partial class ElementSettingsWindow : Window
    {
        public ElementSettingsWindow() => InitializeComponent();

        public ElementSettingsWindow(Element element)
        {
            InitializeComponent();
            Element = element;
            LabelTextBox.Text = element.CustomLabel;
            IDTextBox.Text = element.UserFacingId;
            ShowPresetCheckBox.IsChecked = element.ShowPreset;
            if (!element.IsContextSpecific)
            {
                ContextSpecificInfo.Visibility = Visibility.Collapsed;
            }
            if (element.ContextModifiers.Count > 0)
            {
                ConvertCheckBox.Visibility = Visibility.Collapsed;
            }
            else
            {
                ContextModifierInfo.Visibility = Visibility.Collapsed;
            }
            if (element.InstanceKeyOverride != null)
            {
                InstanceKeyOverrideExpander.IsExpanded = true;
                InstanceKeyOverrideTextBox.Text = element.InstanceKeyOverride.ToString();
            }
        }

        private Element Element { get; set; }

        private void CancelButton_Click(object sender, RoutedEventArgs e) => Close();

        private void GenerateIDButton_Click(object sender, RoutedEventArgs e)
            => IDTextBox.Text = ElementManager.GenerateID(Element.Label);

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var inputId = IDTextBox.Text;

            if (string.IsNullOrEmpty(inputId))
            {
                inputId = Element.Guid;
            }

            if (!inputId.All(char.IsLetterOrDigit))
            {
                FancyMessageBox.Show($"ID cannot contain spaces or non-alphanumeric characters.");
                return;
            }

            foreach (var element in ElementManager.GetAll())
            {
                if (element == Element)
                {
                    continue;
                }

                if (element.UserFacingId == inputId)
                {
                    FancyMessageBox.Show($"{element.UserFacingId} is already in use by another element.");
                    return;
                }
            }

            Element.CustomLabel = !string.IsNullOrEmpty(LabelTextBox.Text) ? LabelTextBox.Text : null;
            Element.UserFacingId = inputId;

            Element.ShowPreset = ShowPresetCheckBox.IsChecked ?? false;

            if (ConvertCheckBox.IsChecked ?? false)
            {
                Element.IsContextSpecific = false;
            }

            if (!string.IsNullOrEmpty(InstanceKeyOverrideTextBox.Text))
            {
                Element.InstanceKeyOverride = ulong.TryParse(InstanceKeyOverrideTextBox.Text, out var value) ? value : (ulong?)null;
            }
            else
            {
                Element.InstanceKeyOverride = null;
            }

            Close();
        }
    }
}