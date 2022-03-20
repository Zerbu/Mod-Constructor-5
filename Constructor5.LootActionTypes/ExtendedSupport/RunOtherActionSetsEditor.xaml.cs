using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.LootActionTypes.ExtendedSupport
{
    [ObjectEditor(typeof(RunOtherActionSets))]
    public partial class RunOtherActionSetsEditor : UserControl, IObjectEditor
    {
        public RunOtherActionSetsEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}