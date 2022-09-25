using Constructor5.Base.ElementSystem;
using Constructor5.Elements.SituationJobs;
using Constructor5.Elements.SituationJobs.Components;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.SituationTemplates.CareerEventSituation
{
    [ObjectEditor(typeof(CareerEventSituationTemplate))]
    public partial class CareerEventSituationTemplateEditor : UserControl, IObjectEditor
    {
        public CareerEventSituationTemplateEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }

        private Element ReferenceControl_CreateElementFunction()
        {
            var job = (SituationJob)ElementManager.Create(typeof(SituationJob), null, true);
            job.GetComponent<SituationJobInfoComponent>().IsCareerEventPlayerSituation = true;
            return job;
        }
    }
}