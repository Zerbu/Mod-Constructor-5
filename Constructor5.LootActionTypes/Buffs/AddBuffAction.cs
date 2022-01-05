using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.Buffs.References;
using Constructor5.Elements.LootActionSets;
using Constructor5.Elements.TestConditions;
using Constructor5.TestConditionTypes.Buffs;
using Constructor5.Core;

namespace Constructor5.LootActionTypes.Buffs
{
    [SelectableObjectType("LootActionTypes", "Buffs: Add Buff")]
    [XmlSerializerExtraType]
    public class AddBuffAction : LootAction
    {
        public AddBuffAction() => GeneratedLabel = "Add Buff";

        [AutoTuneBuffWithReasonTuple("buff")]
        public BuffWithReason Buff { get; set; } = new BuffWithReason();

        [AutoTuneComplexChance]
        public ComplexChance Chance { get; set; } = new ComplexChance();

        public bool IgnoreIfAlreadyHasBuff { get; set; } = true;

        [AutoTuneEnum("subject")]
        public string Participant { get; set; }

        protected override void OnExport(LASExportContext originalContext)
        {
            var mainTuple = LootTuning.GetActionTuple(originalContext.LootListTunable, "buff");

            AutoTunerInvoker.Invoke(this, mainTuple);

            var newContext = new LASExportContext(originalContext);

            if (IgnoreIfAlreadyHasBuff)
            {
                var buffCondition = new BuffCondition();
                buffCondition.Blacklist.Items.Add(new ReferenceListItem
                {
                    Reference = Buff.Buff
                });
                newContext.TestConditions.Add(buffCondition);
            }

            TestConditionTuning.TuneTestList(mainTuple, newContext.TestConditions, "tests");
        }
    }
}