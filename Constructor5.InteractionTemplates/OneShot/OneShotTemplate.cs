using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.Interactions.Shared;

namespace Constructor5.InteractionTemplates.OneShot
{
    [SelectableObjectType("SuperInteractionTemplates", "OneShot")]
    [XmlSerializerExtraType]
    public class OneShotTemplate : InteractionTemplate
    {
        public Reference Animation { get; set; } = new Reference();
        public bool HasAnimation { get; set; }
        public override string Label => "One Shot";
        public ReferenceList LootActionSets { get; set; } = new ReferenceList();

        [AutoTuneBasic("category")]
        public Reference PieMenuCategory { get; set; } = new Reference();

        public string TuningActionsFile { get; set; } = "OneShot";

        protected override void OnExport(InteractionExportContext context)
        {
            AutoTunerInvoker.Invoke(this, context.Tuning);
            RunTuningActions(context, TuningActionsFile);
        }
    }
}