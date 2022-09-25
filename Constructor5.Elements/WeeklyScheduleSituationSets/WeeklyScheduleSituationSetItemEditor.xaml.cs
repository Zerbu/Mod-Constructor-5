using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.WeeklyScheduleSituationSets
{
    [ObjectEditor(typeof(WeeklyScheduleSituationSetItem))]
    public partial class WeeklyScheduleSituationItemEditor : UserControl, IObjectEditor
    {
        public WeeklyScheduleSituationItemEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}