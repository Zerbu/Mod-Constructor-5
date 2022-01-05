using Constructor5.UI.Dialogs;
using Constructor5.UI.Shared;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.Elements.LootActionSets
{
    [ObjectEditor(typeof(LootActionSet))]
    public partial class LootActionSetEditor : UserControl, IObjectEditor
    {
        public LootActionSetEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}