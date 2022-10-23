using Constructor5.Elements.Traits.Components;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Traits
{
    [ObjectEditor(typeof(Trait), "ElementMini")]
    public partial class TraitMiniEditor : UserControl, IObjectEditor
    {
        public TraitMiniEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
            var trait = (Trait)obj;
            var info = trait.GetTraitComponent<TraitInfoComponent>();
            NameDescriptionIcon.DataContext = info;
            Type.DataContext = info;

            if (tag == "ShowOrigin")
            {
                TraitOrigin.DataContext = trait.GetTraitComponent<TraitSpecialCasesComponent>();
                TraitOrigin.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}