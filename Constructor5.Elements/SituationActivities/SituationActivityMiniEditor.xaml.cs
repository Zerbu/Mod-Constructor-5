using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SituationActivities
{
    [ObjectEditor(typeof(SituationActivity), "ElementMini")]
    public partial class SituationActivityMiniEditor : UserControl, IObjectEditor
    {
        public SituationActivityMiniEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}