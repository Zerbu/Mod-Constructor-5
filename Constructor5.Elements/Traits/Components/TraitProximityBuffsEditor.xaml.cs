using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Traits.Components
{
    [ObjectEditor(typeof(TraitProximityBuffs))]
    public partial class TraitProximityBuffsEditor : UserControl, IObjectEditor
    {
        public TraitProximityBuffsEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}