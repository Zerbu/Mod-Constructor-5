using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.WeeklyScheduleSituationDataSnippets
{
    [ObjectEditor(typeof(WeeklyScheduleSituationData))]
    [ObjectEditor(typeof(WeeklyScheduleSituationData), "ElementMini")]
    public partial class WeeklyScheduleSituationDataEditor : UserControl, IObjectEditor
    {
        public WeeklyScheduleSituationDataEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}