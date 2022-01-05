using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Elements.LootActionSets;
using Constructor5.Core;

namespace Constructor5.LootActionTypes.Statistic
{
    //[SelectableObjectType("LootActionTypes", "Add Buff")]
    [XmlSerializerExtraType]
    public abstract class StatisticActionBase : LootAction
    {
        //public StatisticActionBase() => GeneratedLabel = "Add Buff";

        [AutoTuneBasic("stat")]
        public Reference Statistic { get; set; } = new Reference();

        [AutoTuneEnum("subject")]
        public string Participant { get; set; }

        [AutoTuneComplexChance]
        public ComplexChance Chance { get; set; } = new ComplexChance();

        protected TunableTuple GetStatActionTunable(TunableList lootListTunable, string name)
        {
            var tunableVariant1 = lootListTunable.Set<TunableVariant>(null, "statistics");
            var tunableVariant2 = tunableVariant1.Set<TunableVariant>("statistics", name);
            var tunableTuple1 = tunableVariant2.Get<TunableTuple>(name);
            AutoTunerInvoker.Invoke(this, tunableTuple1);
            return tunableTuple1;
        }
    }
}
