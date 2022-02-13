using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Objectives
{
    [ObjectEditor(typeof(Objective))]
    public partial class ObjectiveEditor : UserControl, IObjectEditor
    {
        public ObjectiveEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
            if (tag == "NoSatisfactionPoints")
            {
                SatisfactionPointsField.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
}