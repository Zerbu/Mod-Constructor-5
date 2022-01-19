using Constructor5.Base.ElementSystem;
using Constructor5.Elements.CompoundConditionElements;
using Constructor5.UI.Dialogs.ObjectTypeSelector;
using System.Linq;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Compound
{
    [ObjectTypeExtraTab("TestConditionTypes")]
    public partial class CompoundConditionSelector : UserControl, IObjectTypeSelectorExtraTab
    {
        public CompoundConditionSelector() => InitializeComponent();

        public string TabName => "CompoundConditionElements";

        public void Initialize(ObjectTypeSelectorWindow selectorWindow)
        {
            ItemsControl.ItemsSource = ElementManager.GetAll(true).Where(x=>x.ShowPreset).OfType<CompoundConditionElement>();
            ObjectTypeSelectorWindow = selectorWindow;
        }

        private ObjectTypeSelectorWindow ObjectTypeSelectorWindow { get; set; }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var element = (CompoundConditionElement)((Button)sender).Tag;
            var condition = new CompoundCondition() { CompoundConditionElement = new Reference(element), GeneratedLabel = element.Label };
            ObjectTypeSelectorWindow.NotifyObjectChanged(condition);
            ObjectTypeSelectorWindow.Close();
        }
    }
}