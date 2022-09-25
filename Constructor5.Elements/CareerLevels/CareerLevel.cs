using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.SimData;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.PropertyTypes;
using Constructor5.Elements.Careers;
using Constructor5.Elements.Careers.Components;
using Constructor5.Elements.Careers.Templates;
using Constructor5.Elements.CareerTracks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Constructor5.Elements.CareerLevels
{
    [ElementTypeData("CareerLevel", false, ElementTypes = new[] { typeof(CareerLevel) }, PresetFolders = new[] { "CareerLevel" })]
    public class CareerLevel : Element, IExportableElement, ISupportsCustomTuning
    {
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        [AutoTuneBasic("title_description")]
        public STBLString Description { get; set; } = new STBLString();

        public bool Include0Sunday { get; set; } = false;
        public bool Include1Monday { get; set; } = true;
        public bool Include2Tuesday { get; set; } = true;
        public bool Include3Wednesday { get; set; } = true;
        public bool Include4Thursday { get; set; } = true;
        public bool Include5Friday { get; set; } = true;
        public bool Include6Saturday { get; set; } = false;

        public bool InvertedEmotionAngry { get; set; } = false;
        public bool InvertedEmotionBored { get; set; } = false;
        public bool InvertedEmotionDazed { get; set; } = false;
        public bool InvertedEmotionEmbarrassed { get; set; } = false;
        public bool InvertedEmotionSad { get; set; } = false;
        public bool InvertedEmotionTense { get; set; } = false;
        public bool InvertedEmotionUncomfortable { get; set; } = false;

        [AutoTuneBasic("title")]
        public STBLString Name { get; set; } = new STBLString();

        [AutoTuneBasic("aspiration")]
        public Reference ObjectiveSet { get; set; } = new Reference();

        [AutoTuneBasic("promotion_reward")]
        public Reference PromotedToReward { get; set; } = new Reference();

        [AutoTuneBasic("promote_performance_level", IgnoreIf = "100")]
        public int PerformanceRequiredForPromotion { get; set; } = 100;

        public Reference Uniform { get; set; } = new Reference();

        public int SimoleonsPerHour { get; set; }

        public int TimeBeginHour { get; set; } = 9;
        public int TimeBeginMinute { get; set; }
        public float TimeDurationHour { get; set; } = 8;

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "CareerLevel";
            tuning.InstanceType = "career_level";
            tuning.Module = "careers.career_tuning";

            var career = (Career)GetContextModifier<CareerLevelContextModifier>().Career.Element;

            var template = career.GetComponent<CareerTemplateComponent>().Template;

            tuning.SimDataHandler = new SimDataHandler($"SimData/{template.GetLevelSimDataFileName()}.data");

            var positions = template.GetLevelSimDataPositions();

            var stat = career.GetComponent<CareerInfoComponent>().PerformanceStatistic;
            tuning.Set<TunableBasic>("performance_stat", stat);
            tuning.SimDataHandler.Write(positions.PerformanceStat, (ulong)ElementTuning.GetSingleInstanceKey(stat));

            {
                var tunableVariant1 = tuning.Set<TunableVariant>("pay_type", "simoleons_per_hour");
                tunableVariant1.Set<TunableBasic>("simoleons_per_hour", SimoleonsPerHour);
            }

            if (!template.IgnorePay())
            {
                tuning.SimDataHandler.Write(384, SimoleonsPerHour);
            }

            if (!template.IgnorePerformance())
            {
                TunePerformance(tuning);
            }
            
            if (!template.IgnoreSchedule())
            {
                TuneTime(tuning);
            }
            

            TuningActionInvoker.InvokeFromFile(template.GetLevelTuningActionsFile(), new TuningActionContext
            {
                Tuning = tuning,
                DataContext = this,
            });

            AutoTunerInvoker.Invoke(this, tuning);

            if (Uniform.GameReference != 0 || Uniform.Element != null)
            {
                var tunableTuple1 = tuning.Get<TunableTuple>("work_outfit");
                var tunableVariant1 = tunableTuple1.Set<TunableVariant>("outfit_generator", "enabled");
                tunableVariant1.Set<TunableBasic>("enabled", Uniform);
            }

            TuneSimData(tuning, template);

            TuneScreenSlam(tuning);
            
            CustomTuningExporter.Export(this, tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }

        private void TuneScreenSlam(TuningHeader tuning)
        {
            var career = (Career)GetContextModifier<CareerLevelContextModifier>().Career.Element;
            var track = (CareerTrack)GetContextModifier<CareerLevelContextModifier>().Track.Element;

            var isBaseTrack = false;
            if (career.GetComponent<CareerLevelsComponent>().BaseTrack.Element == track)
            {
                isBaseTrack = true;
            }

            var isMax = false;
            if (track.Levels.Items.Last().Reference.Element == this && !track.Branches.HasItems())
            {
                isMax = true;
            }

            var screenSlamVariant = tuning.Set<TunableVariant>("screen_slam", "enabled");
            var literalVariant = screenSlamVariant.Set<TunableVariant>("enabled", "literal");
            var literalTuple = literalVariant.Get<TunableTuple>("literal");

            if (isMax)
            {
                var tunableVariant1 = literalTuple.Set<TunableVariant>("display_type", "size_based");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("size_based");
                tunableTuple1.Set<TunableEnum>("screen_slam_size", "EXTRA_LARGE");
                var tunableVariant2 = literalTuple.Set<TunableVariant>("icon", "enabled");
                tunableVariant2.Set<TunableBasic>("enabled", isBaseTrack ? career.GetComponent<CareerInfoComponent>().Icon : track.Icon);
                var tunableVariant3 = literalTuple.Set<TunableVariant>("text", "enabled");
                tunableVariant3.Set<TunableBasic>("enabled", "0xF385AB5C");
                var tunableVariant4 = literalTuple.Set<TunableVariant>("title", "enabled");
                tunableVariant4.Set<TunableBasic>("enabled", "0x49C064A6");
            }
            else
            {
                var tunableVariant1 = literalTuple.Set<TunableVariant>("display_type", "size_based");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("size_based");
                tunableTuple1.Set<TunableEnum>("screen_slam_size", "SMALL");
                var tunableVariant2 = literalTuple.Set<TunableVariant>("icon", "enabled");
                tunableVariant2.Set<TunableBasic>("enabled", isBaseTrack ? career.GetComponent<CareerInfoComponent>().Icon : track.Icon);
                var tunableVariant3 = literalTuple.Set<TunableVariant>("text", "enabled");
                tunableVariant3.Set<TunableBasic>("enabled", "0xF385AB5C");
                var tunableVariant4 = literalTuple.Set<TunableVariant>("title", "enabled");
                tunableVariant4.Set<TunableBasic>("enabled", "0x570B11A0");
            }
        }

        private void TunePerformance(TuningHeader tuning)
        {
            var career = (Career)GetContextModifier<CareerLevelContextModifier>().Career.Element;
            var template = career.GetComponent<CareerTemplateComponent>().Template;

            var modifier = GetContextModifier<CareerLevelContextModifier>();

            var levels = ((CareerTrack)modifier.Track.Element).GetAllLevelsInTree();

            var levelIndex = Array.IndexOf(levels, levels.FirstOrDefault(x => x.Element == this));

            var tunableTuple1 = tuning.Get<TunableTuple>("performance_metrics");
            tunableTuple1.Set<TunableBasic>("base_performance", template.GetBasePerformance(levelIndex));

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
                tunableTuple2.Set<TunableBasic>("performance_mod", template.GetNegativeEmotionModifier(levelIndex) * 3);
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
                tunableTuple4.Set<TunableBasic>("performance_mod", template.GetNegativeEmotionModifier(levelIndex) * 2);
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
                tunableTuple6.Set<TunableBasic>("performance_mod", template.GetNegativeEmotionModifier(levelIndex));
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
            tunableTuple8.Set<TunableBasic>("performance_mod", template.GetStandardEmotionModifier(levelIndex));
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
            tunableTuple10.Set<TunableBasic>("performance_mod", template.GetStandardEmotionModifier(levelIndex) * 2);
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

        private void TuneSimData(TuningHeader tuning, CareerTemplateBase template)
        {
            var positions = template.GetLevelSimDataPositions();

            // objective set
            tuning.SimDataHandler.Write(positions.ObjectiveSet, ElementTuning.GetSingleInstanceKey(ObjectiveSet) ?? 0);

            // ideal emotion: 272

            // performance statistic: 288

            //day+time
            if (!template.IgnoreSchedule())
            {
                tuning.SimDataHandler.Write(340, TimeDurationHour);
                tuning.SimDataHandler.Write(368, TimeBeginHour);
                tuning.SimDataHandler.Write(372, TimeBeginMinute);
                tuning.SimDataHandler.Write(352, Include0Sunday);
                tuning.SimDataHandler.Write(353, Include1Monday);
                tuning.SimDataHandler.Write(354, Include2Tuesday);
                tuning.SimDataHandler.Write(355, Include3Wednesday);
                tuning.SimDataHandler.Write(356, Include4Thursday);
                tuning.SimDataHandler.Write(357, Include5Friday);
                tuning.SimDataHandler.Write(358, Include6Saturday);
            }

            //level info
            tuning.SimDataHandler.WriteText(positions.Name, Exporter.Current.STBLBuilder.GetKey(Name) ?? 0);
            tuning.SimDataHandler.WriteText(positions.Description, Exporter.Current.STBLBuilder.GetKey(Description) ?? 0);
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

            var startTimeTuple = tunableTuple2.Get<TunableTuple>("start_time");
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