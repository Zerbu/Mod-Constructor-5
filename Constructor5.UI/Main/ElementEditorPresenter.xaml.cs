using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.UI.Dialogs;
using Constructor5.UI.Dialogs.CustomTuningDialog;
using Constructor5.UI.Dialogs.ElementSettings;
using Constructor5.UI.Dialogs.MacroSelector;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Main
{
    /// <summary>
    /// Interaction logic for ElementEditor.xaml
    /// </summary>
    public partial class ElementEditorPresenter : UserControl
    {
        public ElementEditorPresenter() => InitializeComponent();

        public Element Element
        {
            get => (Element)GetValue(ElementProperty);
            set => SetValue(ElementProperty, value);
        }

        public static readonly DependencyProperty ElementProperty =
            DependencyProperty.Register("Element", typeof(Element), typeof(ElementEditorPresenter), new PropertyMetadata(null, (dp, e) =>
            {
                var presenter = (ElementEditorPresenter)dp;
                if (!(e.NewValue is ISupportsCustomTuning))
                {
                    presenter.CustomTuningButton.Visibility = Visibility.Collapsed;
                }
            }));

        private void ElementSettingsButton_Click(object sender, RoutedEventArgs e)
            => new ElementSettingsWindow(Element) { Owner = Window.GetWindow(this) }.ShowDialog();

        private void MacrosButton_Click(object sender, RoutedEventArgs e)
            => new MacroSelectorWindow(Element) { Owner = Window.GetWindow(this) }.ShowDialog();
    }
}
