using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Situations
{
    [ObjectEditor(typeof(Situation))]
    public partial class SituationEditor : UserControl, IObjectEditor
    {
        public SituationEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}