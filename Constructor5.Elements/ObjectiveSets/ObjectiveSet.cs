using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.SimData;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Elements.AspirationTracks;
using Constructor5.Elements.Objectives;
using System.Collections.Generic;
using System.Linq;

namespace Constructor5.Elements.ObjectiveSets
{
    [ElementTypeData("ObjectiveSet", true, ElementTypes = new[] { typeof(ObjectiveSet) }, PresetFolders = new[] { "ObjectiveSet" })]
    public class ObjectiveSet : Element, IExportableElement, ISupportsCustomTuning
    {
        [AutoTuneIfFalse("do_not_register_events_on_load", "True")]
        public bool AlwaysTrack { get; set; } = true;

        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        [AutoTuneBasic("display_name")]
        public STBLString DisplayName { get; set; } = new STBLString();

        public int NumberOfObjectivesRequired { get; set; } = 1;

        [AutoTuneReferenceList("objectives")]
        public ReferenceList Objectives { get; set; } = new ReferenceList();

        public bool OnlyRequireSomeObjectives { get; set; }

        [AutoTuneBasic("reward")]
        public Reference Reward { get; set; } = new Reference();

        public void AssignDataToObjective(Objective element, bool isNew)
        {
            var isCareerOrAssignment = GetContextModifier<CareerObjectiveSetContextModifier>() != null
            || GetContextModifier<CareerAssignmentObjectiveSetContextModifier>() != null;

            if (isNew)
            {
                element.AlwaysTrack =
    GetContextModifier<AssignedAspirationTrackContextModifier>() == null
    && !isCareerOrAssignment;
            }

            if (GetContextModifier<AssignedAspirationTrackContextModifier>() != null)
            {
                element.NonResettable = true;
            }
        }

