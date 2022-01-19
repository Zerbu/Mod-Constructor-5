using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Buffs.Components
{
    [ObjectEditor(typeof(BuffSpecialCasesComponent))]
    public partial class BuffSpecialCasesEditor : UserControl, IObjectEditor
    {
        public BuffSpecialCasesEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}
