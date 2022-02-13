using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Careers.Templates
{
    [ObjectEditor(typeof(CareerTemplateFullTime))]
    public partial class CareerTemplateFullTimeEditor : UserControl, IObjectEditor
    {
        public CareerTemplateFullTimeEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}