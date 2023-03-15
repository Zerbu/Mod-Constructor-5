using Constructor5.Base.ElementSystem;
using Constructor5.Elements.Objectives;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.ObjectiveSets
{
    [ObjectEditor(typeof(ObjectiveSet))]
    [ObjectEditor(typeof(ObjectiveSet), "ElementMini")]
    public partial class ObjectiveSetEditor : UserControl, IObjectEditor
    {
        public ObjectiveSetEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
            if (tag == "Career")
            {
                DisplayNameField.Visibility = System.Windows.Visibility.Collapsed;
                LabelField.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private Element ReferenceListControl_CreateElementFunction()
        {
            var component = (ObjectiveSet)DataContext;

            var element = (Objective)ElementManager.Create(typeof(Objective), null, true);
            component.AssignDataToObjective(element, true);

            var isCareerOrAssignment = component.GetContextModifier<CareerObjectiveSetContextModifier>() != null
            || component.GetContextModifier<CareerAssignmentObjectiveSetContextModifier>() != null;
            if (isCareerOrAssignment)
            {
                ObjectivesListControl.EditorTag = "NoSatisfactionPoints";
            }

            return element;
        }
    }
}