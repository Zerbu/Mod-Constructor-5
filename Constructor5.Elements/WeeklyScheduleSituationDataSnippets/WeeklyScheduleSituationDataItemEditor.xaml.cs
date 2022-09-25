using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.WeeklyScheduleSituationDataSnippets
{
    [ObjectEditor(typeof(WeeklyScheduleSituationDataItem))]
    public partial class WeeklyScheduleSituationDataItemEditor : UserControl, IObjectEditor
    {
        public WeeklyScheduleSituationDataItemEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}