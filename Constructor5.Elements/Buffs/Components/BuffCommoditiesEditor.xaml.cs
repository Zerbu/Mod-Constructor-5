using Constructor5.Elements.Buffs.Modifiers;
using Constructor5.UI.Shared;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Constructor5.Elements.Buffs.Components
{
    [ObjectEditor(typeof(BuffCommoditiesComponent))]
    public partial class BuffCommoditiesEditor : UserControl, IObjectEditor
    {
        public BuffCommoditiesEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}