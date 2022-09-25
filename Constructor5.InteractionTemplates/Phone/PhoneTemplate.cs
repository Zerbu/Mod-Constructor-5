using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.Interactions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.InteractionTemplates.Phone
{
    [SelectableObjectType("SuperInteractionTemplates", "PhoneInteraction")]
    [XmlSerializerExtraType]
    public class PhoneTemplate : InteractionTemplate
    {
        public override string Label => "Phone Interaction";
        public ReferenceList LootActionSets { get; set; } = new ReferenceList();

        public Reference Animation { get; set; } = new Reference() { GameReference = 11702, GameReferenceLabel = "Chat" };

        [AutoTuneBasic("category")]
        public Reference PieMenuCategory { get; set; } = new Reference() { GameReference = 105922, GameReferenceLabel = "Home" };

        public bool UsesInternet { get; set; }

        public string TuningActionsFile { get; set; } = "PhoneInteraction";

        protected override void OnExport(InteractionExportContext context)
        {
            AutoTunerInvoker.Invoke(this, context.Tuning);
            RunTuningActions(context, TuningActionsFile);
        }
    }
}
