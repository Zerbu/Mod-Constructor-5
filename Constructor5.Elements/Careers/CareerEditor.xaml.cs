using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Careers
{
    [ObjectEditor(typeof(Career))]
    public partial class CareerEditor : UserControl, IObjectEditor
    {
        public CareerEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}