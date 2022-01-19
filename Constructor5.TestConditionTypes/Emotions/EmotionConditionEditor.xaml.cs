using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Emotions
{
    [ObjectEditor(typeof(EmotionCondition))]
    [ObjectEditor(typeof(EmotionObjectiveCondition))]
    public partial class EmotionConditionEditor : UserControl, IObjectEditor
    {
        public EmotionConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}