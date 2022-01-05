using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.InteractionTemplates.Mean
{
    [ObjectEditor(typeof(MeanSocialLootItem))]
    public partial class MeanSocialLootItemEditor : UserControl, IObjectEditor
    {
        public MeanSocialLootItemEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}