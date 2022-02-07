using Constructor5.Base.ElementSystem;
using Constructor5.Elements.ObjectiveSets;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.CareerLevels
{
    [ObjectEditor(typeof(CareerLevel))]
    public partial class CareerLevelEditor : UserControl, IObjectEditor
    {
        public CareerLevelEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;

        private Element CreateObjectiveSetFunction()
        {
            var element = (Element)DataContext;

            var result = ElementManager.Create(typeof(ObjectiveSet), null, true);
            result.AddContextModifier(new CareerObjectSetContextModifier
            {
                CareerTrack = element.GetContextModifier<CareerLevelContextModifier>().Track
            });

            return result;
        }
    }
}