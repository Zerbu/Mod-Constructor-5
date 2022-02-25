using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.LootActionTypes.Situations
{
    [ObjectEditor(typeof(StartSituationAction))]
    public partial class StartSituationActionEditor : UserControl, IObjectEditor
    {
        public StartSituationActionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}