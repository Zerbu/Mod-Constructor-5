using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Elements.Buffs.References;

namespace Constructor5.Elements.RoleStates
{
    [ElementTypeData("RoleState", false, ElementTypes = new[] { typeof(RoleState) }, PresetFolders = new[] { "RoleState" })]
    public class RoleState : Element, IExportableElement, ISupportsCustomTuning
    {
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        [AutoTuneBuffWithReasonList("_buffs")]
        public ReferenceList Buffs { get; set; } = new ReferenceList();
        public Reference OffLotAutonomyBuff { get; set; } = new Reference(38292, "On Lot Only");

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "RoleState";
            tuning.InstanceType = "role_state";
            tuning.Module = "role.role_state";

            AutoTunerInvoker.Invoke(this, tuning);

            var tunableTuple1 = tuning.Get<TunableTuple>("_off_lot_autonomy_buff");
            tunableTuple1.Set<TunableBasic>("buff_type", OffLotAutonomyBuff);

            CustomTuningExporter.Export(tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }
    }
}