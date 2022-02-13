using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Careers.Components
{
    [ObjectEditor(typeof(CareerTemplateComponent))]
    public partial class CareerTemplateComponentEditor : UserControl, IObjectEditor
    {
        public CareerTemplateComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}