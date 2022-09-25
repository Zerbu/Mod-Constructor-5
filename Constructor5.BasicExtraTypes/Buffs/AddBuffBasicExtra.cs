using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.Buffs.References;
using Constructor5.Elements.InteractionBasicExtras;
using Constructor5.Elements.LootActionSets;
using Constructor5.Elements.TestConditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.BasicExtraTypes.Buffs
{
    [SelectableObjectType("BasicExtraTypes", "BuffsAddBuff")]
    [XmlSerializerExtraType]
    public class AddBuffBasicExtra : BasicExtra
    {
        public AddBuffBasicExtra() => GeneratedLabel = "Add Buff";

        [AutoTuneBuffWithReasonTuple("buff_type")]
        public BuffWithReason Buff { get; set; } = new BuffWithReason();

        public string Participant { get; set; }

        protected override void OnExport(BasicExtraExportContext originalContext)
        {
            var mainTuple = BasicExtrasTuning.GetActionTuple(originalContext.BasicExtrasListTunable, "buff");

            AutoTunerInvoker.Invoke(this, mainTuple);

            var newContext = new BasicExtraExportContext(originalContext);

            TestConditionTuning.TuneTestList(mainTuple, newContext.TestConditions, "tests");

            if (!string.IsNullOrEmpty(Participant))
            {
                var tunableList1 = mainTuple.Get<TunableList>("subject");
                tunableList1.Set<TunableEnum>(null, Participant);
            }
        }
    }
}
