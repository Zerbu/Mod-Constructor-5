using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Careers.Components
{
    [ObjectEditor(typeof(CareerInfoComponent))]
    public partial class CareerInfoComponentEditor : UserControl, IObjectEditor
    {
        public CareerInfoComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}