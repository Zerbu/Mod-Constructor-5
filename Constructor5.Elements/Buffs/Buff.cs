using Constructor5.Base.ComponentSystem;
using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Core;
using Constructor5.Elements.Buffs;

namespace Constructor5.Elements
{
    [ElementTypeData("Buff", true, ElementTypes = new[] { typeof(Buff) }, PresetFolders = new[] { "Buff" })]
    public class Buff : SimpleComponentElement<BuffComponent>, IExportableElement, ISupportsCustomTuning
    {
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        void IExportableElement.OnExport()
            => SharedBuffTuner.CreateTuning(this, Components.ToArray());

        protected override void OnElementCreatedOrLoaded()
        {
            base.OnElementCreatedOrLoaded();
            foreach (var type in Reflection.GetSubtypes(typeof(BuffComponent)))
            {
                AddComponent(type);
            }
        }
    }
}