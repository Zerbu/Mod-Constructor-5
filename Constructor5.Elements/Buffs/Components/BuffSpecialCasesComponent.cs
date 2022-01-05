using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.PropertyTypes;
using Constructor5.Core;

namespace Constructor5.Elements.Buffs.Components
{
    [XmlSerializerExtraType]
    public class BuffSpecialCasesComponent : BuffComponent
    {
        [AutoTuneIfTrue("is_npc_only")]
        public bool IsNPCOnly { get; set; }

        [AutoTuneIfTrue("show_timeout", "False")]
        public bool HideTimeout { get; set; }

        [AutoTuneIfTrue("refresh_on_add", "False")]
        public bool NoRefreshOnAdd { get; set; }

        [AutoTuneBasic("timeout_string")]
        public STBLString TimeoutStringOverride { get; set; } = new STBLString();

        public override string ComponentLabel => "Special Cases";

        protected internal override bool HasContent() => true;

        protected internal override void OnExport(BuffExportContext context)
        {
            AutoTunerInvoker.Invoke(this, context.Tuning);
        }
    }
}
