using Constructor5.Base.ElementSystem;
using Constructor5.Core;
using Constructor5.Elements.Situations;
using Constructor5.Elements.Situations.Components;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.CareerEvents
{
    [ObjectEditor(typeof(CareerEvent), "ElementMini")]
    public partial class CareerEventMiniEditor : UserControl, IObjectEditor
    {
        public CareerEventMiniEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }

        private Element ReferenceControl_CreateElementFunction()
        {
            var situation = (Situation)ElementManager.Create(typeof(Situation), null, true);

            situation.AddContextModifier(new CareerEventSituationContextModifier
            {
                CareerEvent = new Reference((CareerEvent)DataContext)
            });

            situation.GetComponent<SituationTemplateComponent>().Template = (SituationTemplate)Reflection.CreateObject(Reflection.GetTypeByName("CareerEventSituationTemplate"));

            return situation;
        }
    }
}