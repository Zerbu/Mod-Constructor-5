using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.Icons;
using Constructor5.Base.PropertyTypes;
using Constructor5.Elements.Careers;
using Constructor5.Elements.Careers.Components;
using System;
using System.Collections.Generic;

namespace Constructor5.Elements.CareerTracks
{
    [ElementTypeData("CareerTrack", false, ElementTypes = new[] { typeof(CareerTrack) }, PresetFolders = new[] { "CareerTrack" })]
    public class CareerTrack : Element, IExportableElement
    {
        [AutoTuneReferenceList("branches")]
        public ReferenceList Branches { get; set; } = new ReferenceList();

        [AutoTuneReferenceList("career_levels")]
        public ReferenceList Levels { get; set; } = new ReferenceList();

        public STBLString Description { get; set; } = new STBLString();
        public ElementIcon Icon { get; set; } = new ElementIcon();
        public ElementIcon Image { get; set; } = new ElementIcon();
        public STBLString Name { get; set; } = new STBLString();

        public bool OvermaxOverrideEnabled { get; set; }
        public Reference OvermaxReward { get; set; } = new Reference();
        public int OvermaxSalaryIncreaseAmount { get; set; }

        public Reference[] GetAllLevelsInTree()
        {
            var trackTree = new List<CareerTrack> { this };

            var current = this;
            while (true)
            {
                current = (CareerTrack)current.GetContextModifier<CareerTrackContextModifier>().ParentTrack.Element;
                if (current == null)
                {
                    break;
                }
                trackTree.Add(current);
            }

            var result = new List<Reference>();
            trackTree.Reverse();
            foreach (var track in trackTree)
            {
                foreach (var level in track.Levels.Items)
                {
                    result.Add(level.Reference);
                }
            }
            return result.ToArray();
        }

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "TunableCareerTrack";
            tuning.InstanceType = "career_track";
            tuning.Module = "careers.career_tuning";

            var nameToUse = Name;
            var descriptionToUse = Description;
            var iconToUse = Icon;
            var imageToUse = Image;

            var contextModifier = GetContextModifier<CareerTrackContextModifier>();
            if (contextModifier.ParentTrack.Element == null)
            {
                var info = ((Career)contextModifier.Career.Element).GetComponent<CareerInfoComponent>();
                nameToUse = info.Name;
                descriptionToUse = info.Description;
                iconToUse = info.Icon;
                imageToUse = info.Image;
            }

            tuning.Set<TunableBasic>("active_assignment_amount", "0");

            tuning.Set<TunableBasic>("busy_time_situation_picker_tooltip", "0x77D1D57E");

            tuning.Set<TunableBasic>("career_description", descriptionToUse);
            tuning.Set<TunableBasic>("career_name", nameToUse);
            tuning.Set<TunableBasic>("career_name_gender_neutral", nameToUse);

            var tunableVariant1 = tuning.Set<TunableVariant>("goodbye_notification", "reference");
            tunableVariant1.Set<TunableBasic>("reference", "110655");
            tuning.Set<TunableBasic>("icon", iconToUse);
            tuning.Set<TunableBasic>("icon_high_res", iconToUse);
            tuning.Set<TunableBasic>("image", imageToUse);
            var tunableVariant2 = tuning.Set<TunableVariant>("knowledge_notification", "enabled");
            var tunableVariant3 = tunableVariant2.Set<TunableVariant>("enabled", "reference");
            tunableVariant3.Set<TunableBasic>("reference", "110279");

            AutoTunerInvoker.Invoke(this, tuning);

            TuningExport.AddToQueue(tuning);
        }
    }
}