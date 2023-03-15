using Constructor5.Base.ElementSystem;
using Constructor5.Core;
using Constructor5.Elements.Situations;
using Constructor5.Elements.Situations.Components;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.CareerEvents
{
    [ObjectEditor(typeof(CareerEvent))]
    public partial class CareerEventEditor : UserControl, IObjectEditor
    {
        public CareerEventEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}