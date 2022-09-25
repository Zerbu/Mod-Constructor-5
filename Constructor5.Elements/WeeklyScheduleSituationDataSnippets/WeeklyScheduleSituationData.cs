using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;

namespace Constructor5.Elements.WeeklyScheduleSituationDataSnippets
{
    [ElementTypeData("WeeklyScheduleSituationData", false, ElementTypes = new[] { typeof(WeeklyScheduleSituationData) }, PresetFolders = new[] { "WeeklyScheduleSituationData" })]
    public class WeeklyScheduleSituationData : Element, IExportableElement
    {
        public ReferenceList JobAssignments { get; set; } = new ReferenceList();

        /*[AutoTuneBasic("situation")]
        public Reference Situation { get; set; } = new Reference();*/

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "WeeklyScheduleSituationData";
            tuning.InstanceType = "snippet";
            tuning.Module = "venues.weekly_schedule_zone_director";

            var tunableList1 = tuning.Get<TunableList>("job_assignments");
            foreach (var jobAssignment in JobAssignments.GetOfType<WeeklyScheduleSituationDataItem>())
            {
                foreach(var key in ElementTuning.GetInstanceKeys(jobAssignment.Reference))
                {
                    var tunableTuple1 = tunableList1.Get<TunableTuple>(null);

                    {
                        tunableTuple1.Set<TunableBasic>("job", key);

                        if (jobAssignment.SimCountMin != 1 || jobAssignment.SimCountMax != 1)
                        {
                            var simCountTuple = tunableTuple1.Get<TunableTuple>("sim_count");
                            simCountTuple.Set<TunableBasic>("lower_bound", jobAssignment.SimCountMin);
                            simCountTuple.Set<TunableBasic>("upper_bound", jobAssignment.SimCountMax);
                        }

                        var tunableList2 = tunableTuple1.Get<TunableList>("tests");
                        var tunableList3 = tunableList2.Get<TunableList>(null);

                        var otherJobKeys = ElementTuning.GetInstanceKeys(jobAssignment.RequireJobInOtherSituation);
                        if (otherJobKeys.Length > 0)
                        {
                            var tunableVariant1 = tunableList3.Set<TunableVariant>(null, "situation_job_test");
                            var tunableTuple2 = tunableVariant1.Get<TunableTuple>("situation_job_test");
                            var tunableList4 = tunableTuple2.Get<TunableList>("situation_jobs");
                            foreach (var otherKey in otherJobKeys)
                            {
                                tunableList4.Set<TunableBasic>(null, otherKey);
                            }
                        }
                    }
                }
            }

            tuning.Set<TunableBasic>("situation", TuneSituation());

            AutoTunerInvoker.Invoke(this, tuning);

            TuningExport.AddToQueue(tuning);
        }

        private ulong TuneSituation()
        {
            var tuning = ElementTuning.Create(this, "Situation");
            tuning.Class = "CustomStatesSituation";
            tuning.InstanceType = "situation";
            tuning.Module = "situations.custom_states.custom_states_situation";

            var tunableList1 = tuning.Get<TunableList>("_situation_states");
            var tunableTuple1 = tunableList1.Get<TunableTuple>(null);
            tunableTuple1.Set<TunableBasic>("Situation State Key", "DoStuff");
            var tunableVariant1 = tunableTuple1.Set<TunableVariant>("Situation State", "literal");
            var tunableTuple2 = tunableVariant1.Get<TunableTuple>("literal");
            var tunableList2 = tunableTuple2.Get<TunableList>("job_and_role_changes");

            foreach (var jobAssignment in JobAssignments.GetOfType<WeeklyScheduleSituationDataItem>())
            {
                foreach (var key in ElementTuning.GetInstanceKeys(jobAssignment.Reference))
                {
                    var tunableTuple3 = tunableList2.Get<TunableTuple>(null);
                    tunableTuple3.Set<TunableBasic>("Situation Job", key);
                    tunableTuple3.Set<TunableBasic>("Role State", jobAssignment.RoleState);
                }
            }

            var tunableVariant2 = tuning.Set<TunableVariant>("_starting_state", "random_starting_state");
            var tunableTuple4 = tunableVariant2.Get<TunableTuple>("random_starting_state");
            var tunableList3 = tunableTuple4.Get<TunableList>("possible_state_keys");
            var tunableTuple5 = tunableList3.Get<TunableTuple>(null);
            tunableTuple5.Set<TunableBasic>("situation_key", "DoStuff");
            tuning.Set<TunableBasic>("audio_sting_on_start", "39b2aa4a:00000000:78b903461d47e4fc");
            var tunableList4 = tuning.Get<TunableList>("compatible_venues");
            tunableList4.Set<TunableBasic>(null, "28614");
            var tunableList5 = tuning.Get<TunableList>("default_job_and_roles");

            foreach (var jobAssignment in JobAssignments.GetOfType<WeeklyScheduleSituationDataItem>())
            {
                foreach (var key in ElementTuning.GetInstanceKeys(jobAssignment.Reference))
                {
                    var tunableTuple6 = tunableList5.Get<TunableTuple>(null);
                    tunableTuple6.Set<TunableBasic>("Situation Job", key);
                    tunableTuple6.Set<TunableBasic>("Role State", jobAssignment.RoleState);
                }
            }

            tuning.Set<TunableBasic>("main_goal_audio_sting", "39b2aa4a:00000000:10b476550150a33f");
            tuning.Set<TunableBasic>("max_participants", "20");
            var tunableVariant3 = tuning.Set<TunableVariant>("situation_end_time_string", "show_end_time");
            tunableVariant3.Set<TunableBasic>("show_end_time", "0xA3E17143");
            var tunableVariant4 = tuning.Set<TunableVariant>("time_jump", "allow");

            TuningExport.AddToQueue(tuning);

            return tuning.InstanceKey;
        }
    }
}
