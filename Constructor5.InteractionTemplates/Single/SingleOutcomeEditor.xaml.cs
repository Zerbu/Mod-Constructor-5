using Constructor5.InteractionTemplates.OneShot;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.InteractionTemplates.Single
{
    [ObjectEditor(typeof(SingleOutcomeTemplate))]
    [ObjectEditor(typeof(OneShotTemplate))]
    public partial class SingleOutcomeEditor : UserControl, IObjectEditor
    {
        public SingleOutcomeEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}