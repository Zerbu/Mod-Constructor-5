using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Elements.Buffs.Components;
using Constructor5.Elements.Buffs.References;
using Constructor5.Elements.CASPreferences;
using Constructor5.Elements.TestConditions;
using Constructor5.Elements.Traits;

namespace Constructor5.Elements.Buffs
{
    public class PreferenceTraitTuner
    {
        public PreferenceTraitTuner(BuffExportContext context, CASPreferenceContextModifier preferenceModifier)
        {
            Context = context;
            PreferenceModifier = preferenceModifier;
        }

        public BuffWithReason Buff { get; set; }
        public BuffExportContext Context { get; }
        public CASPreferenceContextModifier PreferenceModifier { get; }

        public void TunePreferenceTrait()
        {
            var preference = (CASPreference)PreferenceModifier.CASPreference.Element;

            var buffReference = (Reference)null;
            var tuningName = (string)null;

            if (PreferenceModifier.IsDislike)
            {
                buffReference = preference.DislikeBuff;
                tuningName = "DisikeLoot";
            }
            else
            {
                buffReference = preference.LikeBuff;
                tuningName = "LikeLoot";
            }

            var key = ElementTuning.GetSingleInstanceKey(buffReference);
            if (key == 0 || key == null)
            {
                return;
            }

            var tuning = ElementTuning.Create(Context.Element, tuningName);
            tuning.Class = "LootActions";
            tuning.InstanceType = "action";
            tuning.Module = "interactions.utils.loot";

            var lootListTunable = tuning.Get<TunableList>("loot_actions");

            var tunableVariant1 = lootListTunable.Set<TunableVariant>(null, "statistics");
            var mainTuple = tunableVariant1.GetVariant<TunableTuple>("statistics", "statistic_set_max");

            AutoTunerInvoker.Invoke(this, lootListTunable);

            mainTuple.Set<TunableBasic>("stat", CreatePreferenceTraitCommodity(buffReference, tuningName));

            TestConditionTuning.TuneTestList(mainTuple, new TestCondition[] { preference.AutoCondition }, "tests");

            BuffLootOnIntervalBuilder.AddToCommodity(Context, 10, 10, new Reference(tuning.InstanceKey));

            TuningExport.AddToQueue(tuning);
        }

        private ulong CreatePreferenceTraitCommodity(Reference buffReference, string tuningName)
        {
            var tuning = ElementTuning.Create(Context.Element, $"{tuningName}:Commodity");
            tuning.Class = "Commodity";
            tuning.InstanceType = "statistic";
            tuning.Module = "statistics.commodity";

            Buff = new BuffWithReason
            {
                Buff = buffReference
            };
            TuningActionInvoker.InvokeFromFile("Persistant Buff Commodity", new TuningActionContext
            {
                Tuning = tuning,
                DataContext = this
            });

            TuningExport.AddToQueue(tuning);

            return tuning.InstanceKey;
        }
    }
}