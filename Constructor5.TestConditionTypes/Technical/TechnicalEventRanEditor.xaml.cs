using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Technical
{
    [ObjectEditor(typeof(TechnicalEventRanCondition))]
    public partial class TechnicalEventRanEditor : UserControl, IObjectEditor
    {
        public TechnicalEventRanEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}