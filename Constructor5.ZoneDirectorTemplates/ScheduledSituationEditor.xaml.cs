using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.ZoneDirectorTemplates
{
    [ObjectEditor(typeof(ScheduledSituation))]
    public partial class ScheduledSituationEditor : UserControl, IObjectEditor
    {
        public ScheduledSituationEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}