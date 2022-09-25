using Constructor5.Base.ElementSystem;
using Constructor5.Elements.SituationGoals;
using Constructor5.Elements.SituationGoals.Components;
using Constructor5.Elements.Whims;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Traits.Components
{
    [ObjectEditor(typeof(TraitWhimsComponent))]
    public partial class TraitWhimsEditor : UserControl, IObjectEditor
    {
        public TraitWhimsEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}