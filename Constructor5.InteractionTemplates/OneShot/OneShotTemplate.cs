using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.Interactions.Shared;
using Constructor5.Elements.Interactions.Social;

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
        public override Reference PieMenuCategory { get; set; } = new Reference();

        public string TuningActionsFile { get; set; } = "OneShot";

        public override ulong GetCustomScoreTypeKey(InteractionExportContext context) => 0;

        public override ulong GetFallbackScoreType(SocialInteractionExportContext socialContext) => 0;

        protected override void OnExport(InteractionExportContext context)
        {
            AutoTunerInvoker.Invoke(this, context.Tuning);
            RunTuningActions(context, TuningActionsFile);
        }
    }
}