using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.InteractionTemplates.Funny
{
    [ObjectEditor(typeof(FunnyIntroductionLootItem))]
    public partial class FunnyIntroductionLootItemEditor : UserControl, IObjectEditor
    {
        public FunnyIntroductionLootItemEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}