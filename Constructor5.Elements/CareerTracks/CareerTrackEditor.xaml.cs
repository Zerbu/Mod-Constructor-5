using Constructor5.Base.ElementSystem;
using Constructor5.Elements.CareerLevels;
using Constructor5.Elements.ObjectiveSets;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.CareerTracks
{
    [ObjectEditor(typeof(CareerTrack))]
    public partial class CareerTrackEditor : UserControl, IObjectEditor
    {
        public CareerTrackEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
            var element = (Element)obj;
            
            var modifier = element.GetContextModifier<CareerTrackContextModifier>();

            if (modifier.ParentTrack.Element == null)
            {
                InfoStack.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private Element CreateBranchFunction()
        {
            var element = (CareerTrack)DataContext;

            var result = ElementManager.Create(typeof(CareerTrack), null, true);
            result.AddContextModifier(new CareerTrackContextModifier
            {
                Career = element.GetContextModifier<CareerTrackContextModifier>().Career,
                ParentTrack = new Reference(element)
            });
            return result;
        }

        private Element CreateLevelFunction()
        {
            var element = (CareerTrack)DataContext;

            var result = ElementManager.Create(typeof(CareerLevel), null, true);
            result.AddContextModifier(new CareerLevelContextModifier
            {
                Career = element.GetContextModifier<CareerTrackContextModifier>().Career,
                Track = new Reference(element)
            });
            return result;
        }

        private Element CreateAssignmentFunction()
        {
            var element = (CareerTrack)DataContext;

            var result = (ObjectiveSet)ElementManager.Create(typeof(ObjectiveSet), null, true);
            result.AddContextModifier(new CareerAssignmentObjectiveSetContextModifier
            {
                CareerTrack = new Reference(element),
            });
            result.AlwaysTrack = false;
            return result;
        }
    }
}