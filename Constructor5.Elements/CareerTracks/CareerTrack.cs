using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.SimData;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.Icons;
using Constructor5.Base.PropertyTypes;
using Constructor5.Elements.Careers;
using Constructor5.Elements.Careers.Components;
using Constructor5.Elements.TestConditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Constructor5.Elements.CareerTracks
{
    [ElementTypeData("CareerTrack", false, ElementTypes = new[] { typeof(CareerTrack) }, PresetFolders = new[] { "CareerTrack" })]
    public class CareerTrack : Element, IExportableElement, ISupportsCustomTuning
    {
        public ReferenceList Assignments { get; set; } = new ReferenceList();

        [AutoTuneBasic("active_assignment_amount", IgnoreIf = 2)]
        public int AssignmentsAmount { get; set; } = 2;

        [AutoTuneReferenceList("branches")]
        public ReferenceList Branches { get; set; } = new ReferenceList();

        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        public STBLString Description { get; set; } = new STBLString();
        public ElementIcon Icon { get; set; } = new ElementIcon();
        public ElementIcon Image { get; set; } = new ElementIcon();

        [AutoTuneReferenceList("career_levels")]
        public ReferenceList Levels { get; set; } = new ReferenceList();

        public STBLString Name { get; set; } = new STBLString();

        /*public bool OvermaxOverrideEnabled { get; set; }
        public Reference OvermaxReward { get; set; } = new Reference();
        public int OvermaxSalaryIncreaseAmount { get; set; }*/

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
            var career = (Career)contextModifier.Career.Element;
            if (contextModifier.ParentTrack.Element == null)
            {
                var info = career.GetComponent<CareerInfoComponent>();
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

            tuning.SimDataBuilder = new SimDataBuilder();
            BuildSimData(tuning.SimDataBuilder, nameToUse, descriptionToUse, iconToUse, imageToUse);

            if (Branches.Items.Count <= 0)
            {
                var template = career.GetComponent<CareerTemplateComponent>().Template;
                template.TuneOvermax(tuning, this);
            }

            TuneAssignments(tuning);

            CustomTuningExporter.Export(this, tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }

        private void BuildSimData(SimDataBuilder simDataBuilder, STBLString nameToUse, STBLString descriptionToUse, ElementIcon iconToUse, ElementIcon imageToUse)
        {
            var branches = ElementTuning.GetInstanceKeys(Branches);
            var levels = ElementTuning.GetInstanceKeys(Levels);

            var levelListSize = levels.Length * 8;
            var branchListSize = branches.Length * 8;

            // schema offset = 168 + number of levels*8 + number of branches*8
            var schemaOffset = 168 + levelListSize + branchListSize;
            simDataBuilder.BuildHeader(24, 2, schemaOffset, 1);

            // TableInfo 0
            var nameOffset = 469 + levelListSize + branchListSize;
            var tableSchemaOffset = 144 + levelListSize + branchListSize;
            simDataBuilder.BuildTableInfo(nameOffset, 2014394279, tableSchemaOffset, 13, 80, 44, 1);

            // TableInfo 1
            simDataBuilder.BuildTableInfo(-2147483648, 2166136261, -2147483648, 18, 8, 96, levels.Length + branches.Length);

            simDataBuilder.Writer.Write(0);
            simDataBuilder.Writer.Write(0);

            // branches table (TableData 0)
            simDataBuilder.BuildTableDataBase(80, branches.Length);

            // LocKeys
            simDataBuilder.Writer.Write(0x77D1D57E); // 1
            simDataBuilder.Writer.Write(Exporter.Current.STBLBuilder.GetKey(descriptionToUse) ?? 0);

            // levels table (TableData 1)
            simDataBuilder.BuildTableDataBase(64 + branchListSize, levels.Length);

            // some blank data
            simDataBuilder.Writer.Write(Exporter.Current.STBLBuilder.GetKey(nameToUse) ?? 0); // LocKey 4
            simDataBuilder.Writer.Write(0); // unknown

            // icons
            simDataBuilder.WriteResourceKey(iconToUse.GetUncommentedText());

            simDataBuilder.WriteResourceKey(imageToUse.GetUncommentedText());

            simDataBuilder.WriteResourceKey(0xB2D882, 0x0, 0x6665077284098FA2);

            // insert values (branches, then levels)
            foreach (var branch in branches)
            {
                simDataBuilder.Writer.Write(Convert.ToUInt64(branch));
            }

            foreach (var level in levels)
            {
                simDataBuilder.Writer.Write(Convert.ToUInt64(level));
            }

            // some blank bytes at the end of the value list (unknown purpose)
            simDataBuilder.Writer.Write(0);
            simDataBuilder.Writer.Write(0);

            // start schema
            simDataBuilder.WriteSchemaHeader(298, 999219117, 2590922216, 80, 8, 8);

            simDataBuilder.WriteSchemaColumn(204, 928197604, 20, 0, 12, -2147483648);
            simDataBuilder.WriteSchemaColumn(149, 1791709452, 20, 0, 8, -2147483648);

            simDataBuilder.WriteSchemaColumn(209, 1856672634, 19, 0, 32, -2147483648);
            simDataBuilder.WriteSchemaColumn(194, 1884253194, 19, 0, 48, -2147483648);

            simDataBuilder.WriteSchemaColumn(157, 2152427307, 20, 0, 24, -2147483648);

            simDataBuilder.WriteSchemaColumn(168, 2651530348, 19, 0, 64, -2147483648);

            simDataBuilder.WriteSchemaColumn(40, 3513072909, 14, 0, 0, -2147483648);

            simDataBuilder.WriteSchemaColumn(83, 3982613787, 14, 0, 16, -2147483648);

            // string table
            simDataBuilder.Writer.Write(Encoding.ASCII.GetBytes("branches" + char.MinValue));
            simDataBuilder.Writer.Write(Encoding.ASCII.GetBytes("busy_time_situation_picker_tooltip" + char.MinValue));
            simDataBuilder.Writer.Write(Encoding.ASCII.GetBytes("career_description" + char.MinValue));
            simDataBuilder.Writer.Write(Encoding.ASCII.GetBytes("career_levels" + char.MinValue));
            simDataBuilder.Writer.Write(Encoding.ASCII.GetBytes("career_name" + char.MinValue));
            simDataBuilder.Writer.Write(Encoding.ASCII.GetBytes("icon" + char.MinValue));
            simDataBuilder.Writer.Write(Encoding.ASCII.GetBytes("icon_high_res" + char.MinValue));
            simDataBuilder.Writer.Write(Encoding.ASCII.GetBytes("image" + char.MinValue));
            simDataBuilder.Writer.Write(Encoding.ASCII.GetBytes("TunableCareerTrack" + char.MinValue));
            simDataBuilder.Writer.Write(Encoding.ASCII.GetBytes("Constructor" + char.MinValue));
        }

        private void TuneAssignments(TuningHeader tuning)
        {
            foreach (var assignmentItem in Assignments.GetOfType<CareerTrackAssignment>())
            {
                foreach (var instanceKey in ElementTuning.GetInstanceKeys(assignmentItem.Reference))
                {
                    var tunableList1 = tuning.Get<TunableList>("assignments");
                    var tunableTuple1 = tunableList1.Get<TunableTuple>(null);
                    tunableTuple1.Set<TunableBasic>("career_assignment", instanceKey);
                    if (assignmentItem.IsFirstAssignment)
                    {
                        tunableTuple1.Set<TunableBasic>("is_first_assignment", "True");
                    }

                    {
                        var conditions = assignmentItem.Conditions.ToConditionList();

                        if (conditions.Count() > 0 || assignmentItem.LevelRestriction.RestrictLowerBound || assignmentItem.LevelRestriction.RestrictUpperBound)
                        {
                            var testList = tunableTuple1.Get<TunableList>("tests");
                            var tunableList2 = testList.Get<TunableList>(null);

                            if (assignmentItem.LevelRestriction.RestrictLowerBound || assignmentItem.LevelRestriction.RestrictUpperBound)
                            {
                                var tunableVariant1 = tunableList2.Set<TunableVariant>(null, "career_test");
                                var careerTestTuple = tunableVariant1.Get<TunableTuple>("career_test");
                                var tunableVariant2 = careerTestTuple.Set<TunableVariant>("test_type", "career_track");
                                var tunableTuple2 = tunableVariant2.Get<TunableTuple>("career_track");
                                tunableTuple2.Set<TunableBasic>("career_track", instanceKey);

                                var tunableVariant3 = tunableTuple2.Set<TunableVariant>("user_level", "enabled");
                                var tunableTuple3 = tunableVariant3.Get<TunableTuple>("enabled");

                                if (assignmentItem.LevelRestriction.RestrictLowerBound)
                                {
                                    tunableTuple3.Set<TunableBasic>("lower_bound", assignmentItem.LevelRestriction.LowerBound);
                                }

                                if (assignmentItem.LevelRestriction.RestrictUpperBound)
                                {
                                    tunableTuple3.Set<TunableBasic>("upper_bound", assignmentItem.LevelRestriction.UpperBound);
                                }
                            }

                            TestConditionTuning.TuneTestConditions(tunableList2, conditions);
                        }
                    }

                    if (assignmentItem.Weight != 1)
                    {
                        tunableTuple1.Set<TunableBasic>("weight", assignmentItem.Weight);
                    }
                }
            }
        }
    }
}