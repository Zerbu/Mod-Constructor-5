using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.ZoneDirectors
{
    [ObjectEditor(typeof(ZoneDirector))]
    public partial class ZoneDirectorEditor : UserControl, IObjectEditor
    {
        public ZoneDirectorEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}