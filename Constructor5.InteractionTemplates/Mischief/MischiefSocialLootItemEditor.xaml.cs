using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.InteractionTemplates.Mischief
{
    [ObjectEditor(typeof(MischiefSocialLootItem))]
    public partial class MischiefSocialLootItemEditor : UserControl, IObjectEditor
    {
        public MischiefSocialLootItemEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}