using Constructor5.Base.ComponentSystem;
using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Core;
using Constructor5.Elements.Situations.Components;

namespace Constructor5.Elements.Situations
{
    [ElementTypeData("SituationElement", true, ElementTypes = new[] { typeof(Situation) }, PresetFolders = new[] { "Situation" }, IsRootType = true)]
    public class Situation : SimpleComponentElement<SituationComponent>, IExportableElement, ISupportsCustomTuning
    {
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "SituationSimple";
            tuning.InstanceType = "situation";
            tuning.Module = "situations.situation_simple";

            var context = new SituationExportContext
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
            foreach (var type in Reflection.GetSubtypes(typeof(SituationComponent)))
            {
                AddComponent(type);
            }
        }

        protected override void OnUserCreated(string label)
        {
            GeneratedLabel = label;
            var info = GetComponent<SituationInfoComponent>();
            info.Name = new Base.PropertyTypes.STBLString() { CustomText = label };
            info.ImpliesGreetedStatus = true;
            info.IsPlayerFacing = true;
            info.IsSocialEvent = true;
        }
    }
}