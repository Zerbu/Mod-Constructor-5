using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Careers.Components
{
    [ObjectEditor(typeof(CareerInteractionComponent))]
    public partial class CareerInteractionComponentEditor : UserControl, IObjectEditor
    {
        public CareerInteractionComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}