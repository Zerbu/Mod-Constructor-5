using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Elements.ActionTriggers
{
    [XmlSerializerExtraType]
    public class ActionTriggerLootComponent : ActionTriggerComponent
    {
        public override string ComponentLabel => "Actions";

        [AutoTuneReferenceList("completion_loot")]
        public ReferenceList LootActionSets { get; set; } = new ReferenceList();

        protected internal override void OnExport(ActionTriggerExportContext context)
        {
            AutoTunerInvoker.Invoke(this, context.Tuning);
        }
    }
}
