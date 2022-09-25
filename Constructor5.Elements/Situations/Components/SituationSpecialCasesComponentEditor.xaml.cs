using Constructor5.Base.ElementSystem;
using Constructor5.Elements.Rewards;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Situations.Components
{
    //[ObjectEditor(typeof(SituationSpecialCasesComponent))]
    public partial class SituationSpecialCasesComponentEditor : UserControl, IObjectEditor
    {
        public SituationSpecialCasesComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}