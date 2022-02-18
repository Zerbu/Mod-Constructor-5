using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SituationActivities
{
    [ObjectEditor(typeof(SituationActivity))]
    public partial class SituationActivityEditor : UserControl, IObjectEditor
    {
        public SituationActivityEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}