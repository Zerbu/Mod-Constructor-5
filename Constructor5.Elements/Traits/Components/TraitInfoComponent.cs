using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.Icons;
using Constructor5.Base.PropertyTypes;
using Constructor5.Core;
using System;
using System.Collections.Generic;

namespace Constructor5.Elements.Traits.Components
{
    [XmlSerializerExtraType]
    public class TraitInfoComponent : TraitComponent
    {
        [AddEnumToListIfTrue("ages", "ADULT")]
        public bool AllowAdult { get; set; } = true;

        [AddEnumToListIfTrue("ages", "BABY")]
        public bool AllowBaby { get; set; } = true;

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

        public override int ComponentDisplayOrder => 1;
        public override string ComponentLabel => "Trait Info";

        [AutoTuneBasic("trait_description")]
        public STBLString Description { get; set; } = new STBLString();

        [AutoTuneBasic("trait_icon")]
        public ElementIcon Icon { get; set; } = new ElementIcon();

        [AutoTuneBasic("display_name")]
        public STBLString Name { get; set; } = new STBLString();

        public TraitCategories TraitCategory { get; set; } = TraitCategories.Emotional;
        public TraitTypes TraitType { get; set; } = TraitTypes.Gameplay;

        public string GetCategoryTag()
        {
            switch (TraitCategory)
            {
                case TraitCategories.Emotional:
                    return "TraitGroup_Emotional";

                case TraitCategories.Hobby:
                    return "TraitGroup_Hobby";

                case TraitCategories.Lifestyle:
                    return "TraitGroup_Lifestyle";

                case TraitCategories.Social:
                    return "TraitGroup_Social";
            }

            return "Invalid";
        }

        protected internal override void OnExport(TraitExportContext context)
        {
            AutoTunerInvoker.Invoke(this, context.Tuning);

            TuningActionInvoker.InvokeFromFile("Trait Info",
                new TuningActionContext
                {
                    Tuning = context.Tuning,
                    DataContext = this
                });

            if (Exporter.Current.STBLBuilder == null)
            {
                return;
            }

            var typeTunable = context.Tuning.Set<TunableEnum>("trait_type", "PERSONALITY");
            if (TraitType == TraitTypes.Personality)
            {
                var tunableList1 = context.Tuning.Get<TunableList>("tags");
                tunableList1.Set<TunableBasic>(null, "TraitPersonality");
                tunableList1.Set<TunableBasic>(null, GetCategoryTag());
                context.Tuning.Set<TunableVariant>("ui_category", "ui_trait_category_tag");
            }

            var header = context.Tuning;
            header.SimDataHandler.WriteText(188, Exporter.Current.STBLBuilder.GetKey(Name) ?? 0);
            header.SimDataHandler.WriteText(232, Exporter.Current.STBLBuilder.GetKey(Description) ?? 0);
            header.SimDataHandler.WriteTGI(200, Icon.GetUncommentedText());

            SimDataTuneAges(context);
            SimDataTuneType(context, (TunableEnum)typeTunable);
        }

        private ulong GetCategorySimDataTag()
        {
            switch (TraitCategory)
            {
                case TraitCategories.Emotional: return 753;
                case TraitCategories.Hobby: return 754;
                case TraitCategories.Lifestyle: return 755;
                case TraitCategories.Social: return 756;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private void SimDataTuneAges(TraitExportContext context)
        {
            var simDataList = new List<ulong>();

            if (AllowBaby)
            {
                simDataList.Add(1);
            }

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

            context.Tuning.SimDataHandler.WriteList(256, simDataList, 7, true);
        }

        private void SimDataTuneType(TraitExportContext context, TunableEnum typeTunable)
        {
            switch (TraitType)
            {
                case TraitTypes.Personality:
                    var simDataTagList = new List<ulong> { 234, GetCategorySimDataTag() };
                    context.Tuning.SimDataHandler.WriteList(352, simDataTagList, 2, false);
                    break;
                case TraitTypes.Gameplay:
                    context.Tuning.SimDataHandler.Write(240, 1);
                    context.Tuning.Set<TunableEnum>("trait_type", "GAMEPLAY");
                    break;
                case TraitTypes.Hidden:
                    context.Tuning.SimDataHandler.Write(240, 4);
                    context.Tuning.Set<TunableEnum>("trait_type", "HIDDEN");
                    break;
                case TraitTypes.Aspiration:
                    context.Tuning.SimDataHandler.Write(240, 6);
                    context.Tuning.Set<TunableEnum>("trait_type", "ASPIRATION");
                    break;
                case TraitTypes.Phase:
                    context.Tuning.SimDataHandler.Write(240, 10);
                    context.Tuning.Set<TunableEnum>("trait_type", "PHASE");
                    break;
                /*
                    WALKSTYLE = 2
                    GHOST = 5
                    ASPIRATION = 6
                    TAILSTYLE = 7
                    GENDER_OPTIONS = 8
                    SIM_PHONE = 9
                    PHASE = 10
                    AGENT = 11
                    INFECTION = 12
                    CURSE = 13
                    ROOMMATE = 14
                    ROBOT_MODULE = 15
                    ROBOT = 16
                    PROFESSOR = 17
                    UNIVERSITY_DEGREE = 18
                    ROBOT_MODULE_LOCKED = 19
                 */

                /*case "LIKE":
                    tuning.SimDataHandler = new SimDataHandler("SimData/TraitGameplay.data");
                    tuning.SimDataHandler.Write(240, 22);
                    break;

                case "DISLIKE":
                    tuning.SimDataHandler = new SimDataHandler("SimData/TraitGameplay.data");
                    tuning.SimDataHandler.Write(240, 23);
                    break;*/

                default:
                    break;
            }
        }
    }
}