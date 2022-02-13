using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.CareerTracks;
using System.Linq;

namespace Constructor5.Elements.Careers.Templates
{
    [SelectableObjectType("CareerTypeTemplates", "CareerTemplateFullTime")]
    [XmlSerializerExtraType]
    public class CareerTemplateFullTime : CareerTemplateBase
    {
        public override string Label => "Full Time Career";

        public override int GetBasePerformance(int level)
        {
            var arr = new[] { 60, 50, 40, 30, 20, 15, 10, 8, 7, 6, 5 };
            return level >= arr.Length ? arr.Last() : arr[level];
        }

        public override int GetNegativeEmotionModifier(int level) => -4;

        public override int GetStandardEmotionModifier(int level)
        {
            var arr = new[] { 10, 10, 10, 5, 5, 4, 4, 4, 3, 3, 3 };
            return level >= arr.Length ? arr.Last() : arr[level];
        }

        protected internal override void OnExport(CareerExportContext context)
        {
            TuningActionInvoker.InvokeFromFile("Career Type Work", new TuningActionContext
            {
                Tuning = context.Tuning,
                DataContext = this,
            });
        }

        protected internal override void TuneOvermax(TuningBase tuning, CareerTrack track)
        {
            var tunableVariant1 = tuning.Set<TunableVariant>("overmax", "enabled");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("enabled");
            tunableTuple1.Set<TunableBasic>("reward", CreateOvermaxReward(track));
            tunableTuple1.Set<TunableBasic>("salary_increase", "10");
        }

        private ulong CreateOvermaxReward(CareerTrack track)
        {
            var tuning = ElementTuning.Create(track, "OvermaxReward");
            tuning.Class = "SimReward";
            tuning.InstanceType = "reward";
            tuning.Module = "rewards.reward";

            tuning.Set<TunableBasic>("icon", "2f7d0004:00000000:a6ed756af9cb04a1");
            tuning.Set<TunableBasic>("name", "0x9A909927");
            var tunableVariant1 = tuning.Set<TunableVariant>("reward_description", "enabled");
            tunableVariant1.Set<TunableBasic>("enabled", "0x9A909927");
            var tunableList1 = tuning.Get<TunableList>("rewards");
            var tunableVariant2 = tunableList1.Set<TunableVariant>(null, "random_reward");
            var tunableList2 = tunableVariant2.Get<TunableList>("random_reward");
            var tunableTuple1 = tunableList2.Get<TunableTuple>(null);
            var tunableTuple2 = tunableList2.Get<TunableTuple>(null);
            var tunableVariant3 = tunableTuple2.Set<TunableVariant>("reward", "money");
            var tunableTuple3 = tunableVariant3.Get<TunableTuple>("money");
            var tunableVariant4 = tunableTuple3.Set<TunableVariant>("money", "random_in_range");
            var tunableTuple4 = tunableVariant4.Get<TunableTuple>("random_in_range");
            tunableTuple4.Set<TunableBasic>("lower_bound", "1000");
            tunableTuple4.Set<TunableBasic>("upper_bound", "2000");
            var tunableVariant5 = tunableList1.Set<TunableVariant>(null, "specific_reward");
            var tunableVariant6 = tunableVariant5.Set<TunableVariant>("specific_reward", "bucks");
            var tunableTuple5 = tunableVariant6.Get<TunableTuple>("bucks");
            tunableTuple5.Set<TunableBasic>("amount", "10");
            tunableTuple5.Set<TunableEnum>("bucks_type", "InfluenceBuck");

            TuningExport.AddToQueue(tuning);
            return tuning.InstanceKey;
        }
    }
}