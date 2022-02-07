using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Careers.Components
{
    [ObjectEditor(typeof(CareerLevelsComponent))]
    public partial class CareerLevelsComponentEditor : UserControl, IObjectEditor
    {
        public CareerLevelsComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}