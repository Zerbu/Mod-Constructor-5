using Constructor5.Base.ElementSystem;
using Constructor5.Elements.SituationJobs;
using Constructor5.Elements.SituationJobs.Components;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.SituationTemplates.SimpleSituation
{
    [ObjectEditor(typeof(SimpleSituationTemplate))]
    public partial class SimpleSituationEditor : UserControl, IObjectEditor
    {
        public SimpleSituationEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;

        private Element ReferenceListControl_CreateElementFunction()
        {
            var result = (SituationJob)ElementManager.Create(typeof(SituationJob), null, true);
            result.GetComponent<SituationJobInfoComponent>().RestrictTooltip = true;
            return result;
        }
    }
}