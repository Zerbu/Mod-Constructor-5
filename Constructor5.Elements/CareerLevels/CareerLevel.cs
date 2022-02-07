using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.PropertyTypes;
using Constructor5.Elements.CareerTracks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Constructor5.Elements.CareerLevels
{
    [ElementTypeData("CareerLevel", false, ElementTypes = new[] { typeof(CareerLevel) }, PresetFolders = new[] { "CareerLevel" })]
    public class CareerLevel : Element, IExportableElement
    {
        public STBLString Description { get; set; } = new STBLString();

        public bool Include0Sunday { get; set; } = false;
        public bool Include1Monday { get; set; } = true;
        public bool Include2Tuesday { get; set; } = true;
        public bool Include3Wednesday { get; set; } = true;
        public bool Include4Thursday { get; set; } = true;
        public bool Include5Friday { get; set; } = true;
        public bool Include6Saturday { get; set; } = false;

        public bool InvertedEmotionAngry { get; set; } = false;
        public bool InvertedEmotionEmbarrassed { get; set; } = false;
        public bool InvertedEmotionSad { get; set; } = false;
        public bool InvertedEmotionTense { get; set; } = false;
        public bool InvertedEmotionUncomfortable { get; set; } = false;
        public bool InvertedEmotionBored { get; set; } = false;
        public bool InvertedEmotionDazed { get; set; } = false;

        public STBLString Name { get; set; } = new STBLString();

        public Reference ObjectiveSet { get; set; } = new Reference();
        public Reference PromotedToReward { get; set; } = new Reference();
        public int SimoleonsPerHour { get; set; }

        public int TimeBeginHour { get; set; } = 9;
        public int TimeBeginMinute { get; set; }
        public int TimeDurationHour { get; set; } = 8;

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "CareerLevel";
            tuning.InstanceType = "career_level";
            tuning.Module = "careers.career_tuning";

            TunePerformance(tuning);
            TuneTime(tuning);

            TuningActionInvoker.InvokeFromFile("Career Level", new TuningActionContext
            {
                Tuning = tuning,
                DataContext = this,
            });

            AutoTunerInvoker.Invoke(this, tuning);

            TuningExport.AddToQueue(tuning);
        }

        private void TunePerformance(TuningHeader tuning)
        {
            var modifier = GetContextModifier<CareerLevelContextModifier>();

            var levels = ((CareerTrack)modifier.Track.Element).GetAllLevelsInTree();

            var levelIndex = Array.IndexOf(levels, levels.FirstOrDefault(x => x.Element == this));

            var tunableTuple1 = tuning.Get<TunableTuple>("performance_metrics");
            tunableTuple1.Set<TunableBasic>("base_performance", AutomaticCareerPerformance.GetBasePerformance(levelIndex));

            var positiveBuffs = new List<uint>() { 12830, 12836, 12838, 12839, 12841, 12845, 12851, 27107, 12839 };
            var veryPositiveBuffs = new List<uint>() { 12814, 12852, 12850, 12846, 12834, 12844, 12854, 12843, 37939, 12846 };

            var negativeBuffs = new List<uint>() { 12831, 12835, 12853, 12857, 12858, 12829, 12855, 27321, 27154 };
            var veryNegativeBuffs = new List<uint>() { 12827, 12842, 12832, 12856, 12847, 27323, 27155 };
            var extremelyNegativeBuffs = new List<uint>() { 12840, 12848, 27320 };

            var negativeBuffsToMove = new List<uint>();
            var veryNegativeBuffsToMove = new List<uint>();

            if (InvertedEmotionAngry)
            {
                veryNegativeBuffsToMove.Add(12840);
                veryNegativeBuffsToMove.Add(27320);
                veryNegativeBuffsToMove.Add(12827);
                veryNegativeBuffsToMove.Add(27323);
                negativeBuffsToMove.Add(12831);
                negativeBuffsToMove.Add(27321);
            }

            if (InvertedEmotionBored)
            {
                negativeBuffsToMove.Add(12829);
            }

            if (InvertedEmotionDazed)
            {
                negativeBuffsToMove.Add(12855);
            }

            if (InvertedEmotionEmbarrassed)
            {
                veryNegativeBuffsToMove.Add(12848);
                veryNegativeBuffsToMove.Add(12842);
                negativeBuffsToMove.Add(12835);
            }

            if (InvertedEmotionSad)
            {
                veryNegativeBuffsToMove.Add(12832);
                veryNegativeBuffsToMove.Add(27155);
                negativeBuffsToMove.Add(12853);
                negativeBuffsToMove.Add(27154);
            }

            if (InvertedEmotionTense)
            {
                veryNegativeBuffsToMove.Add(12856);
                negativeBuffsToMove.Add(12857);
            }

            if (InvertedEmotionUncomfortable)
            {
                veryNegativeBuffsToMove.Add(12847);
                negativeBuffsToMove.Add(12858);
            }

            foreach (var buffToRemove in veryNegativeBuffsToMove)
            {
                veryNegativeBuffs.Remove(buffToRemove);
                veryPositiveBuffs.Add(buffToRemove);
            }

            foreach (var buffToRemove in negativeBuffsToMove)
            {
                negativeBuffs.Remove(buffToRemove);
                positiveBuffs.Add(buffToRemove);
            }

            var tunableList1 = tunableTuple1.Get<TunableList>("tested_metrics");

            if (extremelyNegativeBuffs.Count > 0)
            {
                var tunableTuple2 = tunableList1.Get<TunableTuple>(null);
                tunableTuple2.Set<TunableBasic>("performance_mod", "-12");
                var tunableList2 = tunableTuple2.Get<TunableList>("tests");
                var tunableList3 = tunableList2.Get<TunableList>(null);
                var tunableVariant1 = tunableList3.Set<TunableVariant>(null, "buff");
                var tunableTuple3 = tunableVariant1.Get<TunableTuple>("buff");
                var tunableVariant2 = tunableTuple3.Set<TunableVariant>("whitelist", "enabled");
                var tunableList4 = tunableVariant2.Get<TunableList>("enabled");
                foreach (var buff in extremelyNegativeBuffs)
                {
                    tunableList4.Set<TunableBasic>(null, buff);
                }
            }

            if (veryNegativeBuffs.Count > 0)
            {
                var tunableTuple4 = tunableList1.Get<TunableTuple>(null);
                tunableTuple4.Set<TunableBasic>("performance_mod", "-8");
                var tunableList5 = tunableTuple4.Get<TunableList>("tests");
                var tunableList6 = tunableList5.Get<TunableList>(null);
                var tunableVariant3 = tunableList6.Set<TunableVariant>(null, "buff");
                var tunableTuple5 = tunableVariant3.Get<TunableTuple>("buff");
                var tunableVariant4 = tunableTuple5.Set<TunableVariant>("whitelist", "enabled");
                var tunableList7 = tunableVariant4.Get<TunableList>("enabled");
                foreach (var buff in veryNegativeBuffs)
                {
                    tunableList7.Set<TunableBasic>(null, buff);
                }
            }

            if (negativeBuffs.Count > 0)
            {
                var tunableTuple6 = tunableList1.Get<TunableTuple>(null);
                tunableTuple6.Set<TunableBasic>("performance_mod", "-4");
                var tunableList8 = tunableTuple6.Get<TunableList>("tests");
                var tunableList9 = tunableList8.Get<TunableList>(null);
                var tunableVariant5 = tunableList9.Set<TunableVariant>(null, "buff");
                var tunableTuple7 = tunableVariant5.Get<TunableTuple>("buff");
                var tunableVariant6 = tunableTuple7.Set<TunableVariant>("whitelist", "enabled");
                var tunableList10 = tunableVariant6.Get<TunableList>("enabled");
                foreach (var buff in negativeBuffs)
                {
                    tunableList10.Set<TunableBasic>(null, buff);
                }
            }

            var tunableTuple8 = tunableList1.Get<TunableTuple>(null);
            tunableTuple8.Set<TunableBasic>("performance_mod", AutomaticCareerPerformance.GetStandardEmotionModifier(levelIndex));
            var tunableList11 = tunableTuple8.Get<TunableList>("tests");
            var tunableList12 = tunableList11.Get<TunableList>(null);
            var tunableVariant7 = tunableList12.Set<TunableVariant>(null, "buff");
            var tunableTuple9 = tunableVariant7.Get<TunableTuple>("buff");
            var tunableVariant8 = tunableTuple9.Set<TunableVariant>("whitelist", "enabled");
            var tunableList13 = tunableVariant8.Get<TunableList>("enabled");
            foreach (var buff in positiveBuffs)
            {
                tunableList13.Set<TunableBasic>(null, buff);
            }
            var tunableTuple10 = tunableList1.Get<TunableTuple>(null);
            tunableTuple10.Set<TunableBasic>("performance_mod", AutomaticCareerPerformance.GetStandardEmotionModifier(levelIndex)*2);
            var tunableList14 = tunableTuple10.Get<TunableList>("tests");
            var tunableList15 = tunableList14.Get<TunableList>(null);
            var tunableVariant9 = tunableList15.Set<TunableVariant>(null, "buff");
            var tunableTuple11 = tunableVariant9.Get<TunableTuple>("buff");
            var tunableVariant10 = tunableTuple11.Set<TunableVariant>("whitelist", "enabled");
            var tunableList16 = tunableVariant10.Get<TunableList>("enabled");
            foreach (var buff in veryPositiveBuffs)
            {
                tunableList16.Set<TunableBasic>(null, buff);
            }
        }

        private void TuneTime(TuningHeader tuning)
        {
            var tunableTuple1 = tuning.Get<TunableTuple>("work_schedule");
            var tunableList1 = tunableTuple1.Get<TunableList>("schedule_entries");
            var tunableTuple2 = tunableList1.Get<TunableTuple>(null);
            var tunableTuple3 = tunableTuple2.Get<TunableTuple>("days_available");
            tunableTuple3.Set<TunableBasic>("0 SUNDAY", Include0Sunday);
            tunableTuple3.Set<TunableBasic>("1 MONDAY", Include1Monday);
            tunableTuple3.Set<TunableBasic>("2 TUESDAY", Include2Tuesday);
            tunableTuple3.Set<TunableBasic>("3 WEDNESDAY", Include3Wednesday);
            tunableTuple3.Set<TunableBasic>("4 THURSDAY", Include4Thursday);
            tunableTuple3.Set<TunableBasic>("5 FRIDAY", Include5Friday);
            tunableTuple3.Set<TunableBasic>("6 SATURDAY", Include6Saturday);

            tunableTuple2.Set<TunableBasic>("duration", TimeDurationHour);

            var startTimeTuple = tuning.Get<TunableTuple>("start_time");
            startTimeTuple.Set<TunableBasic>("hour", TimeBeginHour);
            if (TimeBeginMinute != 0)
            {
                startTimeTuple.Set<TunableBasic>("minute", TimeBeginMinute);
            }

            var wakeupHour = TimeBeginHour - 2;
            if (wakeupHour < 0)
            {
                wakeupHour += 24;
            }
            var wakeupTimeTuple = tuning.Get<TunableTuple>("wakeup_time");
            wakeupTimeTuple.Set<TunableBasic>("hour", wakeupHour);
            wakeupTimeTuple.Set<TunableBasic>("minute", TimeBeginMinute);
        }

        /*protected override void OnUserCreated(string label)
        {
            GeneratedLabel = label;
        }*/
    }
}