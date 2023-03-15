using Constructor5.Base.ElementSystem;
using Constructor5.Elements.CareerEvents;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Careers.Components
{
    //[ObjectEditor(typeof(CareerEventsComponent))]
    public partial class CareerEventsComponentEditor : UserControl, IObjectEditor
    {
        public CareerEventsComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }

        private Element ReferenceListControl_CreateElementFunction()
        {
            return null;
            /*var element = ((CareerEventsComponent)DataContext).Element;

            var result = ElementManager.Create(typeof(CareerEvent), null, true);
            result.ShowPreset = true;
            result.AddContextModifier(new CareerEventContextModifier
            {
                Career = new Reference(element)
            });
            return result;*/
        }
    }
}