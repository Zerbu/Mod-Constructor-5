using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Careers.Components
{
    [ObjectEditor(typeof(CareerAvailabilityConditionsComponent))]
    public partial class CareerAvailabilityConditionsComponentEditor : UserControl, IObjectEditor
    {
        public CareerAvailabilityConditionsComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}