        void IExportableElement.OnExport()
        {
            // fix from previous versions
            foreach (var refItem in Objectives.Items)
            {
                var objective = refItem.Reference.Element as Objective;
                if (objective == null)
                {
                    continue;
                }
                AssignDataToObjective(objective, false);
            }

            var tuning = ElementTuning.Create(this);
            tuning.Class = "Aspiration";
            tuning.InstanceType = "aspiration";
            tuning.Module = "aspirations.aspiration_tuning";

            var simDataFile = "SimData/ObjectiveSet.data";

            var careerModifier = GetContextModifier<CareerObjectiveSetContextModifier>();
            if (careerModifier != null)
            {
                tuning.Class = "AspirationCareer";
                simDataFile = "SimData/ObjectiveSetCareer.data";
            }

            var assignmentModifier = GetContextModifier<CareerAssignmentObjectiveSetContextModifier>();
            if (assignmentModifier != null)
            {
                tuning.Class = "AspirationAssignment";
                simDataFile = "SimData/ObjectiveSetAssignment.data";
            }

            var gigModifier = GetContextModifier<CareerAssignmentGigContextModifier>();
            if (gigModifier != null)
            {
                tuning.Class = "AspirationGig";
                simDataFile = "SimData/ObjectiveSetGig.data";
            }

            tuning.SimDataHandler = new SimDataHandler(simDataFile);

            AutoTunerInvoker.Invoke(this, tuning);

            if (OnlyRequireSomeObjectives)
            {
                var tunableVariant1 = tuning.Set<TunableVariant>("objective_completion_type", "complete_subset");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("complete_subset");
                tunableTuple1.Set<TunableBasic>("number_required", NumberOfObjectivesRequired);
            }

            var aspirationTrackModifier = GetContextModifier<AssignedAspirationTrackContextModifier>();
            if (aspirationTrackModifier != null)
            {
                TuneScreenSlam(tuning, aspirationTrackModifier);

                var track = (AspirationTrack)aspirationTrackModifier.AspirationTrack.Element;

                if (track.GetComponent<AspirationTrackInfoComponent>().IsChildAspiration)
                {
                    tuning.Set<TunableBasic>("is_child_aspiration", true);
                    tuning.SimDataHandler.Write(104, true);
                }
            }

            if (careerModifier != null || assignmentModifier != null || gigModifier != null)
            {
                BuildSimDataCareer(tuning);
            }
            else
            {
                BuildSimData(tuning);
            }

            CustomTuningExporter.Export(this, tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }

        private void BuildSimData(TuningHeader tuning)
        {
            tuning.SimDataHandler.WriteText(100, Exporter.Current.STBLBuilder.GetKey(DisplayName) ?? 0);
            //tuning.SimDataHandler.WriteText(96, Exporter.Current.STBLBuilder.GetKey(Description) ?? 0);

            var list = new List<ulong>();
            foreach (var key in ElementTuning.GetInstanceKeys(Objectives))
            {
                list.Add(key);
            }
            tuning.SimDataHandler.WriteList(128, list, 4, true);
        }

        private void BuildSimDataCareer(TuningHeader tuning)
        {
            var list = new List<ulong>();
            foreach (var key in ElementTuning.GetInstanceKeys(Objectives))
            {
                list.Add(key);
            }
            tuning.SimDataHandler.WriteList(112, list, 4, true);
        }

        private void TuneScreenSlam(TuningHeader tuning, AssignedAspirationTrackContextModifier aspirationTrackModifier)
        {
            var screenSlamVariant = tuning.Set<TunableVariant>("screen_slam", "enabled");
            var literalVariant = screenSlamVariant.Set<TunableVariant>("enabled", "literal");
            var literalTuple = literalVariant.Get<TunableTuple>("literal");

            var trackElement = (AspirationTrack)aspirationTrackModifier.AspirationTrack.Element;
            var trackInfo = trackElement.GetComponent<AspirationTrackInfoComponent>();
            var trackMilestones = trackElement.GetComponent<AspirationTrackMilestonesComponent>();

            if (trackMilestones.Milestones.Items.LastOrDefault()?.Reference?.Element == this)
            {
                var tunableVariant1 = literalTuple.Set<TunableVariant>("audio_sting", "enabled");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("enabled");
                tunableTuple1.Set<TunableBasic>("audio", "39b2aa4a:00000000:ff61943a5171bd0f");
                var tunableVariant2 = literalTuple.Set<TunableVariant>("display_type", "size_based");
                var tunableTuple2 = tunableVariant2.Get<TunableTuple>("size_based");
                tunableTuple2.Set<TunableEnum>("screen_slam_size", "LARGE");
                var tunableVariant3 = literalTuple.Set<TunableVariant>("icon", "enabled");
                tunableVariant3.Set<TunableBasic>("enabled", trackInfo.Icon);
                var tunableVariant4 = literalTuple.Set<TunableVariant>("text", "enabled");
                tunableVariant4.Set<TunableBasic>("enabled", "0x7441E51");
                var tunableVariant5 = literalTuple.Set<TunableVariant>("title", "enabled");
                tunableVariant5.Set<TunableBasic>("enabled", "0x1C245A8");
            }
            else
            {
                var tunableVariant1 = literalTuple.Set<TunableVariant>("audio_sting", "enabled");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("enabled");
                tunableTuple1.Set<TunableBasic>("audio", "39b2aa4a:00000000:ea1687e36b0b32f3");
                var tunableVariant2 = literalTuple.Set<TunableVariant>("display_type", "size_based");
                var tunableTuple2 = tunableVariant2.Get<TunableTuple>("size_based");
                tunableTuple2.Set<TunableEnum>("screen_slam_size", "MEDIUM");
                var tunableVariant3 = literalTuple.Set<TunableVariant>("icon", "enabled");
                tunableVariant3.Set<TunableBasic>("enabled", trackInfo.Icon);
                var tunableVariant4 = literalTuple.Set<TunableVariant>("text", "enabled");
                tunableVariant4.Set<TunableBasic>("enabled", "0x2FCDF82A");
                var tunableVariant5 = literalTuple.Set<TunableVariant>("title", "enabled");
                tunableVariant5.Set<TunableBasic>("enabled", "0xF534069E");
            }
        }
    }
}