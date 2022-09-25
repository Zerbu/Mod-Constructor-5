using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.SituationGoalTemplates.Single
{
    [ObjectEditor(typeof(SituationGoalTravelTemplate))]
    public partial class SituationGoalTravelTemplateEditor : UserControl, IObjectEditor
    {
        public SituationGoalTravelTemplateEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}