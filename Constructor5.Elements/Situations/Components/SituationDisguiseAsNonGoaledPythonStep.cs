using Constructor5.Base.ProjectSystem;
using Constructor5.Base.Python;
using System.Collections.Generic;
using System.Text;

namespace Constructor5.Elements.Situations.Components
{
    public class SituationDisguiseAsNonGoaledPythonStep : PythonBuildStep
    {
        public static SituationDisguiseAsNonGoaledPythonStep Current { get; } = new SituationDisguiseAsNonGoaledPythonStep();

        public static void AddSituation(ulong key) => Current.SituationKeys.Add(key);

        public override string GetContent()
        {
            var result = new StringBuilder();

            result.AppendLine($"@inject_to(situations.situation_manager.SituationManager, 'create_situation')");
            result.AppendLine($"def {Project.Id}_create_situation(original, self, situation_type, guest_list=None, user_facing=True, duration_override = None, custom_init_writer = None, zone_id = 0, scoring_enabled = True, spawn_sims_during_zone_spin_up = False, creation_source = None, travel_request_kwargs = frozendict(), linked_sim_id = GLOBAL_SITUATION_LINKED_SIM_ID, scheduled_time = None, existing_drama_node_uid = None, **extra_kwargs):");
            foreach (var key in SituationKeys)
            {
                result.AppendLine($"  if self.guid64 == {key}:");
            }
            result.AppendLine($"    scoring_enabled = False");
            result.AppendLine($"  return original(self, situation_type, guest_list, user_facing, duration_override, custom_init_writer, zone_id, scoring_enabled, spawn_sims_during_zone_spin_up, creation_source, travel_request_kwargs, linked_sim_id, scheduled_time, existing_drama_node_uid, **extra_kwargs)");

            return result.ToString();
        }

        public override IEnumerable<string> GetHeaders() => new HashSet<string> { "import situations", "from situations.situation_serialization import GLOBAL_SITUATION_LINKED_SIM_ID", "from _sims4_collections import frozendict" };

        protected List<ulong> SituationKeys { get; } = new List<ulong>();

        protected override void Cleanup()
        { }

        private SituationDisguiseAsNonGoaledPythonStep()
        {
        }
    }
}
