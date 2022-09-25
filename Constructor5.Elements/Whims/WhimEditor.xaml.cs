using Constructor5.Base.ElementSystem;
using Constructor5.Elements.SituationGoals;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Whims
{
    [ObjectEditor(typeof(Whim))]
    public partial class WhimEditor : UserControl, IObjectEditor
    {
        public WhimEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}