using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Traits.Components
{
    [ObjectEditor(typeof(TraitInfoComponent))]
    public partial class TraitInfoEditor : UserControl, IObjectEditor
    {
        public TraitInfoEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;

            var component = (TraitInfoComponent)obj;
            var trait = (Trait)component.Element;
            if (trait.GetContextModifier<CASPreferenceContextModifier>() != null)
            {
                Info.Visibility = System.Windows.Visibility.Collapsed;
                InheritedNotice.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
