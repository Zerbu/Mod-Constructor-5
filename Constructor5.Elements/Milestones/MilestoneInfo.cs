using Constructor5.Base.ExportSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Core;
using System.Collections.Generic;

namespace Constructor5.Elements.Milestones
{
    [XmlSerializerExtraType]
    public class MilestoneInfo : MilestoneComponent
    {
        [AddEnumToListIfTrue("ages", "ADULT")]
        public bool AllowAdult { get; set; } = true;

        [AddEnumToListIfTrue("ages", "BABY")]
        public bool AllowInfant { get; set; } = true;

        [AddEnumToListIfTrue("ages", "CHILD")]
        public bool AllowChild { get; set; } = true;

        [AddEnumToListIfTrue("ages", "ELDER")]
        public bool AllowElder { get; set; } = true;

        [AddEnumToListIfTrue("ages", "TEEN")]
        public bool AllowTeen { get; set; } = true;

        [AddEnumToListIfTrue("ages", "TODDLER")]
        public bool AllowToddler { get; set; } = true;

        [AddEnumToListIfTrue("ages", "YOUNGADULT")]
        public bool AllowYoungAdult { get; set; } = true;

        [AutoTuneBasic("category")]
        public MilestoneCategories Category { get; set; } = MilestoneCategories.Life;

        public bool Force31Bit { get; set; }

        [AutoTuneBasic("repeatable")]
        public bool IsRepeatable { get; set; }

        public bool ShowTargetSim { get; set; }

        public override string ComponentLabel => "MilestoneInfo";

        protected internal override void OnExport(MilestoneExportContext context)
        {
            AutoTunerInvoker.Invoke(this, context.Tuning);

            if (Exporter.Current.STBLBuilder != null)
            {
                var header = (TuningHeader)context.Tuning;
                header.SimDataHandler.WriteText(context.SimDataOffset + 136, (uint)Category);

                var simDataList = new List<ulong>();

                if (AllowToddler)
                {
                    simDataList.Add(2);
                }

                if (AllowChild)
                {
                    simDataList.Add(4);
                }

                if (AllowTeen)
                {
                    simDataList.Add(8);
                }

                if (AllowYoungAdult)
                {
                    simDataList.Add(16);
                }

                if (AllowAdult)
                {
                    simDataList.Add(32);
                }

                if (AllowElder)
                {
                    simDataList.Add(64);
                }

                if (AllowInfant)
                {
                    simDataList.Add(128);
                }

                header.SimDataHandler.WriteList(context.SimDataAgesPosition, simDataList, 8, true);
            }

            switch (Category)
            {
                case MilestoneCategories.Life:
                    context.Tuning.Get<TunableList>("loot").Set<TunableBasic>(null, "317831");
                    break;
                case MilestoneCategories.Social:
                    context.Tuning.Get<TunableList>("loot").Set<TunableBasic>(null, "317832");
                    break;
            }

            if (ShowTargetSim)
            {
                var header = (TuningHeader)context.Tuning;
                header.Set<TunableBasic>("unlocked_text_target_sim_header", "0x881E311A");
                header.SimDataHandler.WriteText(context.SimDataOffset + 184, 0x881E311A);
            }
        }
    }
}