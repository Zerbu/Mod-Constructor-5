using Constructor5.Elements.TestConditions;
using Constructor5.UI.Shared;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Constructor5.Elements.SituationGoals.Components
{
    [ObjectEditor(typeof(SituationGoalPreConditionsComponent))]
    public partial class SituationGoalPreConditionsEditor : UserControl, IObjectEditor
    {
        public SituationGoalPreConditionsEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}