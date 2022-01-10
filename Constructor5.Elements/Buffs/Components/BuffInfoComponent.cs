using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.Icons;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Core;
using System;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.Export;

namespace Constructor5.Elements.Buffs.Components
{
    [XmlSerializerExtraType]
    public class BuffInfoComponent : BuffComponent
    {
        public override int ComponentDisplayOrder => 1;
        public override string ComponentLabel => "Buff Info";

        public bool AddEmotionCategory { get; set; } = true;

        [AutoTuneBasic("buff_description")]
        public STBLString Description { get; set; } = new STBLString();

        public int Duration { get; set; } = 240;
        public Reference Emotion { get; set; } = new Reference() { GameReference = 14640, GameReferenceLabel = "Happy" };
        public int EmotionWeight { get; set; } = 1;
        public bool HasFixedDuration { get; set; }
        public bool HasEmotion { get; set; }

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
                    Exporter.Current.AddError($"\"Add Emotion Category\" doesn't support {emotionInt}. No emotion category has been automatically added.");
                    return null;
            }
        }

        protected internal override bool HasContent() => true;

        protected internal override void OnExport(BuffExportContext context)
        {
            AutoTunerInvoker.Invoke(this, context.Tuning);

            TuningActionInvoker.InvokeFromFile("Buff Info",
                new TuningActionContext
                {
                    Tuning = context.Tuning,
                    DataContext = this
                });

            if (HasEmotion || HasFixedDuration)
            {
                var tunableVariant1 = context.Tuning.Set<TunableVariant>("_temporary_commodity_info", "enabled");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("enabled");
                if (HasEmotion)
                {
                    var tunableList1 = tunableTuple1.Get<TunableList>("categories");
                    tunableList1.Set<TunableEnum>(null, GetEmotionCategory());
                }
                if (HasFixedDuration)
                {
                    tunableTuple1.Set<TunableBasic>("max_duration", Duration);
                }
            }

            var header = (TuningHeader)context.Tuning;
            header.SimDataHandler.WriteText(164, Exporter.Current.STBLBuilder.GetKey(Name) ?? 0);
            header.SimDataHandler.WriteText(160, Exporter.Current.STBLBuilder.GetKey(Description) ?? 0);
            header.SimDataHandler.WriteTGI(168, Icon.GetUncommentedText());

            if (HasEmotion)
            {
                header.SimDataHandler.Write(184, Convert.ToUInt64(ElementTuning.GetInstanceKeys(Emotion)[0]));
                header.SimDataHandler.Write(192, Convert.ToInt32(EmotionWeight));
            }
        }
    }
}
