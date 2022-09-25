using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.BasicExtraTypes.Buffs
{
    [ObjectEditor(typeof(AddBuffBasicExtra))]
    public partial class AddBuffBasicExtraEditor : UserControl, IObjectEditor
    {
        public AddBuffBasicExtraEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}