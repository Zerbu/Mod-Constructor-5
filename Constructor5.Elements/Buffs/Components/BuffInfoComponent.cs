using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.Icons;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Core;
using System;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.DebugCommandSystem;
using Constructor5.Base.ExportSystem;

namespace Constructor5.Elements.Buffs.Components
{
    [XmlSerializerExtraType]
    public class BuffInfoComponent : BuffComponent
    {
        public override int ComponentDisplayOrder => 1;
        public override string ComponentLabel => "BuffInfo";

        public bool AddEmotionCategory { get; set; } = true;

        [AutoTuneBasic("buff_description")]
        public STBLString Description { get; set; } = new STBLString();

        public int Duration { get; set; } = 240;
        public Reference Emotion { get; set; } = new Reference() { GameReference = 14640, GameReferenceLabel = "Happy" };
        public int EmotionWeight { get; set; } = 1;
        public bool HasFixedDuration { get; set; }
        public bool HasEmotion { get; set; }
        public bool IsNonPersisted { get; set; }

        [AutoTuneBasic("icon")]
        public ElementIcon Icon { get; set; } = new ElementIcon();

        [AutoTuneBasic("buff_name")]
        public STBLString Name { get; set; } = new STBLString();

        public string GetEmotionCategory()
        {
            var emotionInt = ElementTuning.GetSingleInstanceKey(Emotion);
            switch (emotionInt)
            {
                case 14632:
                    return "Angry_Buffs";
                case 14633:
                    return "Bored_Buffs";
                case 14634:
                    return "Confident_Buffs";
                case 14635:
                    return "Embarrassed_Buffs";
                case 14636:
                    return "Energized_Buffs";
                case 14637:
                    return "Fine_Buffs";
                case 14638:
                    return "Flirty_Buffs";
                case 14639:
                    return "Focused_Buffs";
                case 14640:
                    return "Happy_Buffs";
                case 14641:
                    return "Inspired_Buffs";
                case 14642:
                    return "Playful_Buffs";
                case 14643:
                    return "Sad_Buffs";
                case 14644:
                    return "Sloshed_Buffs";
                case 14645:
                    return "Stressed_Buffs";
                case 14646:
                    return "Uncomfortable_Buffs";
                case 251719:
                    return "Scared_Buffs";
                default:
                    Exporter.Current.AddError(Element, $"\"Add Emotion Category\" doesn't support {emotionInt}. No emotion category has been automatically added.");
                    return null;
            }
        }

        protected internal override bool HasContent() => true;

        protected internal override void OnExport(BuffExportContext context)
        {
            AutoTunerInvoker.Invoke(this, context.Tuning);

            var emotionToUse = Emotion;
            var emotionWeightToUse = EmotionWeight;
            var hasEmotionToUse = HasEmotion;

            if (!hasEmotionToUse && DebugCommandFlags.Values.Contains("visible_buffs"))
            {
                emotionToUse = new Reference(14637);
                emotionWeightToUse = 0;
                hasEmotionToUse = true;
            }

            if (hasEmotionToUse)
            {
                context.Tuning.Set<TunableBasic>("mood_type", emotionToUse);
                context.Tuning.Set<TunableBasic>("mood_weight", emotionWeightToUse);
            }
            else
            {
                context.Tuning.Set<TunableBasic>("visible", "False");
            }

            if (hasEmotionToUse || HasFixedDuration)
            {
                var tunableVariant1 = context.Tuning.Set<TunableVariant>("_temporary_commodity_info", "enabled");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("enabled");
                if (HasEmotion)
                {
                    var tunableList1 = tunableTuple1.Get<TunableList>("categories");
                    if (AddEmotionCategory)
                    {
                        tunableList1.Set<TunableEnum>(null, GetEmotionCategory());
                    }
                }
                if (HasFixedDuration)
                {
                    tunableTuple1.Set<TunableBasic>("max_duration", Duration);
                    if (IsNonPersisted)
                    {
                        context.Tuning.Set<TunableBasic>("persists", false);
                    }
                }

                if (ElementTuning.GetSingleInstanceKey(emotionToUse) == 14638)
                {
                    TuneFlirtyBlocker(context);
                }
            }

            if (Exporter.Current.STBLBuilder != null)
            {
                var header = (TuningHeader)context.Tuning;
                header.SimDataHandler.WriteText(164, Exporter.Current.STBLBuilder.GetKey(Name) ?? 0);
                header.SimDataHandler.WriteText(160, Exporter.Current.STBLBuilder.GetKey(Description) ?? 0);
                header.SimDataHandler.WriteTGI(168, Icon.GetUncommentedText(), Element);

                if (hasEmotionToUse)
                {
                    header.SimDataHandler.Write(184, Convert.ToUInt64(ElementTuning.GetInstanceKeys(emotionToUse)[0]));
                    header.SimDataHandler.Write(192, Convert.ToInt32(emotionWeightToUse));
                }
            }
        }

        private void TuneFlirtyBlocker(BuffExportContext context)
        {
            var tunableVariant1 = context.Tuning.Set<TunableVariant>("_add_test_set", "tests_set");
            var tunableList1 = tunableVariant1.Get<TunableList>("tests_set");
            var tunableList2 = tunableList1.Get<TunableList>(null);
            var tunableVariant2 = tunableList2.Set<TunableVariant>(null, "test_set_reference");
            tunableVariant2.Set<TunableBasic>("test_set_reference", "34093");
        }
    }
}
