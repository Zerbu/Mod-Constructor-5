using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Careers.Templates
{
    [ObjectEditor(typeof(CareerTemplatePartTime))]
    public partial class CareerTemplatePartTimeEditor : UserControl, IObjectEditor
    {
        public CareerTemplatePartTimeEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}