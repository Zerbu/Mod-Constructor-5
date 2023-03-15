using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.ZoneDirectors.Components
{
    [ObjectEditor(typeof(ZoneDirectorMergeComponent))]
    public partial class ZoneDirectorMergeComponentEditor : UserControl, IObjectEditor
    {
        public ZoneDirectorMergeComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}