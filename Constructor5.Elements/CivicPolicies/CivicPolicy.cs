using Constructor5.Base.ComponentSystem;
using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning.SimData;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.Icons;
using Constructor5.Base.PropertyTypes;
using Constructor5.Core;
using Constructor5.Elements.HolidayTraditions.Components;
using Constructor5.Elements.SituationGoals;
using Constructor5.Elements.Statistics;

namespace Constructor5.Elements.CivicPolicies
{
    [ElementTypeData("CivicPolicy", false, ElementTypes = new[] { typeof(CivicPolicy) }, PresetFolders = new[] { "CivicPolicy" }, IsRootType = true)]
    public class CivicPolicy : SimpleComponentElement<CivicPolicyComponent>, IExportableElement, ISupportsCustomTuning
    {
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "StreetCivicPolicy";
            tuning.InstanceType = "snippet";
            tuning.Module = "civic_policies.street_civic_policy";

            tuning.SimDataHandler = new SimDataHandler($"SimData/CivicPolicy.data");

            var context = new CivicPolicyExportContext
            {
                Element = this,
                Tuning = tuning
            };

            foreach (var component in Components)
            {
                component.OnExport(context);
            }

            CustomTuningExporter.Export(this, tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }

        protected override void OnElementCreatedOrLoaded()
        {
            base.OnElementCreatedOrLoaded();

            var infoComponent = GetComponent<CivicPolicyInfo>();
            if (infoComponent.VoteStatistic == null)
            {
                var newReference = (Statistic)ElementManager.Create(typeof(Statistic), null, true);
                newReference.MaxValue = 99;
                infoComponent.VoteStatistic = new Reference(newReference);
                newReference.Label = $"{Label} Statistic";
                newReference.ShowPreset = true;
                ElementSaver.ScheduleOneTime(newReference);
            }
        }
    }
}