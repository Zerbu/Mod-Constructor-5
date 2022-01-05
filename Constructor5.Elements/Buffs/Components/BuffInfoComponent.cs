using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.Icons;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Xml;
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
        public Reference Emotion { get; set; } = new Reference();
        public int EmotionWeight { get; set; } = 1;
        public bool HasFixedDuration { get; set; }
        public bool HasEmotion { get; set; }

        [AutoTuneBasic("icon")]
        public ElementIcon Icon { get; set; } = new ElementIcon();

        [AutoTuneBasic("buff_name")]
        public STBLString Name { get; set; } = new STBLString();

        public string GetEmotionCategory() => "TODO: EMOTION CATEGORY";

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
