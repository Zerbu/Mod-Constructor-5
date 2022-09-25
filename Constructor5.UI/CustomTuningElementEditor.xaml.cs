using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.CustomTuningElements
{
    [ObjectEditor(typeof(CustomTuningElement))]
    public partial class CustomTuningElementEditor : UserControl, IObjectEditor
    {
        public CustomTuningElementEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
            TuningControl.Element = (ISupportsCustomTuning)obj;
        }
    }
}