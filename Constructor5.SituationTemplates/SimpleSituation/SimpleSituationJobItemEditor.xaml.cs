using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.SituationTemplates.SimpleSituation
{
    [ObjectEditor(typeof(SimpleSituationJobItem))]
    public partial class SimpleSituationJobItemEditor : UserControl, IObjectEditor
    {
        public SimpleSituationJobItemEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}